using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Envvio.Parking.Api.Models
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Plate { get; set; }
    }
}
