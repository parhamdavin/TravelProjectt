using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.ProvinceDTOs;
using BaretProject.Application.Extention;
using BaretProject.Application.Services.Citys;
using BaretProject.Core.Domain;
using BaretProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.CityService
{
    public class CityService : ICityService
    {
        #region Filed
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository CityRepository)
        {
            _cityRepository = CityRepository;
        }
        #endregion
        public async Task<IEnumerable<CityItemDTO>> GetAll()
        {
            var lis = await _cityRepository.TableAsNoTracking.Where(p=>p.IsRemoved==false).Select(p=> new CityItemDTO
            {
                ID=p.Id,
                Name = p.Name,
                CreateON = p.InsertTime,
                UpdateON = p.UpdateTime,
                Localcreate = p.InsertTime.ToPersian(),
                LocalUpdate = p.InsertTime.ToPersian(),
                provinceName = p.Province.Name.ToString(),
              

            }).ToListAsync();
            return lis;
        }

        public async Task<CityItemDTO> GetById(int id)
        {
            var pro = await _cityRepository.FindByIdAsync(id);
            var dto = pro.ToDTO<CityItemDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var lis = _cityRepository.FindByIdAsNoTracking(id);
            if (lis == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var list = await _cityRepository.FindByIdAsync(id);
            list.IsRemoved = true;
            await _cityRepository.UpdateAsync(list);
        }

        public async Task<CityDTO> Rigester(CityDTO CityDTO)
        {
            var entity = CityDTO.ToEntity<City>();
            await _cityRepository.AddAsync(entity);
            CityDTO.ID = entity.Id;
          
            return CityDTO;
        }

        public async Task<CityDTO> Update(CityDTO CityDTO)
        {
            var province = await _cityRepository.FindByIdAsync(CityDTO.ID);
            province.Name = CityDTO.Name;
            await _cityRepository.UpdateAsync(province);
            return CityDTO;
        }
    }
}
