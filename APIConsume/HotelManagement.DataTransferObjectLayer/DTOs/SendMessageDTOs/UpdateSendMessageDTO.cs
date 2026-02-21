namespace HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs
{
    public class UpdateSendMessageDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
