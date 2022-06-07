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
    public partial class ApartmentDeleteControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ViewState["apartment"] = null;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            Apartment apartmentToDelete = (Apartment)ViewState["apartment"];
            ((IRepo)Application["database"]).DeleteApartment(apartmentToDelete);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        internal void FillForm(int apartmentId)
        {
            var apartment = ((IRepo)Application["database"]).LoadApartmentById(apartmentId);
            this.lblTitle.Text = $"Are you sure you want to delete {apartment.NameEng}?";
            ViewState["apartment"] = apartment;
        }
    }
}