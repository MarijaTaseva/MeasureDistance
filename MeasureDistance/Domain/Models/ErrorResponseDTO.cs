using Newtonsoft.Json;
namespace MeasureDistance.Domain.Models
{
    public class ErrorResponseDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { set; get; }
    }
}
