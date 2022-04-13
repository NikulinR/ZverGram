using AutoMapper;
using FluentValidation;
using ZverGram.Db.Entities;

namespace ZverGram.CategoryService.Models
{
    public class AddCategoryModel
    {
        public string Name { get; set; } = String.Empty;
    }

    public class AddCategoryModelValidator : AbstractValidator<AddCategoryModel>
    {
        public AddCategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(50).WithMessage("Name is too long");
        }
    }

    public class AddCategoryRequestProfile : Profile
    {
        public AddCategoryRequestProfile()
        {
            CreateMap<AddCategoryModel, Category>();
        }
    }
}
