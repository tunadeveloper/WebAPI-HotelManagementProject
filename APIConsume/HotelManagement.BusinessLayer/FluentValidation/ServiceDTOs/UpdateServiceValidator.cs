using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.ServiceDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.ServiceDTOs
{
    public class UpdateServiceValidator : AbstractValidator<UpdateServiceDTO>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir kayıt numarası gerekir.");

            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş geçilemez.");
            RuleFor(x => x.Icon).MaximumLength(100).WithMessage("İkon en fazla 100 karakter olabilir.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");
        }
    }
}
