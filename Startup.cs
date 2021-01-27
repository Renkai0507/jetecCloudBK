using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BkServer.Models;
using BkServer.Repository;
using BkServer.Service;
using BkServer.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BkServer
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
            //cockie
             services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
             services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            //cockie
           
         
         

            services.AddDbContext<jetecbkContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("BKconnection"));
            });
            services.AddDbContext<jetec_join_systemContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>(); 
            services.AddScoped<IBKRepository,BKRepository>(); 
            services.AddScoped<ICloudAccountService,CloudAccountService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAlarmLog,AlarmlogService>();
            services.AddMvc().AddJsonOptions(options =>
            {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            // services.AddControllersWithViews(options=>{ options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            // _ => "The field is required.");});
           
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
            #region 指定要使用 Cookie & 使用者認證的中介軟體
            app.UseCookiePolicy();
            app.UseAuthentication();
            #endregion

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
