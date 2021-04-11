using Microsoft.AspNetCore.Builder;
using BookApi.Applications.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using System;

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
        private AuthApplication authApplication;

        public AuthorizationRole()
        {
            this.authApplication = new AuthApplication();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                Endpoint endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                string nameRoute = endpoint?.Metadata.GetMetadata<IRouteNameMetadata>()?.RouteName;
                string permission = Global.GetPermissionFromRoute(nameRoute);
                if (permission == null)
                {
                    return next();
                }

                var headers = context.Request.Headers;
                bool isContains = headers.ContainsKey("Role");
                if (!isContains)
                {
                    throw (new Exceptions.UnauthorizedException("Not Authenticated With Correctly Role"));
                }

                string role = headers["Role"].ToString();
                bool isHaveRole = this.authApplication.IsUserHaveRole(Global.UserId, role);
                if (!isHaveRole)
                {
                    throw (new Exceptions.RoleNotAssignedException());
                }

                bool isHavePermission = this.authApplication.IsRoleHavePermission(role, permission);
                if (!isHavePermission)
                {
                    throw (new Exceptions.NotAllowedException());
                }

                return next();
            });
        }
    }
}