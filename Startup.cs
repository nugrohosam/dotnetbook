using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookApi.Responses;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;

namespace BookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                };
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                    {

                        ApiResponse apiResponseError = new ApiResponseValidationError(HttpStatusCode.BadRequest, ErrorValidation.Error(actionContext), "Validation Error");
                        return (new ObjectResult(apiResponseError));
                    };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
