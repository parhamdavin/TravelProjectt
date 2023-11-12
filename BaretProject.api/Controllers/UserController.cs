using BaretProject.Application.DTOs.UserDTOs;
using BaretProject.Application.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        #region filed
        private readonly IUserService _userService;
        private readonly IDistributedCache _distributedCache;
        public UserController(IUserService userService, IDistributedCache distributedCache)
        {
            _userService = userService;
            _distributedCache = distributedCache;
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



        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {


            #region DistributedCach

            IEnumerable<UserItemDTO> _list;
            string Data = await _distributedCache.GetStringAsync("User");
            if (string.IsNullOrEmpty(Data))
            {
                _list = await _userService.GetAllUsers();
                if (_list.Count() != 0)
                {
                    Data = JsonConvert.SerializeObject(_list);
                }

                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                await _distributedCache.SetStringAsync("User", Data, option);
            }
            else
            {
                _list = JsonConvert.DeserializeObject<IEnumerable<UserItemDTO>>(Data);
            }


            #endregion

            

            return Ok();
        }
    }
}
