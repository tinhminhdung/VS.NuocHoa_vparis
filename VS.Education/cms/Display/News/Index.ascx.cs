﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.News
{
    public partial class Index : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
       
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session
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
            if (!IsPostBack)
            {
            }
            LoadItems();
        }

        #region LoadItems
        void LoadItems()
        {
            List<Entity.News> dt = SNews.INDEX(language, "1");
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MoreNews.page());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else lterr.Text = "<div style='color:Red; font-weight:bold; text-align:center; margin-bottom:10px; padding-top:10px'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
        }
        #endregion

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        // load menu dạng đa cấp như trang thuongdinhyen.vn
        ///<%#LoadUrl(Eval("icid").ToString()) %>
        protected string LoadUrl(string ID)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            string nav = "";
            try
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(ID));
                if (item != null)
                {
                    nav += item.TangName.ToString();
                    if (item.Parent_ID != -1)
                    {
                        var item2 = db.Menus.FirstOrDefault(s => s.ID == int.Parse(item.Parent_ID.ToString()));
                        if (item2 != null)
                        {
                            nav += "/" + item2.TangName.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return nav;
        }
    }
}