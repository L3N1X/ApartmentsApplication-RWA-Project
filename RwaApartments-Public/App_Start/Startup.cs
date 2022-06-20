using Microsoft.Owin;
using Owin;
using RwaApartments_Public.Models.Auth;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(RwaApartments_Public.App_Start.Startup))]

namespace RwaApartments_Public.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(DBContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);
        }
    }
}
