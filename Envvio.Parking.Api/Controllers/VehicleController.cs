using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Envvio.Parking.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            List<Vehicle> vehicles = _vehicleService.GetVehicles();

            if (vehicles != null)
            {
                return Ok(vehicles);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);

            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            _vehicleService.CreateVehicle(vehicle);
            return Ok(vehicle);

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveVehicle(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);

            if (vehicle != null)
            {
                VehicleDeleteViewModel deletedVehicle = _vehicleService.RemoveVehicle(vehicle);
                return Ok(deletedVehicle);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, Vehicle alteredVehicle)
        {
            Vehicle registeredVehicle = _vehicleService.GetVehicleById(id); ;

            if (registeredVehicle != null)
            {
                _vehicleService.UpdateVehicle(registeredVehicle, alteredVehicle);
                return Ok(registeredVehicle);
            }

            return NotFound();
        }
    }
}
