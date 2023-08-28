using BaretProject.Application.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Rolese
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleItemDTO>> GetAll();
        Task<RoleItemDTO> GetById(int id);
        bool IExist(int id);
        Task<RoleDTO> Rigester(RoleDTO roleDTO);
        Task Remove(int id);
        Task<RoleDTO> Update(RoleDTO roleDTO);
    }
}
