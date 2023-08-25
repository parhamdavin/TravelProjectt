using BaretProject.Application.DTOs;
using BaretProject.Application.DTOs.KitchenDTOs.Kitchen;
using BaretProject.Application.DTOs.Order;
using BaretProject.Application.DTOs.ProvinceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAll();
        Task<OrderDto> GetById(int id);
        bool IExist(int id);
        Task<OrderDto> Rigester(OrderDto orderDto);
        Task Remove(int id);
        Task<OrderDto> Update(OrderDto orderDto);
    }
}
