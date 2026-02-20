using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _HomeTestimonialSectionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _client;

        public _HomeTestimonialSectionComponentPartial(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
