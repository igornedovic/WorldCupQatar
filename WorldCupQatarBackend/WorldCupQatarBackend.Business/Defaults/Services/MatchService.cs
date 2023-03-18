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
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResult<MatchReadDto>> AddMatchAsync(MatchCreateDto matchCreateDto)
        {
            ServiceResult<MatchReadDto> result = new();

            var newMatch = _mapper.Map<Match>(matchCreateDto);

            var team1 = await _unitOfWork.TeamRepository.GetFirstAsync(x => x.Id == newMatch.Team1Id);
            var team2 = await _unitOfWork.TeamRepository.GetFirstAsync(x => x.Id == newMatch.Team2Id);

            if (team1 == null || team2 == null)
            {
                return result.BadRequestMessage("Invalid team input!");
            }

            newMatch.Team1 = team1;
            newMatch.Team2 = team2;

            var stadium = await _unitOfWork.StadiumRepository.GetFirstAsync(x => x.Id == newMatch.StadiumId);

            if (stadium == null)
            {
                return result.BadRequestMessage("Invalid stadium input!");
            }

            newMatch.Stadium = stadium;

            var isSameStadiumAndDateTime = await _unitOfWork.MatchRepository
                                                        .AnyAsync(x => x.StadiumId == newMatch.StadiumId && (x.MatchDateTime.AddHours(3) >= newMatch.MatchDateTime) && (x.MatchDateTime.AddHours(-3) <= newMatch.MatchDateTime));

            if (isSameStadiumAndDateTime)
            {
                return result
                        .BadRequestMessage("There is already a booked match on the same stadium at the same time!");
            }

            var isSameTeamOnOtherMatch = await _unitOfWork.MatchRepository
                                                        .AnyAsync(x => (x.Team1Id == newMatch.Team1Id || x.Team1Id == newMatch.Team2Id || x.Team2Id == newMatch.Team1Id || x.Team2Id == newMatch.Team2Id) && (x.MatchDateTime.AddDays(1) >= newMatch.MatchDateTime) && (x.MatchDateTime.AddDays(-1) <= newMatch.MatchDateTime));

            if (isSameTeamOnOtherMatch)
            {
                return result
                        .BadRequestMessage("One team is not allowed to play more than one match at the same time!");
            }

            var isSameMatchAlreadyPlayed = await _unitOfWork.MatchRepository
                                                        .AnyAsync(x => (x.Team1Id == newMatch.Team1Id && x.Team2Id == newMatch.Team2Id) || (x.Team1Id == newMatch.Team2Id && x.Team2Id == newMatch.Team1Id));

            var isGroupPhaseActive = await _unitOfWork.TeamRepository
                                                        .AnyAsync(x => x.Id == newMatch.Team1Id && x.MatchesPlayed <= 2);

            if (isSameMatchAlreadyPlayed && isGroupPhaseActive)
            {
                return result
                        .BadRequestMessage("A match between same teams cannot happen again in the group phase!");
            }

            _unitOfWork.MatchRepository.Add(newMatch);

            if (!await _unitOfWork.CommitAsync())
            {
                return result.BadRequestMessage("Failed to add a new match!");
            }

            result.Payload = _mapper.Map<MatchReadDto>(newMatch);

            return result;
        }
    }
}