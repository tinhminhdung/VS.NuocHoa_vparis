﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Search : System.Web.UI.UserControl
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
            if (!IsPostBack)
            {
                //if (Request["keyword"] != null && !Request["keyword"].Equals(""))
                //{
                //    keyword = Request["keyword"].ToString();
                //}
            }
            if (MoreAll.MoreAll.GetCookies("Search").ToString() != null)
            {
                LoadItems();
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
        void LoadItems()
        {

            List<Entity.Products> dt = new List<Entity.Products>();
            string keywords = "";
            if (keywords != null || keywords != "")
            {
                keywords = MoreAll.MoreAll.GetCookies("Search").ToString();
            }
            //if (MoreAll.MoreAll.GetCookies("Searchcate").ToString() != "0")
            //{
            //    dt = SProducts.SearchNewsCate(More.Sub_Menu(More.PR, MoreAll.MoreAll.GetCookies("Searchcate").ToString()), keywords, language);
            //}
            //else
            //{
            dt = SProducts.SearchNews(keywords, language);
            //}
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MorePro.Pages());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else
            {
                lterr.Text += "<div class='ttimkiem'><p style='margin-top: 0.33em'> Không tìm thấy <span style='color:Red;'> <b>" + keywords + "</b></span> trong tài liệu nào.</p><p style='margin-top: 1em'>Ðề xuất:</p><ul style='margin: 0px 0px 2em 1.3em'> <li>Xin bạn chắc chắn rằng tất cả các từ đều đúng chính tả. </li><li>Hãy thử những từ khoá khác. </li><li>Hãy thử những từ khoá chung hơn.</li></ul></div>";
            }
        }
    }
}