using FluentValidation;

namespace ZverGram.Web
{
    public class ExhibitionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExhibitionModelValidator : AbstractValidator<ExhibitionModel>
    {
        public ExhibitionModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name should not be empty")
                .MaximumLength(80).WithMessage("Name is too long");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description is too long");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ExhibitionModel>.CreateWithOptions((ExhibitionModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
