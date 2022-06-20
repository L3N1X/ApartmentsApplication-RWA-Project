using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using RwaApartmaniDataLayer.Models;
using RwaApartments_Public.Models.Auth;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(RwaApartments_Public.App_Start.Startup))]

namespace RwaApartments_Public.App_Start
{
    public class Startup
    {
        public string DefaultAuthentificationType { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(DBContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}
