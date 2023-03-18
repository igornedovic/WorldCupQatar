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
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;      
        }

        // POST api/matches
        [HttpPost]
        public async Task<ActionResult<MatchReadDto>> AddMatch(MatchCreateDto matchCreateDto)
        {
            var result = await _matchService.AddMatchAsync(matchCreateDto);

            if (result.IsBadRequest) return BadRequest(result.Message);

            return Ok(result.Payload);
        }
    }
}