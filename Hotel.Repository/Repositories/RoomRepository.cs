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
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        //genericRepository de _context protected tanımlandığı için burda erişip işlem yapabilcez . burada DBSEt belli yani Room
        //ama genericte blli değildi bu sebeple _context.Set<T>(); kullandık !!!!
        public RoomRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> GetRoomsWithFloorAsync()
        {
            return await _context.Rooms.Include(r => r.Floor).ToListAsync();
        }

        public async Task<Room> GetSingleRoomByIdWithBedsAsync(int roomId)
        {
            //gelen id hangi odanın id eşitse o odayı yataklarla gösteriyor.
            return await _context.Rooms.Include(x => x.Beds).Where(x => x.Id == roomId).SingleOrDefaultAsync();
        }

        public async Task<Room> GetSingleRoomByIdWithBedsAndCustomersAsync(int roomId)
        {
            //gelen id hangi odanın id eşitse o odayı yataklar ve müşterilerle gösteriyor.
            return await _context.Rooms.Include(x => x.Beds).Include(x => x.Customers).Where(x => x.Id == roomId).SingleOrDefaultAsync();
        }
    }
}