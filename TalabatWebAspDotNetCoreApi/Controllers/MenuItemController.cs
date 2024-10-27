using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalabatWebAspDotNetCoreApi.Data.ModelViews;
using TalabatWebAspDotNetCoreApi.Data.Repositories.MenuItemData;

namespace TalabatWebAspDotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IServiceMenuItem _serviceMenuItem;

        public MenuItemController(IServiceMenuItem serviceMenuItem)
        {
            _serviceMenuItem = serviceMenuItem;
        }

        [HttpGet("GetAllMenuItmes")]
        public async Task<IActionResult> GetAllMenuItem()
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceMenuItem.GetAll();
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceMenuItem.GetElement(id);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMenuItem(DtoMenuItem dtoMenuItem)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceMenuItem.Add(dtoMenuItem);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateMenuItem([FromRoute] int id, [FromBody] DtoMenuItem dtoMenuItem)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceMenuItem.Update(id, dtoMenuItem);
                if (!result.IsError)
                {
                    return Ok(result);
                }
                ModelState.AddModelError("Error", result.Message!);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteMenuItem([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ModelError result = await _serviceMenuItem.Delete(id);
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
