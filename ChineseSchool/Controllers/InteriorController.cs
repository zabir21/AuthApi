using AutoMapper;
using ChineseSchool.Dto.Request;
using ChineseSchool.Dto.Response;
using ChineseSchool.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSchool.Controllers
{
    [Route("api/interior")]
    [ApiController]
    //[Authorize]
    public class InteriorController : ControllerBase
    {
        private readonly IInteriorRepository _interiorRep;
        private readonly IMapper _mapper;

        public InteriorController(IInteriorRepository interiorRep, IMapper mapper)
        {
            _interiorRep = interiorRep;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllInterior()
        {
            var interiorAll = await _interiorRep.GetAllInterior();
            return Ok(interiorAll);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInteriorById(long id)
        {
            var interior = await _interiorRep.GetByIdInterior(id);

            var response = _mapper.Map<InteriorResponse>(interior);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInterior([FromBody] UpdateInteriorRequest request)
        {
            var dto = _mapper.Map<UpdateInteriorDto>(request);

            await _interiorRep.UpdateInterior(dto);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostInterior([FromBody] InteriorsRequest request)
        {
            var interior = await _interiorRep.CreateInterior(request);

            var response = _mapper.Map<InteriorResponse>(interior);

            return CreatedAtAction(nameof(GetAllInterior), response);
        }

        [HttpDelete("{id}")]     
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteInterior(long id)
        {
            await _interiorRep.DeleteByIdInterior(id);

            return Ok();
        }
    }
}
