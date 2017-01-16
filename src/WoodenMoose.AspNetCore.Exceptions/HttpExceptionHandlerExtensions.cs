using Microsoft.AspNetCore.Builder;

namespace WoodenMoose.AspNetCore.Exceptions
{
    /// <summary>
    /// Extensions to simplify the use of <see cref="HttpExceptionHandlerMiddleware"/>
    /// </summary>
    public static class HttpExceptionHandlerExtensions
    {
        /// <summary>
        /// Register <see cref="HttpExceptionHandlerMiddleware"/> into the request pipeline
        /// </summary>
        /// <param name="app">An instance of <see cref="IApplicationBuilder"/></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHttpStatusCodeExceptions(this IApplicationBuilder app)
        {
            app.UseMiddleware<HttpExceptionHandlerMiddleware>();
            return app;
        }
    }
}
