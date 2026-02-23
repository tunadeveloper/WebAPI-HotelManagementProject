using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var responseMessage = await client.GetAsync("http://localhost:5191/api/About");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
            var lastItem = list.LastOrDefault();
            return View(lastItem);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateAboutDTO dto)
        {
            var client = _httpClientFactory.CreateClient("apiClient");
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5191/api/About", content);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
