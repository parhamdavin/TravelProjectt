using BaretProject.Application.DTOs.Order;
using BaretProject.Application.DTOs.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Services.Order
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetailsDto>> GetAll();
        Task<OrderDetailsDto> GetById(int id);
        bool IExist(int id);
        Task<OrderDetailsDto> Rigester(OrderDetailsDto orderDetailsDto);
        Task Remove(int id);
        Task<OrderDetailsDto> Update(OrderDetailsDto orderDetailsDto);
    }
}
