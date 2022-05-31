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
            if (Session["SelectedStatusFilterValue"] == null)
                Session["SelectedStatusFilterValue"] = "0";
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            this.lblId.Text = Session["SelectedStatusFilterValue"].ToString();
            if (Session["SelectedStatusFilterValue"].ToString() == "0")
            {
                _allApartments = ((IRepo)Application["database"]).LoadApartments(a => true);
            }
            else
            {
                int id = int.Parse(Session["SelectedStatusFilterValue"].ToString());
                _allApartments = ((IRepo)Application["database"]).LoadApartments(a => a.StatusId.Equals(id));
            }

            LoadApartments();
        }

        private void FillDropDownLists()
        {

            this.ddlCityFilter.DataSource = _allCities;
            this.ddlCityFilter.DataValueField = "Id";
            this.ddlCityFilter.DataTextField = "Name";
            this.ddlCityFilter.DataBind();
            //this.ddlCityFilter.Items.Insert(0, new ListItem(" - Any - ", "0"));

            this.ddlStatusFilter.DataSource = _allStatuses;
            this.ddlStatusFilter.DataValueField = "Id";
            this.ddlStatusFilter.DataTextField = "NameEng";
            this.ddlStatusFilter.DataBind();
            //this.ddlStatusFilter.Items.Insert(0, new ListItem(" - Any - ", "0"));

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
            int id = int.Parse(ddlStatusFilter.SelectedValue); 
            Session["SelectedStatusFilterValue"] = this.ddlStatusFilter.SelectedValue;
        }
    }
}