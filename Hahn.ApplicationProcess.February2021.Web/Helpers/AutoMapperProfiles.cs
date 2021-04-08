using System;
using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Entities;

namespace Hahn.ApplicationProcess.February2021.Web.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => Enum.GetName(typeof(DepartmentType), src.Department)));
        }
    }
}