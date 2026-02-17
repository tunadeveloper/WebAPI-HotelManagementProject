using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.GetListBL();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertSubscribe(Subscribe subscribe)
        {
            _subscribeService.InsertBL(subscribe);
            return Ok("Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int subscribeId)
        {
            var values = _subscribeService.GetByIdBL(subscribeId);
            _subscribeService.DeleteBL(values);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.UpdateBL(subscribe);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetSubscribe(int subscribeId)
        {
            var values = _subscribeService.GetByIdBL(subscribeId);
            return Ok(values);
        }
    }
}
