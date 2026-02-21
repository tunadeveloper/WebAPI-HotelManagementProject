using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;

        public SendMessageController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var list = _sendMessageService.GetListBL();
            var values = _mapper.Map<List<ResultSendMessageDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertSendMessage(InsertSendMessageDTO dto)
        {
            var entity = _mapper.Map<SendMessage>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            _sendMessageService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var entity = _sendMessageService.GetByIdBL(id);
            _sendMessageService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateSendMessage(UpdateSendMessageDTO dto)
        {
            var entity = _mapper.Map<SendMessage>(dto);
            _sendMessageService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var entity = _sendMessageService.GetByIdBL(id);
            var value = _mapper.Map<ResultSendMessageDTO>(entity);
            return Ok(value);
        }
    }
}
