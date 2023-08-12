using System.Text.RegularExpressions;

namespace Envvio.Parking.Api.Models
{
    public class Vehicle
    {
        public Vehicle(string plate, VehicleType type, ParkingLot parkingLot)
        {
            Plate = plate;
            Type = type;
            ParkingLot = parkingLot;

            if (Regex.IsMatch(plate, "[A-Z]{3}[0-9][A-Z][0-9]{2}"))
                Country = "Brasil";
            if (Regex.IsMatch(plate, "[A-Z]{2}[0-9]{3}[A-Z]{2}"))
                Country = "Argentina";
        }

        public string Plate { get; set; }
        public string Country { get; set; }
        public VehicleType Type { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}
