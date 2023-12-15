using Hotel.API.Filters;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Services;
using Hotel.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerServiceWithDTO _customerService;

        public CustomerController(ICustomerServiceWithDTO customerServiceWithDTO)
        {
            _customerService = customerServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _customerService.GetAllAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomersWithRoom() => CreateActionResult(await _customerService.GetCustomersWithRoomAsync());

        [ServiceFilter(typeof(NotFoundFilter<Customer, NoContentDTO>))] //filter notfoundda content dönmediği için !!
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _customerService.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyCustomer(int id) => CreateActionResult(await _customerService.AnyAsync(x => x.Id == id));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer(CustomerCreateDTO request) => CreateActionResult(await _customerService.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeCustomer(IEnumerable<CustomerDTO> dtoList) => CreateActionResult(await _customerService.AddRangeAsync(dtoList));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateDTO request)
        {
            return CreateActionResult(await _customerService.UpdateAsync(request));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveCustomer(int id) => CreateActionResult(await _customerService.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeCustomer(IEnumerable<int> idList) => CreateActionResult(await _customerService.RemoveRangeAsync(idList));
    }
}