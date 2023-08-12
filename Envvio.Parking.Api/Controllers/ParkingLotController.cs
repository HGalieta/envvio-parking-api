using Envvio.Parking.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController : Controller
    {
        private readonly DataContext _context;

        [HttpGet]
        public IActionResult GetParkingLots()
        {
            List<ParkingLot> parkingLots = _context.ParkingLots.ToList();

            if (parkingLots != null)
            {
                return Ok(parkingLots);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetParkingLotById(int id)
        {
            ParkingLot parkingLot = _context.ParkingLots.FirstOrDefault(p => p.Id == id);

            if (parkingLot != null)
            {
                return Ok(parkingLot);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult PostParkingLot(ParkingLot parkingLot)
        {
            _context.ParkingLots.Add(parkingLot);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParkingLot(int id)
        {
            ParkingLot parkingLot = _context.ParkingLot.FirstOrDefault(p => p.Id == id);

            if (parkingLot != null)
            {
                _context.Vehicles.Remove(parkingLot);
                _context.SaveChanges();
                return Ok(parkingLot);
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchVehicle(int id, ParkingLot alteredParkingLot)
        {
            ParkingLot registeredParkingLot = _context.Vehicle.FirstOrDefault(p => p.Id == id);

            if (registeredParkingLot != null)
            {
                registeredParkingLot.State = alteredParkingLot.State;
                registeredParkingLot.City = alteredParkingLot.City;
                registeredParkingLot.Country = alteredParkingLot.Country;
                _context.SaveChanges();
                return Ok(registeredVehicle);
            }

            return NotFound();
        }
    }
}
