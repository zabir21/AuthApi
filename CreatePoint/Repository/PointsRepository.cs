using AutoMapper;
using CreatePoint.Data;
using CreatePoint.Dto;
using CreatePoint.Dto.Request;
using CreatePoint.Models;
using CreatePoint.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CreatePoint.Repository
{
    public class PointsRepository : IPointsRepository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public PointsRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PointsDto> CreatePoints(PointsRequest request)
        {
            var point = _mapper.Map<Points>(request);

            await _db.Points.AddAsync(point);
            await _db.SaveChangesAsync();

            var dto = _mapper.Map<PointsDto>(point);

            return dto;
        }

        public async Task<List<Points>> GetAllPoints()
        {
            return await _db.Points.ToListAsync();
        }

        public async Task<PointsDto> GetByIdPoint(long id)
        {
            var point = await _db.Points.FindAsync(id);

            if (point == null)
            {
                throw new Exception();
            }

            var dto = _mapper.Map<PointsDto>(point);
            return dto;
        }

        public async Task DeleteByIdPoints(long id)
        {
            var point = await _db.Points.FindAsync(id);

            if (point == null)
            {
                throw new Exception();
            }

            _db.Points.Remove(point);
            await _db.SaveChangesAsync();
        }

        public async Task<PointsDto> UpdatePoint(UpdatePoints model)
        {
            var point = await _db.Points.FindAsync(model.Id);

            if (point == null)
            {
                throw new Exception();
            }

            point.UserName = model.UserName ?? point.UserName;
            point.QuantityPoint = model.QuantityPoint;

            await _db.SaveChangesAsync();

            var dto = _mapper.Map<PointsDto>(point);
            return dto;
        }
    }
}
