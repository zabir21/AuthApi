using AutoMapper;
using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Dto.Response;
using ChineseSchool.Models;

namespace ChineseSchool.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<InteriorsRequest, Interiors>().ReverseMap();

            CreateMap<Interiors, InteriorsDto>().ReverseMap();

            CreateMap<InteriorsRequest, InteriorsDto>().ReverseMap();

            CreateMap<InteriorsDto, InteriorResponse>().ReverseMap();

            CreateMap<UpdateInteriorRequest, UpdateInteriorDto>().ReverseMap();

            CreateMap<UpdateInteriorDto, InteriorResponse>().ReverseMap();
        }
    }
}
