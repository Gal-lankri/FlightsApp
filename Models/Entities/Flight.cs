namespace FlightsApp.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public required string Airline { get; set; }
        public required string Departure { get; set; }
        public required string Arrival { get; set; }
    }
}
