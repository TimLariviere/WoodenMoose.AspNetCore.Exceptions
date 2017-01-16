using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WoodenMoose.AspNetCore.Exceptions
{
    /// <summary>
    /// Writes into the response when a <see cref="HttpStatusCodeException"/> is thrown
    /// </summary>
    public class HttpExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initialize a new instance of the <see cref="HttpExceptionHandlerMiddleware"/> class
        /// </summary>
        /// <param name="next">The next middleware to execute</param>
        public HttpExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Run the current middleware
        /// </summary>
        /// <param name="context">The <see cref="HttpContext"/> of the request</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException exception)
            {
                context.Response.StatusCode = (int)exception.StatusCode;

                if (!string.IsNullOrEmpty(exception.Message))
                {
                    await context.Response.WriteAsync(exception.Message);
                }
            }
        }
    }
}
