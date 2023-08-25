using BaretProject.Application.DTOs.FoodDTOs;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Kitchens.KitchenService
{
    public interface IKitchenService
    {
        Task<IEnumerable<KitchenItemDTO>> GetAll();
        Task<KitchenItemDTO> GetById(int id);
        bool IExist(int id);
        Task<KitchenDTO> Rigester(KitchenDTO kitchenDTO);
        Task Remove(int id);
        Task<KitchenDTO> Update(KitchenDTO kitchenDTO);
    }
}
