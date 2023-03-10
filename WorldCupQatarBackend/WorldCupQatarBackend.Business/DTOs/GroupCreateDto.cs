using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int WorldCupId { get; set; }
        public List<TeamCreateDto> Teams { get; set; } = new List<TeamCreateDto>();
    }
}