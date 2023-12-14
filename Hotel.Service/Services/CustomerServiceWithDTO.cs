using AutoMapper;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Repositories;
using Hotel.Core.Services;
using Hotel.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Services
{
    public class CustomerServiceWithDTO : ServiceWithDTO<Customer, CustomerDTO>, ICustomerServiceWithDTO
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServiceWithDTO(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(repository, unitOfWork, mapper)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomResponseDTO<IEnumerable<CustomerWithPaymentDTO>>> GetCustomersWithPaymentAsync()
        {
            var customers = await _customerRepository.GetCustomersWithPaymentAsync();
            var customersWithPaymentDto = _mapper.Map<IEnumerable<CustomerWithPaymentDTO>>(customers);
            return CustomResponseDTO<IEnumerable<CustomerWithPaymentDTO>>.Success(StatusCodes.Status200OK, customersWithPaymentDto);
        }

        public async Task<CustomResponseDTO<decimal>> GetCustomerWithPriceAsync(int id)
        {
            var price = await CalculateAmountAsync(id);
            return CustomResponseDTO<decimal>.Success(StatusCodes.Status200OK, price);
        }

        public async Task<CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>> GetCustomersWithRoomAsync()
        {
            var customers = await _customerRepository.GetCustomersWithRoomAsync();
            var customersWithRoomDto = _mapper.Map<IEnumerable<CustomerWithRoomDTO>>(customers);
            return CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>.Success(StatusCodes.Status200OK, customersWithRoomDto);
        }

        public async Task<decimal> CalculateAmountAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            var roomPrice = customer.Room.Price;
            customer.CheckInDate = DateTime.UtcNow;
            customer.CheckOutDate = DateTime.UtcNow.AddDays(3);
            TimeSpan difference = customer.CheckOutDate - customer.CheckInDate;
            return (roomPrice * difference.Days);
        }

        //public async Task<CustomResponseDTO<PaymentDTO>> SetPaymentAsync(PaymentDTO paymentDTO, int customerId)
        //{
        //    //  var payment = _mapper.Map<Payment>(paymentDTO);
        //    //  await _customerRepository.AddAsync(paymentDTO);
        //}
    }
}