using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen_financial_InfoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Kitchen.Kitchen_financial_Info
{
    public interface IKitchen_financial_Info_Services
    {
        Task<IEnumerable<Kitchen_financial_Info_ItemDTO>> GetAll();
        Task<Kitchen_financial_Info_ItemDTO> GetById(int id);
        bool IExist(int id);
        Task<Kitchen_financial_InfoDTO> Rigester(Kitchen_financial_InfoDTO kitchen_Financial_InfoDTO);
        Task Remove(int id);
        Task<Kitchen_financial_InfoDTO> Update(Kitchen_financial_InfoDTO Kitchen_financial_InfoDTO);
    }
}
