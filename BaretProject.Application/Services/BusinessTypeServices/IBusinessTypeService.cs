using BaretProject.Application.DTOs.KitchenDTOs.BusinessItemDTO;
using BaretProject.Application.DTOs.PermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.BusinessTypeServices
{
    public interface IBusinessTypeService
    {
        Task<IEnumerable<BusinessItemDTO>> GetAll();
        Task<BusinessItemDTO> GetById(int id);
        bool IExist(int id);
        Task<BusinessTypeDTO> Rigester(BusinessTypeDTO businessTypeDTO);
        Task Remove(int id);
        Task<BusinessTypeDTO> Update(BusinessTypeDTO businessTypeDTO);
    }
}
