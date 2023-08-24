using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen_financial_InfoDTO;
using BaretProject.Application.DTOs.ProvinceDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Kitchen.Kitchen_financial_Info
{
    public class Kitchen_financial_Info_Services : IKitchen_financial_Info_Services
    {
        #region Filed
        private readonly IKitchen_financial_InfoRepository _kitchen_Financial_InfoRepository;
        public Kitchen_financial_Info_Services(IKitchen_financial_InfoRepository Kitchen_Financial_InfoRepository)
        {
            Kitchen_Financial_InfoRepository = _kitchen_Financial_InfoRepository;
        }
        #endregion
        public async Task<IEnumerable<Kitchen_financial_Info_ItemDTO>> GetAll()
        {
            var list = await _kitchen_Financial_InfoRepository.TableAsNoTracking.Where(p => !p.IsRemoved).Select(kitchenifn => new Kitchen_financial_Info_ItemDTO
            {
                BankName = kitchenifn.BankName,
                AccountNumber = kitchenifn.AccountNumber,
                CardNumber = kitchenifn.CardNumber,
                ShabaNumber = kitchenifn.ShabaNumber,
                CardFileName = kitchenifn.CardFileName,
                BusinessLicenseFileName = kitchenifn.BusinessLicenseFileName
            }).ToListAsync();
            return list;
        }

        public async Task<Kitchen_financial_Info_ItemDTO> GetById(int id)
        {
            var pro = await _kitchen_Financial_InfoRepository.FindByIdAsync(id);
            var dto = pro.ToDTO<Kitchen_financial_Info_ItemDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var lis = _kitchen_Financial_InfoRepository.FindByIdAsNoTracking(id);
            if (lis == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var list = await _kitchen_Financial_InfoRepository.FindByIdAsync(id);
            list.IsRemoved = true;
            await _kitchen_Financial_InfoRepository.UpdateAsync(list);
        }

        public async Task<Kitchen_financial_InfoDTO> Rigester(Kitchen_financial_InfoDTO kitchen_Financial_InfoDTO)
        {
            var entity = kitchen_Financial_InfoDTO.ToEntity<KitchenFinancialInfo>();
            await _kitchen_Financial_InfoRepository.AddAsync(entity);
            kitchen_Financial_InfoDTO.ID = entity.Id;
            return kitchen_Financial_InfoDTO;
        }

        public async Task<Kitchen_financial_InfoDTO> Update(Kitchen_financial_InfoDTO Kitchen_financial_InfoDTO)
        {
            var kitchenFN = await _kitchen_Financial_InfoRepository.FindByIdAsync(Kitchen_financial_InfoDTO.ID);
            kitchenFN.BankName = Kitchen_financial_InfoDTO.BankName;
            kitchenFN.AccountNumber = Kitchen_financial_InfoDTO.AccountNumber;
            kitchenFN.CardNumber = Kitchen_financial_InfoDTO.CardNumber;
            kitchenFN.CardFileName = Kitchen_financial_InfoDTO.CardFileName;
            kitchenFN.BusinessLicenseFileName = Kitchen_financial_InfoDTO.BusinessLicenseFileName;
            kitchenFN.ShabaNumber = Kitchen_financial_InfoDTO.ShabaNumber;

            await _kitchen_Financial_InfoRepository.UpdateAsync(kitchenFN);
            return Kitchen_financial_InfoDTO;
        }


    }
}
