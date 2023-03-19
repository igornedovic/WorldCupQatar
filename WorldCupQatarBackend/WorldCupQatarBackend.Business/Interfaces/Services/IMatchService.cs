using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Helpers;

namespace WorldCupQatarBackend.Business.Interfaces.Services
{
    public interface IMatchService
    {
        public Task<List<MatchReadDto>> GetAllMatchesAsync();
        public Task<ServiceResult<MatchReadDto>> AddMatchAsync(MatchCreateDto matchCreateDto);
        public Task<string> UpdateMatchStatusAndResult(int id, MatchResultDto matchResultDto);
    }
}