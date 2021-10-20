using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Services;
using Framework;
using Entity;

namespace VS.E_Commerce.cms.Display
{
    public partial class Lefmenu : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        public string Case = "";
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
                }
                #endregion
                LoadItems();
            }
        }

        #region LoadItems
        void LoadItems()
        {
            List<Entity.News> dt = SNews.Name_Text("SELECT top 5 * FROM [News] WHERE Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                rpcates.DataSource = dt;
                rpcates.DataBind();
            }
            List<Entity.Products> dt1 = SProducts.Name_Text("SELECT  top 5 * FROM [Products] WHERE  Status=1  order by Create_Date desc");
            if (dt1.Count > 0)
            {
                prPronews.DataSource = dt1;
                prPronews.DataBind();
            }


        }
        #endregion


        protected string ShowMenuNews()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.NS, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    str += MenuNews(item.ID.ToString());
                    str += "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuNews(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.NS, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuNews(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
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
                        str += "<li><img  class='anhicon' src='" + item.Noidung1 + "' alt='" + item.Name + "' /><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuPro(item.ID.ToString()) + "</li>";
                    }
                    else
                    {
                        str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuPro(item.ID.ToString()) + "</li>";
                    }
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
                    str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuNews(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }


        protected string ShowVideo()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.VD, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    str += MenuVideo(item.ID.ToString());
                    str += "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuVideo(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.VD, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuNews(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }

        protected string ShowAlbum()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.AB, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>";
                    str += MenuAlbum(item.ID.ToString());
                    str += "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuAlbum(string id)
        {
            string str = "";

            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.AB, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a  href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + MenuNews(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}