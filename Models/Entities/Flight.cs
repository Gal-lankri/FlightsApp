namespace FlightsApp.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; } 
        public required string Airline { get; set; } 
        public required string Destination { get; set; }
        public required decimal Price { get; set; }
    }
}
