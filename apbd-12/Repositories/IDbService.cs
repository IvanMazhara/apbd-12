using apbd_12.Models;
using apbd_12.Models.DTOs;

namespace apbd_12.Repositories;

public interface IDbService
{
    Task<List<TripResponseDto>> GetAllTrips();
    Task<bool> DeleteClientById(int idClient);
    Task AssignClientToTrip(int idTrip, ClientTripRequestDto requestDto);
}