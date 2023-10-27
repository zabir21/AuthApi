using AutoMapper;
using CreatePoint.Dto;
using CreatePoint.Dto.Request;
using CreatePoint.Dto.Response;
using CreatePoint.Models;

namespace CreatePoint.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<PointsRequest, Points>().ReverseMap();

            CreateMap<Points, PointsDtoPost>().ReverseMap();

            CreateMap<Points, PointsDtoGetById>().ReverseMap();

            CreateMap<PointsDtoGetById, PointsResponse>().ReverseMap();

            CreateMap<UpdatePointsRequest, UpdatePoints>().ReverseMap();

            CreateMap<UpdatePoints, Points>().ReverseMap();

            CreateMap<PointsRequest, PointsDtoPost>().ReverseMap();

            CreateMap<PointsDtoPost, PointsResponse>().ReverseMap();
        }
    }
}
