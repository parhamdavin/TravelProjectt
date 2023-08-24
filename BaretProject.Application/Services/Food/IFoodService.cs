using BaretProject.Application.DTOs.FoodDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Food
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodItemDTO>> GetAll();
        Task<FoodItemDTO> GetById(int id);
        bool IExist(int id);
        Task<FoodDTO> Rigester(FoodDTO foodDTO);
        Task Remove(int id);
        Task<FoodDTO> Update(FoodDTO foodDTO);
    }
}
