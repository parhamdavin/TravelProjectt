using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.Order;
using BaretProject.Application.Extention;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        #region Filed
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }
        #endregion
        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var list = await _repository.TableAsNoTracking.Where(o => !o.IsRemoved).Select(order => new OrderDto
            {
                ID = order.Id,
                IsFinally = order.IsFinally,
                CustomerId = order.Customer.Id,
                OrderStatus = order.OrderStatus,
                OrderStatusId = order.OrderStatusId,
                IsRemoved = order.IsRemoved,
               

            }).ToListAsync();
            return list;
        }

        public async Task<OrderDto> GetById(int id)
        {
            var pro = await _repository.FindByIdAsync(id);
            var dto = pro.ToDTO<OrderDto>();
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

        public async Task<OrderDto> Rigester(OrderDto orderDto)
        {
            var entity = orderDto.ToEntity<Order>();
            await _repository.AddAsync(entity);
            orderDto.ID = entity.Id;
            return orderDto;
        }

        public async Task<OrderDto> Update(OrderDto orderDto)
        {
            var entity = await _repository.FindByIdAsync(orderDto.ID);
            entity.Id = orderDto.ID;
            entity.IsFinally = orderDto.IsFinally;
            entity.OrderStatus = orderDto.OrderStatus;
            entity.OrderStatusId = orderDto.OrderStatusId;
            entity.Customer.Id = entity.Customer.Id;
            return orderDto;
        }
    }
}
