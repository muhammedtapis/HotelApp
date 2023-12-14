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
    public class PaymentServiceWithDTO : ServiceWithDTO<Payment, PaymentDTO>, IPaymentServiceWithDTO
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentServiceWithDTO(IGenericRepository<Payment> repository, IUnitOfWork unitOfWork, IMapper mapper, IPaymentRepository paymentRepository) : base(repository, unitOfWork, mapper)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<CustomResponseDTO<PaymentWithCustomerDTO>> GetPaymentByIdWithCustomerAsync(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdWithCustomerAsync(id);
            var paymentDto = _mapper.Map<PaymentWithCustomerDTO>(payment);
            return CustomResponseDTO<PaymentWithCustomerDTO>.Success(StatusCodes.Status200OK, paymentDto);
        }
    }
}