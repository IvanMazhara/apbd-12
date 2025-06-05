using apbd_12.Models.DTOs;
using apbd_12.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd_12.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly IDbService _dbService;

    public TripsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<List<TripResponseDto>> GetTrips()
    {
        return await _dbService.GetAllTrips();
    }

    [HttpPost]
    [Route("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] ClientTripRequestDto request)
    {
        try
        {
            await _dbService.AssignClientToTrip(idTrip, request);
            return Ok("Client assigned to the trip.");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

}