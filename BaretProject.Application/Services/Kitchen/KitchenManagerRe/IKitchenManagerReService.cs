using BaretProject.Application.DTOs.KitchenDTOs.KitckenManagerReDTO;

namespace BaretProject.Application.Services.Kitchen.KitchenManagerReService
{
    public interface IKitchenManagerReService 
    {
        Task AddKitchenManagerRe(KitckenManagerReDTO createKitckenManagerReDTO);
        Task RemoveKitchenManagerRe(KitckenManagerReDTO KitckenManagerReDTO);
    }
}
