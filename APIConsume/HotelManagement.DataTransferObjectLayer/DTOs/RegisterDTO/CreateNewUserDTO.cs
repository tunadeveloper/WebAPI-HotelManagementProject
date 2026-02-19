using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataTransferObjectLayer.DTOs.RegisterDTO
{
    public class CreateNewUserDTO
    {
        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş bırakılamaz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçersiz email formatı.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı boş bırakılamaz.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
