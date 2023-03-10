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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStats> TeamsStats { get; set; }

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

            // Group
            modelBuilder.Entity<Group>().HasKey(g => new { g.Id, g.WorldCupId });
            modelBuilder.Entity<Group>().Property(g => g.Name).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Group>().HasOne(g => g.WorldCup).WithMany(wc => wc.Groups)
                 .HasForeignKey(g => g.WorldCupId).OnDelete(DeleteBehavior.Cascade);

            // Team
            modelBuilder.Entity<Team>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.IconUrl).IsRequired();
            modelBuilder.Entity<Team>().HasOne(t => t.Group).WithMany(g => g.Teams)
                 .HasForeignKey(s => new { s.GroupId, s.WorldCupId }).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Team>().HasOne(t => t.TeamStats).WithMany()
                .HasForeignKey(s => s.TeamStatsId).OnDelete(DeleteBehavior.Restrict);

            // TeamStats
            modelBuilder.Entity<TeamStats>().Property(ts => ts.MatchesPlayed).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.Wins).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.Draws).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.Losses).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.GoalsScored).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.GoalsConceded).IsRequired();
            modelBuilder.Entity<TeamStats>().Property(ts => ts.Points).IsRequired();
        }
    }
}
