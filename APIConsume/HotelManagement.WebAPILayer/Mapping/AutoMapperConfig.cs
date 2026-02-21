using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ContactDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.WebAPILayer.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<InsertRoomDTO, Room>().ReverseMap();
            CreateMap<UpdateRoomDTO, Room>().ReverseMap();
            CreateMap<ResultRoomDTO, Room>().ReverseMap();

            CreateMap<InsertTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDTO, Testimonial>().ReverseMap();

            CreateMap<InsertServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
            CreateMap<ResultServiceDTO, Service>().ReverseMap();

            CreateMap<InsertSubscribeDTO, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDTO, Subscribe>().ReverseMap();
            CreateMap<ResultSubscribeDTO, Subscribe>().ReverseMap();

            CreateMap<InsertAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDTO, About>().ReverseMap();
            CreateMap<ResultAboutDTO, About>().ReverseMap();

            CreateMap<InsertBookingDTO, Booking>().ReverseMap();
            CreateMap<UpdateBookingDTO, Booking>().ReverseMap();
            CreateMap<ResultBookingDTO, Booking>().ReverseMap();

            CreateMap<InsertContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();
            CreateMap<ResultContactDTO, Contact>().ReverseMap();

            CreateMap<InsertMessageDTO, Message>().ReverseMap();
            CreateMap<UpdateMessageDTO, Message>().ReverseMap();
            CreateMap<ResultMessageDTO, Message>().ReverseMap();

            CreateMap<InsertSendMessageDTO, SendMessage>().ReverseMap();
            CreateMap<UpdateSendMessageDTO, SendMessage>().ReverseMap();
            CreateMap<ResultSendMessageDTO, SendMessage>().ReverseMap();

            CreateMap<CreateNewUserDTO, AppUser>().ReverseMap();
            CreateMap<LoginUserDTO, AppUser>().ReverseMap();
            CreateMap<ResultUserDTO, AppUser>().ReverseMap();
        }
    }
}
