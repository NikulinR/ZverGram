using AutoMapper;
using FluentValidation;
using ZverGram.Db.Entities;

namespace ZverGram.CategoryService.Models
{
    public class UpdateCategoryModel
    {
        public string Name { get; set; } = String.Empty;
    }

    public class UpdateCategoryModelValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(50).WithMessage("Name is too long");
        }
    }

    public class UpdateCategoryRequestProfile : Profile
    {
        public UpdateCategoryRequestProfile()
        {
            CreateMap<UpdateCategoryModel, Category>();
        }
    }
}
