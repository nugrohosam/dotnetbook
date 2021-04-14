using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace BookApi.Middlewares
{
    public class DefineRouteValuesGlobaly
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                Global.RouteValues = context.Request.RouteValues;
                return next();
            });
        }
    }
}