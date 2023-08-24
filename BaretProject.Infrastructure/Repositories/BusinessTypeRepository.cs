using BaretProject.Application.Contracts;
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
    internal class BusinessTypeRepository: GenericRepository<BusinessType>,IBusiness_TypeRepository
    {
        public BusinessTypeRepository(IApplicationContext context):base(context)
        {
            
        }
    }
}
