using AutoMapper;
using FluentValidation;
using ZverGram.ExhibitionService.Models;

namespace ZverGram.Api.Controllers.Exhibitions.Models
{
    public class UpdateExhibitionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateExhibitionValidator : AbstractValidator<UpdateExhibitionRequest>
    {
        public UpdateExhibitionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }
    }

    public class UpdateExhibitionRequestProfile : Profile
    {
        public UpdateExhibitionRequestProfile()
        {
            CreateMap<UpdateExhibitionRequest, UpdateExhibitionModel>();
        }
    }
}
