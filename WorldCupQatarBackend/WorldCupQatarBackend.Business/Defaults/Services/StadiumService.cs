using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Business.Interfaces.Services;
using WorldCupQatarBackend.Data.Interfaces.UnitOfWork;

namespace WorldCupQatarBackend.Business.Defaults.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StadiumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<StadiumProjectionDto>> GetProjectedStadiumsAsync()
        {
            return await _unitOfWork.StadiumRepository.GetProjectedListAsync<StadiumProjectionDto>(selector: x => new StadiumProjectionDto() { Id = x.Id, Name = x.Name });
        }
    }
}