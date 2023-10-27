using CreatePoint.Dto.Request;
using CreatePoint.Dto;
using CreatePoint.Models;

namespace CreatePoint.Repository.IRepository
{
    public interface IPointsRepository
    {
        Task<PointsDtoPost> CreatePoints(PointsRequest request);
        Task<IEnumerable<Points>> GetAllPoints();
        Task DeleteByIdPoints(long id);
        Task UpdatePoint(UpdatePoints model);
        Task<PointsDtoGetById> GetByIdPoint(long id);
    }
}
