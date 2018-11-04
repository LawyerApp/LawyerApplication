using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using LawyerApp.Models;
using System.Resources;
using System.Reflection;

namespace LawyerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();

            using (IServiceScope serviceScope = webHost.Services.CreateScope())
            {
                using (RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>())
                {
                    if (roleManager.Roles.Count() == 0)
                    {
                        Task<IdentityResult> role = roleManager.CreateAsync(new IdentityRole
                        {
                            Name = "Admin"
                        });
                        role.Wait();
                    }
                }

                using (UserManager<AppUser> db = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>())
                {
                    if (!db.Users.Any())
                    {
                        AppUser app = new AppUser
                        {
                            Name = "Nihad",
                            Email = "nihad@gmail.com",
                            UserName = "Nihad_UN"
                        };
                        IdentityResult identityResult = db.CreateAsync(app,"Seymur855_").GetAwaiter().GetResult();
                        if (identityResult.Succeeded)
                        {
                            Task<IdentityResult> res = db.AddToRoleAsync(app, "Admin");
                            res.Wait();
                        }
                        else
                        {
                            IEnumerable<IdentityError> identityErrors = identityResult.Errors;
                        }
                    }
                }

                using (LawyerDbContext lawyerdbcontext = serviceScope.ServiceProvider.GetRequiredService<LawyerDbContext>())
                {
                    if (!lawyerdbcontext.Languages.Any())
                    {
                        IEnumerable<Language> languages = new List<Language>
                        {
                            new Language
                            {
                                LangShort = "en-US",
                                LangLong = "English",
                            },
                            new Language
                            {
                                LangShort = "az-LATN",
                                LangLong = "Azerbaijan",
                            },
                            new Language
                            {
                                LangShort = "ru-RU",
                                LangLong = "Russian",
                            }
                         };
                        lawyerdbcontext.AddRange(languages);
                    }
                    lawyerdbcontext.SaveChanges();
                }

                    webHost.Run();
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(serviceCollection=>
            {
                serviceCollection.AddSingleton(new ResourceManager("LawyerApp.Resources.Controllers.HomeController", 
                                                                    typeof(Startup).GetTypeInfo().Assembly));
            })
                .UseStartup<Startup>();
    }
}
