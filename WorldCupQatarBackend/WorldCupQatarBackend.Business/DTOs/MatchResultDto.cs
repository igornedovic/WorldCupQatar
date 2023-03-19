using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class MatchResultDto
    {
        public string NewStatus { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
    }
}