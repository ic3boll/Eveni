using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Migrations;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Web.Services.Interfaces;
using Web.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity;
using Web.ViewModels.Services.Interfaces;
using Web.ViewModels.Services;
using Microsoft.AspNetCore.Http;
using System;
using Web.Helpers;
using Web.Helpers.Interfaces;
using System.Web.Http;

namespace Web
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
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IProductServices), typeof(ProductServices));
            services.AddScoped(typeof(IViewModelServices), typeof(ViewModelServices));
            services.AddScoped(typeof(IOrderServices), typeof(OrderServices));
            services.AddScoped(typeof(IOrderSecurityServices), typeof(OrderSecurityServices));
            services.AddScoped(typeof(IImageHelper), typeof(ImageHelper));
            services.AddScoped(typeof(IImageServices), typeof(ImageServices));
            services.AddScoped(typeof(ICookieHelper), typeof(CookieHelper));

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddScoped(typeof(CookieHelper));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });




            services.AddDbContext<EveniDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc(option => option.EnableEndpointRouting = false


            );
            

            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequiredLength = 6;

            })

      .AddDefaultTokenProviders()
      .AddEntityFrameworkStores<EveniDbContext>();


            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
            app.Use(async (context, next) =>
            {
                var visitorsIpAddr = context.Request.HttpContext.Connection.RemoteIpAddress;
                var User = context.Request.Cookies["UserID"];

                if (User == null)
                {
                    string cookieValue = Guid.NewGuid().ToString();

                    var cookieOptions = new CookieOptions()
                    {
                        Path = "/",
                        IsEssential = true,
                        HttpOnly = false,
                        Secure = false,
                    };
                  //  context.Response.Cookies.Append("UserID", visitorsIpAddr.MapToIPv4().ToString(), cookieOptions);

                    context.Response.Cookies.Append("UserID", cookieValue, cookieOptions);

                }
                await next();


            });
            app.UseCookiePolicy();
            // app.UseCookieMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            //   app.UseIdentityServer();
            app.UseAuthorization();


            app.UseMvc(routes =>
            {

            routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Home}/{id?}");


                routes.MapRoute(
              name: "DefaultApi",
              template: "api/{controller}/{category}",
                  defaults: new { category = "all" });


         });
        }
    }
}