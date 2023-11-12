using BaretProject.Application.DTOs.Order;
using BaretProject.Application.DTOs.OrderDetail;
using BaretProject.Application.Services.Orderees;
using BaretProject.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    public class OrderDetailsController: ControllerBase
    {
        private readonly IOrderDetailsService _service;
        public OrderDetailsController(IOrderDetailsService service)
        {
            _service = service;
        }
        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var orderDetails = await _service.GetById(id);
            if (orderDetails is not null)
            {
                return Ok(orderDetails);
            }
            else { return NotFound(); }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] OrderDetailsDto orderDetailsDto)
        {
            if (orderDetailsDto.ID != 0)
            {
                return BadRequest();
            }
            var orderDetails = await _service.Rigester(orderDetailsDto);
            return CreatedAtAction("FindById", new { Id = orderDetails.ID }, orderDetails);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("orderDetails is delete");
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] OrderDetailsDto orderDetailsDto)
        {
            if (!_service.IExist(orderDetailsDto.ID))
            {
                return BadRequest();
            }
            var orderDetails = await _service.Update(orderDetailsDto);
            return Ok(orderDetails);
        }
    }
}
