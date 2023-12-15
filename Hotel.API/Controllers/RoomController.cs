using Hotel.Core.DTOs;
using Hotel.Core.Services;
using Hotel.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    public class RoomController : CustomBaseController
    {
        private readonly IRoomServiceWithDTO _roomService;

        public RoomController(IRoomServiceWithDTO roomServiceWithDTO)
        {
            _roomService = roomServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _roomService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _roomService.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyRoom(int id) => CreateActionResult(await _roomService.AnyAsync(x => x.Id == id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleRoomByIdWithCustomers(int id) => CreateActionResult(await _roomService.GetSingleRoomByIdWithCustomersAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoomsWithFloor() => CreateActionResult(await _roomService.GetRoomsWithFloor());

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRoom(RoomCreateDTO request) => CreateActionResult(await _roomService.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeRoom(IEnumerable<RoomCreateDTO> request) => CreateActionResult(await _roomService.AddRangeAsync(request));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateDTO request) => CreateActionResult(await _roomService.UpdateAsync(request));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRoom(int id) => CreateActionResult(await _roomService.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeRoom(IEnumerable<int> idList) => CreateActionResult(await _roomService.RemoveRangeAsync(idList));
    }
}