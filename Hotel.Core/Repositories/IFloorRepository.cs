using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Repositories
{
    public interface IFloorRepository : IGenericRepository<Floor>
    {
        Task<List<Floor>> GetFloorsWithHostelAsync();

        Task<Floor> GetSingleFloorByIdWithRoomsAsync(int floorId);
    }
}