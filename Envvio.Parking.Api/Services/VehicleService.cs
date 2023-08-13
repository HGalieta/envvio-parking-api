using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Services
{
    public class VehicleService
    {
        private readonly DataContext _context;

        public VehicleService(DataContext context)
        {
            _context = context;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            ParkingLot parkingLot = _context.ParkingLots.FirstOrDefault(p => p.Id == vehicle.ParkingLotId);
            parkingLot.Vehicles.Add(vehicle);
            _context.ParkingLots.Update(parkingLot);
                
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
    }
}
