using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class MatchReadDto
    {
        public int Id { get; set; }
        public DateTime MatchDateTime { get; set; }
        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }
        public string Status { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
        public string StadiumName { get; set; }
    }
}