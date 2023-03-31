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
    public class StadiumsController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumsController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        // GET api/stadiums
        [HttpGet]
        public async Task<ActionResult<List<StadiumProjectionDto>>> GetAllStadiums()
        {
            var stadium = await _stadiumService.GetProjectedStadiumsAsync();

            return Ok(stadium);
        }

    }
}