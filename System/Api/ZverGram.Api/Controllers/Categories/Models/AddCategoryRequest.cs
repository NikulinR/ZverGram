using AutoMapper;
using FluentValidation;
using ZverGram.CategoryService.Models;

namespace ZverGram.Api.Controllers.Categories.Models
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
    }

    public class AddCategoryValidator: AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");
        }
    }

    public class AddCategoryRequestProfile: Profile
    {
        public AddCategoryRequestProfile()
        {
            CreateMap<AddCategoryRequest, AddCategoryModel>();
        }
    }
}
