using Envvio.Parking.Api.Models;

namespace Envvio.Parking.Api.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();
        Vehicle GetVehicleById(int id);
        void CreateVehicle(Vehicle vehicle);
        VehicleDeleteViewModel RemoveVehicle(Vehicle vehicle);
        void UpdateVehicle(Vehicle registeredVehicle, Vehicle alteredVehicle);

    }
}
