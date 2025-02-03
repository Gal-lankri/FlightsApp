using FlightsApp.Data;
using FlightsApp.Models.Entities;

namespace FlightsApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;

        public FlightService(IFlightRepository flightRepository)
        {
            _repository = flightRepository;
        }
        public async Task<List<Flight>> GetAllFlights()
        {
          return await _repository.GetAllFlightsAsync();
        }

        public async Task<Flight> GetFlightById(int id)
        {
            return await _repository.GetFlightByIdAsync(id);
        }
    }
}
