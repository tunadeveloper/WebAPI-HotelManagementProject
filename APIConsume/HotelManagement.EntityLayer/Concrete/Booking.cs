namespace HotelManagement.EntityLayer.Concrete
{
    public class Booking : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int RoomCount { get; set; }
        public string? SpecialRequest { get; set; }
        public string Status { get; set; }
    }
}
