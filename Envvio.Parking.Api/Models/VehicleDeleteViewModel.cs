using System.ComponentModel.DataAnnotations;

namespace Envvio.Parking.Api.Models
{
    public class VehicleDeleteViewModel
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int ParkingLotId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public double AmountToPay { get; set; }
        public string Currency { get; set; }

    }
}
