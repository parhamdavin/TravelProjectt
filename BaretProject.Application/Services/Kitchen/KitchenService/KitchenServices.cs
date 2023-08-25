using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Kitchens.KitchenService
{
    public class KitchenServices : IKitchenService
    {

        #region Filed
        private readonly IKitchenRepository _repository;
        public KitchenServices(IKitchenRepository repository)
        {
            _repository = repository;
        }
        #endregion
        public async Task<IEnumerable<KitchenItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(k => !k.IsRemoved).Select(kitchen => new KitchenItemDTO
            {
                KName = kitchen.KName,
                Adress = kitchen.Address,
                Phone = kitchen.Phone,
                ID = kitchen.Id,
                
            }).ToListAsync();
            return list;
        }

        public async Task<KitchenItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<KitchenItemDTO>();
            return dto;
        }

        public  bool IExist(int id)
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

        public async Task<KitchenDTO> Rigester(KitchenDTO kitchenDTO)
        {
            var entity = kitchenDTO.ToEntity <Kitchen>();
            await _repository.AddAsync(entity);
            kitchenDTO.ID = entity.Id;
            return kitchenDTO;
        }

        public async Task<KitchenDTO> Update(KitchenDTO kitchenDTO)
        {
            var entity = await _repository.FindByIdAsync(kitchenDTO.ID);
            entity.Id = kitchenDTO.ID;
            entity.KName = kitchenDTO.KName;
            entity.Address = kitchenDTO.Adress;
            entity.Phone = kitchenDTO.Phone;
            await _repository.UpdateAsync(entity);
            return kitchenDTO ;
        }
    }
}
