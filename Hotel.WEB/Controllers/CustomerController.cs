using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.WEB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.WEB.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerAPIService _customerAPIService;
        private readonly RoomAPIService _roomAPIService;

        public CustomerController(CustomerAPIService customerAPIService, RoomAPIService roomAPIService)
        {
            _customerAPIService = customerAPIService;
            _roomAPIService = roomAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _customerAPIService.GetCustomersWithRoom();
            return View(response.ToList());
        }

        public async Task<IActionResult> Save()
        {
            //kayıt için odaları listeliyoruz ki kullanıcı seçsin.
            var roomsDto = await _roomAPIService.GetAllRoomsAsync();
            ViewBag.Rooms = new SelectList(roomsDto, "Id", "RoomNo");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerCreateDTO customerCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await _customerAPIService.SaveAsync(customerCreateDTO);
                return RedirectToAction(nameof(Index));
            }
            var roomsDTO = await _roomAPIService.GetAllRoomsAsync();
            ViewBag.Rooms = new SelectList(roomsDTO, "Id", "RoomNo"); //dropdown listte arka planda id tutulcak kullanıcı ise name görcek

            return View();
        }

    }
}