using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Business.DTOs;

namespace WorldCupQatarBackend.Business.Interfaces.Services
{
    public interface ITeamService
    {
        public Task<List<TeamProjectionDto>> GetProjectedTeamsAsync();
    }
}