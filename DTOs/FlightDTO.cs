namespace FlightsApp.DTOs
{
    public record class FlightDTO(
        int Id,
        string Airline,
        string Destination,
        decimal Price);

}
