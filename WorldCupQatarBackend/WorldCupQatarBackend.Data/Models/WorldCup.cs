using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Models
{
    public class WorldCup : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stadium> Stadiums { get; set; } = new List<Stadium>();
    }
}