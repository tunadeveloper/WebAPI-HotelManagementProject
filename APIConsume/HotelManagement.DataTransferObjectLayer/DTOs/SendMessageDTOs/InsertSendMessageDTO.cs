namespace HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs
{
    public class InsertSendMessageDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
    }
}
