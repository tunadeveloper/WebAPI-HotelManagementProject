using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
