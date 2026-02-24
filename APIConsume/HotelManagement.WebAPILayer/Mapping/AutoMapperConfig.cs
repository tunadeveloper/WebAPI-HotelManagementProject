using AutoMapper;
using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.AppRoleDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ContactDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.HotelBookingKaggleDatasetDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.LoginDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;
using HotelManagement.DataTransferObjectLayer.DTOs.UserDTO;
using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using HotelManagement.EntityLayer.Concrete;

namespace HotelManagement.WebAPILayer.Mapping
{
    public class AutoMapperConfig : Profile
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
            CreateMap<UpdateUserDTO, AppUser>().ReverseMap();

            CreateMap<InsertAppRoleDTO, AppRole>().ReverseMap();
            CreateMap<UpdateAppRoleDTO, AppRole>().ReverseMap();
            CreateMap<ResultAppRoleDTO, AppRole>().ReverseMap();

            CreateMap<InsertWorkLocationDTO, WorkLocation>().ReverseMap();
            CreateMap<UpdateWorkLocationDTO, WorkLocation>().ReverseMap();
            CreateMap<ResultWorkLocationDTO, WorkLocation>().ReverseMap();

            CreateMap<HotelBookingKaggleDataset, ResultHotelBookingDTO>()
    .ForMember(d => d.Hotel, o => o.MapFrom(s => s.hotel))
    .ForMember(d => d.IsCanceled, o => o.MapFrom(s => s.is_canceled))
    .ForMember(d => d.LeadTime, o => o.MapFrom(s => s.lead_time))
    .ForMember(d => d.ArrivalYear, o => o.MapFrom(s => s.arrival_date_year))
    .ForMember(d => d.ArrivalMonth, o => o.MapFrom(s => s.arrival_date_month))
    .ForMember(d => d.WeekendNights, o => o.MapFrom(s => s.stays_in_weekend_nights))
    .ForMember(d => d.WeekNights, o => o.MapFrom(s => s.stays_in_week_nights))
    .ForMember(d => d.Adults, o => o.MapFrom(s => s.adults))
    .ForMember(d => d.Children, o => o.MapFrom(s => s.children))
    .ForMember(d => d.Babies, o => o.MapFrom(s => s.babies))
    .ForMember(d => d.Country, o => o.MapFrom(s => s.country))
    .ForMember(d => d.MarketSegment, o => o.MapFrom(s => s.market_segment))
    .ForMember(d => d.DistributionChannel, o => o.MapFrom(s => s.distribution_channel))
    .ForMember(d => d.IsRepeatedGuest, o => o.MapFrom(s => s.is_repeated_guest))
    .ForMember(d => d.PreviousCancellations, o => o.MapFrom(s => s.previous_cancellations))
    .ForMember(d => d.PreviousNotCanceled, o => o.MapFrom(s => s.previous_bookings_not_canceled))
    .ForMember(d => d.BookingChanges, o => o.MapFrom(s => s.booking_changes))
    .ForMember(d => d.DepositType, o => o.MapFrom(s => s.deposit_type))
    .ForMember(d => d.DaysInWaitingList, o => o.MapFrom(s => s.days_in_waiting_list))
    .ForMember(d => d.CustomerType, o => o.MapFrom(s => s.customer_type))
    .ForMember(d => d.ADR, o => o.MapFrom(s => s.adr))
    .ForMember(d => d.RequiredParkingSpaces, o => o.MapFrom(s => s.required_car_parking_spaces))
    .ForMember(d => d.TotalSpecialRequests, o => o.MapFrom(s => s.total_of_special_requests))
    .ForMember(d => d.ReservationStatus, o => o.MapFrom(s => s.reservation_status));
        }

    }
}
