using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() {  return View(); }
    }
}
