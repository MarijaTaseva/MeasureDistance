using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MeasureDistance.Domain.Models;
using System;
using MeasureDistance.Interfaces;

namespace MeasureDistance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureDistanceController : Controller
    {
        private readonly IMeasureDistanceService _measureDistanceService;

        public MeasureDistanceController(IMeasureDistanceService measureDistanceService)
        {
            _measureDistanceService = measureDistanceService;
        }
        
        // GET api/MeasureDistance/AMS/SKP
        [HttpGet("{iataCode1}/{iataCode2}")]
        public async Task<DistanceDTO> Get(string iataCode1, string iataCode2)
        {
            DistanceDTO distance = new DistanceDTO();
            try
            {
                distance = await _measureDistanceService.Get(iataCode1, iataCode2);
            }
            catch (Exception exc)
            {
                distance.ErrorMessage = exc.Message;
            }
            return distance;
        }
    }
}