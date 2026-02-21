using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.ContactDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.ContactDTOs
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactDTO>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir kayıt numarası gerekir.");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş geçilemez.");
            RuleFor(x => x.Address).MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.");
            RuleFor(x => x.PhoneNumber).MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir.");

            RuleFor(x => x.MapUrl).MaximumLength(1000).WithMessage("Harita URL en fazla 1000 karakter olabilir.");
        }
    }
}
