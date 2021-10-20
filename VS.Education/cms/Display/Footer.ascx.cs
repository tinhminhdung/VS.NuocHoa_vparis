using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Data;
using Framework;
using Entity;

namespace VS.E_Commerce.cms.Display
{
    public partial class Footer : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }

            if (!base.IsPostBack)
            {
                this.ltfootercontent.Text = FooTer(language);
            }
        }
        public static string FooTer(string language)
        {
            string Pages = "";
            List<Entity.Setting> str = SSetting.GETBYALL(language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "FooTer")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}