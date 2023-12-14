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
        private readonly ICustomerServiceWithDTO _customerServiceWithDTO;

        public CustomerController(ICustomerServiceWithDTO customerServiceWithDTO)
        {
            _customerServiceWithDTO = customerServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _customerServiceWithDTO.GetAllAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomersWithRoom() => CreateActionResult(await _customerServiceWithDTO.GetCustomersWithRoomAsync());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomersWithPayment() => CreateActionResult(await _customerServiceWithDTO.GetCustomersWithPaymentAsync());

        [ServiceFilter(typeof(NotFoundFilter<Customer, NoContentDTO>))] //filter notfoundda content dönmediği için !!
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _customerServiceWithDTO.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCustomerPrice(int id) => CreateActionResult(await _customerServiceWithDTO.GetCustomersWithPaymentAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyCustomer(int id) => CreateActionResult(await _customerServiceWithDTO.AnyAsync(x => x.Id == id));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer(CustomerDTO request) => CreateActionResult(await _customerServiceWithDTO.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeCustomer(IEnumerable<CustomerDTO> dtoList) => CreateActionResult(await _customerServiceWithDTO.AddRangeAsync(dtoList));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO request) => CreateActionResult(await _customerServiceWithDTO.UpdateAsync(request));

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveCustomer(int id) => CreateActionResult(await _customerServiceWithDTO.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeCustomer(IEnumerable<int> idList) => CreateActionResult(await _customerServiceWithDTO.RemoveRangeAsync(idList));
    }
}