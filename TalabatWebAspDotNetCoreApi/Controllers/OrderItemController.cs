using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IServiceOrderItem _serviceOrderItem;

        public OrderItemController(IServiceOrderItem serviceOrderItem)
        {
            _serviceOrderItem = serviceOrderItem;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrderItem()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrderItem.GetAll();
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderItem(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrderItem.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderItem([FromBody] DtoOrderItem dtoOrderItem)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrderItem.Add(dtoOrderItem);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] int id, DtoOrderItem dtoOrderItem)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrderItem.Update(id, dtoOrderItem);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceOrderItem.Delete(id);
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
