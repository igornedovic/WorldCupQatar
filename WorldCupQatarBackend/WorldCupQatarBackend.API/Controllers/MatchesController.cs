using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldCupQatarBackend.API.Helpers.Validation;
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

        // GET api/matches
        [HttpGet]
        public async Task<ActionResult<List<MatchReadDto>>> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();

            return Ok(matches);
        }

        // POST api/matches
        [HttpPost]
        [ServiceFilter(typeof(MatchValidationFilter))]
        public async Task<ActionResult<MatchReadDto>> AddMatch(MatchCreateDto matchCreateDto)
        {
            var result = await _matchService.AddMatchAsync(matchCreateDto);

            if (result.IsBadRequest) return BadRequest(result.Message);

            return Ok(result.Payload);
        }

        // PUT api/matches/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMatchStatus(int id, MatchResultDto matchResultDto)
        {
            var newStatus = await _matchService.UpdateMatchStatusAndResult(id, matchResultDto);

            if (newStatus == null) return BadRequest("Failed to update match status and result!");

            return Ok("Successfully updated match status and result!");
        }

    }
}