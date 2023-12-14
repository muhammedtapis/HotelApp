using Hotel.Core.DTOs;
using Hotel.Core.Services;
using Hotel.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    public class RoomController : CustomBaseController
    {
        private readonly IRoomServiceWithDTO _roomServiceWithDTO;

        public RoomController(IRoomServiceWithDTO roomServiceWithDTO)
        {
            _roomServiceWithDTO = roomServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _roomServiceWithDTO.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _roomServiceWithDTO.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyRoom(int id) => CreateActionResult(await _roomServiceWithDTO.AnyAsync(x => x.Id == id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleRoomByIdWithCustomers(int id) => CreateActionResult(await _roomServiceWithDTO.GetSingleRoomByIdWithCustomersAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoomsWithFloor() => CreateActionResult(await _roomServiceWithDTO.GetRoomsWithFloor());

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRoom(RoomCreateDTO request) => CreateActionResult(await _roomServiceWithDTO.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeRoom(IEnumerable<RoomCreateDTO> request) => CreateActionResult(await _roomServiceWithDTO.AddRangeAsync(request));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateDTO request) => CreateActionResult(await _roomServiceWithDTO.UpdateAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRoom(int id) => CreateActionResult(await _roomServiceWithDTO.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeRoom(IEnumerable<int> idList) => CreateActionResult(await _roomServiceWithDTO.RemoveRangeAsync(idList));
    }
}