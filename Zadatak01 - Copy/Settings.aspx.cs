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
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("Default.aspx");
            //}
            Session["user"] = new User();
            var tagscounts = ((IRepo)Application["database"]).LoadTagsCounted();
            var countedTags = tagscounts.Select(t => new TagCount { Name = t.Item1.Name, NameEng = t.Item1.NameEng, Count = t.Item2 });
            StringBuilder sb = new StringBuilder().Append(@"<table>");
            foreach (var tagCount in countedTags)
            {
                sb
                    .AppendLine("<tr>")
                    .AppendLine($"<td style='width:30%'>{tagCount.Name}</td>")
                    .AppendLine($"<td style='width:30%'>{tagCount.Count}</td>")
                    .AppendLine($"{(tagCount.Count == 0 ? "<td style='width:30%'>DELETE</td>" : "<td style='width:30%'></td>")}");
            }
            sb.AppendLine("</table>");
            this.fieldset.InnerHtml = sb.ToString();
            //else
            //{
            //    PreselectDDLAfterRefresh();
            //}
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