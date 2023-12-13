using Hotel.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers
{
    //bu alt satırı silince çalışmadı api halbuk basecontrollerdan geliyo ???
    //[Route("api/[controller]")]
    //[ApiController]
    public class RoomController : CustomBaseController
    {
        private readonly IRoomServiceWithDTO _roomServiceWithDTO;

        public RoomController(IRoomServiceWithDTO roomServiceWithDTO)
        {
            _roomServiceWithDTO = roomServiceWithDTO;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _roomServiceWithDTO.GetAllAsync());
        }
    }
}