using HotelManagement.EntityLayer.Concrete;
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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı boş bırakılamaz.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        public int WorkLocationId { get; set; }
    }
}
