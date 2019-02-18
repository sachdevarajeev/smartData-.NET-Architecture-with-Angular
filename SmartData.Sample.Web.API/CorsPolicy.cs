using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SmartData.Sample.Web.API
{
    public class CorsPolicy
    {
        public const string PRODUCTION = "Production";
        public const string ALLOW_ALL = "AllowAll";


        public static void ConfigureServices(IServiceCollection services)
        {            
            services.AddCors(AllowAll);
        }


        private static void AllowProduction(CorsOptions options)
        {
            throw new Exception("Not Implemented");
        }

        private static void AllowAll(CorsOptions options)
        {
            options.AddPolicy(ALLOW_ALL, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        }
    }
}
