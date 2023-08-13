using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Envvio.Parking.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.ParkingLot)
                .WithMany(p => p.Vehicles)
                .HasForeignKey(v => v.ParkingLotId);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
    }
}
