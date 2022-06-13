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
    public partial class ApartmentPictureDeleteControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ViewState["picture"] = null;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ApartmentPicture picture = (ApartmentPicture)ViewState["picture"];
            ((IRepo)Application["databae"]).DeleteApartmentPicture(picture.Id);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        internal void FillForm(int pictureId)
        {
            var picture = ((IRepo)Application["database"]).LoadApartmentPictureById(pictureId);
            ViewState["picure"] = picture;
            this.lblTitle.Text = $"Are you sure you want to delete {(string.IsNullOrEmpty(picture.Name) ? "Unnamed picture" : picture.Name + " picture")}?";
        }
    }
}