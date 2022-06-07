using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
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
        private IList<User> _allUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = new User();
            _allUsers = ((IRepo)Application["database"]).LoadUsers();
            FillTable();
        }

        private void FillTable()
        {
            this.rptUsers.DataSource = _allUsers;
            this.rptUsers.DataBind();
        }
    }
}