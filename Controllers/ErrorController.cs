using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Exceptions = BookApi.Exceptions;
using System.Text.Json;
using System.Collections.Generic;

namespace BookApi.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [Route("/error")]
        public ApiResponse Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            HttpStatusCode statusCode = new HttpStatusCode();
            if (context.Error is Exceptions.DataException)
            {
                statusCode = HttpStatusCode.BadRequest;
                this.HttpContext.Response.StatusCode = 400;
                return (new ApiResponseValidationError(statusCode, JsonSerializer.Deserialize<List<IDictionary<string, string>>>(context.Error.Message)));
            }
            else if (context.Error is Exceptions.UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                this.HttpContext.Response.StatusCode = 401;
                return (new ApiResponseError(statusCode, context.Error.Message));
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                this.HttpContext.Response.StatusCode = 500;
                return (new ApiResponseError(statusCode, context.Error.Message));
            }

        }
    }
}