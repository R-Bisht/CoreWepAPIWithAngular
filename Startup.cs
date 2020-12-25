using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CoreWepAPI.Model;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer; //library for jwt auth
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using CoreWepAPI.Infrastructure;
using CoreWepAPI.Repository;
using System.Text.Json;
using CoreWepAPI.RSA;

namespace CoreWepAPI
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
            //It's use for store session data
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(90);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // services.AddSession();
            //services.AddMemoryCache();
            //services.AddControllers().AddNewtonsoftJson(option => 
            //option.SerializerSettings.ReferenceLoopHandling.)
            

            services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            //Set the json format

            //services.AddControllers().AddJsonOptions(option =>
            //{
            //    option.JsonSerializerOptions.WriteIndented = true;
            //});

            //Get Data to Json 
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped<IRsaHelper, RsaHelper>();
            services.AddScoped<IDropDown, RDropDown>();
            services.AddScoped<IAddStudentDetail, RAddStudentDetail>();
            services.AddControllers();




            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 4;
            //}
            //);


            //Inject Appsetting

            services.Configure<ApplicationSetting>(Configuration.GetSection("Applicationsetting"));

            // it use identity custom for user 
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>().AddDefaultTokenProviders();



            services.AddDbContext<AuthenticationContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            //password
            services.Configure<IdentityOptions>(option =>
            {

                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 4;

            });
            //remove default json formatting
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            //add cors package

            services.AddCors();

            // JWT authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSetting:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {

                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                };

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

           // app.UseSession();

            //configurations to cosume the Web API from port : 4200 (Angualr App)
            app.UseCors(options =>
            options.WithOrigins(Configuration["ApplicationSetting:Client_URL"].ToString())
            .AllowAnyMethod()
            .AllowAnyHeader());
          


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSession();

            // after Login anthor page post data
            app.UseAuthentication();

            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
