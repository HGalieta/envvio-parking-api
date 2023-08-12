using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envvio.Parking.Api.Models
{
    public class ParkingLot
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
