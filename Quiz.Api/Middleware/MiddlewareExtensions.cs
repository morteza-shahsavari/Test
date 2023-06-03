namespace Quiz.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder bulider) 
        {
            return bulider.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
