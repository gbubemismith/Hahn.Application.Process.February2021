using System;
using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Entities;

namespace Hahn.ApplicationProcess.February2021.Domain.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //map from asset enitity to data transfer object
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => Enum.GetName(typeof(DepartmentType), src.Department)));

            CreateMap<AssetDto, Asset>()
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => (DepartmentType)Enum.Parse(typeof(DepartmentType), src.Department)))
            .ForMember(dest => dest.ID, act => act.Ignore());

            CreateMap<AssetDto, AsssetForViewDto>().ReverseMap();

            CreateMap<AsssetForViewDto, Asset>()
                .ForMember(dest => dest.Department,
                opt => opt.MapFrom(src => (DepartmentType)Enum.Parse(typeof(DepartmentType), src.Department)))
                .ForMember(dest => dest.ID, act => act.Ignore());
        }
    }
}