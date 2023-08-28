using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen;
using BaretProject.Application.DTOs.RoleDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Rolese
{
    public class RoleService : IRoleService
    {
        #region filed
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository roleRepository)
        {
            _repository = roleRepository;
        }
        #endregion
        public async Task<IEnumerable<RoleItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(r => !r.IsRemoved).Select(role => new RoleItemDTO 
            {
               ID=role.Id,
               Role=role.Role,
               CreateON=role.InsertTime,
               UpdateON=role.UpdateTime,

            }).ToListAsync();
            return list;
        }

        public async Task<RoleItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<RoleItemDTO>();
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

        public async Task<RoleDTO> Rigester(RoleDTO roleDTO)
        {
            var entity = roleDTO.ToEntity <Roles>();
            await _repository.AddAsync(entity);
            roleDTO.ID = entity.Id;
            return roleDTO;
        }

        public async Task<RoleDTO> Update(RoleDTO roleDTO)
        {
            var entity = await _repository.FindByIdAsync(roleDTO.ID);
            roleDTO.ID = entity.Id;
            roleDTO.Role = entity.Role;
            roleDTO.IsDelete = entity.IsRemoved;
            await _repository.UpdateAsync(entity);
            return roleDTO ;
        }
    }
}
