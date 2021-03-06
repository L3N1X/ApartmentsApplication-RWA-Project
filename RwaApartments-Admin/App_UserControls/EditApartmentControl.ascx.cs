using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01.UserControls
{
    public partial class EditApartmentControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pnlConfirm.Visible = false;
            if (!IsPostBack)
            {
                FillListControls();
                Session["dbPictures"] = new List<ApartmentPicture>();

                /*Only used when editing existing apartment*/
                Session["dbPicturesToRemove"] = new List<ApartmentPicture>();
                /*Only used when editing existing apartment*/
            }
        }

        private void BindPicturesGridView()
        {
            this.gwPictures.DataSource = ((List<ApartmentPicture>)Session["dbPictures"]);
            this.gwPictures.DataBind();
            /*Set representative picture radio button in GridView*/
            ApartmentPicture representativePicture = ((List<ApartmentPicture>)Session["dbPictures"]).FirstOrDefault(picture => picture.IsRepresentative);
            if (representativePicture != null)
            {
                foreach (GridViewRow row in this.gwPictures.Rows)
                {
                    string base64content = (row.FindControl("img") as Image).ImageUrl;
                    if (representativePicture.Base64Content == base64content)
                    {
                        RadioButton radio = (row.FindControl("rbRepresentative") as RadioButton);
                        radio.Checked = true;
                    }
                }
            }
            /*Set textbox values (picture names) in GridView*/
            foreach (GridViewRow row in this.gwPictures.Rows)
            {
                Guid currentGuid = Guid.Parse((row.FindControl("guidLabel") as Label).Text);
                ApartmentPicture corespondingPicture = ((List<ApartmentPicture>)Session["dbPictures"]).FirstOrDefault(picture => picture.Guid.Equals(currentGuid));
                TextBox txtPictureName = (row.FindControl("txtImageDescription") as TextBox);
                txtPictureName.Text = corespondingPicture.Name;
            }
        }

        private void ApartmentPictureDeleteControl_DeletePictureConfirmed(object sender, EventArgs args)
        {
            Page_Load(sender, args);
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

            //Users drop down list
            this.ddlUsers.DataSource = ((IRepo)Application["database"]).LoadUsers();
            this.ddlUsers.DataValueField = "Id";
            this.ddlUsers.DataTextField = "UserName";
            this.ddlUsers.DataBind();
            this.ddlUsers.SelectedIndex = 0;
        }

        public void FillForm(int apartmentId)
        {
            var apartment = ((IRepo)Application["database"]).LoadApartmentById(apartmentId);

            Session["apartmentControlVisible"] = true;
            ViewState["apartment"] = apartment;
            ViewState["currentStatus"] = apartment.StatusId;
            Session["dbPictures"] = apartment.Pictures;

            this.BindPicturesGridView();

            this.ddlStatus.Enabled = true;
            foreach (ListItem item in cblTags.Items)
                item.Selected = false;
            this.txtApartmentName.Text = apartment.Name;
            this.txtApartmentNameEng.Text = apartment.NameEng;
            this.txtPrice.Text = ((int)apartment.Price).ToString();
            this.txtTotalRooms.Text = apartment.TotalRooms.ToString();
            this.txtAdults.Text = apartment.MaxAdults.ToString();
            this.txtChildren.Text = apartment.MaxChildren.ToString();
            this.txtBeach.Text = apartment.BeachDistance.ToString();
            this.txtAddress.Text = apartment.Address;

            foreach (var tag in apartment.Tags)
            {
                ListItem foundTag = cblTags.Items.FindByValue(tag.Id.ToString());
                foundTag.Selected = true;
            }

            this.ddlCity.SelectedValue = apartment.CityId.ToString();
            this.ddlApartmentOwner.SelectedValue = apartment.OwnerId.ToString();
            this.ddlStatus.SelectedValue = apartment.StatusId.ToString();

            this.pnlUpdate.Visible = true;
            this.pnlCreate.Visible = false;
            this.lblTitle.Text = "Edit apartment";
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.gwPictures.DataSource = null;
            this.ddlStatus.Enabled = false;

            ViewState["apartment"] = null;
            ViewState["currentStatus"] = null;

            Session["dbPictures"] = new List<ApartmentPicture>();
            Session["dbPicturesToRemove"] = new List<ApartmentPicture>();

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

            Session["apartmentControlVisible"] = false;
            Response.Redirect("/Dashboard");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.ddlStatus.Enabled = false;

            var newPictures = (List<ApartmentPicture>)Session["dbPictures"];

            foreach (ApartmentPicture picture in newPictures)
                picture.IsRepresentative = false;

            foreach (GridViewRow row in this.gwPictures.Rows)
            {
                Guid currentPictureGuid = Guid.Parse((row.FindControl("guidLabel") as Label).Text);
                string currentPictureName = (row.FindControl("txtImageDescription") as TextBox).Text;
                ApartmentPicture currentPicture = newPictures.FirstOrDefault(picture => picture.Guid.Equals(currentPictureGuid));
                currentPicture.Name = currentPictureName;
                RadioButton radio = (row.FindControl("rbRepresentative") as RadioButton);
                if (radio.Checked)
                    currentPicture.IsRepresentative = true;
            }

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
                Pictures = newPictures,
            };

            apartment.Tags = new List<Tag>();
            foreach (ListItem item in this.cblTags.Items)
            {
                if (item.Selected)
                    apartment.Tags.Add(new Tag { Id = int.Parse(item.Value) });
            }

            foreach (GridViewRow row in this.gwPictures.Rows)
            {
                RadioButton radio = (row.FindControl("rbRepresentative") as RadioButton);
                Guid currentGuid = Guid.Parse((row.FindControl("guidLabel") as Label).Text);
                ApartmentPicture corespondingPicture = apartment.Pictures.FirstOrDefault(picture => picture.Guid.Equals(currentGuid));
                if (corespondingPicture != null)
                {
                    if (radio.Checked)
                        corespondingPicture.IsRepresentative = true;
                }
            }

            ((IRepo)Application["database"]).InsertApartment(apartment);

            Session["apartmentControlVisible"] = false;

            Session["dbPictures"] = new List<ApartmentPicture>();
            Session["dbPicturesToRemove"] = new List<ApartmentPicture>();

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            this.ddlStatus.Enabled = false;
            var selectedApartment = ((Apartment)ViewState["apartment"]);
            selectedApartment.Name = this.txtApartmentName.Text.Trim();
            selectedApartment.NameEng = this.txtApartmentNameEng.Text.Trim();
            selectedApartment.Address = this.txtAddress.Text.Trim();
            selectedApartment.CreatedAt = DateTime.Now;
            selectedApartment.MaxAdults = int.Parse(this.txtAdults.Text.Trim());
            selectedApartment.MaxChildren = int.Parse(this.txtChildren.Text.Trim());
            selectedApartment.BeachDistance = int.Parse(this.txtBeach.Text.Trim());
            selectedApartment.OwnerId = int.Parse(this.ddlApartmentOwner.SelectedValue);
            selectedApartment.CityId = int.Parse(this.ddlCity.SelectedValue);
            selectedApartment.StatusId = int.Parse(this.ddlStatus.SelectedValue);
            selectedApartment.Price = decimal.Parse(this.txtPrice.Text.Trim());
            selectedApartment.TotalRooms = int.Parse(this.txtTotalRooms.Text.Trim());

            IList<Tag> tags = new List<Tag>();
            foreach (ListItem item in this.cblTags.Items)
            {
                if (item.Selected)
                    tags.Add(new Tag { Id = int.Parse(item.Value) });
            }
            selectedApartment.Tags = tags;

            selectedApartment.Pictures = ((List<ApartmentPicture>)Session["dbPictures"]);

            foreach (ApartmentPicture picture in selectedApartment.Pictures)
                picture.IsRepresentative = false;

            foreach (GridViewRow row in this.gwPictures.Rows)
            {
                Guid currentPictureGuid = Guid.Parse((row.FindControl("guidLabel") as Label).Text);
                string currentPictureName = (row.FindControl("txtImageDescription") as TextBox).Text;
                ApartmentPicture currentPicture = selectedApartment.Pictures.FirstOrDefault(picture => picture.Guid.Equals(currentPictureGuid));
                currentPicture.Name = currentPictureName;
                RadioButton radio = (row.FindControl("rbRepresentative") as RadioButton);
                if (radio.Checked)
                    currentPicture.IsRepresentative = true;
            }

            ((IRepo)Application["database"]).UpdateApartment(selectedApartment, ((List<ApartmentPicture>)Session["dbPicturesToRemove"]));

            if (this.cbGenerateNewReservation.Checked == true)
            {
                if (this.ddlUserType.SelectedValue == "registered")
                {
                    string bla = this.ddlUsers.SelectedValue;
                    /*Generate reservation with registered user*/
                    ((IRepo)Application["database"]).InsertApartmentReservation(new ApartmentReservation
                    {
                        Guid = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        ApartmentId = selectedApartment.Id,
                        Details = this.txtDetails.Text,
                        UserId = int.Parse(this.ddlUsers.SelectedValue),
                    });
                }
                else if (this.ddlUserType.SelectedValue == "not_registered")
                {
                    /*Generate resevation with unregistered user*/
                    ((IRepo)Application["database"]).InsertApartmentReservation(new ApartmentReservation
                    {
                        Guid = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        ApartmentId = selectedApartment.Id,
                        Details = this.txtDetails.Text,
                        UserEmail = this.txtEmail.Text,
                        UserName = this.txtUserName.Text,
                        UserAddress = this.txtUserAddress.Text,
                        UserPhone = this.txtPhone.Text
                    });
                }
            }
            Session["apartmentControlVisible"] = false;

            Session["dbPictures"] = new List<ApartmentPicture>();
            Session["dbPicturesToRemove"] = new List<ApartmentPicture>();

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["apartmentControlVisible"] = true;
        }

        protected void btnAddPicture_Click(object sender, EventArgs e)
        {
            Session["apartmentControlVisible"] = true;

            this.BindPicturesGridView();

            System.IO.Stream fs = this.PictureUpload.PostedFile.InputStream;
            string extention = Path.GetExtension(this.PictureUpload.PostedFile.FileName);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            byte[] bytes = br.ReadBytes((int)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            string base64databaseString = $"data:image/{extention};base64," + base64String;

            ((List<ApartmentPicture>)Session["dbPictures"]).Add(new ApartmentPicture
            {
                Guid = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Base64Content = base64databaseString,
                Name = string.Empty
            });

            this.BindPicturesGridView();

            Session["apartmentControlVisible"] = true;
        }

        protected void btnDeletePicture_Click(object sender, EventArgs e)
        {
            Session["apartmentControlVisible"] = true;
            Guid pictureToDeleteGuid = Guid.Parse(((LinkButton)sender).CommandArgument);
            ((List<ApartmentPicture>)Session["dbPicturesToRemove"]).Add(new ApartmentPicture { Guid = pictureToDeleteGuid });
            ((List<ApartmentPicture>)Session["dbPictures"]).RemoveAll(picture => picture.Guid.Equals(pictureToDeleteGuid));
            this.BindPicturesGridView();
        }
    }
}