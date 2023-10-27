using AutoMapper;
using AutoMapper.Internal;
using CreatePoint.Data;
using CreatePoint.Dto;
using CreatePoint.Dto.Request;
using CreatePoint.Models;
using CreatePoint.Repository.IRepository;
using CreatePoint.Utility.Exceptions;
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

        public async Task<PointsDtoPost> CreatePoints(PointsRequest request)
        {
            var point = _mapper.Map<Points>(request);

            _db.Points.Add(point);
            await _db.SaveChangesAsync();

            var dto = _mapper.Map<PointsDtoPost>(point);

            return dto;
        }

        public async Task<IEnumerable<Points>> GetAllPoints()
        {
            return await _db.Points.ToArrayAsync();
        }

        public async Task<PointsDtoGetById> GetByIdPoint(long id)
        {
            var point = await _db.Points.FindAsync(id);

            if (point == null)
                throw new NotFoundApiException();

            var dto = _mapper.Map<PointsDtoGetById>(point);
            return dto;
        }

        public async Task DeleteByIdPoints(long id)
        {
            var point = await _db.Points.FindAsync(id);

            if (point == null)
                throw new NotFoundApiException();

            _db.Points.Remove(point);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePoint(UpdatePoints model)
        {
            var point = await _db.Points.FindAsync(model.Id);

            if (point == null)
                throw new NotFoundApiException();

            _mapper.Map(model, point);            

            await _db.SaveChangesAsync();
        }
    }
}
