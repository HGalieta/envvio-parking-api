using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Envvio.Parking.Api.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int ParkingLotId { get; set; }
        [JsonIgnore]
        public ParkingLot? ParkingLot { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
