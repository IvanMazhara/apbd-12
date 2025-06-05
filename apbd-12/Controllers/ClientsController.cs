using apbd_12.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace apbd_12.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpDelete]
    [Route("{idClient}")]
    public async Task<IActionResult> DeleteClientById(int idClient)
    {
        try
        {
            var result = await _dbService.DeleteClientById(idClient);
            return Ok($"Client with ID {idClient} has been deleted.");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}