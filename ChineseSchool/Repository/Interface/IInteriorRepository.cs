using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Models;

namespace ChineseSchool.Repository.Interface
{
    public interface IInteriorRepository
    {
        Task<InteriorsDtoPost> CreateInterior(InteriorsRequest request);
        Task<IEnumerable<Interiors>> GetAllInterior();
        Task<InteriorsDtoGetById> GetByIdInterior(long id);
        Task UpdateInterior(UpdateInteriorDto model);
        Task DeleteByIdInterior(long id);
    }
}
