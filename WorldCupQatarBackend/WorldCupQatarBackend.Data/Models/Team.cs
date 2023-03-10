using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Models
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
