using BaretProject.Application.Contracts;
using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.UserDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BaretProject.Application.Services.UserServices
{
    internal class UserService : IUserService
    {
        #region Fild
        private readonly IUserRepository _repositoryUser;
        
        public UserService(IUserRepository repositoryUser)
        {
            _repositoryUser = repositoryUser;
            
        }




        #endregion

        public async Task<IEnumerable<UserItemDTO>> GetAllUsers()
        {
            var list = _repositoryUser.TableAsNoTracking.Where(U => !U.IsRemoved).Select(U => new UserItemDTO()
            {
                ID = U.Id,
                Mobile = U.Mobile,
                Email = U.Email,
                CreateON = U.InsertTime,
                UpdateON = U.UpdateTime,


            }).ToList();
            return list;

        }

        public async Task<UserDTO> RegisterUser(UserDTO userDTO)
        {
            var user = userDTO.ToEntity<Userr>();
            await _repositoryUser.AddAsync(user);
            userDTO.ID = user.Id;

            return userDTO;
        }

        public async Task RemoveUser(int userId)
        {
            var user = await _repositoryUser.FindByIdAsync(userId);
            user.IsRemoved = true;
            await _repositoryUser.UpdateAsync(user);
        }

        public async Task<UserItemDTO> SearchUserById(int userId)
        {
            var user = await _repositoryUser.FindByIdAsync(userId);
            var UserDTO = user.ToDTO<UserItemDTO>();
            return UserDTO;
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var User = await _repositoryUser.FindByIdAsync(userDTO.ID);
           
            User.Id=userDTO.ID;
            User.Mobile = userDTO.Mobile;
            User.Email = userDTO.Email;
            User.ActiveCode= userDTO.ActiveCode;
            await _repositoryUser.UpdateAsync(User);
 
            return userDTO;
        }
        
        public bool UserIsExist(int userId)
        {
            var prod = _repositoryUser.FindByIdAsNoTracking(userId);
            if (prod == null ) return false;
            return true;

        }
    }
}
