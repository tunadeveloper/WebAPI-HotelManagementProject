using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.BookingDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.BookingDTOs
{
    public class UpdateBookingValidator : AbstractValidator<UpdateBookingDTO>
    {
        public UpdateBookingValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir kayıt numarası gerekir.");

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(x => x.NameSurname).MaximumLength(200).WithMessage("Ad soyad en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");

            RuleFor(x => x.CheckIn).NotEmpty().WithMessage("Giriş tarihi boş geçilemez.");
            RuleFor(x => x.CheckOut).NotEmpty().WithMessage("Çıkış tarihi boş geçilemez.");
            RuleFor(x => x.CheckOut).GreaterThanOrEqualTo(x => x.CheckIn).WithMessage("Çıkış tarihi giriş tarihinden sonra olmalıdır.");

            RuleFor(x => x.AdultCount).GreaterThanOrEqualTo(0).WithMessage("Yetişkin sayısı 0 veya daha büyük olmalıdır.");
            RuleFor(x => x.ChildCount).GreaterThanOrEqualTo(0).WithMessage("Çocuk sayısı 0 veya daha büyük olmalıdır.");
            RuleFor(x => x.RoomCount).GreaterThan(0).WithMessage("Oda sayısı en az 1 olmalıdır.");

            RuleFor(x => x.SpecialRequest).MaximumLength(1000).WithMessage("Özel istek en fazla 1000 karakter olabilir.");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Durum boş geçilemez.");
            RuleFor(x => x.Status).MaximumLength(50).WithMessage("Durum en fazla 50 karakter olabilir.");
        }
    }
}
