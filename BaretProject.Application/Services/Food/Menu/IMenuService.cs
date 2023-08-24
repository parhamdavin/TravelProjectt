using BaretProject.Application.DTOs.MenuDTOs;

namespace BaretProject.Application.Services.Food.Menu
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItemDTO>> GetAllMenu();
        Task<MenuItemDTO> GetById(int Id);
        Task<long> Add(CreateMenuDTO CreateMenuDTO);
        Task Remove(int Id);
        bool IsExists(int Id);
    }
}
