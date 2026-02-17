using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.GetListBL();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertRoom(Room room)
        {
            _roomService.InsertBL(room);
            return Ok("Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteRoom(int roomId)
        {
            var values = _roomService.GetByIdBL(roomId);
            _roomService.DeleteBL(values);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _roomService.UpdateBL(room);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetRoom(int roomId)
        {
            var values = _roomService.GetByIdBL(roomId);
            return Ok(values);
        }
    }
}
