using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using HotelManagement.WebUILayer.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(InsertBookingDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5191/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View();
        }
    }
}
