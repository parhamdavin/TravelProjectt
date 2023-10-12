using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.Order;
using BaretProject.Application.DTOs.OrderDetail;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Order
{
    public class OrderDetailsService: IOrderDetailsService
    {
        #region Filed
        private readonly IOrderDetailsRepository _repository;
        public OrderDetailsService(IOrderDetailsRepository orderDetails)
        {
            _repository = orderDetails;
        }
        #endregion
        public async Task<IEnumerable<OrderDetailsDto>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(o => !o.IsRemoved).Select(orderDetails => new OrderDetailsDto
            {
                ID = orderDetails.Id,
                Count = orderDetails.Count,
                Price = orderDetails.Price,
                
                IsRemoved = orderDetails.IsRemoved,


            }).ToListAsync();
            return list;
        }

        public async Task<OrderDetailsDto> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<OrderDetailsDto>();
            return dto;
        }

        public bool IExist(int id)
        {
            var pro = _repository.FindByIdAsNoTracking(id);
            if (pro is not null)
                return false;
            return true;
        }

        public async Task Remove(int id)
        {
            var entity = await _repository.FindByIdAsync(id);
            entity.IsRemoved = true;
            _repository.UpdateAsync(entity);

        }

        public async Task<OrderDetailsDto> Rigester(OrderDetailsDto orderDetailsDto)
        {
            var entity = orderDetailsDto.ToEntity<OrderDetails>();
            await _repository.AddAsync(entity);
            orderDetailsDto.ID = entity.Id;
            return orderDetailsDto;
        }

        public async Task<OrderDetailsDto> Update(OrderDetailsDto orderDetailsDto)
        {
            var entity = await _repository.FindByIdAsync(orderDetailsDto.ID);
            entity.Id = orderDetailsDto.ID;
            entity.Price = orderDetailsDto.Price;
            entity.Count = orderDetailsDto.Count;
            return orderDetailsDto;
        }
    }
}
