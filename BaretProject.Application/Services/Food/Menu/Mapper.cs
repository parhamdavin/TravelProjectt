using BaretProject.Application.DTOs.MenuDTOs;
using BaretProject.Core.Domain;

namespace BaretProject.Application.Services.Food.Menu
{
    public static class Mapper
    {
        //public static BaretProject.Core.Domain.Menu ToEntity(CreateMenuDTO CreateMenuDTO)
        //{
        //    return new Core.Domain.Menu()
        //    {               
        //        Kitchen.Id= CreateMenuDTO.kit
        //        MenuTitle = CreateMenuDTO.MenuTitle
        //    };
        //}

        public static MenuItemDTO MenuItemDTO(BaretProject.Core.Domain.Menu menu)
        {
            return new MenuItemDTO()
            {
                ID = menu.Id,
                IsRemoved = menu.IsRemoved,
                MenuTitle = menu.MenuTitle,
                Foods = menu.Foods.ToList(),
                FoodCount = menu.Foods.Count()
            };
        }


        public static MenuDTO ToMenuDTO(BaretProject.Core.Domain.Menu menu)
        {
            return new MenuDTO()
            {
                ID = menu.Id,
                MenuTitle = menu.MenuTitle
            };
        }
    }
}
