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
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return Ok(vehicle);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = _context.Vehicles.Include(x => x.ParkingLot).FirstOrDefault(v => v.Id == id);

            if (vehicle != null)
            {
                DateTime checkoutTime = DateTime.Now;
                double amountToPay = _vehicleService.CalculatePayment(vehicle, checkoutTime);
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                var result = new VehicleDeleteViewModel()
                {
                    AmountToPay = amountToPay,
                    LeaveDate = checkoutTime,
                    EntryDate = vehicle.EntryDate,
                    Plate = vehicle.Plate,
                    Id = vehicle.Id,
                    ParkingLotId = vehicle.ParkingLotId,
                    Currency = vehicle.ParkingLot.Currency

                };
                return Ok(result);
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
