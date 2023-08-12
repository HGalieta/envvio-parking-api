using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Envvio.Parking.Api.Models
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Plate { get; set; }
        [Required]
        public ParkingLot ParkingLot { get; set; }
    }
}
