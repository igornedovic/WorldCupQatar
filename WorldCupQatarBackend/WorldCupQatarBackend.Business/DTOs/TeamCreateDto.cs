using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorldCupQatarBackend.Business.DTOs
{
    public class TeamCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string IconUrl { get; set; }
        // [Required]
        // public int GroupId { get; set; }
        // [Required]
        // public int WorldCupId { get; set; }
    }
}