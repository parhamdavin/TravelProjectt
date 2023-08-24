using BaretProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.WalletService
{
    public interface IWalletService
    {
        Task<IEnumerable<WalletDto>> GetAllWallets();
        Task<WalletDto> SearchWalletById(int Id);
        Task<WalletDto> RegisterWallet(WalletDto walletDto);
        bool WalletIsExist(int Id);
        Task RemoveWallet(int Id);
        Task<WalletDto> UpdateWallet(WalletDto walletDto);

    }
}
