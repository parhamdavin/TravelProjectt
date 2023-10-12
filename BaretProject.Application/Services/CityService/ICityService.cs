using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Citys
{
    public interface ICityService
    {
        Task<IEnumerable<CityItemDTO>> GetAll();
        Task<CityItemDTO> GetById(int id);
        bool IExist(int id);
        Task<CityDTO> Rigester(CityDTO cityDTO);
        Task Remove(int id);
        Task<CityDTO> Update(CityDTO cityDTO);
    }
}
