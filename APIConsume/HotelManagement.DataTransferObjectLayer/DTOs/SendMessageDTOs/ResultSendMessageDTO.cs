namespace HotelManagement.DataTransferObjectLayer.DTOs.SendMessageDTOs
{
    public class ResultSendMessageDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
