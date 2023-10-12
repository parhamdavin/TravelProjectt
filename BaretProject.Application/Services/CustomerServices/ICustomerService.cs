using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(int id);
        bool IExist(int id);
        Task<CustomerDTO> Rigester(CustomerDTO customerDTO);
        Task Remove(int id);
        Task<CustomerDTO> Update(CustomerDTO customerDTO);
    }
}
