using Envvio.Parking.Api.Data;
using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Services
{
    public class VehicleService
    {
        internal double CheckPayment(Vehicle vehicle)
        {
            double baseValue = 5;

            TimeSpan period = DateTime.Now - vehicle.EntryDate;
            double hours = period.TotalHours;
            Console.WriteLine(period);
            Console.WriteLine(hours);
            if (hours  <= 1)
            {
                return baseValue;
            } else if (hours <= 2)
            {
                return (baseValue * 2);
            } else if (hours <= 3)
            {
                return (baseValue * 3);
            } else if (hours <= 4) 
            {
                return (baseValue * 4);
            } else if(hours <= 5)
            {
                return (baseValue * 5);
            } else
            {
                return (baseValue * 6);
            }
        }
    }
}
