using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SmartData.Sample.Repository.Payroll;
using SmartData.Sample.RepositoryContract.Payroll;
using SmartData.Sample.Service.Payroll;
using SmartData.Sample.ServiceContract.Payroll;

namespace SmartData.Sample.Web.API
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
            services.AddMvc()
                .AddJsonOptions(a => a.SerializerSettings.NullValueHandling = NullValueHandling.Ignore)
                .AddJsonOptions(a => a.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc);
            CorsPolicy.ConfigureServices(services);
            ConfigureDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicy.ALLOW_ALL);
            app.UseMvc();
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IPayrollService, PayrollService>();

            // Add repos as scoped dependency so they are shared per request.
            services.AddScoped<IPayrollRepository, PayrollRepository>();

            services.AddSingleton<IConfiguration>(Configuration);
        }
    }
}
