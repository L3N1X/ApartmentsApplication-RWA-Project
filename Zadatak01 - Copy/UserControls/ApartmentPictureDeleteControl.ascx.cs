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
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ApartmentPicture pictureToDelete = (ApartmentPicture)ViewState["pictureToDelete"];
            ((List<ApartmentPicture>)Session["dbPicturesToRemove"]).Add(pictureToDelete);
            ((List<ApartmentPicture>)Session["dbPictures"]).Remove(pictureToDelete);
        }

        internal void FillForm(Guid pictureGuid)
        {
            ApartmentPicture pictureToDelete = ((List<ApartmentPicture>)Session["dbPictures"]).FirstOrDefault(picture => picture.Guid.Equals(pictureGuid));
            ViewState["pictureToDelete"] = pictureToDelete;
            this.lblTitle.Text = $"Are you sure you want to delete {(string.IsNullOrEmpty(pictureToDelete.Name) ? "unnamed picture" : pictureToDelete.Name + " picture" )}?";
        }  
    }
}