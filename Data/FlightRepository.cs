using FlightsApp.Models.Entities;
using MySql.Data.MySqlClient;
using System.Data;


namespace FlightsApp.Data
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public FlightRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            List<Flight> flights = new List<Flight>();
            using (var connection = _databaseConnection.CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand("SELECT id, airline, departure, arrival FROM flights", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        flights.Add(new Flight
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Airline = reader.GetString(reader.GetOrdinal("airline")),
                            Departure = reader.GetString(reader.GetOrdinal("departure")),
                            Arrival = reader.GetString(reader.GetOrdinal("arrival"))
                        });
                    }
                }
            }
            return flights;
        }
        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            using (var connection = _databaseConnection.CreateConnection())
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand())

            }


        }


        public void AddFlight(Flight flight)
        {

        }

        public void DeleteFlight(int id)
        {
            throw new NotImplementedException();
        }


        public void UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
