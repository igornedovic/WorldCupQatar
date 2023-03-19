using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Helpers;

namespace WorldCupQatarBackend.Business.Interfaces.Services
{
    public interface IGroupService
    {
        public Task<List<GroupReadDto>> GetAllGroupsAsync();
        public Task<ServiceResult<GroupReadDto>> AddGroupAsync(GroupCreateDto groupCreateDto);
    }
}