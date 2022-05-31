using rwaLib.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApartmentTags = rwaLib.Models.Tags;

namespace Zadatak01
{
    public partial class Tags : DefaultPage
    {
        private IList<ApartmentTags> _listOfAlltags;
        protected void Page_Load(object sender, EventArgs e)
        {
            _listOfAlltags = ((DBRepo)Application["database"]).LoadTags();
            if (!IsPostBack) LoadData();
        }

        private void LoadData()
        {
            this.rptTags.DataSource = _listOfAlltags;
            this.rptTags.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            int tagID = int.Parse(button.CommandArgument);
            this.gwApartments.DataSource = ((DBRepo)Application["database"]).LoadApartmentsByTagId(tagID);    
        }
    }
}