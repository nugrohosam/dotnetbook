using Microsoft.AspNetCore.Builder;
using Exceptions = BookApi.Exceptions;
using System;

namespace BookApi.Middlewares
{
    public class Authorization
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                bool isContains = context.Request.Headers.ContainsKey("Authorization");
                if (!isContains)
                {
                    throw (new Exceptions.UnauthorizedAccessException("Not Authenticated"));
                }

                return next();
            });
        }
    }
}