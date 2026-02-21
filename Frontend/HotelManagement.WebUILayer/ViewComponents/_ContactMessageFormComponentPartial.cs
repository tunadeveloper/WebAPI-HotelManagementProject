using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _ContactMessageFormComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(InsertMessageDTO model = null)
        {
            return View(model ?? new InsertMessageDTO());
        }
    }
}
