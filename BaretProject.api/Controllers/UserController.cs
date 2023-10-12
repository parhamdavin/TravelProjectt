using BaretProject.Application.DTOs.UserDTOs;
using BaretProject.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        #region filed
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        [HttpGet("FindById/{id}")]
        public async Task<IActionResult> FindById(int id)
        {

            var user = await _userService.SearchUserById(id);
            if (user is not null && user.IsDelete==false)
            {
                return Ok(user);
            }
            else { return NotFound(); }
                


        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] UserDTO userDTO)
        {
            if (userDTO.ID != 0)
            {
                return BadRequest();
            }
            var user = await _userService.RegisterUser(userDTO);
            return CreatedAtAction("FindById", new { Id = user.ID }, user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!_userService.UserIsExist(id))
            {
                return BadRequest();

            }
            await _userService.RemoveUser(id);
            return Ok("user is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm]UserDTO userDTO)
        {
            if (!_userService.UserIsExist(userDTO.ID))
            {
                return BadRequest();
            }
            var user = await _userService.UpdateUser(userDTO);
            return Ok(user);
        }
       
    }
}
