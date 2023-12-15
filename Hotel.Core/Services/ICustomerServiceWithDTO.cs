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

        Task<CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>> GetCustomersWithRoomAsync();

        Task<CustomResponseDTO<decimal>> GetCustomerWithPriceAsync(int id);

        //generic serviste başka çalışıyo overload ettik aldığı parametre değişti.
        Task<CustomResponseDTO<CustomerDTO>> AddAsync(CustomerCreateDTO createDTO);

        Task<CustomResponseDTO<CustomerDTO>> UpdateAsync(CustomerUpdateDTO updateDTO);

        //   Task<CustomResponseDTO<PaymentDTO>> SetPaymentAsync(PaymentDTO paymentDTO, int customerId);
    }
}