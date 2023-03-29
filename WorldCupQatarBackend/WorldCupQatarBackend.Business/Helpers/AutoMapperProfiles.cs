using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WorldCupQatarBackend.Business.DTOs;
using WorldCupQatarBackend.Data.Models;

namespace WorldCupQatarBackend.Business.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<WorldCup, WorldCupReadDto>();

            CreateMap<Stadium, StadiumReadDto>();

            CreateMap<Location, LocationReadDto>();

            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupReadDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Name));

            CreateMap<TeamCreateDto, Team>();
            CreateMap<Team, TeamReadDto>();

            CreateMap<MatchCreateDto, Match>()
                .ForMember(dest => dest.MatchDateTime, opt => opt.MapFrom(src =>
                    DateTime.ParseExact(src.MatchDateTime, "yyyy-MM-dd HH:mm", null)));
            CreateMap<Match, MatchReadDto>();
        }
    }
}