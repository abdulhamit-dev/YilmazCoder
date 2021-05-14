using AutoMapper;
using CoderBlog.UI.AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfil());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => {
                x.LoginPath = "/auth/login";
                x.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), @"resources")),
                RequestPath = new PathString("/resources")
            });
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "yaziseo",
                    pattern: "{controller=Yazi}/{action=Detay}/{id}/{title}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
