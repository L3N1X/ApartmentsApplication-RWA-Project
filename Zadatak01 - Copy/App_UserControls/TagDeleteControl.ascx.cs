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
    public partial class TagDeleteControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ViewState["tag"] = null;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Tag tagToDelete = (Tag)ViewState["tag"];
            ((IRepo)Application["database"]).DeleteTag(tagToDelete.Id);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        internal void FillForm(int tagId)
        {
            var tag = ((IRepo)Application["database"]).LoadTagById(tagId);
            this.lblTitle.Text = $"Are you sure you want to delete {tag.NameEng}?";
            ViewState["tag"] = tag;
        }
    }
}