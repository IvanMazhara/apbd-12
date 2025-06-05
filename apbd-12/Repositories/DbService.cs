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
        throw new NotImplementedException();
    }

    public async Task AssignClientToTrip(int idTrip, ClientTripRequestDto requestDto)
    {
        throw new NotImplementedException();
    }
}