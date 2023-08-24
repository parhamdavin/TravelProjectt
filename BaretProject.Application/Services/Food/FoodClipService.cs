using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Food
{
    
    public class FoodClipService : IFoodClipService
    {
        #region Field
        private readonly IFoodClipRepository _repository;
        public FoodClipService(IFoodClipRepository repository)
        {
            _repository = repository;
        }
        #endregion
        public async Task<IEnumerable<FoodClipItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(p => !p.IsRemoved).Select(foodclip => new FoodClipItemDTO
            {
                ID = foodclip.Id,
                ClipTitle = foodclip.ClipTitle,
                CreateON = foodclip.InsertTime,
                UpdateON = foodclip.UpdateTime,
                TimeDuration = foodclip.TimeDuration,
                ClipFileName = foodclip.ClipFileName
                
            }).ToListAsync();
            return list;
        }

        public async Task<FoodClipItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<FoodClipItemDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var lis = _repository.FindByIdAsNoTracking(id);
            if (lis == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var list = await _repository.FindByIdAsync(id);
            list.IsRemoved = true;
            await _repository.UpdateAsync(list);

        }

        public async Task<FoodClipDTO> Rigester(FoodClipDTO foodClipDTO)
        {
            var entity = foodClipDTO.ToEntity<FoodClip>();
            await _repository.AddAsync(entity);
            foodClipDTO.ID = entity.Id;
            return foodClipDTO;
        }

        public async Task<FoodClipDTO> Update(FoodClipDTO foodClipDTO)
        {
            var foodclip = await _repository.FindByIdAsync(foodClipDTO.ID);
            foodclip.ClipTitle = foodClipDTO.ClipTitle;
            foodclip.ClipFileName = foodClipDTO.ClipFileName;
            foodclip.TimeDuration = foodClipDTO.TimeDuration;

            await _repository.UpdateAsync(foodclip);
            return foodClipDTO;
        }
    }
}
