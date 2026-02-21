using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.SubscribeDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.SubscribeDTOs
{
    public class InsertSubscribeValidator : AbstractValidator<InsertSubscribeDTO>
    {
        public InsertSubscribeValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta adresi boş geçilemez.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
        }
    }
}
