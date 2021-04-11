using Microsoft.AspNetCore.Builder;
using BookApi.Applications.Auth;
namespace BookApi.Middlewares
{
    public class AuthorizationCheck
    {
        private AuthApplication authApplication;

        public AuthorizationCheck()
        {
            this.authApplication = new AuthApplication();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                var headers = context.Request.Headers;

                bool isContains = headers.ContainsKey("Authorization");
                if (!isContains)
                {
                    throw (new Exceptions.UnauthorizedException());
                }

                string token = headers["Authorization"].ToString();
                bool isValid = this.authApplication.ValidateToken(token);
                if (!isValid)
                {
                    throw (new Exceptions.TokenNotValidException());
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