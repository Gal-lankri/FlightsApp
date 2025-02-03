using FlightsApp.Models.Entities;

namespace FlightsApp.Services
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAllFlights();
        Task<Flight> GetFlightById(int id);

    }
}
