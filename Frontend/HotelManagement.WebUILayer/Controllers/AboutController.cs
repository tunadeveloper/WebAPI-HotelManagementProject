using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HotelManagement.WebUILayer.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
