using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Interfaces.Services;
using WorldCupQatarBackend.Data.Interfaces.UnitOfWork;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Business.Defaults.Services
{
    public class WorldCupService : IWorldCupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WorldCupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<WorldCupReadDto> GetWorldCupByIdAsync(int id)
        {
            var worldCup = await _unitOfWork.WorldCupRepository.GetByIdAsync(id, includes: new List<Func<IQueryable<WorldCup>, IIncludableQueryable<WorldCup, object>>>()
            {
                { x => x.Include(wc => wc.Stadiums).ThenInclude(s => s.Location)}
            }
            );

            if (worldCup == null) return null;

            return _mapper.Map<WorldCupReadDto>(worldCup);
        }
    }
}