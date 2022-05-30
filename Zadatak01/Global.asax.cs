using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Zadatak01
{
    public class Global : System.Web.HttpApplication
    {
        private readonly IRepo _repo;

        public Global()
        {
            _repo = RepoFactory.GetRepo();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = _repo;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Cookies["lang"] != null)
            {
                if (Request.Cookies["lang"]["lang"] != null)
                {
                    string culture = Request.Cookies["lang"]["lang"];
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                }
            }
        }
    }
}