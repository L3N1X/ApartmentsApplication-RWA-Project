using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01.UserControls
{
    public partial class CreateTagControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillTagTypeDdl();
        }

        protected void btnCreateTag_Click(object sender, EventArgs e)
        {
            int tagTypeId = int.Parse(this.ddlTagType.SelectedValue);
            Tag tag = new Tag
            {
                CreatedAt = DateTime.Now,
                Guid = new Guid(),
                Name = this.txtTagName.Text,
                NameEng = this.txtTagNameEng.Text,
                TypeId = tagTypeId,
            };
            ((IRepo)Application["database"]).InsertTag(tag);
            this.txtTagName.Text = String.Empty;
            this.txtTagNameEng.Text = String.Empty;
            this.ddlTagType.SelectedIndex = 0;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void FillTagTypeDdl()
        {
            var tagTypes = ((IRepo)Application["database"]).LoadTagTypes();
            this.ddlTagType.DataSource = tagTypes;
            this.ddlTagType.DataValueField = "Id";
            this.ddlTagType.DataTextField = "NameEng";
            this.ddlTagType.DataBind();
            this.ddlTagType.SelectedIndex = 0;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}