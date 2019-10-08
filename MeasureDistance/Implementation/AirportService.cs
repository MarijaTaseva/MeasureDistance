using MeasureDistance.Domain.Models;
using MeasureDistance.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MeasureDistance.Implementation
{
    public class AirportService : IAirportService
    {
        [HttpGet]
        public async Task<List<AirportDTO>> GetAirports(string[] iataCodes)
        {
            string baseUrl = "https://places-dev.cteleport.com/airports/";
            AirportDTO airport = null;
            List<AirportDTO> _airports = new List<AirportDTO>();

            using (var client = new HttpClient())
            {
                try
                {
                    foreach (var iataCode in iataCodes)
                    {
                        HttpResponseMessage response = await client.GetAsync(baseUrl + iataCode);
                        var json = response.Content.ReadAsStringAsync().Result;

                        if (json.Any() && json != "Not Found")
                        {
                            airport = JsonConvert.DeserializeObject<AirportDTO>(json);
                            _airports.Add(airport);
                        }
                    }
                    return _airports;
                }
                catch (HttpRequestException)
                {
                    throw new HttpRequestException("Something happened, please try again later.");
                }
            }
        }
    }
}
