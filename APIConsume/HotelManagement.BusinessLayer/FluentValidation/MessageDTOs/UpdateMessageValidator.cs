using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.MessageDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.MessageDTOs
{
    public class UpdateMessageValidator : AbstractValidator<UpdateMessageDTO>
    {
        public UpdateMessageValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir kayıt numarası gerekir.");

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(x => x.NameSurname).MaximumLength(200).WithMessage("Ad soyad en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez.");
            RuleFor(x => x.Subject).MaximumLength(200).WithMessage("Konu en fazla 200 karakter olabilir.");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez.");
            RuleFor(x => x.MessageContent).MaximumLength(2000).WithMessage("Mesaj içeriği en fazla 2000 karakter olabilir.");
        }
    }
}
