using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LawyerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LawyerApp.Infrastructures;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using LawyerApp.Infrastructures.CustomCulture;

namespace LawyerApp
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailServiceOption>(emailOpt =>
            {
                emailOpt.DisplayName = "Lawyer LLC";
                emailOpt.Email = "ganbarovseymur@gmail.com";
                emailOpt.Password = "48028802";
                emailOpt.EnableSSL = true;
                emailOpt.Host = "smtp.gmail.com";
                emailOpt.Port = 587;
            });

            services.AddSingleton<EmailService>();

            services.AddIdentity<AppUser, IdentityRole>()
                                    .AddEntityFrameworkStores<LawyerDbContext>()
                                                     .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/lawyeradminpanel/account/login");
            });

            services.AddDbContext<LawyerDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:con"]);
            });

            services.AddLocalization(option => option.ResourcesPath = "Resources");

            services.AddSession();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ru-RU"),
                    new CultureInfo("az-LATN")
                };
               
                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0], uiCulture: supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Insert(0, new RouteRequestCultureProvider());
            });


            services.AddMvc()
                       .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                       .AddViewLocalization()
                       .AddDataAnnotationsLocalization(option => {
                           option.DataAnnotationLocalizerProvider = (type, factory) =>
                           factory.Create(typeof(SharedResource));
                       });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithRedirects("/en-US/home/error/{0}");

            //Supported cultures in application
            
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(route =>
            {
                route.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                route.MapRoute(
                   name: "default",
                   template: "{culture=en-US}/{controller=Home}/{action=Index}/{id?}"
                   ,defaults: null
                   ,constraints: new { culture= new CultureRouteConstraint() });
            });
        }
    }
}
