using ChineseSchool.DataBase;
using ChineseSchool.Dto;
using ChineseSchool.Dto.Request;
using ChineseSchool.Models;
using ChineseSchool.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ChineseSchool.Service
{
    public class InteriorService : IInteriorService
    {
        private readonly AppDbContext _context;

        public InteriorService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<InteriorsDto> CreateInterior(InteriorsRequest request)
        {
            var interior = new Interiors
            {
                Name = request.Name,
                Description = request.Description,
                ImageInterior =request.ImageInterior
            };

            await _context.Interiors.AddAsync(interior);
            await _context.SaveChangesAsync();

            return new InteriorsDto
            {
                Id = interior.Id,
                Name = interior.Name,
                Description = interior.Description,
                ImageInterior = interior.ImageInterior
            };
        }

        public async Task<List<Interiors>> GetAllInterior()
        {
           return await _context.Interiors.ToListAsync();          
        }

        public async Task<InteriorsDto> GetByIdInterior(long id)
        {
            var interior = await _context.Interiors.FindAsync(id);

            if (interior == null)
            {
                throw new Exception();
            }

            return new InteriorsDto
            { 
                Id = interior.Id,
                Name = interior.Name,
                Description = interior.Description,
                ImageInterior = interior.ImageInterior
            };
        }

        public async Task DeleteByIdInterior(long id)
        {
            var interior = await _context.Interiors.FindAsync(id);

            if (interior == null)
            {
                throw new Exception();
            }

            _context.Interiors.Remove(interior);
            await _context.SaveChangesAsync();
        }

        public async Task<InteriorsDto> UpdateInterior(UpdateInteriorModel model)
        {
            var interior = await _context.Interiors.FindAsync(model.Id);

            if (interior == null)
            {
                throw new Exception();
            }

            interior.Name = model.Name ?? interior.Name;
            interior.Description = model.Description ?? interior.Description;
            interior.ImageInterior = model.ImageInterior ?? interior.ImageInterior;

            await _context.SaveChangesAsync();

            return new InteriorsDto
            {
                Name = interior.Name,
                Description= interior.Description,
                ImageInterior = interior.ImageInterior
            };
        }
    }
}
