using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
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
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var list = _roomService.GetListBL();
            var values = _mapper.Map<List<ResultRoomDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertRoom(InsertRoomDTO dto)
        {
            var values = _mapper.Map<Room>(dto);
            _roomService.InsertBL(values);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var values = _roomService.GetByIdBL(id);
            _roomService.DeleteBL(values);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDTO dto)
        {
            var values = _mapper.Map<Room>(dto);
            _roomService.UpdateBL(values);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var values = _roomService.GetByIdBL(id);
            return Ok(values);
        }
    }
}
