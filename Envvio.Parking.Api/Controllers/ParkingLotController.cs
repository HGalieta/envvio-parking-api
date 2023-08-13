using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Envvio.Parking.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Envvio.Parking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingLotController : Controller
    {
        private  readonly DataContext _context;
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        [HttpGet]
        public IActionResult GetParkingLots()
        {
            List<ParkingLot> parkingLots = _parkingLotService.GetParkingLots();

            if (parkingLots != null)
            {
                return Ok(parkingLots);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetParkingLotById(int id)
        {
            ParkingLot parkingLot = _parkingLotService.GetParkingLotById(id);

            if (parkingLot != null)
            {
                return Ok(parkingLot);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateParkingLot(ParkingLot parkingLot)
        {
            _parkingLotService.CreateParkingLot(parkingLot);
            return Ok(parkingLot);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveParkingLot(int id)
        {
            ParkingLot parkingLot = _parkingLotService.GetParkingLotById(id);

            if (parkingLot != null)
            {
                _parkingLotService.RemoveParkingLot(parkingLot);
                return Ok(parkingLot);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateParkingLot(int id, ParkingLot alteredParkingLot)
        {
            ParkingLot registeredParkingLot = _parkingLotService.GetParkingLotById(id);

            if (registeredParkingLot != null)
            {
                _parkingLotService.UpdateParkingLot(registeredParkingLot, alteredParkingLot);
                return Ok(registeredParkingLot);
            }

            return NotFound();
        }
    }
}
