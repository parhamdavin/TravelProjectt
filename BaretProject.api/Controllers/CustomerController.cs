using BaretProject.Application.DTOs.CityDTOs;
using BaretProject.Application.DTOs.Customer;
using BaretProject.Application.Services.Citys;
using BaretProject.Application.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;

namespace BaretProject.api.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController:ControllerBase
    {
        #region filed
        private readonly ICustomerService  _service;
        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }

        #endregion

        [HttpGet("FindById/{id}")]
        
        public async Task<IActionResult> FindById(int id)
        {

            var customer = await _service.GetById(id);
            if (customer is not null )
            {
                return Ok(customer);
            }
            else { return NotFound(); }



        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CustomerDTO customerDTO)
        {
            //if (customerDTO.ID != 0)
            //{
            //    return BadRequest();
            //}
            var customer = await _service.Rigester(customerDTO);
            return CreatedAtAction("FindById", new { Id = customer.ID }, customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_service.IExist(id))
            {
                return BadRequest();

            }
            await _service.Remove(id);
            return Ok("Customer is delete");
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] CustomerDTO customerDTO)
        {
            if (!_service.IExist(customerDTO.ID))
            {
                return BadRequest();
            }
            var user = await _service.Update(customerDTO);
            return Ok(user);
        }
    }
}
