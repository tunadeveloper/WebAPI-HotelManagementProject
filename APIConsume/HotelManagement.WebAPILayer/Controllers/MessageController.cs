using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var list = _messageService.GetListBL();
            var values = _mapper.Map<List<ResultMessageDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertMessage(InsertMessageDTO dto)
        {
            var entity = _mapper.Map<Message>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            _messageService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var entity = _messageService.GetByIdBL(id);
            _messageService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO dto)
        {
            var entity = _mapper.Map<Message>(dto);
            _messageService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var entity = _messageService.GetByIdBL(id);
            var value = _mapper.Map<ResultMessageDTO>(entity);
            return Ok(value);
        }
    }
}
