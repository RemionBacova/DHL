using System;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using DHLWebAPI.Data;
using DHLWebAPI.Installer;
using DHLWebAPI.Mapper;
using DHLWebAPI.Models.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;


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

            //Calling the extension method that calls all the scoped services
            services.InstallServicesInAssembly(Configuration);

            //JWT Scheme 
            //match jwt with the class we have created
            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);

            //to validate the token which has been sent by clients
            var appSettings = jwtSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });


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

            //add controllers
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

            //Authentication middleware is responsible for authentication in ASP.Net Core
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers().RequireCors(OurPolicy);
                endpoints.MapControllers();
            });
        }
    }
}
