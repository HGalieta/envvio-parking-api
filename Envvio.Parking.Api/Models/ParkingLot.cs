using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envvio.Parking.Api.Models
{
    public class ParkingLot
    {
        public ParkingLot(string name)
        {
            Name = name;
            Vehicles = new List<Vehicle>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
    }

}
