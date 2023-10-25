using ChineseSchool.Dto.Request;
using ChineseSchool.Dto.Response;
using ChineseSchool.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseSchool.Controllers
{
    [Route("api/interior")]
    [ApiController]
    [Authorize]
    public class InteriorController : ControllerBase
    {
        private readonly IInteriorService _interiorService;

        public InteriorController(IInteriorService interiorService)
        {
            _interiorService = interiorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InteriorResponse>>> GetAllInterior()
        {
            var interiorAll = await _interiorService.GetAllInterior();
            return Ok(interiorAll);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InteriorResponse>> GetInteriorById(long id)
        {
            try
            {
                var interior = await _interiorService.GetByIdInterior(id);

                return Ok(new InteriorResponse
                {
                    Id = interior.Id,
                    Name = interior.Name,
                    Description = interior.Description,
                    ImageInterior = interior.ImageInterior,
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InteriorResponse>> UpdateInterior(long id, [FromBody] InteriorsRequest request)
        {
            try
            {
                var interiorDto = await _interiorService.UpdateInterior(new UpdateInteriorModel
                {
                    Id=id,
                    Name = request.Name,
                    Description = request.Description,
                    ImageInterior = request.ImageInterior,
                });

                return Ok(new InteriorResponse
                {
                    Id = interiorDto.Id,
                    Name = interiorDto.Name,
                    Description = interiorDto.Description,
                    ImageInterior= interiorDto.ImageInterior
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<InteriorResponse>> PostInterior([FromBody] InteriorsRequest request)
        {
            var interior = await _interiorService.CreateInterior(new InteriorsRequest
            {
                Name = request.Name,
                Description = request.Description,
                ImageInterior = request.ImageInterior,
            });

            return CreatedAtAction(nameof(GetAllInterior), new InteriorResponse
            {
                Id = interior.Id,
                Name = interior.Name,
                Description = interior.Description,
                ImageInterior = interior.ImageInterior,
            });
        }

        [HttpDelete("{id}")]     
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteInterior([FromRoute] long id)
        {
            try
            {
                await _interiorService.DeleteByIdInterior(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
