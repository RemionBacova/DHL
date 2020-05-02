using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using DHLWebAPI.Data;
using DHLWebAPI.Mapper;
using DHLWebAPI.Repository;
using DHLWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DHLWebAPI
{
    public class Startup
    {
        //private readonly string OurPolicy = "DHLPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: OurPolicy,
            //        builder =>
            //        {
            //            builder.WithOrigins("https://localhost:44392/")
            //                .WithMethods("Put");
            //        });
            //});
            
            //DbContext added as a service
            services.AddDbContext<DHLContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //Added automapper service for class "ClassMappings"
            services.AddAutoMapper(typeof(ClassMappings));

            //Part of Repository Pattern for class CustomerAddressRepository
            services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICardsRepository, CardsRepository>();
            services.AddScoped<ICustomerLogsRepository,CustomerLogsRepository>();
            services.AddScoped<IDiscountRepository,DiscountRepository>();


            //Added Smagger service and also different metadata
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("DHLOpenAPI",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "DHL Rest API",
                        Version = "1",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Email = "info@sitel.al",
                            Name = "Internship Team",
                            Url = new Uri("http://www.sitel.com.al/")
                        }
                    });
                var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                options.IncludeXmlComments(cmlCommentsFullPath);
            });
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            //added Swagger middleware, also the Swagger UI for better documentation
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/DHLOpenAPI/swagger.json", "DHL Rest API");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            //app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers().RequireCors(OurPolicy);
                endpoints.MapControllers();
            });
        }
    }
}
