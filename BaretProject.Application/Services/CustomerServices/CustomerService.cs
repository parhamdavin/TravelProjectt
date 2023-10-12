using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.Customer;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.CustomerServices
{
    public class CustomerService:ICustomerService
    {
        #region Filed
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var lis = await _customerRepository.TableAsNoTracking.Where(p => p.IsRemoved == false).Select(p => new CustomerDTO
            {
                Address = p.Address,
                Family = p.Family,
                Name = p.Name,
                WalletBalance = p.WalletBalance,
                ID = p.Id,
               
               

            }).ToListAsync();
            return lis;
        }

        public async Task<CustomerDTO> GetById(int id)
        {
            var pro = await _customerRepository.FindByIdAsync(id);
            var dto = pro.ToDTO<CustomerDTO>();
            return dto;
        }

        public bool IExist(int id)
        {
            var lis = _customerRepository.FindByIdAsNoTracking(id);
            if (lis == null) return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var list = await _customerRepository.FindByIdAsync(id);
            list.IsRemoved = true;
            await _customerRepository.UpdateAsync(list);
        }

        public async Task<CustomerDTO> Rigester(CustomerDTO customerDTO)
        {
            var entity = customerDTO.ToEntity<Customers>();
            await _customerRepository.AddAsync(entity);
            customerDTO.ID = entity.Id;
            return customerDTO;
        }

        public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
        {
            var customer = await _customerRepository.FindByIdAsync(customerDTO.ID);
            customer.Name = customerDTO.Name;
            customer.Address = customerDTO.Address;
            customer.Family= customerDTO.Family;
            customer.WalletBalance = customerDTO.WalletBalance;
            
            await _customerRepository.UpdateAsync(customer);
            return customerDTO;
        }
    }
}
