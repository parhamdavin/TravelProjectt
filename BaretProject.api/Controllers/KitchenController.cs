using BaretProject.Application.DTOs.Customer;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen;
using BaretProject.Application.Services.Kitchens.KitchenService;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Kitchen")]
    public class KitchenController: ControllerBase
    {
        private readonly IKitchenService _service;
        public KitchenController(IKitchenService service)
        {
            _service = service;
        }
        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var customer = await _service.GetById(id);
            if (customer is not null)
            {
                return Ok(customer);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] KitchenDTO kitchenDTO)
        {
            if (kitchenDTO.ID != 0)
            {
                return BadRequest();
            }
            var kitchen = await _service.Rigester(kitchenDTO);
            return CreatedAtAction("FindById", new { Id = kitchen.ID }, kitchen);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("kitchen is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] KitchenDTO kitchenDTO)
        {
            if (!_service.IExist(kitchenDTO.ID))
            {
                return BadRequest();
            }
            var kitchen = await _service.Update(kitchenDTO);
            return Ok(kitchen);
        }

    }
}
