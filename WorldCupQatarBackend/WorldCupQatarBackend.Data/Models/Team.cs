﻿using System;
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
        public int GroupId { get; set; }
        public int WorldCupId { get; set; }
        public Group Group { get; set; }
        public int TeamStatsId { get; set; }
        public TeamStats TeamStats { get; set; }
    }
}
