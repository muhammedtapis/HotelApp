using Hotel.Core.DTOs;
using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Services
{
    public interface IFloorServiceWithDTO : IServiceWithDTO<Floor, FloorDTO>
    {
        Task<CustomResponseDTO<FloorWithRoomsDTO>> GetSingleFloorByIdWithRoomsAsync(int floorId);

        Task<CustomResponseDTO<IEnumerable<FloorWithHostelDTO>>> GetFloorsWithHostelAsync();
    }
}