using RwaApartmaniDataLayer.Models;
using RwaApartmaniDataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zadatak01
{
    public partial class Settings : DefaultPage
    {
        private IEnumerable<TagCount> _tagCounts;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}

            if (!IsPostBack)
            {
                FillTagTypeDdl();
            }

            Session["user"] = new User();

            var tagscounts = ((IRepo)Application["database"]).LoadTagsCounted();
            _tagCounts = tagscounts.Select(t => new TagCount { Id = t.Item1.Id, Name = t.Item1.Name, NameEng = t.Item1.NameEng, Count = t.Item2 });
            Filltable();


            //StringBuilder sb = new StringBuilder().Append(@"<table>");
            //foreach (var tagCount in countedTags)
            //{
            //    sb
            //        .AppendLine("<tr>")
            //        .AppendLine($"<td style='width:30%'>{tagCount.Name}</td>")
            //        .AppendLine($"<td style='width:30%'>{tagCount.Count}</td>")
            //        .AppendLine($"{(tagCount.Count == 0 ? "<td style='width:30%'>DELETE</td>" : "<td style='width:30%'></td>")}");
            //}
            //sb.AppendLine("</table>");
            //this.fieldset.InnerHtml = sb.ToString();
            //else
            //{
            //    PreselectDDLAfterRefresh();
            //}
        }

        private void FillTagTypeDdl()
        {
            var tagTypes = ((IRepo)Application["database"]).LoadTagTypes();
            this.ddlTagType.DataSource = tagTypes;
            this.ddlTagType.DataValueField = "Id";
            this.ddlTagType.DataTextField = "Name";
            this.ddlTagType.DataBind();
            this.ddlTagType.SelectedIndex = 0;
        }

        private void Filltable()
        {
            this.rptTags.DataSource = _tagCounts;
            this.rptTags.DataBind();
            foreach (RepeaterItem item in rptTags.Items)
            {
                Label countLabel = (Label)item.FindControl("lblCount");
                LinkButton button = (LinkButton)item.FindControl("btnDelete");
                int count = int.Parse(countLabel.Text);
                if (!count.Equals(0))
                    button.Style.Add("visibility", "hidden");
                   
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void rptTags_DataBinding(object sender, EventArgs e)
        {

        }

        protected void rptTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    var count = (e.Item.FindControl("count")).;
            //}
        }

        protected void btnCreateTag_Click(object sender, EventArgs e)
        {
            int tagTypeId = int.Parse(this.ddlTagType.SelectedValue);
            Tag tag = new Tag
            {
                CreatedAt = DateTime.Now,
                Guid = new Guid(),
                Name = this.txtTagName.Text,
                NameEng = this.txtTagNameEng.Text,
                TypeId = tagTypeId, 
            };
            ((IRepo)Application["database"]).InsertTag(tag);
            this.txtTagName.Text = String.Empty;
            this.txt
        }

        //private void PreselectDDLAfterRefresh()
        //{
        //    if (!IsPostBack)
        //    {
        //        ddlTheme.SelectedIndex = DDLThemeIndex;
        //        ddlLang.SelectedIndex = DDLLangIndex;
        //    }
        //}

        //protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlTheme.SelectedValue != "0")
        //    {
        //        HttpCookie cookieTheme = new HttpCookie("theme");
        //        cookieTheme.Expires.AddDays(10);
        //        cookieTheme["theme"] = ddlTheme.SelectedValue;
        //        cookieTheme["index"] = ((DropDownList)sender).SelectedIndex.ToString();
        //        Response.Cookies.Add(cookieTheme);
        //        Response.Redirect(Request.Url.LocalPath);
        //    }
        //}

        //protected void ddlLang_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlLang.SelectedValue != "0")
        //    {
        //        HttpCookie cookieLang = new HttpCookie("lang");
        //        cookieLang.Expires.AddDays(10);
        //        cookieLang["lang"] = ddlLang.SelectedValue;
        //        cookieLang["index"] = ((DropDownList)sender).SelectedIndex.ToString();
        //        Response.Cookies.Add(cookieLang);
        //        Response.Redirect(Request.Url.LocalPath);
        //    }
        //}
    }
}