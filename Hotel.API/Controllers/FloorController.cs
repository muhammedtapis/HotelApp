using Hotel.Core.DTOs;
using Hotel.Core.Services;
using Hotel.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class FloorController : CustomBaseController
    {
        private readonly IFloorServiceWithDTO _floorService;

        public FloorController(IFloorServiceWithDTO floorServiceWithDTO)
        {
            _floorService = floorServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _floorService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _floorService.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyFloor(int id) => CreateActionResult(await _floorService.AnyAsync(x => x.Id == id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleFloorByIdWithRooms(int id) => CreateActionResult(await _floorService.GetSingleFloorByIdWithRoomsAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFloorsWithHostelAsync() => CreateActionResult(await _floorService.GetFloorsWithHostelAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> AddFloor(FloorDTO request) => CreateActionResult(await _floorService.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeFloor(IEnumerable<FloorDTO> dtoList) => CreateActionResult(await _floorService.AddRangeAsync(dtoList));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFloor(FloorDTO request) => CreateActionResult(await _floorService.UpdateAsync(request));

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveFloor(int id) => CreateActionResult(await _floorService.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeFloor(IEnumerable<int> idList) => CreateActionResult(await _floorService.RemoveRangeAsync(idList));
    }
}