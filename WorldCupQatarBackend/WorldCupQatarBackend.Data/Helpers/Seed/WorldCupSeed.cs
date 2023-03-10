using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Data.Helpers.Seed
{
    public class WorldCupSeed
    {
        public static async Task SeedAsync(WorldCupDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(typeof(WorldCupSeed).Assembly.Location);

                if (!context.WorldCups.Any())
                {
                    var worldCupData = File.ReadAllText(path + @"/Seed/worldcup.json");
                    var worldCup = JsonSerializer.Deserialize<WorldCup>(worldCupData);

                    context.WorldCups.Add(worldCup);
                    await context.SaveChangesAsync();
                }

                if (!context.Locations.Any())
                {
                    var locationsData = File.ReadAllText(path + @"/Seed/locations.json");
                    var locations = JsonSerializer.Deserialize<List<Location>>(locationsData);

                    foreach (var location in locations)
                    {
                        context.Locations.Add(location);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Stadiums.Any())
                {
                    var stadiumsData = File.ReadAllText(path + @"/Seed/stadiums.json");
                    var stadiums = JsonSerializer.Deserialize<List<Stadium>>(stadiumsData);

                    foreach (var stadium in stadiums)
                    {
                        context.Stadiums.Add(stadium);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<WorldCupSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}