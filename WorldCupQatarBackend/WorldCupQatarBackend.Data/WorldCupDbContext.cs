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
        public DbSet<Match> Matches { get; set; }

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
            modelBuilder.Entity<Team>().Property(ts => ts.MatchesPlayed).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.Wins).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.Draws).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.Losses).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.GoalsScored).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.GoalsConceded).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().Property(ts => ts.Points).IsRequired().HasDefaultValue(0);
            modelBuilder.Entity<Team>().HasOne(t => t.Group).WithMany(g => g.Teams)
                 .HasForeignKey(s => new { s.GroupId, s.WorldCupId }).OnDelete(DeleteBehavior.Restrict);

            // Match
            modelBuilder.Entity<Match>().Property(m => m.MatchDateTime).IsRequired();
            modelBuilder.Entity<Match>().Property(m => m.Team1Goals).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Match>().Property(m => m.Team2Goals).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Match>().Property(m => m.Status)
                .HasConversion(m => m.ToString(), x => (MatchStatus)Enum.Parse(typeof(MatchStatus), x))
                .IsRequired();
            modelBuilder.Entity<Match>().HasOne(m => m.Team1).WithMany()
                .HasForeignKey(m => m.Team1Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>().HasOne(m => m.Team2).WithMany()
                .HasForeignKey(m => m.Team2Id).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>().HasOne(m => m.Stadium).WithMany()
                .HasForeignKey(m => m.StadiumId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
