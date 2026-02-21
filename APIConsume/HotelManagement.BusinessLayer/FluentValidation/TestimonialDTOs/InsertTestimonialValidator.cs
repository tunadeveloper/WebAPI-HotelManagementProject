using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.TestimonialDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.TestimonialDTOs
{
    public class InsertTestimonialValidator : AbstractValidator<InsertTestimonialDTO>
    {
        public InsertTestimonialValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad soyad boş geçilemez.");
            RuleFor(x => x.NameSurname).MaximumLength(200).WithMessage("Ad soyad en fazla 200 karakter olabilir.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL boş geçilemez.");
            RuleFor(x => x.ImageUrl).MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş geçilemez.");
            RuleFor(x => x.Comment).MaximumLength(1000).WithMessage("Yorum en fazla 1000 karakter olabilir.");
        }
    }
}
