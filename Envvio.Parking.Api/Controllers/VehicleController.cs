using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Envvio.Parking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly DataContext _context;
        private readonly VehicleService _vehicleService;

        public VehicleController(DataContext context, VehicleService vehicleService)
        {
            _context = context;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            List<Vehicle> vehicles = _context.Vehicles.ToList();

            if (vehicles != null)
            {
                return Ok(vehicles);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            Vehicle vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle != null)
            {
                return Ok(vehicle);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult PostVehicle(Vehicle vehicle)
        {
            _vehicleService.AddVehicle(vehicle);
            return Ok(vehicle);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                return Ok(vehicle);
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchVehicle(int id, Vehicle alteredVehicle)
        {
            Vehicle registeredVehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);

            if (registeredVehicle != null)
            {
                registeredVehicle.Plate = alteredVehicle.Plate;
                _context.SaveChanges();
                return Ok(registeredVehicle);
            }

            return NotFound();
        }
    }
}
