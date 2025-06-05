using apbd_12.Data;
using apbd_12.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_12.Repositories;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetAllTripsAsync()
    {
        return await _context.Trips.ToListAsync();
    }
}