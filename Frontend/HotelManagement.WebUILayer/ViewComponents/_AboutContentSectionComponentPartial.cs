using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _AboutContentSectionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutContentSectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
                return View(values.FirstOrDefault());
            }
            return View();
        }
    }
}
