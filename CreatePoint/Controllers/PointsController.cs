using AutoMapper;
using CreatePoint.Dto.Request;
using CreatePoint.Dto.Response;
using CreatePoint.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CreatePoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        private readonly IPointsRepository _pointsRep;
        private readonly IMapper _mapper;


        public PointsController(IPointsRepository pointsRepository, IMapper mapper)
        {
            _pointsRep = pointsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPoints()
        {
            var pointAll = await _pointsRep.GetAllPoints();

            return Ok(pointAll);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInteriorById(long id)
        {
            var point = await _pointsRep.GetByIdPoint(id);
            var dto = _mapper.Map<PointsResponse>(point);

            return Ok(dto);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePoints([FromBody] UpdatePointsRequest request)
        {
            var points = _mapper.Map<UpdatePoints>(request);
            await _pointsRep.UpdatePoint(points);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostPoint([FromBody] PointsRequest request)
        {
            var point = await _pointsRep.CreatePoints(request);

            var dto = _mapper.Map<PointsResponse>(point);

            return CreatedAtAction(nameof(GetAllPoints), dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePoint(long id)
        {
            await _pointsRep.DeleteByIdPoints(id);
            return Ok();   
        }
    }
}
