using GeoCoordinatePortable;
using MeasureDistance.Domain.Models;
using MeasureDistance.Helpers;
using MeasureDistance.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeasureDistance.Implementation
{
    public class MeasureDistanceService : IMeasureDistanceService
    {
        private readonly IAirportService _airportService;

        public MeasureDistanceService(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public async Task<DistanceDTO> Get(string iataCode1, string iataCode2)
        {
            if (Validation.ValidateIataCode(iataCode1) && Validation.ValidateIataCode(iataCode2))
            {
                string[] iataCodes = { iataCode1.ToUpper(), iataCode2.ToUpper() };
                List<AirportDTO> _airports = await _airportService.GetAirports(iataCodes);
                DistanceDTO _distance = new DistanceDTO();

                if (_airports != null)
                {
                    GeoCoordinate pin1 = new GeoCoordinate(_airports[0].Location.Lat, _airports[0].Location.Lon);
                    GeoCoordinate pin2 = new GeoCoordinate(_airports[1].Location.Lat, _airports[1].Location.Lon);

                    double distanceBetween = pin1.GetDistanceTo(pin2);
                    if (_airports[0].Name != null) _distance.FirstAirportName = _airports[0].Name;
                    if (_airports.Count > 1 && _airports[1].Name != null) _distance.SecondAirportName = _airports[1].Name;
                    _distance.Distance = Conversion.GetMiles(distanceBetween);
                }
                return _distance;
            }
            else
                return null;
        }
    }
}
