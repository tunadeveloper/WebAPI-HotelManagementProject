using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
