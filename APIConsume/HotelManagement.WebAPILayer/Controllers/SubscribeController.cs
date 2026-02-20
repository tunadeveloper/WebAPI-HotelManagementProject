using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var list = _subscribeService.GetListBL();
            var values = _mapper.Map<List<ResultSubscribeDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertSubscribe(InsertSubscribeDTO dto)
        {
            var entity = _mapper.Map<Subscribe>(dto);
            _subscribeService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete]
        public IActionResult DeleteSubscribe(int subscribeId)
        {
            var entity = _subscribeService.GetByIdBL(subscribeId);
            _subscribeService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDTO dto)
        {
            var entity = _mapper.Map<Subscribe>(dto);
            _subscribeService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("GetById")]
        public IActionResult GetSubscribe(int subscribeId)
        {
            var entity = _subscribeService.GetByIdBL(subscribeId);
            var value = _mapper.Map<ResultSubscribeDTO>(entity);
            return Ok(value);
        }
    }
}
