namespace HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
