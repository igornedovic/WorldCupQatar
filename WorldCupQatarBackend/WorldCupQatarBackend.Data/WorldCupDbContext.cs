using Microsoft.EntityFrameworkCore;
using System;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data
{
    public class WorldCupDbContext : DbContext
    {
        public WorldCupDbContext(DbContextOptions<WorldCupDbContext> options) : base(options)
        {

        }

        public DbSet<WorldCup> WorldCups { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // World cup
            modelBuilder.Entity<WorldCup>().Property(wc => wc.Name).IsRequired();

            // Stadium
            modelBuilder.Entity<Stadium>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Stadium>().Property(s => s.Capacity).IsRequired();
            modelBuilder.Entity<Stadium>().HasOne(s => s.WorldCup).WithMany(wc => wc.Stadiums)
                .HasForeignKey(s => s.WorldCupId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stadium>().HasOne(s => s.Location).WithMany()
                .HasForeignKey(s => s.LocationId).OnDelete(DeleteBehavior.Restrict);

            // Location
            modelBuilder.Entity<Stadium>().Property(l => l.Name).IsRequired();
        }
    }
}
