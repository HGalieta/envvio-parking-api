﻿using Envvio.Parking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Envvio.Parking.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingLot>()
                .HasMany(p => p.Vehicles)
                .WithOne(v => v.ParkingLot);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
    }
}
