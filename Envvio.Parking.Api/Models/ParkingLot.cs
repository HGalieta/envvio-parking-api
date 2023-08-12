using System.ComponentModel.DataAnnotations;

namespace Envvio.Parking.Api.Models
{
    public class ParkingLot
    {
        public ParkingLot(string country, string state, string city)
        {
            Country = country;
            State = state;
            City = city;
        }

        public List<Vehicle> Vehicles { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
    }

}
