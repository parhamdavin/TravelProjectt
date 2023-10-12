using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.WalletType;
using BaretProject.Application.Services.WalletTypeService;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("WalletType")]
    public class WalletTypeController: ControllerBase
    {
        private readonly IWalletTypeService _service;
        public WalletTypeController(IWalletTypeService sevice)
        {
            _service = sevice;
        }

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var wallettype = await _service.GetById(id);
            if (wallettype is not null)
            {
                return Ok(wallettype);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] WalletTypeDto walletTypeDto)
        {
            if (walletTypeDto.ID != 0)
            {
                return BadRequest();
            }
            var walletType = await _service.Rigester(walletTypeDto);
            return CreatedAtAction("FindById", new { Id = walletType.ID }, walletType);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("wallettype is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] WalletTypeDto walletTypeDto)
        {
            if (!_service.IExist(walletTypeDto.ID))
            {
                return BadRequest();
            }
            var walletType = await _service.Update(walletTypeDto);
            return Ok(walletType);
        }


    }
}
