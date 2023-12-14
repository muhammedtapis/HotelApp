using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Services
{
    //customer ozel srvis metodları
    public interface ICustomerServiceWithDTO : IServiceWithDTO<Customer, CustomerDTO>
    {
        //servisin customer response dönmesi gerek ki controllerda business kod olmasın
        Task<CustomResponseDTO<IEnumerable<CustomerWithPaymentDTO>>> GetCustomersWithPaymentAsync();

        Task<CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>> GetCustomersWithRoomAsync();

        Task<CustomResponseDTO<decimal>> GetCustomerWithPriceAsync(int id);

        //   Task<CustomResponseDTO<PaymentDTO>> SetPaymentAsync(PaymentDTO paymentDTO, int customerId);
    }
}