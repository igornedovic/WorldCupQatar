using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class MatchCreateDto
    {
        public string MatchDateTime { get; set; }
        public string Status { get; set; } = "NotStarted";
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int StadiumId { get; set; }
    }
}