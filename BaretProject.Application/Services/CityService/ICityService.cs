using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.City
{
    public interface ICityService
    {
        Task<IEnumerable<CityItemDTO>> GetAll();
        Task<CityItemDTO> GetById(int id);
        bool IExist(int id);
        Task<CityDTO> Rigester(CityDTO provinceDTO);
        Task Remove(int id);
        Task<CityDTO> Update(CityDTO provinceDTO);
    }
}
