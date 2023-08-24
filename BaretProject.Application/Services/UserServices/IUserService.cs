using BaretProject.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserItemDTO>> GetAllUsers();
        Task<UserItemDTO> SearchUserById(int Id);
        Task<UserDTO> RegisterUser(UserDTO userDTO);
        bool UserIsExist(int Id);
        Task RemoveUser(int Id);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
    
 
    }
}
