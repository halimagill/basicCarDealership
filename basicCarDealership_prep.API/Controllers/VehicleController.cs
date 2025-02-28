using System.Drawing;
using System.Net.Mime;
using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.data.Repositories;
using basicCarDealership_prep.Data.DTOs;
using basicCarDealership_prep.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace basicCarDealership_prep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private ICarRepository _carRepository;
        public VehicleController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/<VehicleController>
        [HttpGet("GetCars")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IEnumerable<VehicleSearchResult>> GetCars()
        {
            var results = await _carRepository.FindVehicleByParams();

            return results;
        }

        [HttpPost("GetSelectedCars")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IEnumerable<VehicleSearchResult>> GetSelectedCars([FromBody] VehicleSelectionDto selection = null)
        {
            var results = await _carRepository.FindVehicleByParams(selection);

            return results;
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
