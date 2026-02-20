using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.ViewComponents
{
    public class _UserLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new InsertSubscribeDTO());
        }
    }
}
