using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly DataContext _context;

        public ParkingLotService(DataContext context)
        {
            _context = context;
        }

        public List<ParkingLot> GetParkingLots()
        {
            return _context.ParkingLots.Include(x => x.Vehicles).AsNoTracking().ToList();
        }

        public ParkingLot GetParkingLotById(int id)
        {
            return _context.ParkingLots.FirstOrDefault(p => p.Id == id);
        }

        public void CreateParkingLot(ParkingLot parkingLot)
        {
            _context.ParkingLots.Add(parkingLot);
            _context.SaveChanges();
        }

        public void RemoveParkingLot(ParkingLot parkingLot)
        {
            _context.ParkingLots.Remove(parkingLot);
            _context.SaveChanges();
        }

        public void UpdateParkingLot(ParkingLot registeredParkingLot, ParkingLot alteredParkingLot)
        {
            registeredParkingLot.Name = alteredParkingLot.Name;
            _context.SaveChanges();
        }

    }
}
