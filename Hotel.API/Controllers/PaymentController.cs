using Hotel.Core.Services;
using Hotel.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        private readonly IPaymentServiceWithDTO _paymentService;

        public PaymentController(IPaymentServiceWithDTO paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _paymentService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPaymentWithCustomer(int id) => CreateActionResult(await _paymentService.GetPaymentByIdWithCustomerAsync(id));
    }
}