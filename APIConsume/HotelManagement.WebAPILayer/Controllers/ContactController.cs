using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.ContactDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var list = _contactService.GetListBL();
            var values = _mapper.Map<List<ResultContactDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertContact(InsertContactDTO dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            _contactService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var entity = _contactService.GetByIdBL(id);
            _contactService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            _contactService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var entity = _contactService.GetByIdBL(id);
            var value = _mapper.Map<ResultContactDTO>(entity);
            return Ok(value);
        }
    }
}
