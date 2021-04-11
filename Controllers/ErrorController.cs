using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using BookApi.Exceptions;
using System.Text.Json;
using System.Collections.Generic;
using System;

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
            if (context.Error is DataException)
            {
                statusCode = HttpStatusCode.BadRequest;
                this.HttpContext.Response.StatusCode = 400;
                return (new ApiResponseValidationError(statusCode, JsonSerializer.Deserialize<List<IDictionary<string, string>>>(context.Error.Message)));
            }
            else if (context.Error is DataNotFoundException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                this.HttpContext.Response.StatusCode = 401;
                return (new ApiResponseError(statusCode, context.Error.Message + " Not found"));
            }
            else if (context.Error is UnauthorizedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                this.HttpContext.Response.StatusCode = 401;
                return (new ApiResponseError(statusCode, context.Error.Message + ", please change with your role"));
            }
            else if (context.Error is RoleNotAssignedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                this.HttpContext.Response.StatusCode = 401;
                return (new ApiResponseError(statusCode, context.Error.Message + ", please sign in first"));
            }
            else if (context.Error is TokenNotValidException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                this.HttpContext.Response.StatusCode = 401;
                return (new ApiResponseError(statusCode, context.Error.Message + ", please sign in again"));
            }

            statusCode = HttpStatusCode.InternalServerError;
            this.HttpContext.Response.StatusCode = 500;
            return (new ApiResponseError(statusCode, context.Error.Message));

        }
    }
}
