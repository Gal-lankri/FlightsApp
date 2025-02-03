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
                using (var command = new MySqlCommand("SELECT * FROM flights", connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        flights.Add(new Flight
                        {
                            Id = reader.GetInt32("Id"),
                            Airline = reader.GetString("Airline"),
                            Destination = reader.GetString("Destination"),
                            Price = reader.GetDecimal("Price")
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
                using (var command = new MySqlCommand($"SELECT * FROM flights WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Flight
                            {
                                Id = reader.GetInt32("Id"),
                                Airline = reader.GetString("Airline"),
                                Destination = reader.GetString("Destination"),
                                Price = reader.GetDecimal("Price")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public Task AddFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFlightAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
