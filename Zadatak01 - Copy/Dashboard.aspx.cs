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
        //TO DO: Avoid always calling the database when refreshing
        //Add constant apartments then filter them (maybe??)

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

            SortApartments();

            LoadApartments();
        }

        private void SortApartments()
        {
            //< asp:ListItem meta:resourcekey = "liPriceLH" Selected = "True" Value = "0" > Price: low to high </ asp:ListItem >
            //                < asp:ListItem meta:resourcekey = "liPriceHL" Value = "1" > Price: high to low </ asp:ListItem >
            //                < asp:ListItem meta:resourcekey = "liRoomsLH" Value = "2" > Rooms: least to most </ asp:ListItem >
            //                < asp:ListItem meta:resourcekey = "liRoomsHL" Value = "3" > Rooms: most to least </ asp:ListItem >
            //                < asp:ListItem meta:resourcekey = "liRoomsLH" Value = "4" > Rooms: least to most </ asp:ListItem >
            //                < asp:ListItem meta:resourcekey = "liRoomsHL" Value = "5" > Rooms: most to least </ asp:ListItem >
            int sortBy = int.Parse(this.ddlSortBy.SelectedValue);
            List<Apartment> sortedApartments = new List<Apartment>(_allApartments);
            switch (sortBy)
            {
                case 0:
                    sortedApartments.Sort((left, right) => left.Price.CompareTo(right.Price));
                    break;
                case 1:
                    sortedApartments.Sort((left, right) => -left.Price.CompareTo(right.Price));
                    break;
                case 2:
                    sortedApartments.Sort((left, right) => left.TotalRooms.CompareTo(right.TotalRooms));
                    break;
                case 3:
                    sortedApartments.Sort((left, right) => -left.TotalRooms.CompareTo(right.TotalRooms));
                    break;
                case 4:
                    sortedApartments.Sort((left, right) => (left.MaxAdults + left.MaxChildren).CompareTo(right.MaxAdults + right.MaxChildren));
                    break;
                case 5:
                    sortedApartments.Sort((left, right) => -(left.MaxAdults + left.MaxChildren).CompareTo(right.MaxAdults + right.MaxChildren));
                    break;
            }
            _allApartments = sortedApartments;
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