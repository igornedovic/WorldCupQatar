using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Models
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorldCupId { get; set; }
        public WorldCup WorldCup { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}