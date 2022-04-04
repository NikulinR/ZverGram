using AutoMapper;
using FluentValidation;

namespace ZverGram.ExhibitionService.Models
{
    public class UpdateExhibitionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateExhibitionModelValidator : AbstractValidator<UpdateExhibitionModel>
    {
        public UpdateExhibitionModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }
    }

    //public class UpdateExhibitionRequestProfile : Profile
    //{
    //    public UpdateExhibitionRequestProfile()
    //    {
    //        CreateMap<UpdateExhibitionRequest, UpdateExhibitionModel>();
    //    }
    //}
}
