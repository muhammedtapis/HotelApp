using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Repositories
{
    public interface IBedRepository : IGenericRepository<Bed>
    {
        Task<IEnumerable<Bed>> GetBedsWithRoom();

        Task<IEnumerable<Product>> GetSingleBedByIdWithCustomer();
    }
}