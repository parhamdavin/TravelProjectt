using BaretProject.Application.Contracts.IRepositories;
using BaretProject.Application.DTOs.KitchenDTOs.KitckenManagerReDTO;


namespace BaretProject.Application.Services.Kitchens.KitchenManagerReService
{
    public class KitckenManagerReService : IKitchenManagerReService
    {
        
        private readonly IKitckenManagerReRepository _kitckenManagerReRepository;
        public KitckenManagerReService(IKitckenManagerReRepository kitckenManagerReRepository)
        {
            _kitckenManagerReRepository = kitckenManagerReRepository;
        }


        public async Task AddKitchenManagerRe(KitckenManagerReDTO KitckenManagerReDTO)
        {
            var KitckenManagerRe = Mapper.ToEntity(KitckenManagerReDTO);
            await _kitckenManagerReRepository.AddAsync(KitckenManagerRe);
        }

        public async Task RemoveKitchenManagerRe(KitckenManagerReDTO KitckenManagerReDTO)
        {
            var KitckenManagerRe = Mapper.ToEntity(KitckenManagerReDTO);
            await _kitckenManagerReRepository.DeleteAsync(KitckenManagerRe);
        }
    }
}
