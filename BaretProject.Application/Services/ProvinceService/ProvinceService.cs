using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.ProvinceDTOs;
using BaretProject.Application.Services;
using BaretProject.Application.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaretProject.Core.Domain;
using BaretProject.Domain;

namespace BaretProject.Application.Services.ProvinceService
{ 
    public class ProvinceService : IProvinceService
    {
        #region Filed
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository ProvinceRepository)
        {
            _provinceRepository = ProvinceRepository;
        }
        #endregion
        public async Task<IEnumerable<ProvinceItemDTO>> GetAll()
        {
            var list = await _provinceRepository.TableAsNoTracking.Where(p => !p.IsRemoved).Select(province => new ProvinceItemDTO{
                Name = province.Name,
                CreateON = province.InsertTime,
                UpdateON = province.UpdateTime,
                LocalCreate = province.InsertTime.ToPersian(),
                LocalUpdate = province.UpdateTime.ToPersian(),
                Citys = province.Citys.Select(c => c.Name).ToList(),
                CityIds = province.Citys.Select(c => c.Id).ToList(),
            }).ToListAsync();
            return list;
           
        }

        public async Task<ProvinceItemDTO> GetById(int id)
        {
            var pro = await _provinceRepository.FindByIdAsync(id);
            var dto = pro.ToDTO<ProvinceItemDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var lis = _provinceRepository.FindByIdAsNoTracking(id);
            if (lis == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var list = await _provinceRepository.FindByIdAsync(id);
            list.IsRemoved = true;
            await _provinceRepository.UpdateAsync(list);
            
        }

        public async Task<ProvinceDTO> Rigester(ProvinceDTO provinceDTO)
        {
            var entity = provinceDTO.ToEntity<Province>();
            await _provinceRepository.AddAsync(entity);
            provinceDTO.ID = entity.Id;
            return provinceDTO;
        }

        public async Task<ProvinceDTO> Update(ProvinceDTO provinceDTO)
        {
            var province = await _provinceRepository.FindByIdAsync(provinceDTO.ID);
            province.Name = provinceDTO.Name;
            await _provinceRepository.UpdateAsync(province);
            return provinceDTO;
        }
    }
}
