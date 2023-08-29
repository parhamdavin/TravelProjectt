using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.KitchenDTOs.BusinessItemDTO;
using BaretProject.Application.DTOs.PermissionDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.BusinessTypeServices
{
    public class BusinessTypeService : IBusinessTypeService
    {
        #region filed
        private readonly IBusiness_TypeRepository _repository;
        public BusinessTypeService(IBusiness_TypeRepository business_TypeRepository)
        {
            _repository = business_TypeRepository;
        }

        public async Task<IEnumerable<BusinessItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(r => !r.IsRemoved).Select(business => new BusinessItemDTO
            {
                ID = business.Id,
                BTTitle = business.BTTitle,
                CreateON=business.InsertTime,
                UpdateON=business.UpdateTime

            }).ToListAsync();
            return list;
        }

        public async Task<BusinessItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<BusinessItemDTO>();
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

        public async Task<BusinessTypeDTO> Rigester(BusinessTypeDTO businessTypeDTO)
        {
            var entity = businessTypeDTO.ToEntity<BusinessType>();
            await _repository.AddAsync(entity);
            businessTypeDTO.ID = entity.Id;
            return businessTypeDTO;
        }

        public async Task<BusinessTypeDTO> Update(BusinessTypeDTO businessTypeDTO)
        {
            var entity = await _repository.FindByIdAsync(businessTypeDTO.ID);
            businessTypeDTO.ID = entity.Id;
            businessTypeDTO.BTTitle = entity.BTTitle;
            await _repository.UpdateAsync(entity);
            return businessTypeDTO;
        }
        #endregion
    }
}
