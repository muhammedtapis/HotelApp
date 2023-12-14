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
        private readonly IFloorServiceWithDTO _floorServiceWithDTO;

        public FloorController(IFloorServiceWithDTO floorServiceWithDTO)
        {
            _floorServiceWithDTO = floorServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _floorServiceWithDTO.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _floorServiceWithDTO.GetByIdAsync(id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AnyFloor(int id) => CreateActionResult(await _floorServiceWithDTO.AnyAsync(x => x.Id == id));

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSingleFloorByIdWithRooms(int id) => CreateActionResult(await _floorServiceWithDTO.GetSingleFloorByIdWithRoomsAsync(id));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFloorsWithHostelAsync() => CreateActionResult(await _floorServiceWithDTO.GetFloorsWithHostelAsync());

        [HttpPost("[action]")]
        public async Task<IActionResult> AddFloor(FloorDTO request) => CreateActionResult(await _floorServiceWithDTO.AddAsync(request));

        [HttpPost("[action]")]
        public async Task<IActionResult> AddRangeFloor(IEnumerable<FloorDTO> dtoList) => CreateActionResult(await _floorServiceWithDTO.AddRangeAsync(dtoList));

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFloor(FloorDTO request) => CreateActionResult(await _floorServiceWithDTO.UpdateAsync(request));

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveFloor(int id) => CreateActionResult(await _floorServiceWithDTO.RemoveAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveRangeFloor(IEnumerable<int> idList) => CreateActionResult(await _floorServiceWithDTO.RemoveRangeAsync(idList));
    }
}