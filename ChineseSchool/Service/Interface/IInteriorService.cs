using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Models;

namespace ChineseSchool.Service.Interface
{
    public interface IInteriorService
    {
        Task<InteriorsDto> CreateInterior(InteriorsRequest request);
        Task<List<Interiors>> GetAllInterior();
        Task<InteriorsDto> GetByIdInterior(long id);
        Task<InteriorsDto> UpdateInterior(UpdateInteriorModel model);
        Task DeleteByIdInterior(long id);
    }
}
