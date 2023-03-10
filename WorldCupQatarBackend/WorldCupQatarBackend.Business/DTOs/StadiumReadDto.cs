using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class StadiumReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string LocationName { get; set; }
    }
}