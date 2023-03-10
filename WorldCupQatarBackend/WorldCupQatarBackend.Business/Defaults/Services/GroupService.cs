using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Helpers;
using WorldCupQatarBackend.Business.Interfaces.Services;
using WorldCupQatarBackend.Data.Interfaces.UnitOfWork;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Business.Defaults.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ServiceResult<GroupReadDto> BadRequestMessage(ServiceResult<GroupReadDto> result, string message)
        {
            result.IsBadRequest = true;
            result.Message = message;
            return result;
        }

        public async Task<ServiceResult<GroupReadDto>> AddGroupAsync(GroupCreateDto groupCreateDto)
        {
            ServiceResult<GroupReadDto> result = new();

            var group = await _unitOfWork.GroupRepository.GetFirstAsync(x => x.Name == groupCreateDto.Name);

            if (group != null)
            {
                return BadRequestMessage(result, $"{group.Name} already exists!");
            }

            group = _mapper.Map<Group>(groupCreateDto);

            if (group.Teams.Count != 4)
            {
                return BadRequestMessage(result, "Number of teams must be 4 in one group!");
            }

            foreach (var team in group.Teams)
            {
                var existingTeam = await _unitOfWork.TeamRepository.GetFirstAsync(x => x.Name == team.Name);

                if (existingTeam != null)
                {
                    return BadRequestMessage(result, $"{team.Name} already exists in another group!");
                }

                team.Group = group;

                _unitOfWork.TeamRepository.Add(team);
            }

            if (!await _unitOfWork.CommitAsync())
            {
                return BadRequestMessage(result, "Failed to add a new group and its teams!");
            }

            result.Payload = _mapper.Map<GroupReadDto>(group);

            return result;
        }
    }
}