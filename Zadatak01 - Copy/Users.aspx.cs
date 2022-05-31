using rwaLib.Dal;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Users : DefaultPage
    {
        private IList<User> _listOfAllUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            _listOfAllUsers = ((IRepo)Application["database"]).LoadUsers();
            lblResult.Visible = false;

            if (!IsPostBack)
            {
                ShowUsers();
                toggleForm(false);
            } else
            {
                toggleForm(true);
            }
        }

        private void toggleForm(bool status)
        {
            txtFname.Enabled = status;
            txtFname.CssClass = "form-control";

            txtLname.Enabled = status;
            txtLname.CssClass = "form-control";

            txtUsername.Enabled = status;
            txtUsername.CssClass = "form-control";

            updateUser.Enabled = status;
            updateUser.CssClass = "btn btn-primary";
        }

        private void ShowUsers()
        {
            lbUsers.DataSource = _listOfAllUsers;
            lbUsers.DataValueField = "IDAuth";
            lbUsers.DataTextField = "FullName";
            lbUsers.DataBind();
        }

        protected void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var userId = int.Parse(lbUsers.SelectedValue);
            var selectedUser = _listOfAllUsers.SingleOrDefault(u => u.IDAuth == userId);

            if(selectedUser != null)
            {
                txtFname.Text = selectedUser.FName;
                txtLname.Text = selectedUser.LName;
                txtUsername.Text = selectedUser.Username;
            }
        }

        protected void updateUser_Click(object sender, EventArgs e)
        {
            var userId = int.Parse(lbUsers.SelectedValue);
            var selectedUser = _listOfAllUsers.SingleOrDefault(u => u.IDAuth == userId);

            selectedUser.FName = txtFname.Text;
            selectedUser.LName = txtLname.Text;
            selectedUser.Username = txtUsername.Text;

            try
            {
                // Update DB
                ((IRepo)Application["database"]).SaveUser(selectedUser);

                // Update SESSION
                if(((User)Session["user"]).IDAuth == userId)
                {
                    Session["user"] = selectedUser;
                }

                Response.Redirect(Request.Url.LocalPath);
            } catch (SqlException ex)
            {
                if (ex.Errors.Count > 0)
                {
                    switch (ex.Errors[0].Number)
                    {
                        case 2627: // Constraint violation
                            lblResult.Text = "Pogreška: Korisnik s tim korisničkim imenom postoji!";
                            lblResult.Visible = true;
                            txtUsername.Text = "";
                            break;
                    }
                }
            } catch (Exception)
            {

            }
        }
    }
}