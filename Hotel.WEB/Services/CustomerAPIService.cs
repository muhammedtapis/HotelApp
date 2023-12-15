using Hotel.Core.DTOs;

namespace Hotel.WEB.Services
{
    public class CustomerAPIService
    {
        private readonly HttpClient _httpClient;

        public CustomerAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //bu metod apiden gelen json okuyor apideki metodun dönüş tipini GetFromJsonAsync<içinde vermemiz lazım> sonra hangi controllerın hangi actionuna gidio onu ver
        public async Task<IEnumerable<CustomerWithRoomDTO>> GetCustomersWithRoom()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>>("customer/GetCustomersWithRoom"); //customer controllerdaki action metoduna
            return response.Data;
        }

        public async Task<CustomerCreateDTO> SaveAsync(CustomerCreateDTO customerCreateDTO) //burdaki parametre de bize web controllrerdaki Save metodundan gelicek orda çağırcaz index sayfasından
        {
            //postaskson async deikinc, parametre Customer Apı controllerdaki save post metodu bizden hangşi parametreyi istiyosa onu vercez
            var response = await _httpClient.PostAsJsonAsync("customer/AddCustomer", customerCreateDTO);
            if (!response.IsSuccessStatusCode) return null;  //eğer statuscode false ise null dön

            //fALSE DEĞİLSE artık bu responsun bodysini almamız lazım bize döndüğü değer  CustomREsponseDto<ProductDTO>> bunu okuycaz.
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CustomerCreateDTO>>();

            return responseBody.Data;  //daha sonra bu responsebody datasını dönyoruz
        }
    }
}