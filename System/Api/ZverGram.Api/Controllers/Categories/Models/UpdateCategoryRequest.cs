using AutoMapper;
using FluentValidation;
using ZverGram.CategoryService.Models;

namespace ZverGram.Api.Controllers.Categories.Models
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");
        }
    }

    public class UpdateCategoryRequestProfile : Profile
    {
        public UpdateCategoryRequestProfile()
        {
            CreateMap<UpdateCategoryRequest, UpdateCategoryModel>();
        }
    }
}
