using BaretProject.Application.DTOs.Customer;
using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.Services.Food;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("food")]
    public class FoodController: ControllerBase
    {
        private readonly IFoodService _service;
        public FoodController(IFoodService service)
        {
            _service = service;
        }
        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var food = await _service.GetById(id);
            if (food is not null)
            {
                return Ok(food);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] FoodDTO foodDTO)
        {
            if (foodDTO.ID != 0)
            {
                return BadRequest();
            }
            var food = await _service.Rigester(foodDTO);
            return CreatedAtAction("FindById", new { Id = food.ID }, food);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("food is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] FoodDTO foodDTO)
        {
            if (!_service.IExist(foodDTO.ID))
            {
                return BadRequest();
            }
            var food = await _service.Update(foodDTO);
            return Ok(food);
        }
    }
}
