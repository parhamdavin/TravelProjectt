using BaretProject.Application.DTOs.Customer;
using BaretProject.Application.DTOs.RoleDTOs;
using BaretProject.Application.Services.CustomerServices;
using BaretProject.Application.Services.Rolese;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Role")]
    public class RoleController: ControllerBase
    {
        #region filed
        private readonly IRoleService _service;
        public RoleController(IRoleService roleService)
        {
            _service = roleService;
        }

        #endregion

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var role = await _service.GetById(id);
            if (role is not null)
            {
                return Ok(role);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] RoleDTO roleDTO)
        {
            if (roleDTO.ID != 0)
            {
                return BadRequest();
            }
            var role = await _service.Rigester(roleDTO);
            return CreatedAtAction("FindById", new { Id = role.ID }, role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("role is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] RoleDTO roleDTO)
        {
            if (!_service.IExist(roleDTO.ID))
            {
                return BadRequest();
            }
            var role = await _service.Update(roleDTO);
            return Ok(role);
        }
    }
}
