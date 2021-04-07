using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using dotenv.net;
using BookApi.Responses;
using Middlewares = BookApi.Middlewares;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace BookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            DotEnv.Load();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IDictionary<string, string> env = DotEnv.Read();
            services.AddDbContext<Context>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        env["CONNECTION_STRING"],
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    ApiResponseValidationError responseError = new ApiResponseValidationError(HttpStatusCode.BadRequest, ErrorValidation.Error(actionContext), "Validation Error");
                    return (new ObjectResult(responseError));
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

            app.UseRequestLocalization();

            app.UseCors();

            // app.UseResponseCompression();

            app.UseResponseCaching();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
