using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Infrastructure.Repositories
{
    internal class Kitchen_financial_InfoRepository: GenericRepository<KitchenFinancialInfo>,IKitchen_financial_InfoRepository
    {
        public Kitchen_financial_InfoRepository(IApplicationContext context):base(context)
        {
            
        }
    }
}
