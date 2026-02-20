using System.ComponentModel.DataAnnotations;

namespace HotelManagement.WebUILayer.Models.Booking
{
    public class BookingViewModel
    {
        [Display(Name = "Ad Soyad")]
        public string NameSurname { get; set; }

        [Display(Name = "E-posta")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Yetişkin Sayısı")]
        public int AdultCount { get; set; } = 1;

        [Display(Name = "Çocuk Sayısı")]
        public int ChildCount { get; set; } = 0;

        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CheckIn { get; set; }

        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CheckOut { get; set; }

        [Display(Name = "Oda Sayısı")]
        public int RoomCount { get; set; } = 1;

        [Display(Name = "Özel İstek")]
        public string SpecialRequest { get; set; }
    }
}
