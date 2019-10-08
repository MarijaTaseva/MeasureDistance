using MeasureDistance.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeasureDistance.Interfaces
{
    public interface IAirportService
    {
        Task<List<AirportDTO>> GetAirports(string[] iataCodes);
    }
}
