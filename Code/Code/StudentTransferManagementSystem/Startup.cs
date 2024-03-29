using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentTransferManagementSystem.Classes;
using StudentTransferManagementSystem.Data;
using StudentTransferManagementSystem.Data.Container;
using StudentTransferManagementSystem.Data.Repository.Classes;
using StudentTransferManagementSystem.Data.Repository.Interface;
using StudentTransferManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem
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
            services.AddDbContext<ManagementSystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ManagementSystemContext")),ServiceLifetime.Transient);

            services.AddControllersWithViews();
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

            services.AddScoped<IStudentBusiness, StudentBusiness>();
            services.AddScoped<IAdminBusiness, AdminBusiness>();
            services.AddScoped<IAccountBusiness, AccountBusiness>();
            services.AddScoped<IContainer, Container>();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".Stms.Session";
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.IsEssential = true;

            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNotyf();

            app.UseSession();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
