using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Dashboard : DefaultPage
    {
        private IList<Apartment> _allApartments;
        private IList<City> _allCities;
        private IList<ApartmentStatus> _allStatuses;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] is null)
                Response.Redirect("/Default");
            if (Session["apartmentControlVisible"] == null || (bool)Session["apartmentControlVisible"] == false)
                this.pnlApartment.Visible = false;
            else
                this.pnlApartment.Visible = true;
            this.pnlConfirm.Visible = false;
            if (!IsPostBack)
            {
                _allCities = ((IRepo)Application["database"]).LoadCities();
                _allStatuses = ((IRepo)Application["database"]).LoadApartmentStatus();
                FillDropDownLists();
            }

            FilterAndSortApartments();
            LoadApartments();
        }

        private void FilterAndSortApartments()
        {
            int selectedStatusId = int.Parse(this.ddlStatusFilter.SelectedValue);
            int selectedCityId = int.Parse(this.ddlCityFilter.SelectedValue);

            Predicate<Apartment> statusFilter;
            Predicate<Apartment> cityFilter;

            if (selectedStatusId == 0)
                statusFilter = (apartment => true);
            else
                statusFilter = (apartment => apartment.StatusId.Equals(selectedStatusId));

            if (selectedCityId == 0)
                cityFilter = (apartment => true);
            else
                cityFilter = (apartment => apartment.CityId.Equals(selectedCityId));

            if (selectedStatusId == 0 && selectedCityId == 0)
                _allApartments = ((IRepo)Application["database"]).LoadApartments(apartment => true);

            else
                _allApartments = ((IRepo)Application["database"]).LoadApartments(statusFilter, cityFilter);

            int sortBy = int.Parse(this.ddlSortBy.SelectedValue);
            List<Apartment> sortedApartments = new List<Apartment>(_allApartments);
            
            switch (sortBy)
            {
                case 0:
                    sortedApartments.Sort(Apartment.PriceLowToHighComparison);
                    break;
                case 1:
                    sortedApartments.Sort(Apartment.PriceHighToLowComparison);
                    break;
                case 2:
                    sortedApartments.Sort(Apartment.TotalRoomsLowToHighComparison);
                    break;
                case 3:
                    sortedApartments.Sort(Apartment.TotalRoomsHighToLowComparison);
                    break;
                case 4:
                    sortedApartments.Sort(Apartment.TotalSpaceLowToHighComparison);
                    break;
                case 5:
                    sortedApartments.Sort(Apartment.TotalSpaceHighToLowComparison);
                    break;
            }
            _allApartments = sortedApartments;
        }

        private void FillDropDownLists()
        {
            //City filter
            this.ddlCityFilter.DataSource = _allCities;
            this.ddlCityFilter.DataValueField = "Id";
            this.ddlCityFilter.DataTextField = "Name";
            this.ddlCityFilter.DataBind();
            this.ddlCityFilter.Items.Insert(0, new ListItem(" - Any - ", "0"));

            //Status filter
            this.ddlStatusFilter.DataSource = _allStatuses;
            this.ddlStatusFilter.DataValueField = "Id";
            this.ddlStatusFilter.DataTextField = "NameEng";
            this.ddlStatusFilter.DataBind();
            this.ddlStatusFilter.Items.Insert(0, new ListItem(" - Any - ", "0"));

        }

        private void LoadApartments()
        {
            this.rptApartments.DataSource = _allApartments;
            rptApartments.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int apartmentId = int.Parse(((LinkButton)sender).CommandArgument);
            this.EditApartmentControl.FillForm(apartmentId);
            this.pnlApartment.Visible = true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Session["apartmentControlVisible"] = true;
            this.pnlApartment.Visible = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int apartmentId = int.Parse(((LinkButton)sender).CommandArgument);
            this.ApartmentDeleteControl.FillForm(apartmentId);
            pnlConfirm.Visible = true;
        }
    }
}