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
                FillListControls();
        }

        private void FillListControls()
        {
            //Cities dropDownlList
            this.ddlCity.DataSource = ((IRepo)Application["database"]).LoadCities();
            this.ddlCity.DataValueField = "Id";
            this.ddlCity.DataTextField = "Name";
            this.ddlCity.DataBind();
            this.ddlCity.SelectedIndex = 0;

            //Tags checked listbox
            this.cblTags.DataSource = ((IRepo)Application["database"]).LoadTags();
            this.cblTags.DataValueField = "Id";
            this.cblTags.DataTextField = "NameEng";
            this.cblTags.DataBind();

            //Owners drop down list
            this.ddlApartmentOwner.DataSource = ((IRepo)Application["database"]).LoadApartmentOwners();
            this.ddlApartmentOwner.DataValueField = "Id";
            this.ddlApartmentOwner.DataTextField = "Name";
            this.ddlApartmentOwner.DataBind();
            this.ddlApartmentOwner.SelectedIndex = 0;

            //Status drop down list
            this.ddlStatus.DataSource = ((IRepo)Application["database"]).LoadApartmentStatus();
            this.ddlStatus.DataValueField = "Id";
            this.ddlStatus.DataTextField = "NameEng";
            this.ddlStatus.DataBind();
            this.ddlStatus.SelectedIndex = 2;
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

            this.ddlCity.SelectedValue = this._apartment.CityId.ToString();
            this.ddlApartmentOwner.SelectedValue = this._apartment.OwnerId.ToString();
            this.ddlStatus.SelectedValue = this._apartment.StatusId.ToString();

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

            this.ddlApartmentOwner.SelectedIndex = 0;
            this.ddlCity.SelectedIndex = 0;
            this.ddlStatus.SelectedIndex = 0;

            this.lblTitle.Text = "Create new apartment";

            Response.Redirect("/Dashboard");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Apartment apartment = new Apartment
            {
                Guid = Guid.NewGuid(),
                Name = this.txtApartmentName.Text.Trim(),
                NameEng = this.txtApartmentNameEng.Text.Trim(),
                Address = this.txtAddress.Text.Trim(),
                CreatedAt = DateTime.Now,
                MaxAdults = int.Parse(this.txtAdults.Text.Trim()),
                MaxChildren = int.Parse(this.txtChildren.Text.Trim()),
                BeachDistance = int.Parse(this.txtBeach.Text.Trim()),
                OwnerId = int.Parse(this.ddlApartmentOwner.SelectedValue),
                CityId = int.Parse(this.ddlCity.SelectedValue),
                StatusId = int.Parse(this.ddlStatus.SelectedValue),
                Price = decimal.Parse(this.txtPrice.Text.Trim()),
                TotalRooms = int.Parse(this.txtTotalRooms.Text.Trim()),
            };
            apartment.Tags = new List<Tag>();
            foreach (ListItem item in this.cblTags.Items)
            {
                if (item.Selected)
                    apartment.Tags.Add(new Tag { Id = int.Parse(item.Value)});
            }
            ((IRepo)Application["database"]).InsertApartment(apartment);
        }
    }
}