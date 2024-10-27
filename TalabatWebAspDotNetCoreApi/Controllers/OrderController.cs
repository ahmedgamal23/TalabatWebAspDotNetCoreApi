using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceData<DtoOrder> _serviceOrder;

        public OrderController(IServiceData<DtoOrder> serviceOrder)
        {
            _serviceOrder = serviceOrder;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrder(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrder.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrder([FromBody] DtoOrder dtoOrder)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrder.Add(dtoOrder);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, DtoOrder dtoOrder)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrder.Update(id, dtoOrder);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrder.Delete(id);
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
