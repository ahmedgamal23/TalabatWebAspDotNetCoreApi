using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.DeliveryData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.ReviewData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IServiceDelivery _serviceDelivery;

        public DeliveryController(IServiceDelivery serviceDelivery)
        {
            _serviceDelivery = serviceDelivery;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDelivery()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceDelivery.GetAll();
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDelivery(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceDelivery.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddDeliveryItem([FromBody] DtoDelivery dtoDelivery)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceDelivery.Add(dtoDelivery);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateDeliveryItem([FromRoute] int id, DtoDelivery dtoDelivery)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceDelivery.Update(id, dtoDelivery);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteDeliveryItem([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceDelivery.Delete(id);
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
