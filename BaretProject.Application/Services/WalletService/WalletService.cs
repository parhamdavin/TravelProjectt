using BaretProject.Application.Contracts;
using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.UserDTOs;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.WalletService
{
    internal class WalletService : IWalletService
    {
        #region filed
        private readonly IWalletRepository _repositoryWallet;


        public WalletService(IWalletRepository repositoryWallet)
        {
            _repositoryWallet = repositoryWallet;
        }
        #endregion



        public async Task<WalletDto> RegisterWallet(WalletDto walletDto)
        {
            var wallet = walletDto.ToEntity<Wallet>();
            await _repositoryWallet.AddAsync(wallet);
            walletDto.ID = wallet.Id;

            return walletDto;
        }

        public async Task RemoveWallet(int Id)
        {
            var wallet = await _repositoryWallet.FindByIdAsync(Id);
            wallet.IsRemoved = true;
            await _repositoryWallet.UpdateAsync(wallet);
        }

        public async Task<WalletDto> SearchWalletById(int Id)
        {
            var wallet = await _repositoryWallet.FindByIdAsync(Id);
            var WalletDTO = wallet.ToDTO<WalletDto>();
            return WalletDTO;
        }

        public async Task<WalletDto> UpdateWallet(WalletDto walletDto)
        {
            var wallet = await _repositoryWallet.FindByIdAsync(walletDto.ID);
            wallet.IsPay = walletDto.IsPay;
            wallet.Amount = walletDto.Amount;
            wallet.Description = walletDto.Description;

            await _repositoryWallet.UpdateAsync(wallet);
            return walletDto;

        }

        public bool WalletIsExist(int Id)
        {
            var prod = _repositoryWallet.FindByIdAsNoTracking(Id);
            if (prod == null) return false;
            return true;

        }

        public async Task<IEnumerable<WalletDto>> GetAllWallets()
        {
            var list = _repositoryWallet.TableAsNoTracking.Where(W => !W.IsRemoved).Select(W => new WalletDto()
            {
                IsPay = W.IsPay,
                Amount = W.Amount,
                Description = W.Description,

            }).ToList();
            return list;
        }
    }
}
