

using AutoMapper;
using FluentValidation;
using ZverGram.Db.Entities;

namespace ZverGram.ExhibitionService.Models
{
    public class AddPictureModel
    {
        public string Filename { get; set; }
        public string? Description { get; set; }
        public char isPrimary { get; set; }
        public int ExhibitionId { get; set; }
        public byte[] Image { get; set; }
    }

    public class AddPictureModelValidator : AbstractValidator<AddPictureModel>
    {
        public AddPictureModelValidator()
        {
            RuleFor(x => x.Filename)
                .NotEmpty().WithMessage("Filename should not be empty")
                .MaximumLength(100).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }
    }

    public class AddPictureRequestProfile : Profile
    {
        public AddPictureRequestProfile()
        {
            CreateMap<AddPictureModel, Picture>();
        }
    }
}
