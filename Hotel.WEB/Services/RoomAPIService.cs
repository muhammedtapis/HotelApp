using Hotel.Core.DTOs;
using System.Net.Http;

namespace Hotel.WEB.Services
{
    public class RoomAPIService
    {
        //kullandığı url program.cs de belirlicez
        private readonly HttpClient _httpClient; //apiden istek atma için gerekli

        public RoomAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRoomsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<IEnumerable<RoomDTO>>>("room");
            return response.Data;
        }
    }
}