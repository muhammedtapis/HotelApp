using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Services
{
    //customer ozel srvis metodları
    public interface ICustomerServiceWithDTO : IServiceWithDTO<Customer, CustomerDTO>
    {
        Task<CustomResponseDTO<CustomerWithPaymentDTO>> GetCustomerWithPaymentAsync(int customerId);
    }
}