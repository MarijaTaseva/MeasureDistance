using MeasureDistance.Domain.Models;
using System.Threading.Tasks;

namespace MeasureDistance.Interfaces
{
    public interface IMeasureDistanceService
    {
        Task<DistanceDTO> Get(string iataCode1, string iataCode2);
    }
}
