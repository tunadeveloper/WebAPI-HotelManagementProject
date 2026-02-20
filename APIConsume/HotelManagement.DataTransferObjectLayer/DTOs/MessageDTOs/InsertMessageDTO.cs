namespace HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs
{
    public class InsertMessageDTO
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
    }
}
