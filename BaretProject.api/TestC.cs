using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.Services.City;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api
{
    public class TestC : ControllerBase
    {
        private readonly ICityService _service;
        public TestC(ICityService cityService)
        {
            _service = cityService;
        }
        [HttpPost]
        public async Task<IActionResult> Register( CityDTO cityDTO)
        {
            #region Version 1.0

            //var category = categoryDto.Adapt<Category>();
            //Category category = new Category();
            //category.Name = categoryDto.Name;
            //category.ParentID = categoryDto.ParentID;

            #endregion



            if (cityDTO.ID != 0)
                return BadRequest();

            var category = await _service.Rigester(cityDTO);

            return CreatedAtAction("FindById", new { Id = category.ID }, category);

        }
    }
}
