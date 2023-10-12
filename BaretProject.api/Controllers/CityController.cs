using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.UserDTOs;
using BaretProject.Application.Services.Citys;
using BaretProject.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("City")]
    public class CityController: ControllerBase
    {
        #region filed
        private readonly ICityService _service;
        public CityController(ICityService cityService)
        {
            _service = cityService;
        }

        #endregion

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var city = await _service.GetById(id);
            if (city is not null && city.IsRemoved == false)
            {
                return Ok(city);
            }
            else { return NotFound(); }



        }
        [HttpPost] 
        public async Task<IActionResult> AddCity([FromForm] CityDTO cityDTO)
        {
            if (cityDTO.ID != 0)
            {
                return BadRequest();
            }
            var city = await _service.Rigester(cityDTO);
            return CreatedAtAction("FindById", new { Id = city.ID }, city);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("user is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] CityDTO cityDTO)
        {
            if (!_service.IExist(cityDTO.ID))
            {
                return BadRequest();
            }
            var user = await _service.Update(cityDTO);
            return Ok(user);
        }
    }
}
