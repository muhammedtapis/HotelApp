using Hotel.Core.Models;
using Hotel.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Payment> GetPaymentByIdWithCustomerAsync(int paymentId)
        {
            return await _context.Payments.Include(x => x.Customer).Where(x => x.Id == paymentId).FirstOrDefaultAsync();
        }
    }
}