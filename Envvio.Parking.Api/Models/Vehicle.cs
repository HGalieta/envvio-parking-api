using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Plate { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        public ParkingLot ParkingLot { get; set; }
    }
}
