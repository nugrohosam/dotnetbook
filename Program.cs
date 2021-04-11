using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using dotenv.net;
using System.Collections.Generic;
using BookApi.Exceptions;

namespace BookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
            .Build()
            .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    IDictionary<string, string> env = DotEnv.Read();

                    webBuilder
                        .UseSentry(options =>
                            {
                                options.Dsn = env["SENTRY_DSN"];
                                options.BeforeSend = @event =>
                                {
                                    if (
                                        @event.Exception is DataNotFoundException ||
                                        @event.Exception is DataException ||
                                        @event.Exception is UnauthorizedException ||
                                        @event.Exception is TokenNotValidException
                                    )
                                    {
                                        return null;
                                    }

                                    @event.ServerName = null;
                                    return @event;
                                };
                            })
                        .UseStartup<Startup>();
                });
    }
}
