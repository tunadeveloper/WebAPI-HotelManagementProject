using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _HomeFacilitiesSectionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _client;

        public _HomeFacilitiesSectionComponentPartial(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client.CreateClient();
            var responseMessege = await client.GetAsync("http://localhost:5191/api/Service");
            if (responseMessege.IsSuccessStatusCode)
            {
                var jsonData = await responseMessege.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
