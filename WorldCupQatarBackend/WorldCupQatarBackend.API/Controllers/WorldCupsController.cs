using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Interfaces.Services;

namespace WorldCupQatarBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldCupsController : ControllerBase
    {
        private readonly IWorldCupService _worldCupService;

        public WorldCupsController(IWorldCupService worldCupService)
        {
            _worldCupService = worldCupService;
        }

        // GET api/worldcups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldCupReadDto>> GetWorldCupById(int id)
        {
            var worldCup = await _worldCupService.GetWorldCupByIdAsync(id);

            if (worldCup == null) return NotFound("No existing world cup found!");

            return Ok(worldCup);
        }
    }
}