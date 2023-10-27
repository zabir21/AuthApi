using AutoMapper;
using ChineseSchool.DataBase;
using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Exceptions;
using ChineseSchool.Models;
using ChineseSchool.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ChineseSchool.Repository
{
    public class InteriorRepository : IInteriorRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InteriorRepository(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InteriorsDtoPost> CreateInterior(InteriorsRequest request)
        {
            var interior = _mapper.Map<Interiors>(request);

            _context.Interiors.Add(interior);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<InteriorsDtoPost>(interior);
            return dto;
        }

        public async Task<IEnumerable<Interiors>> GetAllInterior()
        {
           return await _context.Interiors.ToArrayAsync();          
        }

        public async Task<InteriorsDtoGetById> GetByIdInterior(long id)
        {
            var interior = await _context.Interiors.FindAsync(id);

            if (interior == null)
                throw new NotFoundException();

            var dto = _mapper.Map<InteriorsDtoGetById>(interior);
            return dto;
            
        }

        public async Task DeleteByIdInterior(long id)
        {
            var interior = await _context.Interiors.FindAsync(id);

            if (interior == null)
                throw new NotFoundException();

            _context.Interiors.Remove(interior);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateInterior(UpdateInteriorDto dto)
        {
            var interior = await _context.Interiors.FindAsync(dto.Id);

            if (interior == null)
                throw new NotFoundException();

            _mapper.Map(dto, interior);

            await _context.SaveChangesAsync();
        }
    }
}
