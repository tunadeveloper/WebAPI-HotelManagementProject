namespace HotelManagement.EntityLayer.Concrete
{
    public class SendMessage : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
