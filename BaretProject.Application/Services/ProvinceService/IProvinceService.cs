using BaretProject.Application.DTOs.ProvinceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.ProvinceService
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceItemDTO>> GetAll();
        Task<ProvinceItemDTO> GetById(int id);
        bool IExist(int id);
        Task<ProvinceDTO> Rigester(ProvinceDTO provinceDTO);
        Task Remove(int id);
        Task<ProvinceDTO> Update(ProvinceDTO provinceDTO);
    }
}
