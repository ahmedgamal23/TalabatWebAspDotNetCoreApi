using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.OrderItemData;
using TalabatWebAspDotNetCoreApi.Data.Repositories.ReviewData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IServiceReview _serviceReview;

        public ReviewController(IServiceReview serviceReview)
        {
            _serviceReview = serviceReview;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllReviews()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceReview.GetAll();
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReview(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceReview.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return NotFound(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrderItem([FromBody] DtoReview dtoReview)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceReview.Add(dtoReview);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] int id, DtoReview dtoReview)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceReview.Update(id, dtoReview);
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
                ModelError result = await _serviceReview.Delete(id);
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
