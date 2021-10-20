using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display
{
    public partial class Header : System.Web.UI.UserControl
    {
        string hp = "";
        int iEmptyIndex = 0;
        string nav = "";
        string Module = "";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
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
             
				// if (Request["su"] != "Search")
				// {
				//  MoreAll.MoreAll.SetCookie("Search", "", 5000);
				//  }
				//  else
				// {
				// if (MoreAll.MoreAll.GetCookies("Search").ToString() != null)
				//  {
				//   txtkeyword.Text = MoreAll.MoreAll.GetCookies("Search").ToString();
				//txtkeyword1.Text = MoreAll.MoreAll.GetCookies("Search").ToString();
				// }
				//  }
				
                #region Module
                try
                {
                    if (Request["e"] != null)
                    {
                        if (Request["e"].ToString() == "load")
                        {
                            Module = MoreAll.Other.RequestMenu(Request["hp"]);
                        }
                    }
                }
                catch (Exception)
                {
                  //  Response.Redirect("/page-404.html");
                }
               #endregion

            }
        }
     

        //protected void lnksearch_Click(object sender, EventArgs e)
        //{
        //    if ((this.txtkeyword.Text.Trim().Length <= 0) || this.txtkeyword.Text.Equals(this.label("l_search") + "..."))
        //    {
        //        return;
        //    }
        //    Response.Redirect("/Search/" + txtkeyword.Text.Replace("&nbsp;", "") + "/Search.aspx");
        //}
        //protected void lnksearch1_Click(object sender, EventArgs e)
        //{
        //    if ((this.txtkeyword1.Text.Trim().Length <= 0) || this.txtkeyword1.Text.Equals(this.label("l_search") + "..."))
        //    {
        //        return;
        //    }
        //    Response.Redirect("/Search/" + txtkeyword.Text.Replace("&nbsp;", "") + "/Search.aspx");
        //}

        #region MenuAll
        protected string MenuAll(string ID, string link, string capp)
        {
            string str = "";
            List<Entity.Menu> table = MoreAll.More.LoadMenu(ID, language, link, capp);
            if (table.Count > 0)
            {
                str += "<ul>";
                foreach (var item in table)
                {
                    str += "<li><a class='" + Active(item.Link.Replace(".html", ""), Nav_Active(), item.Type.ToString(), item.ID.ToString()) + "' href='" + More.MenuLink(item.capp.ToString(), item.Type.ToString(), item.ID.ToString(), item.TangName.ToString(), item.Link.ToString(), item.Styleshow.ToString()) + "'>" + item.Name.ToString() + "</a>";
                    str += MenuSup(item.ID.ToString(), item.Link.ToString(), item.capp.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return (str);
        }
        protected string MenuSup(string ID, string link, string capp)
        {
            string str = "";
            List<Entity.Menu> table = More.LoadMenu(ID, language, link, capp);
            if (table.Count > 0)
            {
                str += "<ul>";
                foreach (var item in table)
                {
                    str += "<li><a href='" + More.MenuLink(item.capp.ToString(), item.Type.ToString(), item.ID.ToString(), item.TangName.ToString(), item.Link.ToString(), item.Styleshow.ToString()) + "'>" + item.Name.ToString() + "</a> " + MenuSup(item.ID.ToString(), item.Link.ToString(), item.capp.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str;
        }
        private string Active(string link, string capp, string Type, string ID)
        {
            string hhp = "";
            if (Module == "100")
            {
                hhp = More.MenuDacap(More.TangNameUrl_Name(hp));
            }
            else
            {
                hhp = More.MenuDacap(More.TangNameicid(hp));
            }
            string result = "";
            #region result
            if (Type != "1")
            {
                if (Request["su"] == null && Request["e"] == null)
                {
                    if (link.IndexOf("/") > -1)
                    {
                        if (Request["su"] == null && Request["e"] == null)
                        {
                            result = "active";
                        }
                    }
                }
                else if (link.IndexOf("tin-tuc") > -1 && (capp == "NS"))
                {
                    result = "active";
                }
                else if (link.IndexOf("san-pham") > -1 && (capp == "PR"))
                {
                    result = "active";
                }
                else if (link.IndexOf("thu-vien-video") > -1 && (capp == "VD"))
                {
                    result = "active";
                }
                else if (link.IndexOf("thu-vien-anh") > -1 && (capp == "AB"))
                {
                    result = "active";
                }
                else
                {
                    if (Request["su"] != null && Request["e"] != null)
                    {
                        if (((link.Length > 1 && (Request.Url.AbsolutePath.Contains(link) || Request.RawUrl.Contains(link)))))
                        {
                            result = "active";
                        }
                    }
                }
            }
            else if (More.Sub_Menu(More.MN, More.MenuDacap(ID)) == More.Sub_Menu(More.MN, More.MenuDacap(hhp)) || ID == More.TangNameUrl_Name(hhp))
            {
                if (Request["su"] != null && Request["e"] != null)
                {
                    result = "active";
                }
            }
            #endregion
            return result;
        }
        private string Nav_Active()
        {
            string strReturn = "";
            #region strReturn
            if (Module == "1" || Module == "2")
            {
                strReturn = "NS";
            }
            else if (Module == "3" || Module == "4")
            {
                strReturn = "IF";
            }
            else if (Module == "5" || Module == "6")
            {
                strReturn = "AB";
            }
            else if (Module == "7" || Module == "8")
            {
                strReturn = "VD";
            }
            else if (Module == "20" || Module == "21" || Request["su"] == "viewcart" || Request["su"] == "msg" || Request["su"] == "Search")
            {
                strReturn = "PR";
            }
            #endregion
            return strReturn;
        }
        #endregion

        protected string MenuNews()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Parent_ID=-1  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    if (item.Parent_ID == -1)
                    {
                        if (More.TangNameicid(hp) == item.ID.ToString())
                        {
                            str += "<li><a class=\"active\" href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + SupNews(item.ID.ToString()) + "</li>";
                        }
                        else
                        {
                            str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + SupNews(item.ID.ToString()) + "</li>";
                        }
                    }
                }
            }
            return str.ToString();
        }
        protected string SupNews(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Parent_ID=" + id + "  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuNewsMobile()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Parent_ID=-1  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    if (item.Parent_ID == -1)
                    {
                        if (item.News == 1)
                        {
                            str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                        }
                        else
                        {
                            str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + SupNews(item.ID.ToString()) + "</li>";
                        }
                    }
                }
            }
            return str.ToString();
        }
        protected string MenuPro()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, "-1", "1");
            if (dt.Count > 0)
            {
                //str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    if (More.TangNameicid(hp) == item.ID.ToString())
                    {
                        str += "<li><a class=\"active\" href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                    }
                    else
                    {
                        str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                    }
                }
                //str += "</ul>";
            }
            return str.ToString();
        }
        protected string Menu_Pro(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuVideo()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.VD, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Video(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string Menu_Video(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.VD, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Video(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuAlbum()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.AB, language, "-1", "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string index()
        {
            if (Request["su"] == null && Module == "")
            {
                return "curent";
            }
            return "";
        }
        protected string sanpham()
        {
            if ((Module == "20") || Request["su"] == ("prd") || Module == "21" || Module == "22" || Request["su"] == ("Search"))
            {
                return "curent";
            }
            return "";
        }
        protected string contact()
        {
            if ((Request["su"] == "contact"))
            {
                return "curent";
            }
            return "";
        }
        protected string Hinhanh()
        {
            if ((Request["su"] == "ADetail"))
            {
                return "curent";
            }
            return "";
        }
        protected string News()
        {
            if ((Module == "1" || Module == "2") || (Request["su"] == "nws"))
            {
                return "curent";
            }
            return "";
        }
        protected void lnkthoat_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Members", "", -1);
            Response.Redirect("/");
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}