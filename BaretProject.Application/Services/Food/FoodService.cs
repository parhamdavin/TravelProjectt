using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.FoodDTOs;
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
    public class FoodService : IFoodService
    {
        #region Filed
        private readonly IFoodRepository _repository;
        public FoodService(IFoodRepository foodRepository)
        {
            _repository = foodRepository;
        }

        #endregion
        public async Task<IEnumerable<FoodItemDTO>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(p => !p.IsRemoved).Select(food => new FoodItemDTO
            {
                ID = food.Id,
                Description=food.Description,
                CreateON = food.InsertTime,
                UpdateON = food.UpdateTime,
                PreparationTime = food.PreparationTime,
                Name = food.Name,
                ImageFileName=food.ImageFileName

            }).ToListAsync();
            return list;
        }

        public async Task<FoodItemDTO> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<FoodItemDTO>();
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

        public async Task<FoodDTO> Rigester(FoodDTO foodDTO)
        {
            var food = foodDTO.ToEntity<Core.Domain.Food>();
            await _repository.AddAsync(food);
            foodDTO.ID = food.Id;
            return foodDTO;
        }

        public async Task<FoodDTO> Update(FoodDTO foodDTO)
        {
            var food = await _repository.FindByIdAsync(foodDTO.ID);
            food.Description = foodDTO.Description;
            food.Name = foodDTO.Name;
            food.ImageFileName = foodDTO.ImageFileName;
            food.Id = foodDTO.ID;

            await _repository.UpdateAsync(food);
            return foodDTO;
        }

    }
}
