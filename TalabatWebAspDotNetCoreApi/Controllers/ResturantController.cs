using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.Resturant;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly IServiceResturant _resturantService;

        public ResturantController(IServiceResturant resturantService)
        {
            _resturantService = resturantService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllResturant()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _resturantService.GetAll();
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetResturant(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _resturantService.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddResturant([FromBody] DtoResturant dtoResturant)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _resturantService.Add(dtoResturant);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, DtoResturant dtoResturant)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _resturantService.Update(id,dtoResturant);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _resturantService.Delete(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }
    }
}
