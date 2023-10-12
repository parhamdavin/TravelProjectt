using BaretProject.Application.DTOs.PermissionDTOs;
using BaretProject.Application.DTOs.RoleDTOs;
using BaretProject.Application.Services.Permissions;
using BaretProject.Application.Services.Rolese;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Permission")]
    public class PermissionController:ControllerBase
    {
        #region filed
        private readonly IPermissionService _service;
        public PermissionController(IPermissionService permissionService)
        {
            _service = permissionService;
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
        public async Task<IActionResult> Add([FromForm] PermissionDTO permissionDTO)
        {
            if (permissionDTO.ID != 0)
            {
                return BadRequest();
            }
            var permission = await _service.Rigester(permissionDTO);
            return CreatedAtAction("FindById", new { Id = permission.ID }, permission);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("permission is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] PermissionDTO permissionDTO)
        {
            if (!_service.IExist(permissionDTO.ID))
            {
                return BadRequest();
            }
            var permission = await _service.Update(permissionDTO);
            return Ok(permission);
        }
    }
}
