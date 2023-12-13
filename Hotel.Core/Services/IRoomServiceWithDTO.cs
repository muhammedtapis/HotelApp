using Hotel.Core.DTOs;
using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Services
{
    //room özel servis metodları
    public interface IRoomServiceWithDTO : IServiceWithDTO<Room, RoomDTO>
    {
        Task<CustomResponseDTO<List<RoomWithFloorDTO>>> GetRoomsWithFloor();

        //ServiceControllerdaki update metodu ProductUpdateDTO alıyor ama bizim Iservicewithdto dan generic DTO gidiyor bunu düzeltmek için overload metod yazca
        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(RoomUpdateDTO updateDTO);

        //create-add için de overload ediyoruz. ikisinin deDTO ları farklı!
        Task<CustomResponseDTO<RoomDTO>> AddAsync(RoomCreateDTO createDTO);

        Task<CustomResponseDTO<IEnumerable<RoomDTO>>> AddRangeAsync(IEnumerable<RoomCreateDTO> roomCreateDtoList);
    }
}