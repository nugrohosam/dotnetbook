using Microsoft.AspNetCore.Builder;
using Exceptions = BookApi.Exceptions;
using System;

namespace BookApi.Middlewares
{
    public class AuthorizationCheck
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                bool isContains = context.Request.Headers.ContainsKey("Authorization");
                if (!isContains)
                {
                    throw (new Exceptions.UnauthorizedException());
                }

                return next();
            });
        }
    }

    public class AuthorizationRole
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                bool isContains = context.Request.Headers.ContainsKey("Role");
                if (!isContains)
                {
                    throw (new Exceptions.UnauthorizedException("Not Authenticated With Correctly Role"));
                }

                return next();
            });
        }
    }
}