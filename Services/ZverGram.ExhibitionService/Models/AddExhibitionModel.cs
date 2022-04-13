using AutoMapper;
using FluentValidation;
using ZverGram.Db.Entities;

namespace ZverGram.ExhibitionService.Models
{
    public class AddExhibitionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddExhibitionModelValidator : AbstractValidator<AddExhibitionModel>
    {
        public AddExhibitionModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }
    }

    public class AddExhibitionRequestProfile : Profile
    {
        public AddExhibitionRequestProfile()
        {
            CreateMap<AddExhibitionModel, Exhibition>();
        }
    }
}
