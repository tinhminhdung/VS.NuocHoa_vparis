using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display
{
    public partial class Menu_Xo : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        #endregion

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
            if (!base.IsPostBack)
            {
            }
        }

        protected string ShowMenuProduts()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    if (item.Noidung1.Length > 0)
                    {
                        str += "<li><img  class='anhicon' src='" + item.Noidung1 + "' alt='" + item.Name + "' /><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    }
                    else
                    {
                        str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    }

                    str += MenuPro(item.ID.ToString());
                    str += "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuPro(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuPro(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
    }
}