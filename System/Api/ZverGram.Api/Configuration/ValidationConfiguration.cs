using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ZverGram.Common.Helpers;
using ZverGram.Common.Responses;

namespace ZverGram.Api.Configuration
{
    public static class ValidationConfiguration
    {
        public static IMvcBuilder AddValdator(this IMvcBuilder builder)
        {
            builder.ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var fieldErrors = new List<ErrorResponseInfo>();
                    foreach (var item in context.ModelState)
                    {
                        if(item.Value.ValidationState == ModelValidationState.Invalid)
                            fieldErrors.Add(new ErrorResponseInfo
                            {
                                Field = item.Key,
                                Message = String.Join(", ", item.Value.Errors.Select(x => x.ErrorMessage))
                            });
                    }

                    var result = new BadRequestObjectResult(new ErrorResponse()
                    {
                        ErrorCode = -1,
                        Message = "Validation errors.",
                        Errors = fieldErrors
                    });

                    return result;
                };
            });

            builder.AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.ImplicitlyValidateChildProperties = true;
                fv.AutomaticValidationEnabled = true;
            });
            ValidatorHelper.Register(builder.Services);

            //builder.Services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

            return builder;
        }
    }
}
