using System;

namespace Zadatak01
{
    public class DefaultPage : System.Web.UI.Page
    {
        public int DDLThemeIndex
        {
            get
            {
                if (Request.Cookies["theme"] != null)
                {
                    if (Request.Cookies["theme"]["index"] != null)
                    {
                        return int.Parse(Request.Cookies["theme"]["index"]);
                    }
                }
                return 0;
            }
            set
            {
                Request.Cookies["theme"]["index"] = value.ToString();
            }
        }

        public int DDLLangIndex
        {
            get
            {
                if (Request.Cookies["lang"] != null)
                {
                    if (Request.Cookies["lang"]["index"] != null)
                    {
                        return int.Parse(Request.Cookies["lang"]["index"]);
                    }
                }
                return 0;
            }
            set
            {
                Request.Cookies["lang"]["index"] = value.ToString();
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (Request.Cookies["theme"] != null)
            {
                if (Request.Cookies["theme"]["theme"] != null)
                {
                    Theme = Request.Cookies["theme"]["theme"];
                }
            }
            base.OnPreInit(e);
        }

        public DefaultPage()
        {

        }
    }
}