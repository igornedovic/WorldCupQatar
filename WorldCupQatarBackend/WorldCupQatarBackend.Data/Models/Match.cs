using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Data.Interfaces.Models;

namespace WorldCupQatarBackend.Data.Models
{
    public enum MatchStatus
    {
        NotStarted,
        Finished,
        Team1Forfeit,
        Team2Forfeit
    }
    public class Match : IEntity
    {
        public int Id { get; set; }
        public DateTime MatchDateTime { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }
        public MatchStatus Status { get; set; }
        public int Team1Id { get; set; }
        public Team Team1 { get; set; }
        public int Team2Id { get; set; }
        public Team Team2 { get; set; }
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
    }
}