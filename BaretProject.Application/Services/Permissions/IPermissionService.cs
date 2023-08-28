using BaretProject.Application.DTOs.PermissionDTOs;
using BaretProject.Application.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Permissions
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionItemDTO>> GetAll();
        Task<PermissionItemDTO> GetById(int id);
        bool IExist(int id);
        Task<PermissionDTO> Rigester(PermissionDTO permissionDTO);
        Task Remove(int id);
        Task<PermissionDTO> Update(PermissionDTO permissionDTO);
    }
}
