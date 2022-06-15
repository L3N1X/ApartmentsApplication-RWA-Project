using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Default : DefaultPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PanelForma.Visible = true;
                PanelIspis.Visible = false;
            }
            if (Session["user"] != null)
            {
                Response.Redirect("/Dashboard");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var email = txtUsername.Text;

                var allUsers = ((IRepo)Application["database"]).LoadUsers();
                var user = allUsers.FirstOrDefault(u => u.Email.Equals(email));

                if (user == null)
                {
                    PanelIspis.Visible = true;
                    PanelForma.Visible = true;

                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                }
                else
                {
                    Session["user"] = user;
                    Session["username"] = user.UserName;
                    Response.Redirect("/Dashboard");
                }
            }
        }
    }
}