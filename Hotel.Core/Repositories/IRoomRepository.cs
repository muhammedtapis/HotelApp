using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Repositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<List<Room>> GetRoomsWithFloorAsync();

        Task<Room> GetSingleRoomByIdWithBedsAsync(int roomId);
    }
}