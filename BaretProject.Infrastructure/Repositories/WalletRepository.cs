using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;

namespace BaretProject.Infrastructure.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(IApplicationContext context) : base(context)
        {
        }
    }
}
