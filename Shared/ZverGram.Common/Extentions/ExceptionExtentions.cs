using FluentValidation.Results;
using ZverGram.Common.Responses;

namespace ZverGram.Common.Extentions;

public static class ExceptionExtentions
{
    public static ErrorResponse ToErrorResponse(this ValidationResult data)
    {
        var res = new ErrorResponse()
        {
            Message = "",
            Errors = data.Errors.Select(x =>
            {
                var elems = x.ErrorMessage.Split('&');
                var errorName = elems[0];
                var errorMessage = elems.Length > 0 ? elems[1] : errorName;
                return new ErrorResponseInfo()
                {
                    Field = x.PropertyName,
                    Message = errorMessage,
                };
            })
        };
        return res;
    }

    public static ErrorResponse ToErrorResonse(this Exception data)
    {
        var res = new ErrorResponse()
        {
            ErrorCode = -1,
            Message = data.Message,
        };
        return res;
    }
}
