using Envvio.Parking.Api.Models;

namespace Envvio.Parking.Api.Services
{
    public interface IParkingLotService
    {
        List<ParkingLot> GetParkingLots();
        ParkingLot GetParkingLotById(int id);
        void CreateParkingLot(ParkingLot parkingLot);
        void RemoveParkingLot(ParkingLot parkingLot);
        void UpdateParkingLot(ParkingLot registeredParkingLot, ParkingLot alteredParkingLot);
    }
}
