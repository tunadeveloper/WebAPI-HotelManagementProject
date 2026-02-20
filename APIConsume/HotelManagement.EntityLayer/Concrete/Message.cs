using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.EntityLayer.Concrete
{
    public class Message : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
