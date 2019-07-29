using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ShoppingCart.Entities;
using ShoppingCart.Models;
using ShoppingCart.Services;

namespace ShoppingCart
{
    public class Startup
    {
        public static IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString =Configuration["connectionStrings:ShoppingCartDBConnectionString"];
            services.AddDbContext<CarContext>(o => o.UseSqlServer(connectionString));
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
            });
            services.AddScoped<ICarRepository, CarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CarContext shoppingCartContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

           

            shoppingCartContext.EnsureSeedDataForContext();
#pragma warning disable CS0618 // Type or member is obsolete
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDto>();
                cfg.CreateMap<CarForCreationDto, Car>();
                cfg.CreateMap<CarForUpdateDto, Car>();
                cfg.CreateMap<Car,CarForUpdateDto>();
            });

            app.UseCors("MyPolicy");
#pragma warning restore CS0618 // Type or member is obsolete
            app.UseMvc();



        }              
    }                  
}
