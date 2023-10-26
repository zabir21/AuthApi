using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Models;

namespace ChineseSchool.Repository.Interface
{
    public interface IInteriorRepository
    {
        Task<InteriorsDto> CreateInterior(InteriorsRequest request);
        Task<List<Interiors>> GetAllInterior();
        Task<InteriorsDto> GetByIdInterior(long id);
        Task<InteriorsDto> UpdateInterior(UpdateInteriorDto model);
        Task DeleteByIdInterior(long id);
    }
}
