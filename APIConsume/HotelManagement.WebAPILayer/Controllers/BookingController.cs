using AutoMapper;
using HotelManagement.BusinessLayer.Abstract;
using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using HotelManagement.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var list = _bookingService.GetListBL();
            var values = _mapper.Map<List<ResultBookingDTO>>(list);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertBooking(InsertBookingDTO dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            entity.Status = "Beklemede";
            _bookingService.InsertBL(entity);
            return Ok("Eklendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var entity = _bookingService.GetByIdBL(id);
            _bookingService.DeleteBL(entity);
            return Ok("Silindi!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDTO dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            _bookingService.UpdateBL(entity);
            return Ok("Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var entity = _bookingService.GetByIdBL(id);
            var value = _mapper.Map<ResultBookingDTO>(entity);
            return Ok(value);
        }
    }
}
