using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Food
{
    public interface IFoodClipService
    {
        Task<IEnumerable<FoodClipItemDTO>> GetAll();
        Task<FoodClipItemDTO> GetById(int id);
        bool IExist(int id);
        Task<FoodClipDTO> Rigester(FoodClipDTO provinceDTO);
        Task Remove(int id);
        Task<FoodClipDTO> Update(FoodClipDTO provinceDTO);
    }
}
