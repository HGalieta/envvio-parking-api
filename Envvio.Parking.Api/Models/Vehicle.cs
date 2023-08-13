using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Envvio.Parking.Api.Models
{
    public class Vehicle
    {
        public Vehicle(string plate, int parkingLotId)
        {
            Plate = plate;
            ParkingLotId = parkingLotId;
            EntryDate = DateTime.Now;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Plate { get; set; }
        public int ParkingLotId { get; set; }
        public ParkingLot? ParkingLot { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
