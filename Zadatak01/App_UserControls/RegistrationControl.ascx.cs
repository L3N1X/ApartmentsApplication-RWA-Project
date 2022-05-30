using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01.App_UserControls
{
    public partial class RegistrationControl : System.Web.UI.UserControl
    {
        private IList<City> _listOfAllCities;

        protected void Page_Load(object sender, EventArgs e)
        {
            _listOfAllCities = ((IRepo)Application["database"]).LoadCities();

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    Response.Redirect("Dashboard.aspx");
                }

                PanelForma.Visible = true;
                PanelIspis.Visible = false;
                AppendCity();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (IsPostBack && ViewState["user"] != null)
            {
                User u = (User)ViewState["user"];
                ((IRepo)Application["database"]).AddUser(u);
                Session["user"] = u;

                var method = Request.HttpMethod.ToLower();
                RenderData(u, method);
            }
            base.OnPreRender(e);
        }

        private void AppendCity()
        {
            ddlCity.DataSource = _listOfAllCities;
            ddlCity.DataValueField = "IDCity";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();
        }

        protected void Username_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.ToLower() == "admin")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnPosalji_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User u = new User
                {
                    FName = txtFname.Text,
                    LName = txtLname.Text,
                    City = new City(int.Parse(ddlCity.SelectedItem.Value), ddlCity.SelectedItem.Text),
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                ViewState["user"] = u;
            }
        }

        private void RenderData(User u, string method)
        {
            PanelForma.Visible = false;
            PanelIspis.Visible = true;

            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='results' class='container p-4'><fieldset>");
            sb.Append($"<legend>{method.ToUpper()} request</legend>");
            sb.Append("<div class='mb-3'><label class='form-label'>First name: </label>");
            sb.Append($"<label class='fw-bold'>{u.FName}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>Last name: </label>");
            sb.Append($"<label class='fw-bold'>{u.LName}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>City: </label>");
            sb.Append($"<label class='fw-bold'>{u.City}</label>");
            sb.Append("</div>");
            sb.Append("<div class='mb-3'><label class='form-label'>Username: </label>");
            sb.Append($"<label class='fw-bold'>{u.Username}</label>");
            sb.Append("</div>");
            sb.Append($"<a href='/Dashboard.aspx' class='btn btn-primary'>Continue</a>");
            sb.Append("</fieldset></div>");

            LiteralControl ispis = new LiteralControl(sb.ToString());
            PanelIspis.Controls.Add(ispis);
        }

        protected void CheckUser_ServerValidate(object source, ServerValidateEventArgs args)
        {
            IList<User> users = ((IRepo)Application["database"]).LoadUsers();
            var user = users.SingleOrDefault(u => u.Username == args.Value);

            if (user != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}