using BaretProject.Application.DTOs.KitchenDTOs.KitckenManagerReDTO;
using BaretProject.Core.Domain;

namespace BaretProject.Application.Services.Kitchen.KitchenManagerReService
{
    public static class Mapper
    {
        public static KitchenManagerRe ToEntity(KitckenManagerReDTO KitckenManagerReDTO)
        {
            return new KitchenManagerRe
            {
                KitchenId = KitckenManagerReDTO.KitchenId,
                ManagerId = KitckenManagerReDTO.ManagerId
            };

        }
    }
}
