using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class WorldCupReadDto
    {
        public string Name { get; set; }
        public List<StadiumReadDto> Stadiums { get; set; }
    }
}