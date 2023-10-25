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
            //Модель запроса в модель 
            CreateMap<PointsRequest, Points>().ReverseMap();

            // Модели в Dto
            CreateMap<Points, PointsDto>().ReverseMap();

            // модель обновления в Dto
            CreateMap<UpdatePoints, PointsDto>().ReverseMap();

            // модель запроса в модель обновления
            CreateMap<PointsRequest, UpdatePoints>().ReverseMap();

            // модель обновления в модель ответа
            CreateMap<UpdatePoints, PointsResponse>().ReverseMap();

            // модель Dto в модель ответа
            CreateMap<PointsDto, PointsResponse>().ReverseMap();

            // модель запроса в модель ответа
            CreateMap<PointsRequest, PointsResponse>().ReverseMap();

            // модель запроса в модель запроса обновление запроса
            CreateMap<PointsRequest, PointsRequest>().ReverseMap(); 
        }
    }
}
