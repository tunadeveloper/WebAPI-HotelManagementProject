using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.AboutDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.AboutDTOs
{
    public class InsertAboutValidator : AbstractValidator<InsertAboutDTO>
    {
        public InsertAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");
            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL boş geçilemez.");
            RuleFor(x => x.ImageUrl).MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
