using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.PermissionDTOs;
using BaretProject.Application.DTOs.WalletType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.WalletTypeService
{
    public interface IWalletTypeService
    {
        Task<IEnumerable<WalletTypeDto>> GetAll();
        Task<WalletTypeDto> GetById(int id);
        bool IExist(int id);
        Task<WalletTypeDto> Rigester(WalletTypeDto walletTypeDto);
        Task Remove(int id);
        Task<WalletTypeDto> Update(WalletTypeDto walletTypeDto);
    }
}
