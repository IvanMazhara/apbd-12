using apbd_12.Models;

namespace apbd_12.Repositories;

public interface IDbService
{
    Task<List<Trip>> GetAllTripsAsync();
}