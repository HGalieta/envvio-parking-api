using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envvio.Parking.Api.Models
{
    public class ParkingLot
    {
        [JsonIgnore]
        public List<Vehicle> Vehicles { get; set; }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
