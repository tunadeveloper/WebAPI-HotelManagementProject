using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _ContactMessageFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new InsertMessageDTO());
        }
    }
}
