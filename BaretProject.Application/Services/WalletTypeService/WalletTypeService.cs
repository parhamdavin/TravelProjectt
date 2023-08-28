using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.WalletType;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.WalletTypeService
{
    public class WalletTypeService:IWalletTypeService
    {
        #region filed
        private readonly IWalletTypeRepository _repository;
        public WalletTypeService(IWalletTypeRepository walletTypeRepository)
        {
            _repository = walletTypeRepository;

        }

        public async Task<IEnumerable<WalletTypeDto>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(W => !W.IsRemoved).Select(W => new WalletTypeDto()
            {
                Title = W.Title

            }).ToListAsync();
            return list;
        }

        public async Task<WalletTypeDto> GetById(int id)
        {
            var wallet = await _repository.FindByIdAsync(id);
            var WalletDTO = wallet.ToDTO<WalletTypeDto>();
            return WalletDTO;
        }

        public bool IExist(int id)
        {
            var prod = _repository.FindByIdAsNoTracking(id);
            if (prod == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var wallettype = await _repository.FindByIdAsync(id);
            wallettype.IsRemoved = true;
            await _repository.UpdateAsync(wallettype);
        }

        public async Task<WalletTypeDto> Rigester(WalletTypeDto walletTypeDto)
        {
            var wallettype = walletTypeDto.ToEntity<WalletType>();
            await _repository.AddAsync(wallettype);
            walletTypeDto.ID = wallettype.Id;

            return walletTypeDto;
        }

        public async Task<WalletTypeDto> Update(WalletTypeDto walletTypeDto)
        {
            var wallettype = await _repository.FindByIdAsync(walletTypeDto.ID);
            wallettype.Title = walletTypeDto.Title;
            await _repository.UpdateAsync(wallettype);
            return walletTypeDto;
        }
        #endregion

    }
}
