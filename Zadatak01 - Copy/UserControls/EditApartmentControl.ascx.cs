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
    public partial class EditApartmentControl : System.Web.UI.UserControl
    {
        private Apartment _apartment;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillDropDownLists();
        }

        private void FillDropDownLists()
        {
            //Create new apartment cites
            this.ddlCity.DataSource = ((IRepo)Application["database"]).LoadCities();
            this.ddlCity.DataValueField = "Id";
            this.ddlCity.DataTextField = "Name";
            this.ddlCity.DataBind();
            this.ddlCity.SelectedIndex = 0;

            //Tags checked listbox
            this.cblTags.DataSource = ((IRepo)Application["database"]).LoadTags();
            this.cblTags.DataValueField = "Id";
            this.cblTags.DataTextField = "Name";
            this.cblTags.DataBind();
        }

        public void FillForm(int apartmentId)
        {
            this._apartment = ((IRepo)Application["database"]).LoadApartmentById(apartmentId);
            foreach (ListItem item in cblTags.Items)
                item.Selected = false;
            this.txtApartmentName.Text = _apartment.Name;
            this.txtApartmentNameEng.Text = _apartment.NameEng;
            this.txtPrice.Text = ((int)_apartment.Price).ToString();
            this.txtTotalRooms.Text = _apartment.TotalRooms.ToString();
            this.txtAdults.Text = _apartment.MaxAdults.ToString();
            this.txtChildren.Text = _apartment.MaxChildren.ToString();
            this.txtBeach.Text = _apartment.BeachDistance.ToString();
            this.txtAddress.Text = _apartment.Address;
            foreach (var tag in _apartment.Tags)
            {
                ListItem foundTag = cblTags.Items.FindByValue(tag.Id.ToString());
                foundTag.Selected = true;
            }
            this.pnlUpdate.Visible = true;
            this.pnlCreate.Visible = false;
            this.lblTitle.Text = "Edit apartment";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            this._apartment = null;
            foreach (ListItem item in cblTags.Items)
                item.Selected = false;
            this.txtApartmentName.Text = string.Empty;
            this.txtApartmentNameEng.Text = string.Empty;
            this.txtPrice.Text = string.Empty;
            this.txtTotalRooms.Text = string.Empty;
            this.txtAdults.Text = string.Empty;
            this.txtChildren.Text = string.Empty;
            this.txtBeach.Text = string.Empty;
            this.txtAdults.Text = string.Empty;

            this.pnlCreate.Visible = true;
            this.pnlUpdate.Visible = false;

            this.lblTitle.Text = "Create new apartment";

            Response.Redirect("/Dashboard");
        }
    }
}