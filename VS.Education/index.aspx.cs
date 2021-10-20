﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Framework;
using System.Web.UI.HtmlControls;
using Services;
using MoreAll.Templates;
using System.Net;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Entity;
using AjaxPro;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Xml;


namespace VS.E_Commerce
{
    public partial class index1 : System.Web.UI.Page
    {
        public static int counter;
        public string hp = "";
        public string Modul = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        string ssl = "http://";
        string Rating = "";
        string link = "";
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
            #region Sét link giới thiệu
            if (Request["link"] != null && !Request["link"].Equals(""))
            {
                link = Request["link"].ToString();//lấy ID qua Request
                if (Request.RawUrl.Contains("?link="))
                {
                    Response.Redirect("/dang-ky.html?info=" + link + "");
                }
            }
            #endregion

            if (!base.IsPostBack)
            {
                if (MoreAll.Other.Giatri("SSL").Equals("1"))
                {
                    ssl = "https://";
                }

                dhShowTrangThai.Value = ShowTrangThai();

                #region Page_404
                if (MoreAll.Other.Giatri("ErrPage").Equals("1"))
                {
                    try
                    {
                        if (Response.StatusCode == 404)
                        {
                            Response.Redirect("/page-404");
                        }
                    }
                    catch (Exception)
                    { }
                    //try
                    //{
                    //    string bc = Request.Url.Authority + Request.RawUrl.ToString();
                    //    if (bc.Contains("?404"))
                    //    {
                    //        Response.Redirect("/page-404.html");
                    //    }
                    //}
                    //catch (Exception)
                    //{ }
                }
                #endregion

                #region Request["hp"] && Page_404
                #region Request["hp"]
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
                #region ErrPage and Redirect Status 301
                if (MoreAll.Other.Giatri("ErrPage").Equals("1"))
                {
                    try
                    {
                        if (Request["e"] != null)
                        {
                            if (Request["e"].ToString() == "load")
                            {
                                Modul = MoreAll.Other.RequestMenu(Request["hp"]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string bc = Request.Url.Authority + Request.RawUrl.ToString();
                        if (!bc.Contains("localhost"))
                        {
                            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu] where capp='" + More.SC + "' and lang='" + language + "' and Status=1  and Name='" + ssl + Request.Url.Host + Request.RawUrl + "'");
                            if (dt.Count > 0)
                            {
                                Response.Redirect(dt[0].Description);
                            }
                        }
                        //  Response.Redirect("/page-404.html");
                    }
                }
                else
                {
                    if (Request["e"] != null)
                    {
                        if (Request["e"].ToString() == "load")
                        {
                            Modul = MoreAll.Other.RequestMenu(Request["hp"]);
                        }
                    }
                }
                #endregion
                #endregion

                #region MetaFacebook
                ltFacebook.Text += MoreAll.Templates.Templates.Facebook(ssl + Request.Url.Host, hp, Modul);
                ltFacebook.Text += "<link rel=\"alternate\" href=\"" + ssl + Request.Url.Host + "\" hreflang=\"vi-vn\" />";
                ltFacebook.Text += "<meta property=\"article:author\" content=\"" + MoreAll.Other.Facebook() + "\" />";
                if (Request["su"] == null && Request["e"] == null)
                {
                    ltFacebook.Text += "<link  rel=\"canonical\" href=\"" + ssl + Request.Url.Host + "\" />";
                }
                else
                {
                    ltFacebook.Text += "<link  rel=\"canonical\" href=\"" + ssl + Request.Url.Host + "/" + hp + ".html\" />";
                }
                if (Other.Icon().Length > 0)
                {
                    ltFacebook.Text += "<link rel='icon' href='" + Other.Icon() + "' type='image/x-icon' /><link rel='shortcut icon' href='" + Other.Icon() + "' type='image/x-icon' />";
                    //ltFacebook.Text += "<link rel=\"icon\" type=\"image/x-icon\" href=\"http://" + Request.Url.Host + "" + Other.Icon() + "\"/>";
                }
                if (MoreAll.Other.Giatri("txtfbapp_id") != "")
                {
                    string fbapp = MoreAll.Other.Giatri("txtfbapp_id") != "0" ? MoreAll.Other.Giatri("txtfbapp_id") : "429741320382398";
                    ltFacebook.Text += "<div id=\"fb-root\"></div><script>(function(d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = \"https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.6&appId=" + fbapp + "\"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>";
                }
                if (Other.GoogleAnalytics() != "")
                {
                    ltFacebook.Text += "<script> (function (i, s, o, g, r, a, m) { i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () { (i[r].q = i[r].q || []).push(arguments) }, i[r].l = 1 * new Date(); a = s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m) })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga'); ga('create', '" + Other.GoogleAnalytics() + "', 'auto'); ga('send', 'pageview'); </script>";
                }
                if (MoreAll.Other.Giatri("head") != "")
                {
                    ltFacebook.Text += MoreAll.Other.Giatri("head");
                }
                if (MoreAll.Other.Giatri("body") != "")
                {
                    ltShowbody.Text = MoreAll.Other.Giatri("body");
                }
                #endregion

                #region ReviewRating
                Rating += "<script type=\"application/ld+json\">";
                Rating += "    {";
                Rating += "        \"@context\": \"https://schema.org/\",";
                Rating += "        \"@type\": \"Review\",";
                Rating += "        \"itemReviewed\": {";
                Rating += "            \"@type\": \"Thing\",";
                Rating += "            \"name\": \"" + MoreAll.Other.Giatri("webname") + "\"";
                Rating += "        },";
                Rating += "        \"author\": {";
                Rating += "            \"@type\": \"Person\",";
                Rating += "            \"name\": \"79850 người\"";
                Rating += "        },";
                Rating += "        \"reviewRating\": {";
                Rating += "            \"@type\": \"Rating\",";
                Rating += "            \"ratingValue\": \"56970\",";
                Rating += "            \"bestRating\": \"79850\"";
                Rating += "        },";
                Rating += "        \"publisher\": {";
                Rating += "            \"@type\": \"Organization\",";
                Rating += "            \"name\": \"" + MoreAll.Other.Giatri("webname") + "\"";
                Rating += "        }";
                Rating += "    }";
                Rating += "</script>";
                ltFacebook.Text += Rating;
                #endregion

                #region Thống kê truy cập
                //counter++;
                //if (!base.IsPostBack && MoreAll.MoreAll.GetCookie("Counter").Equals(""))
                //{
                //    Fweb_statistic obj = new Fweb_statistic();
                //    obj.UpdateCounter();
                //    MoreAll.MoreAll.SetCookie("Counter", "1", 1);
                //}
                //if ((counter % 50) == 0)
                //{
                //    Fweb_statistic obj = new Fweb_statistic();
                //    obj.UpdateHitsCounter();
                //}
                #endregion

                #region Sitemap
                string bcs = Request.Url.Authority + Request.RawUrl.ToString();
                if (!bcs.Contains("localhost"))
                {
                    if (Session["Sitemap"] != "Sitemap")
                    {
                        ShowSitemap();
                        System.Web.HttpContext.Current.Session["Sitemap"] = "Sitemap";
                    }
                }
                #endregion

                #region On Off Website
                if (OnOffs.StatusOnOff().Equals("1"))
                {
                    Response.Redirect("/cms/display/OnOff/index.aspx");
                }
                #endregion

                #region HtmlMeta
                HtmlMeta child = new HtmlMeta();
                child.Name = "keywords";
                child.Content = Templates.Keyword(hp, Modul);
                base.Header.Controls.Add(child);
                HtmlMeta meta2 = new HtmlMeta();
                meta2.Name = "description";
                meta2.Content = Templates.Description(hp, Modul);
                base.Header.Controls.Add(meta2);
                #endregion

                #region Viphamcontent
                if (!base.IsPostBack)
                {
                    try
                    {
                        website();
                    }
                    catch (Exception)
                    { }
                }
                #endregion
            }
        }

        public void website()
        {
            string bc = Request.Url.Authority + Request.RawUrl.ToString();
            if (!bc.Contains("localhost"))
            {
                if (Request["su"] == null)
                {
                    string Chuoi = "";//abc.com','abc.org.vn
                    Chuoi = MoreAll.Other.website().ToString();
                    List<Setting> dt = SSetting.Name_Text("select * from Setting where Properties='website' and Lang='" + language + "' and '" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "' in('" + Chuoi + "')");
                    if (dt.Count == 0)
                    {
                        //if (MoreAll.Other.Giatri("Email").Equals("1"))
                        //{ }
                        Senmail();
                    }
                    if (MoreAll.Other.Giatri("Thongbao").Equals("1"))
                    {
                        if (MoreAll.Other.Giatri("Show").Length > 5)
                        {
                            Response.Write("<div style='display : block ! important;visibility : visible ! important;margin : 0 auto 10px ;position : relative ! important;z-index : 2147483647 ! important;width : 1000px;color:#fff; Background:#ffcb08; width:100%; padding:20px; border-radius:5px;'>" + MoreAll.Other.Giatri("Show") + "</div>");
                        }
                    }
                    else if (MoreAll.Other.Giatri("Thongbao").Equals("2"))
                    {
                        Response.Write("<div style='display : block ! important;visibility : visible ! important;margin : 0 auto 10px ;position : relative ! important;z-index : 2147483647 ! important;width : 1000px;color:#fff; Background:#ffcb08; width:100%; padding:20px; border-radius:5px;'>Vi phạm bản quyền nhân website. mà chưa được sự đồng ý của chủ web. Alo cho Lập trình để biết thêm thông tin chi tiết tại sao nhé?. 097.665.8433</div>");
                    }

                    if (MoreAll.Other.Giatri("Redirectwebsite") != "")
                    {
                        Response.Redirect(ssl + MoreAll.Other.Giatri("Redirectwebsite"));
                    }
                }
            }
        }

        void Senmail()
        {
            try
            {
                string title = "";
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
                strb.AppendLine("<div style=\"font-size:12px; font-weight:bold; text-align:center; color:#F00; text-decoration:underline;text-transform:uppercase;\">Website Vi phạm bản quyền của web site : " + MoreAll.Other.website() + "</div> ");
                strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + " - " + DateTime.Now + "</div>");
                string email = Email.email();
                string password = Email.password();
                int port = Convert.ToInt32(Email.port());
                string host = Email.host();
                MailUtilities.SendMail("Website Vi phạm bản quyền (Email TestSystemWeb): " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", "TestSystemWeb@gmail.com", "Abc12345^&*", "nvietdung1109@gmail.com", host, port, "Website Vi phạm bản quyền : " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", strb.ToString());
            }
            catch (Exception)
            {
                try
                {
                    System.Text.StringBuilder strb = new System.Text.StringBuilder();
                    strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
                    strb.AppendLine("<div style=\"font-size:12px; font-weight:bold; text-align:center; color:#F00; text-decoration:underline;text-transform:uppercase;\">Website Vi phạm bản quyền của web site : " + MoreAll.Other.website() + "</div> ");
                    strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + " - " + DateTime.Now + "</div>");
                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();
                    MailUtilities.SendMail("Website Vi phạm bản quyền (Email khách): " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", email, password, "nvietdung1109@gmail.com", host, port, "Website Vi phạm bản quyền : " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", strb.ToString());
                }
                catch (Exception)
                {

                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        [WebMethod]
        public static string Updatequantity(string id, string quantity)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            return Cart_Updatequantity(ref dtcart, id, quantity);
        }

        protected static string Cart_Updatequantity(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["quantity"] = quantity;
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(dtcart.Rows[i]["Price"].ToString());
                        // return "";
                    }
                }
            }
            return "";
        }

        [WebMethod]
        public static string DeleteShopCart(string id, string quantity)
        {
            return ShoppingCart_RemoveProduct(id.ToString());
        }

        protected static string ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            return "";
        }

        [WebMethod]
        public static string Up_Order(string id, string quantity)
        {
            return ShoppingCart_AddProduct(id.ToString(), int.Parse(quantity));
        }
        protected static string ShoppingCart_AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                SessionCarts.ShoppingCreateCart();
                ShoppingCart_AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    string TrangThai = dt[0].News.ToString();
                    Double TinhTienLoiNhuan = Convert.ToDouble(SessionCarts.Tinh_TienLoiNhuan(dt[0].Price.ToString(), dt[0].OldPrice.ToString()));


                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float price = Convert.ToSingle(dt[0].Price);
                        float money = price * quantity;
                        Double TinhTienLoiNhuans = Convert.ToDouble(TinhTienLoiNhuan) * quantity;

                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["Mausac"] = "0";
                                dtcart.Rows[i]["Kichco"] = "0";
                                dtcart.Rows[i]["TienLoiNhuan"] = Convert.ToInt32(quantity) * TinhTienLoiNhuan;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = "0";
                                dr["Kichco"] = "0";
                                dr["TienLoiNhuan"] = TinhTienLoiNhuans;
                                dr["TrangThai"] = TrangThai;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float price = Convert.ToSingle(0);
                        float money = price * quantity;
                        Double TinhTienLoiNhuans = Convert.ToDouble(TinhTienLoiNhuan) * quantity;

                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["Mausac"] = "0";
                                dtcart.Rows[i]["Kichco"] = "0";
                                dtcart.Rows[i]["TienLoiNhuan"] = Convert.ToInt32(quantity) * TinhTienLoiNhuan;
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Mausac"] = "0";
                                dr["Kichco"] = "0";
                                dr["TienLoiNhuan"] = TinhTienLoiNhuans;
                                dr["TrangThai"] = TrangThai;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }
            return "";
        }

        [WebMethod]
        public static string ShowTrangThai()
        {
            string Chuoi = "2";
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        return dtcart.Rows[i]["TrangThai"].ToString();
                    }
                }
            }
            return Chuoi;
        }

        [WebMethod]
        public static string LogonGoogle(string ID, string FullName, string Email, string Image)
        {
            System.Web.HttpContext.Current.Session["Google"] = ID + ";" + FullName + ";" + Email + ";" + Image;

            return "";
        }

        [WebMethod]
        public static string Up_KichCo(string id, string quantity)
        {
            return Session_Size(id.ToString());
        }

        protected static string Session_Size(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_Size"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_Size"] = pid.ToString();
            return "";
        }

        [WebMethod]
        public static string Up_MauSac(string id, string quantity)
        {
            return Session_MauSac(id.ToString());
        }

        protected static string Session_MauSac(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_MauSac"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_MauSac"] = pid.ToString();
            return "";
        }

        [WebMethod]
        public static string ShowCart()
        {
            string str = "";
            string tongien = "0";
            string sosp = "0";
            string inumofproducts = "0";
            string totalvnd = "0";
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "<div id=\"Loadingshop\">";
                    str += "<div class=\"inner\"><img src=\"/Resources/ShopCart/images/ajax-loader_2.gif\"><p>Đang xử lý...</p></div>";
                    str += "</div>";
                    str += "<div class=\"title\">";
                    str += "<div class=\"tl txt_b\">Giỏ hàng của bạn (<span class=\"shopping_cart_item\">" + Services.SessionCarts.LoadCart() + "</span> sản phẩm)</div>";
                    str += "<input id=\"temp_total\" value=\"0\" type=\"hidden\">";
                    str += "</div>";
                    str += "<table class=\"tbl_cart\" style=\"\" cellpadding=\"5\">";
                    str += "<tbody>";
                    str += "<tr id=\"shopping-cart-first-row\" class=\"txt_u txt_14 txt_b\">";
                    str += "<td style=\"\">Sản phẩm</td>";
                    str += "<td style=\"\" class=\"shopping-cart-price-col\">Đơn giá</td>";
                    str += "<td class=\"shopping-cart-quantity-col center\">Số lượng</td>";
                    str += "<td style=\"text-align: right;\" class=\"shopping-cart-sum-col\">Thành tiền</td>";
                    str += "</tr>";
                    if (dtcart.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                            num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    tongien = MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                    sosp = inumofproducts;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        str += "<tr id=\"itm17876\">";
                        str += "<td style=\"text-align: left;\">";
                        str += "<div class=\"cartInfo-img fl\">";
                        str += "<img src=\"" + dtcart.Rows[i]["Vimg"].ToString() + "\" style=\"vertical-align: middle; margin-right: 10px;width:60px;\">";
                        str += "</div>";
                        str += "<div class=\"sum\">";
                        str += "<div class=\"cartInfo-name\">";
                        str += "<a class=\"\" target=_blank href=\"" + MoreAll.MorePro.LoadLink(dtcart.Rows[i]["PID"].ToString()) + "\"><b>" + dtcart.Rows[i]["Name"].ToString() + "</b></a>";
                        str += "<br>";
                        str += "</div>";
                        str += "<a class=\"i-del shows\" onclick=\"AJdeleteShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "')\"><img src=\"/Resources/ShopCart/images/xoa.png\" /> Bỏ sản phẩm</a>";
                        str += "</div>";
                        str += "</td>";
                        str += "<td style=\"\">";
                        str += "<span id=\"sell_price_pro_17876\">" + MoreAll.MorePro.FormatMoneyCart(dtcart.Rows[i]["Price"].ToString()) + "</span>";
                        str += "<br><span class=\"txt_d\">" + ShopGiacu(dtcart.Rows[i]["PID"].ToString()) + "</span>";
                        str += "<br><span class=\"txt_pink\">" + MoreAll.MorePro.Tietkiem(dtcart.Rows[i]["PID"].ToString()) + "</span>";
                        str += "</td>";
                        str += "<td class=\"center\">";
                        //data-abc='123'
                        str += "<input type=\"number\" max=\"999\" min=\"0\" style=\" width:50px\"  value=\"" + dtcart.Rows[i]["Quantity"].ToString() + "\" onchange=\"AddShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "',$(this))\" class=\"txt_center cor3px shows\">";
                        str += "</td>";
                        str += "<td style=\"text-align: right;\">";
                        str += "<span id=\"price_pro_17876\">" + MoreAll.MorePro.FormatMoneyCart(dtcart.Rows[i]["Money"].ToString()) + "</span>";
                        str += "</td>";
                        str += "</tr>";
                    }

                    str += "<tr>";
                    str += "<td colspan=\"5\" class=\"txt_right\">";
                    str += "<div style=\"line-height: 26px;\">";
                    str += "Tổng cộng : <span class=\"sub1 txt_18 txt_pink total_value_step txt_b\" id=\"total_value\" data-value=\"" + tongien + "\">" + tongien + "</span><br>";
                    str += "<span id=\"other-discount\">Tổng số sản phẩm: <span data-discount=\"0\" id=\"price-discount\" class=\"txt_pink\">" + sosp + "</span></span><br>";
                    str += "<span>Thanh toán: <span id=\"total_shopping_price\" class=\"txt_pink txt_b total_value_step\">" + tongien + "</span></span>";
                    str += "<br>Giá đã bao gồm VAT";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "<tr>";
                    str += "<td colspan=\"4\" class=\"txt_right\">";
                    str += "<a href=\"/\" class=\"txt_pink txt_18 txt_b\" style=\"float:left;\"><i class=\"fa fa-angle-left\"></i> Tiếp tục mua hàng</a>";
                    str += "<div style=\"float:right;\">";
                    //str += "<a class=\"btn bg_pink txt_center txt_20 txt_u\" href=\"/gio-hang.html\" style=\"padding:5px 50px;\">";
                    //str += "MUA ONLINE<br> <span class=\"txt_12\" style=\"text-transform: none;\">(giao hàng tận nơi)</span>";
                    //str += "</a>";
                    str += "<a class=\"adrbutton tienhanh\" href=\"/gio-hang.html\" >Tiến hành đặt hàng</a>";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "</tbody>";
                    str += "</table>";
                    str += "</div> ";
                }
                else
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "  <div class=\"num0\">";
                    str += " <div class=\"modalbodys cart_body\">";
                    str += "<i class=\"icon_cart\"></i>";
                    str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                    str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                    str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                    str += " </div>";
                    str += "  </div>";
                    str += "</div> ";
                }
            }
            else
            {
                str += "<div class=\"shop_cart ajax\">";
                str += "  <div class=\"num0\">";
                str += " <div class=\"modalbodys cart_body\">";
                str += "<i class=\"icon_cart\"></i>";
                str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                str += " </div>";
                str += "  </div>";
                str += "</div> ";
            }
            return str.ToString();
        }

        public static string ShopGiacu(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                if (dt[0].OldPrice.ToString().Length > 0)
                {
                    str = MorePro.Detail_Price(dt[0].OldPrice.ToString()) + " đ";
                }
            }
            return str.ToString();
        }

        [WebMethod]
        public static string LoadCart()
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable cartdetail = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (cartdetail.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    if (cartdetail.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < cartdetail.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(cartdetail.Rows[i]["Money"].ToString());
                            num2 += Convert.ToInt32(cartdetail.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    return inumofproducts;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        //[WebMethod]
        //public static string[] GetCustomers(string prefix, string condition)
        //{
        //    List<string> customers = new List<string>();
        //    string strWhere = "";

        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "Select  top 15  Name from products where dbo.fuConvertToUnsign(Name) LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(prefix)) + "'" + strWhere;
        //            cmd.Connection = conn;
        //            conn.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    customers.Add(sdr["Name"].ToString());
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    return customers.ToArray();
        //}

        [WebMethod]
        public static List<resultAutocomplete> GetAutocomplete(string prefix, string condition)
        {
            List<resultAutocomplete> customers = new List<resultAutocomplete>();
            string strWhere = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select  top 15  TangName,Name,ImagesSmall,Price,OldPrice from products where dbo.fuConvertToUnsign(Name) LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(prefix)) + "'" + strWhere;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            resultAutocomplete obj = new resultAutocomplete();
                            obj.TangName = sdr["TangName"].ToString();
                            obj.Name = sdr["Name"].ToString();
                            obj.ImagesSmall = sdr["ImagesSmall"].ToString();
                            obj.Price = MoreAll.MorePro.FormatMoney_Cart_Total(sdr["Price"].ToString());
                            obj.OldPrice = MoreAll.MorePro.FormatMoney_Cart_Total(sdr["OldPrice"].ToString());
                            customers.Add(obj);
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToList();
        }
        public class resultAutocomplete
        {
            public string TangName { get; set; }
            public string Name { get; set; }
            public string ImagesSmall { get; set; }
            public string Price { get; set; }
            public string OldPrice { get; set; }
        }

        public class SearchApproximate
        {
            // Phương thức chuyển đổi một chuỗi ký tự: Nếu chuỗi đó có ký tự " " sẽ thay thế bằng "%"
            public static string Exec(string keyWord)
            {
                string[] arrWord = keyWord.Split(' ');
                StringBuilder str = new StringBuilder("%");
                for (int i = 0; i < arrWord.Length; i++)
                {
                    str.Append(arrWord[i] + "%");
                }
                return str.ToString();
            }
        }

        public class ConvertVN
        {
            // Phương thức Convert một chuỗi ký tự Có dấu sang Không dấu
            public static string Convert(string chucodau)
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = chucodau.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(chucodau[index]);
                    chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
                }
                return chucodau;
            }
        }
        void ShowSitemap()
        {
            try
            {
                string dsd = Server.MapPath("~");
                string Url = ssl + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/";
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
                using (XmlWriter writer = XmlWriter.Create(dsd + "\\sitemap.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                    writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xsi", "schemaLocation", null, "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

                    #region Home
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url);
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion

                    #region Products
                    List<Entity.Products> list1 = SProducts.GetByAll(language);
                    foreach (var its in list1)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + its.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region News
                    List<Entity.News> list45 = SNews.GETBYALL(language);
                    foreach (var its in list45)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + its.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Video
                    List<Entity.VideoClip> list6 = SVideoClip.GET_BY_ALL(language);
                    foreach (var its in list6)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + its.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Album
                    List<Entity.Album> list16 = SAlbum.GET_GY_ALL(language);
                    foreach (var its in list16)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + its.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Menu Tin tuc
                    List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in list)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Nhoms san pham
                    List<Entity.Menu> list2 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in list2)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Hang san pham
                    List<Entity.Menu> list3 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.HG + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in list3)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Video Menu
                    List<Entity.Menu> list4 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.VD + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in list4)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Menu Album
                    List<Entity.Menu> list14 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.AB + "' and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in list14)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region Menu page
                    List<Entity.Menu> listMN = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.MN + "'  and Module='99' and type=2 and Lang='" + language + "'  and Status=1 order by Orders asc");
                    foreach (var item in listMN)
                    {
                        #region link
                        writer.WriteStartElement("url");
                        writer.WriteStartElement("loc");
                        writer.WriteString(Url + item.TangName.ToString() + ".html");
                        writer.WriteEndElement();
                        writer.WriteStartElement("priority");
                        writer.WriteString("1.0");
                        writer.WriteEndElement();
                        writer.WriteStartElement("changefreq");
                        writer.WriteString("weekly");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        #endregion
                    }
                    #endregion

                    #region lien-he
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "lien-he.html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion

                    #region tin-tuc-new
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "tin-tuc-new.html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion

                    #region san-pham
                    writer.WriteStartElement("url");
                    writer.WriteStartElement("loc");
                    writer.WriteString(Url + "san-pham.html");
                    writer.WriteEndElement();
                    writer.WriteStartElement("priority");
                    writer.WriteString("1.0");
                    writer.WriteEndElement();
                    writer.WriteStartElement("changefreq");
                    writer.WriteString("weekly");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            catch (Exception)
            {
                Response.Write("Yêu cầu thiết lập quyền nghi file (Sitemap.xml)");
            }
        }

        //void CheckBrowserCaps()
        //{
        //    System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
        //    if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
        //    {
        //        //labelText = "Trình duyệt là một thiết bị di động.";
        //        Response.Redirect("Mobile.aspx");
        //    }
        //}

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    //html minifier & JS at bottom
        //    // not tested
        //    if (this.Request.Headers["X-MicrosoftAjax"] != "Delta=true")
        //    {
        //        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"<script[^>]*>[\w|\t|\r|\W]*?</script>");
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //        base.Render(hw);
        //        string html = sb.ToString();
        //        System.Text.RegularExpressions.MatchCollection mymatch = reg.Matches(html);
        //        html = reg.Replace(html, string.Empty);
        //        reg = new System.Text.RegularExpressions.Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}|(?=[\r])\s{2,}");
        //        html = reg.Replace(html, string.Empty);
        //        reg = new System.Text.RegularExpressions.Regex(@"</body>");
        //        string str = string.Empty;
        //        foreach (System.Text.RegularExpressions.Match match in mymatch)
        //        {
        //            str += match.ToString();
        //        }
        //        html = reg.Replace(html, str + "</body>");
        //        writer.Write(html);
        //    }
        //    else
        //        base.Render(writer);
        //}

    }
}
