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
            _allCities = ((IRepo)Application["database"]).LoadCities();
            _allStatuses = ((IRepo)Application["database"]).LoadApartmentStatus();
            if (!IsPostBack)
            {
                FillDropDownLists();
            }
            if (Session["user"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (Session["SelectedStatusFilterValue"] == null || Session["SelectedStatusFilterValue"].ToString() == "0")
            {
                _allApartments = ((IRepo)Application["database"]).LoadApartments(a => true);
            }
            else
            {
                _allApartments = ((IRepo)Application["database"]).LoadApartments(a => a.StatusId.Equals(int.Parse(Session["SelectedStatusFilterValue"].ToString())));
            }

            LoadApartments();
        }

        private void FillDropDownLists()
        {

            this.ddlCityFilter.DataSource = _allCities;
            this.ddlCityFilter.DataValueField = "Id";
            this.ddlCityFilter.DataTextField = "Name";
            this.ddlCityFilter.DataBind();
            this.ddlCityFilter.Items.Insert(0, new ListItem(" - Any - ", "NA"));

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
            //User u = (User)Session["user"];
            //pFName.InnerText = u.FName;
            //pLName.InnerText = u.LName;
            //bUsername.InnerText = u.Username;
            base.OnPreRender(e);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void ddlStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedStatusFilterValue"] = this.ddlStatusFilter.SelectedValue;
        }
    }
}