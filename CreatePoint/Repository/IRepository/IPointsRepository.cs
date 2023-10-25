using CreatePoint.Dto.Request;
using CreatePoint.Dto;
using CreatePoint.Models;

namespace CreatePoint.Repository.IRepository
{
    public interface IPointsRepository
    {
        Task<PointsDto> CreatePoints(PointsRequest request);
        Task<List<Points>> GetAllPoints();
        Task DeleteByIdPoints(long id);
        Task<PointsDto> UpdatePoint(UpdatePoints model);
        Task<PointsDto> GetByIdPoint(long id);
    }
}
