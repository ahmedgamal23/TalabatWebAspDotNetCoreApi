using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IServicePayment _servicePayment;

        public PaymentController(IServicePayment servicePayment)
        {
            _servicePayment = servicePayment;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrderItem()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _servicePayment.GetAll();
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
                ModelError result = await _servicePayment.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderItem([FromBody] DtoPayment dtoPayment)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _servicePayment.Add(dtoPayment);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] int id, DtoPayment dtoPayment)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _servicePayment.Update(id, dtoPayment);
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
                ModelError result = await _servicePayment.Delete(id);
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
