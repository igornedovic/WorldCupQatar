using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<List<GroupReadDto>> GetAllGroupsAsync()
        {
            var groups = await _unitOfWork.GroupRepository.GetListAsync(orderAsc: x => x.Name);

            return _mapper.Map<List<GroupReadDto>>(groups);
        }

        public async Task<ServiceResult<GroupReadDto>> AddGroupAsync(GroupCreateDto groupCreateDto)
        {
            ServiceResult<GroupReadDto> result = new();

            var group = await _unitOfWork.GroupRepository.GetFirstAsync(x => x.Name == groupCreateDto.Name);

            if (group != null)
            {
                return result.BadRequestMessage($"{group.Name} already exists!");
            }

            group = _mapper.Map<Group>(groupCreateDto);

            if (group.Teams.Count != 4)
            {
                return result.BadRequestMessage("Number of teams must be 4 in one group!");
            }

            foreach (var team in group.Teams)
            {
                var existingTeam = await _unitOfWork.TeamRepository.GetFirstAsync(x => x.Name == team.Name);

                if (existingTeam != null)
                {
                    return result.BadRequestMessage($"{team.Name} already exists in another group!");
                }

                team.Group = group;

                _unitOfWork.TeamRepository.Add(team);
            }

            if (!await _unitOfWork.CommitAsync())
            {
                return result.BadRequestMessage("Failed to add a new group and its teams!");
            }

            result.Payload = _mapper.Map<GroupReadDto>(group);

            return result;
        }
    }
}