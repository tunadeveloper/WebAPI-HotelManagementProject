using FluentValidation;
using HotelManagement.DataTransferObjectLayer.DTOs.RoomDTOs;

namespace HotelManagement.BusinessLayer.FluentValidation.RoomDTOs
{
    public class UpdateRoomValidator : AbstractValidator<UpdateRoomDTO>
    {
        public UpdateRoomValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Geçerli bir kayıt numarası gerekir.");

            RuleFor(x => x.RoomNumber).NotEmpty().WithMessage("Oda numarası boş geçilemez.");
            RuleFor(x => x.RoomNumber).MaximumLength(20).WithMessage("Oda numarası en fazla 20 karakter olabilir.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("Fiyat 0 veya daha büyük olmalıdır.");

            RuleFor(x => x.CoverImage).MaximumLength(500).WithMessage("Kapak görseli URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.BedCount).MaximumLength(10).WithMessage("Yatak sayısı en fazla 10 karakter olabilir.");
            RuleFor(x => x.BathCount).MaximumLength(10).WithMessage("Banyo sayısı en fazla 10 karakter olabilir.");

            RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");
        }
    }
}
