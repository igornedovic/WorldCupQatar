using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Interfaces.Services;
using WorldCupQatarBackend.Data.Interfaces.UnitOfWork;

namespace WorldCupQatarBackend.Business.Defaults.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TeamProjectionDto>> GetProjectedTeamsAsync()
        {
            return await _unitOfWork.TeamRepository.GetProjectedListAsync<TeamProjectionDto>(selector: x => new TeamProjectionDto() { Id = x.Id, Name = x.Name, GroupId = x.GroupId } );
        }
    }
}