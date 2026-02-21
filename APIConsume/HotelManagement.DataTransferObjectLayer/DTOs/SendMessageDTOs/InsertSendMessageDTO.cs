namespace HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs
{
    public class InsertSendMessageDTO
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
    }
}
