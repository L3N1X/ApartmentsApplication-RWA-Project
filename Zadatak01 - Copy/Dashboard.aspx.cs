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
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            if (!IsPostBack)
            {
                _allCities = ((IRepo)Application["database"]).LoadCities();
                _allStatuses = ((IRepo)Application["database"]).LoadApartmentStatus();
                FillDropDownLists();
            }
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

            LoadApartments();
        }

        private void FillDropDownLists()
        {

            this.ddlCityFilter.DataSource = _allCities;
            this.ddlCityFilter.DataValueField = "Id";
            this.ddlCityFilter.DataTextField = "Name";
            this.ddlCityFilter.DataBind();
            this.ddlCityFilter.Items.Insert(0, new ListItem(" - Any - ", "0"));

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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}