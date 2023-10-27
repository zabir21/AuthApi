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

            CreateMap<Interiors, InteriorsDtoPost>().ReverseMap();

            CreateMap<Interiors, InteriorsDtoGetById>().ReverseMap();

            CreateMap<UpdateInteriorDto, Interiors? > ().ReverseMap();

            CreateMap<UpdateInteriorRequest, UpdateInteriorDto>().ReverseMap();

            CreateMap<InteriorsRequest, InteriorsDtoPost>().ReverseMap();

            CreateMap<InteriorsDtoPost, InteriorResponse>().ReverseMap();

            CreateMap<InteriorsDtoGetById, InteriorResponse>().ReverseMap();
        }
    }
}
