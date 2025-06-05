using apbd_12.Models.DTOs;
using apbd_12.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd_12.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController
{
    private readonly IDbService _dbService;

    public TripsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<TripResponseDto> GetTrip(int id)
    {
        var trips = await _dbService.GetAllTrips();
        return trips.FirstOrDefault();
    }
}