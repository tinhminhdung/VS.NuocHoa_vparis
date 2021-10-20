using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.Page
{
    public partial class MenuPage : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        #endregion
        public string Case = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region #
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            #endregion
            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion

            #region Module
            try
            {
                if (Request["e"] != null)
                {
                    if (Request["e"].ToString() == "load")
                    {
                        Case = MoreAll.Other.RequestMenu(Request["hp"]);
                    }
                }
            }
            catch (Exception)
            {
                // Response.Redirect("/page-404.html");
            }
            #endregion

            if (!base.IsPostBack)
            {
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        protected string ShowMenuPage()
        {
            string str = "";
            List<Entity.Menu> dt2 = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "'  and  len([Level])= 5 and [Level] like '" + RequestMenuLevel(Request["hp"]) + "%'   and Views=1  and lang='" + language + "'  and status=1 order by level,Orders asc");
            if (dt2.Count > 0)
            {
                str += "<li class=\"header\"><a  href='/" + dt2[0].TangName.ToString() + ".html'>" + dt2[0].Name.ToString() + "</a></li>";
            }
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "'  and  len([Level]) >= 10 and [Level] like '" + RequestMenuLevel(Request["hp"]) + "%'   and Views=1  and lang='" + language + "'  and status=1 order by level,Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    if (More.MenuDacap(More.TangNameicid(hp)) == More.MenuDacap(item.ID.ToString()))
                    {
                        str += "<li  class=\"activer\"><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                    }
                    else
                    {
                        str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                    }
                }
            }
            return str.ToString();
        }

        public  string RequestMenuLevel(string Request)
        {
            string Modul = "";
            List<Entity.Menu> str = SMenu.Name_Text("SELECT top 1 * FROM [Menu]  where TangName='" + Request + "'");
            if (str.Count > 0 || str != null)
            {
                Modul = str[0].Level.Substring(0, 5).ToString();
            }
            return Modul;
        }
    }
}