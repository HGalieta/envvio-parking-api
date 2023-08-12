using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : Controller
    {
        private readonly DataContext _context;

        public VehicleController(DataContext context)
        {
            _context = context;
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
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return Ok();

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
