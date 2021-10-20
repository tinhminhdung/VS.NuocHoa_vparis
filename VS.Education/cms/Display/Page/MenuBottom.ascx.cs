﻿using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.Page
{
    public partial class MenuBottom : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        #endregion
        string hp = "";
        int iEmptyIndex = 0;
        DatalinqDataContext db = new DatalinqDataContext();
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

            if (!IsPostBack)
            {
            }
        }

        protected string bindmenu()
        {
            string str = "";
            List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=2 and status=1 order by level,Orders asc");//Views là vị trí menu top
            table = table.Where(s => s.Level.Length == 5).ToList();
            if (table.Count > 0)
            {
                for (int i = 0; i < table.Count; i++)
                {
                    string Link = "";
                    if (table[i].ShowID == 2)
                    {
                        Link = "/" + table[i].TangName + ".html";
                    }
                    else if (table[i].ShowID == 3)
                    {
                        Link = table[i].Link;
                    }
                    else
                    {
                        if (table[i].Link == "/")
                        {
                            Link = table[i].Link;
                        }
                        else
                        {
                            Link = "/" + table[i].Link;
                        }
                    }
                    str += "<div class=\"col-xs-12 col-sm-6 col-lg-2\">";
                    str += "<div class=\"footer-widget\">";
                    str += "<h3 class=\"hastog\"><span>" + table[i].Name.ToString() + "</span></h3>";
                    str += submenu(table[i].Level.ToString());
                    str += "</div>";
                    str += "</div>";

                }
            }
            return (str);
        }
        protected string submenu(string id)
        {
            string str = "<ul class=\"list-menu list-blogs\">";
            List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=2 and status=1 and  len([Level]) >= 10 and [Level] like '" + id + "%'  order by level,Orders asc");//Views là vị trí menu top
            if (list.Count > 0)
            {
                foreach (Entity.Menu item in list)
                {
                    string Link = "";
                    if (item.ShowID == 2)
                    {
                        Link = "/" + item.TangName + ".html";
                    }
                    else if (item.ShowID == 3)
                    {
                        Link = item.Link;
                    }
                    else
                    {
                        if (item.Link == "/")
                        {
                            Link = item.Link;
                        }
                        else
                        {
                            Link = "/" + item.Link;
                        }
                    }
                    str += "<li><a  href='" + Link + "'>" + item.Name.ToString() + "</a></li>";
                }
            }
            str += "</ul>";
            return str.ToString();
        }
        public string MenuDacap(string cat)
        {
            string str = "";
            List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.MN + "' and lang='" + language + "' and Views=2 and status=1 and  len([Level]) >= 10 and [Level] like '" + cat + "%'  order by level,Orders asc");//Views là vị trí menu top
            if (list.Count > 0)
            {
                return list[0].Level.Substring(0, 5).ToString();
            }
            return str;
        }
    }
}