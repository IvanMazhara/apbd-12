using apbd_12.Data;
using apbd_12.Models;
using apbd_12.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace apbd_12.Repositories;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<TripResponseDto>> GetAllTrips()
    {
        return await _context.Trips
            .Include(t => t.CountryTrips)
            .ThenInclude(ct => ct.Country)
            .Include(t => t.ClientTrips)
            .ThenInclude(ct => ct.Client)
            .OrderByDescending(t => t.DateFrom)
            .Select(t => new TripResponseDto
            {
                Name = t.Name,
                Description = t.Description,
                DateFrom = t.DateFrom,
                DateTo = t.DateTo,
                MaxPeople = t.MaxPeople,
                Countries = t.CountryTrips.Select(ct => new CountryDto
                {
                    Name = ct.Country.Name
                }).ToList(),
                Clients = t.ClientTrips.Select(ct => new ClientDto
                {
                    FirstName = ct.Client.FirstName,
                    LastName = ct.Client.LastName
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<bool> DeleteClientById(int idClient)
    {
        var client = await _context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.IdClient == idClient);

        if (client == null)
        {
            throw new Exception($"Client with such ID {idClient} not found.");
        }

        if (client.ClientTrips.Any())
        {
            throw new InvalidOperationException($"Client with ID {idClient} cannot be deleted because they are assigned to trips.");
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task AssignClientToTrip(int idTrip, ClientTripRequestDto requestDto)
    {
        var trip = await _context.Trips
            .Include(t => t.ClientTrips)
            .FirstOrDefaultAsync(t => t.IdTrip == idTrip);

        if (trip == null)
            throw new Exception("Trip not found.");

        if (trip.DateFrom <= DateTime.Now)
            throw new Exception("Cannot assign to a trip that already started.");
        
        var client = await _context.Clients
            .FirstOrDefaultAsync(c => c.Pesel == requestDto.Pesel);

        if (client != null)
        {
            var alreadyAssigned = await _context.ClientTrips
                .AnyAsync(ct => ct.IdTrip == idTrip && ct.IdClient == client.IdClient);

            if (alreadyAssigned)
                throw new InvalidOperationException("Client is already registered for this trip.");
        }
        else
        {
            client = new Client
            {
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                Email = requestDto.Email,
                Telephone = requestDto.Telephone,
                Pesel = requestDto.Pesel
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        var clientTrip = new ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = idTrip,
            RegisteredAt = DateTime.UtcNow,
            PaymentDate = requestDto.PaymentDate
        };

        _context.ClientTrips.Add(clientTrip);
        await _context.SaveChangesAsync();
    }

}