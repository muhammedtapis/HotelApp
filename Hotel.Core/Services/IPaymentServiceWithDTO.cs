using Hotel.Core.DTOs;
using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Services
{
    public interface IPaymentServiceWithDTO : IServiceWithDTO<Payment, PaymentDTO>
    {
        Task<CustomResponseDTO<PaymentWithCustomerDTO>> GetPaymentByIdWithCustomerAsync(int id);
    }
}