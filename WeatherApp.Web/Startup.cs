using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WeatherApp.Core.Adapters;
using WeatherApp.Core.Client;
using WeatherApp.Core.Factories;
using WeatherApp.Core.Infrastructure.Adapter;
using WeatherApp.Core.Infrastructure.Services;
using WeatherApp.Domain;
using WeatherApp.Validation;
using WeatherAppi.Core.Services;

namespace WeatherApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddControllersWithViews().AddFluentValidation();
            services.AddSwaggerGen();

            services.AddTransient(settings => Configuration.GetSection("OpenWeatherMapApiSettings").Get<OpenWeatherMapApiSettings>());
            services.AddScoped<WeatherDataAdapterFactory>();
            services.AddTransient<IWeatherClient, OpenWeatherMapDataClient>();
            services.AddScoped<OpenWeatherMapDataAdapter>()
                .AddScoped<IWeatherDataAdapter, OpenWeatherMapDataAdapter>(s => s.GetService<OpenWeatherMapDataAdapter>());
            services.AddScoped<OpenWeatherMapDataAdapter>()
                .AddScoped<IWeatherDataAdapter, DummyDataAdapter>(s => s.GetService<DummyDataAdapter>());
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddTransient<IValidator<WeatherRequest>, WeatherRequestValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseCors(_policyName);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
