using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using BaretProject.Application.Services.ProvinceService;
using BaretProject.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Province")]
    public class ProvinceController: ControllerBase
    {
        private readonly IProvinceService _service;
        public ProvinceController(IProvinceService service)
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
        public async Task<IActionResult> Add([FromForm] ProvinceDTO provinceDTO)
        {
            if (provinceDTO.ID != 0)
            {
                return BadRequest();
            }
            var province = await _service.Rigester(provinceDTO);
            return CreatedAtAction("FindById", new { Id = province.ID }, province);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("province is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] ProvinceDTO provinceDTO)
        {
            if (!_service.IExist(provinceDTO.ID))
            {
                return BadRequest();
            }
            var province = await _service.Update(provinceDTO);
            return Ok(province);
        }
    }
}
