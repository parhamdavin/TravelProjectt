using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.Order;
using BaretProject.Application.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Order")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var order = await _service.GetById(id);
            if (order is not null)
            {
                return Ok(order);
            }
            else { return NotFound(); }


            
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] OrderDto orderDto)
        {
            if (orderDto.ID != 0)
            {
                return BadRequest();
            }
            var order = await _service.Rigester(orderDto);
            return CreatedAtAction("FindById", new { Id = order.ID }, order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("order is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] OrderDto orderDto)
        {
            if (!_service.IExist(orderDto.ID))
            {
                return BadRequest();
            }
            var order = await _service.Update(orderDto);
            return Ok(orderDto);
        }
    }
}
