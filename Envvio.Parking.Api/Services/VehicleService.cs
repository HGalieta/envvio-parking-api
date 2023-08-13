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

        public List<Vehicle> GetVehicles()
        {
            return _context.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _context.Vehicles.Include(x => x.ParkingLot).FirstOrDefault(v => v.Id == id);
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public VehicleDeleteViewModel RemoveVehicle(Vehicle vehicle)
        {
            DateTime checkoutTime = DateTime.Now;
            double amountToPay = CalculatePayment(vehicle, checkoutTime);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return new VehicleDeleteViewModel()
            {
                AmountToPay = amountToPay,
                LeaveDate = checkoutTime,
                EntryDate = vehicle.EntryDate,
                Plate = vehicle.Plate,
                Id = vehicle.Id,
                ParkingLotId = vehicle.ParkingLotId,
                Currency = vehicle.ParkingLot.Currency

            };
        }

        public void UpdateVehicle(Vehicle registeredVehicle, Vehicle alteredVehicle)
        {
            registeredVehicle.EntryDate = alteredVehicle.EntryDate;
            registeredVehicle.Plate = alteredVehicle.Plate;
            registeredVehicle.ParkingLotId = alteredVehicle.ParkingLotId;
            _context.SaveChanges();
        }

        public double CalculatePayment(Vehicle vehicle, DateTime checkoutTime)
        {
            double baseValueForHour = 5;
            double baseValueForHourFraction = 3;

            double hours = (checkoutTime - vehicle.EntryDate).TotalHours;

            return Math.Floor(hours) * baseValueForHour + Math.Ceiling(hours - Math.Floor(hours)) * baseValueForHourFraction;
        }
    }
}
