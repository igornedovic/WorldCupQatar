using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Interfaces.Services;

namespace WorldCupQatarBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        // GET api/teams
        [HttpGet]
        public async Task<ActionResult<List<TeamProjectionDto>>> GetAllTeams()
        {
            var teams = await _teamService.GetProjectedTeamsAsync();

            return Ok(teams);
        }

    }
}