using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController : Controller
    {
        private  readonly DataContext _context;

        public ParkingLotController(DataContext context)
        {
            _context = context;
        }

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
            return Ok(parkingLot);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParkingLot(int id)
        {
            ParkingLot parkingLot = _context.ParkingLots.FirstOrDefault(p => p.Id == id);

            if (parkingLot != null)
            {
                _context.ParkingLots.Remove(parkingLot);
                _context.SaveChanges();
                return Ok(parkingLot);
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchParkingLot(int id, ParkingLot alteredParkingLot)
        {
            ParkingLot registeredParkingLot = _context.ParkingLots.FirstOrDefault(p => p.Id == id);

            if (registeredParkingLot != null)
            {
                registeredParkingLot.Name = alteredParkingLot.Name;
                _context.SaveChanges();
                return Ok(registeredParkingLot);
            }

            return NotFound();
        }
    }
}
