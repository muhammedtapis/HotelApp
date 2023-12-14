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
    public class FloorRepository : GenericRepository<Floor>, IFloorRepository
    {
        public FloorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Floor>> GetFloorsWithHostelAsync()
        {
            return await _context.Floors.Include(x => x.Hostel).ToListAsync();
        }

        public async Task<Floor> GetSingleFloorByIdWithRoomsAsync(int floorId)
        {
            var a = await _context.Floors.Include(x => x.Rooms).ThenInclude(x => x.Customers).Where(x => x.Id == floorId).SingleOrDefaultAsync();
            return a;
        }
    }
}