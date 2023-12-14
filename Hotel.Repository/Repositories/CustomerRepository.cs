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
    //_context GenericREpodan gelio
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithPaymentAsync()
        {
            return await _context.Customers.Include(x => x.Payment).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithRoomAsync()
        {
            return await _context.Customers.Include(x => x.Room).ToListAsync();
        }
    }
}