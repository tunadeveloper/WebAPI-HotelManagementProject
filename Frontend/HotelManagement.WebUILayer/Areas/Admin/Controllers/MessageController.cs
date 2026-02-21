using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/Message/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Inbox", "Message", new { area = "Admin" });
            return RedirectToAction("Inbox", "Message", new { area = "Admin" });
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateMessage() => View();
        [HttpPost]
        public async Task<IActionResult> CreateMessage(InsertSendMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Message/", new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
        }
    }
}
