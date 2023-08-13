using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Services
{
    public class VehicleService
    { 
        public double CalculatePayment(Vehicle vehicle, DateTime checkoutTime)
        {
            double baseValueForHour = 5;
            double baseValueForHourFraction = 3;

            double hours = (checkoutTime - vehicle.EntryDate).TotalHours;

            return Math.Floor(hours) * baseValueForHour + Math.Ceiling(hours - Math.Floor(hours)) * baseValueForHourFraction;
        }
    }
}
