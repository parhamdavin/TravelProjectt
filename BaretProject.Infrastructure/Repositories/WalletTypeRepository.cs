using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;

namespace BaretProject.Infrastructure.Repositories
{
    internal class WalletTypeRepository : GenericRepository<WalletType>, IWalletTypeRepository
    {
        public WalletTypeRepository(IApplicationContext context) : base(context)
        {
        }
    }
}
