using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.PermissionDTOs;
using BaretProject.Application.DTOs.RoleDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        #region filed
        private readonly IPermissionRepository _repository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _repository = permissionRepository;
        }
        #endregion
        public async Task<IEnumerable<PermissionItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(r => !r.IsRemoved).Select(permission => new PermissionItemDTO
            {
                ID = permission.Id,
                PermissionTitle=permission.PermissionTitle,
                CreateON = permission.InsertTime,
                UpdateON = permission.UpdateTime

            }).ToListAsync();
            return list;
        }

        public async Task<PermissionItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<PermissionItemDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var pro = _repository.FindByIdAsNoTracking(id);
            if (pro is not null)
                return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            pro.IsRemoved = true;
            await _repository.UpdateAsync(pro);
        }

        public async Task<PermissionDTO> Rigester(PermissionDTO permissionDTO)
        {
            var entity = permissionDTO.ToEntity<Permission>();
            await _repository.AddAsync(entity);
            permissionDTO.ID = entity.Id;
            return permissionDTO;
        }

        public async Task<PermissionDTO> Update(PermissionDTO permissionDTO)
        {
            var entity = await _repository.FindByIdAsync(permissionDTO.ID);
            permissionDTO.ID = entity.Id;
            permissionDTO.PermissionTitle = entity.PermissionTitle;
            await _repository.UpdateAsync(entity);
            return permissionDTO;
        }
    }
}
