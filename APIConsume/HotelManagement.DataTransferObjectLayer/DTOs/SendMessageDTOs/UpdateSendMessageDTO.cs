namespace HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs
{
    public class UpdateSendMessageDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
