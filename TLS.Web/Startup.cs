using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using System;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using TLS.DataProvider;
using TLS.DataProvider.Entities;
using TLS.Repository.Base;
using TLS.Service.Account;
using TLS.Service.Catalog;
using TLS.Service.Common.Storage;
using TLS.Service.Mapping;
using TLS.Service.NewsService;

namespace TLS
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
           
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Identity
            services.AddIdentity<AppUser,AppRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Config cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(10);
                options.SlidingExpiration = true;
                options.LoginPath = $"/Account/Login"; // Chuyển hướng nếu truy cập chức năng cần đăng nhập
                options.LogoutPath = $"/Account/Logout";
                options.AccessDeniedPath = $"/Home/Index"; // Chuyển hướng khi truy cập chức năng ko cho phép
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // Trên 30 giấy truy cập lại sẽ nạp lại thông tin User (Role)
                // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
                options.ValidationInterval = TimeSpan.FromSeconds(30);
            });

            // Session storage config
            services.AddSession(options => {
                options.Cookie.Name = "WebCookie"; // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                options.IdleTimeout = TimeSpan.FromHours(10); // Thời gian tồn tại của Session
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // DI 
            ConfigureDependencyInjection(services);

            // Mapping
            services.AddSingleton(provider => new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            }).CreateMapper());

            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IRepository<AppUser>, BaseRepository<AppUser>>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IRepository<Contact>, BaseRepository<Contact>>();
            services.AddTransient<IRepository<News>, BaseRepository<News>>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddScoped<IStorageService, StorageService>();
        }
    }
}
