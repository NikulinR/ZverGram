using AutoMapper;
using FluentValidation;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.Api.Controllers.Exhibitions.Models
{
    public class AddExhibitionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AddExhibitionValidator: AbstractValidator<AddExhibitionRequest>
    {
        public AddExhibitionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }
    }

    public class AddExhibitionRequestProfile: Profile
    {
        public AddExhibitionRequestProfile()
        {
            CreateMap<AddExhibitionRequest, AddExhibitionModel>();
        }
    }
}
