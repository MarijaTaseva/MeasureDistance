namespace MeasureDistance.Domain.Models
{
    public class DistanceDTO : ErrorResponseDTO
    {
        public string FirstAirportName { get; set; } = string.Empty;
        public string SecondAirportName { get; set; } = string.Empty;
        public double Distance { get; set; }
    }
}
