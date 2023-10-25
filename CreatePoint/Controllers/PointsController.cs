using AutoMapper;
using CreatePoint.Dto.Request;
using CreatePoint.Dto.Response;
using CreatePoint.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<PointsResponse>>> GetAllPoints()
        {
            var pointAll = await _pointsRep.GetAllPoints();

            return Ok(pointAll);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PointsResponse>> GetInteriorById(long id)
        {
            try
            {
                var point = await _pointsRep.GetByIdPoint(id);
                var dto = _mapper.Map<PointsResponse>(point);

                return Ok(dto);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PointsResponse>> UpdatePoint(long id, [FromBody] PointsRequest request)
        {
            try
            {
                var point = await _pointsRep.UpdatePoint(new UpdatePoints
                {
                    Id = id,
                    UserName = request.UserName,
                    QuantityPoint = request.QuantityPoint,
                });               

                var dto = _mapper.Map<PointsResponse>(point);

                return Ok(dto);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<PointsResponse>> PostPoint([FromBody] PointsRequest request)
        {
            //var point = await _pointsRep.CreatePoints(new PointsRequest
            //{
            //    UserName = request.UserName,
            //    QuantityPoint = request.QuantityPoint
            //});

            var point = await _pointsRep.CreatePoints(_mapper.Map<PointsRequest>(request));

            var dto = _mapper.Map<PointsResponse>(point);

            return CreatedAtAction(nameof(GetAllPoints), dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePoint([FromRoute] long id)
        {
            try
            {
                await _pointsRep.DeleteByIdPoints(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
