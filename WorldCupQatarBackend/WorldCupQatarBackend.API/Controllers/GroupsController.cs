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
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;   
        }

        // GET api/groups
        [HttpGet]
        public async Task<ActionResult<List<GroupReadDto>>> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroupsAsync();

            return Ok(groups);
        }

        // GET api/groups/{id}/teams
        [HttpGet("{id}/teams")]
        public async Task<ActionResult<List<TeamReadDto>>> GetTeamsByGroup(int id)
        {
            var teamsForGroup = await _groupService.GetTeamsByGroupAsync(id);

            return Ok(teamsForGroup);
        }


        // POST api/groups
        [HttpPost]
        [ServiceFilter(typeof(GroupTeamsValidationFilter))]
        public async Task<ActionResult<GroupReadDto>> AddGroup(GroupCreateDto groupCreateDto)
        {
            var result = await _groupService.AddGroupAsync(groupCreateDto);

            if (result.IsBadRequest) return BadRequest(result.Message);

            return Ok(result.Payload);
        }
    }
}