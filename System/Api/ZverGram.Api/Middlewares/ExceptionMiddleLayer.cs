using System.Text.Json;
using ZverGram.Common.Extentions;
using ZverGram.Common.Responses;

namespace ZverGram.Api.Middlewares
{
    public class ExceptionMiddleLayer
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleLayer(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse response = null;
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                response = ex.ToErrorResonse();
            }
            finally
            {
                if(response != null)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
