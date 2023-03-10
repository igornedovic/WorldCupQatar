using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Models
{
    public class Stadium : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int WorldCupId { get; set; }
        public WorldCup WorldCup { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}