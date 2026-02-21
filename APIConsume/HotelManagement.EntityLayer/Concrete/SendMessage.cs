namespace HotelManagement.EntityLayer.Concrete
{
    public class SendMessage : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
