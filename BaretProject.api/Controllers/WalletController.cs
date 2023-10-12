using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.RoleDTOs;
using BaretProject.Application.Services.WalletService;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Wallet")]
    public class WalletController: ControllerBase
    {
        private readonly IWalletService _service;
        public WalletController(IWalletService service)
        {
            _service = service;

        }

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var role = await _service.SearchWalletById(id);
            if (role is not null)
            {
                return Ok(role);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] WalletDto walletDto)
        {
            if (walletDto.ID != 0)
            {
                return BadRequest();
            }
            var wallet = await _service.RegisterWallet(walletDto);
            return CreatedAtAction("FindById", new { Id = wallet.ID }, wallet);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.WalletIsExist(id))
            {
                return BadRequest();

            }
            await _service.RemoveWallet(id);
            return Ok("wallet is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] WalletDto walletDto)
        {
            if (!_service.WalletIsExist(walletDto.ID))
            {
                return BadRequest();
            }
            var role = await _service.UpdateWallet(walletDto);
            return Ok(role);
        }
    }
}
