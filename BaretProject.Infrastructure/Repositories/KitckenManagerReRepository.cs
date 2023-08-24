using BaretProject.Application.Contracts.IRepositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;

namespace BaretProject.Infrastructure.Repositories
{
    public class KitckenManagerReRepository : GenericRepository<KitchenManagerRe>, IKitckenManagerReRepository
    {
        public KitckenManagerReRepository(IApplicationContext context) : base(context)
        {
        }
    }
}
