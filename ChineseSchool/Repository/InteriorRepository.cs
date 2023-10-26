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

        public async Task<InteriorsDto> CreateInterior(InteriorsRequest request)
        {
            var interior = _mapper.Map<Interiors>(request);

            _context.Interiors.Add(interior);
            await _context.SaveChangesAsync();

            var dto = _mapper.Map<InteriorsDto>(interior);
            return dto;
        }

        public async Task<List<Interiors>> GetAllInterior()
        {
           return await _context.Interiors.ToListAsync();          
        }

        public async Task<InteriorsDto> GetByIdInterior(long id)
        {
            var interior = await _context.Interiors.FindAsync(id);

            if (interior == null)
                throw new NotFoundException();

            var dto = _mapper.Map<InteriorsDto>(interior);
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

        public async Task<InteriorsDto> UpdateInterior(UpdateInteriorDto model)
        {
            var interior = await _context.Interiors.FindAsync(model.Id);

            if (interior == null)
                throw new NotFoundException();

            interior.Name = model.Name ?? interior.Name;
            interior.Description = model.Description ?? interior.Description;
            interior.ImageInterior = model.ImageInterior ?? interior.ImageInterior;

            await _context.SaveChangesAsync();

            var dto = _mapper.Map<InteriorsDto>(interior);
            return dto;
        }
    }
}
