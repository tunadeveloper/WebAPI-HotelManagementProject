using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

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

        public async Task<IActionResult> Inbox(int? page)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/Message");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData) ?? new List<ResultMessageDTO>();
                int pageNumber = page ?? 1;
                return View(new PagedList<ResultMessageDTO>(values, pageNumber, 8));
            }
            return View(new PagedList<ResultMessageDTO>(new List<ResultMessageDTO>(), 1, 8));
        }

        public async Task<IActionResult> DeleteInboxMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/Message/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Inbox", "Message", new { area = "Admin" });
            return RedirectToAction("Inbox", "Message", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteSendboxMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5191/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
            return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
        }

        public async Task<IActionResult> Sendbox(int? page)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5191/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendMessageDTO>>(jsonData) ?? new List<ResultSendMessageDTO>();
                int pageNumber = page ?? 1;
                return View(new PagedList<ResultSendMessageDTO>(values, pageNumber, 8));
            }
            return View(new PagedList<ResultSendMessageDTO>(new List<ResultSendMessageDTO>(), 1, 8));
        }

        public IActionResult CreateMessage() => View(new InsertSendMessageDTO());
        [HttpPost]
        public async Task<IActionResult> CreateMessage(InsertSendMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var responseMessage = await client.PostAsync("http://localhost:5191/api/SendMessage/", new StringContent(jsonData, Encoding.UTF8, "application/json"));
            return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
        }
    }
}
