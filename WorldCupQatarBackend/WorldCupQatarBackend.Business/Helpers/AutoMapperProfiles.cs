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
            CreateMap<Group, GroupReadDto>();

            CreateMap<TeamCreateDto, Team>();
            CreateMap<Team, TeamReadDto>();
        }
    }
}