using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envvio.Parking.Api.Models
{
    public class ParkingLot
    {
        public ParkingLot(string name, string currency)
        {
            Name = name;
            Vehicles = new List<Vehicle>();
            Currency = currency;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public string Currency { get; set; }
    }

}
