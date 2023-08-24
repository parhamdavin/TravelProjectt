using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;

namespace BaretProject.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(IApplicationContext context) : base(context)
        {
        }
    }
}
