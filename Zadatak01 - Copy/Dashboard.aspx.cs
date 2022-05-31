using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Dashboard : DefaultPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //User u = (User)Session["user"];
            //pFName.InnerText = u.FName;
            //pLName.InnerText = u.LName;
            //bUsername.InnerText = u.Username;
            base.OnPreRender(e);
        }
    }
}