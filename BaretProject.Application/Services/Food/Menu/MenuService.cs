using BaretProject.Application.Contracts.Repositories;
using BaretProject.Application.DTOs.MenuDTOs;
using Microsoft.EntityFrameworkCore;

namespace BaretProject.Application.Services.Food.Menu
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }


        //public async Task<long> Add(CreateMenuDTO CreateMenuDTO)
        //{
        //    var menu = Mapper.ToEntity(CreateMenuDTO);
        //    await _menuRepository.AddAsync(menu);

        //    return menu.Id;
        //}


        public async Task<IEnumerable<MenuItemDTO>> GetAllMenu()
        {
            var list = await _menuRepository.Table.Select(menu => Mapper.MenuItemDTO(menu)).ToListAsync();
            return list;
        }


        public async Task<MenuItemDTO> GetById(int Id)
        {
            var menu = await _menuRepository.FindByIdAsync(Id);
            var MenuItemDTO = Mapper.MenuItemDTO(menu);
            return MenuItemDTO;
        }


        public bool IsExists(int Id)
        {
            var menu = _menuRepository.FindByIdAsNoTracking(Id);
            if (menu == null)
                return false;
            return true;
        }


        public async Task Remove(int Id)
        {
            var category = await _menuRepository.FindByIdAsync(Id);
            await _menuRepository.DeleteAsync(category);
        }

    }
}
