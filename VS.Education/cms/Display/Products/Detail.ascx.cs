using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using System.Data;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Detail : System.Web.UI.UserControl
    {
        string pid = "-1";
        string cid = "-1";
        string hp = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (!IsPostBack)
            {
                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    cid = dt[0].icid.ToString();
                    List<Entity.Menu> str = SMenu.Detail(cid);
                    if (str.Count > 0)
                    {
                        ltcatename.Text = str[0].Name.ToString();
                    }
                    pid = dt[0].ipid.ToString();
                    hdipid.Value = dt[0].ipid.ToString();
                    hdTrangThai.Value = dt[0].News.ToString();

                    if (Commond.ShowTrangThai() != "2")
                    {
                        if (hdTrangThai.Value != Commond.ShowTrangThai())
                        {
                            Panel1.Visible = false;
                            Panel2.Visible = true;
                          
                        }
                        else if (hdTrangThai.Value == Commond.ShowTrangThai())
                        {
                            Panel1.Visible = true;
                            Panel2.Visible = false;
                        }
                    }
                    else
                    {
                        Panel1.Visible = true;
                        Panel2.Visible = false;
                    }


                    ltname.Text = dt[0].Name;
                    ltdesc.Text = dt[0].Brief;
                    ltdetail.Text = dt[0].Contents;
                    ltxem.Text = dt[0].Views.ToString();
                    ltdate.Text = MoreAll.MoreAll.Date(dt[0].Create_Date.ToString());
                    ltcode.Text = dt[0].Code.ToString();
                    ltpriceoll.Text = MorePro.Detail_Price(dt[0].OldPrice.ToString());
                    ltprice.Text = MorePro.Detail_Price(dt[0].Price.ToString());
                    //ltkaddtocart.Text = "<a  rel=\"popuprel3\"  onclick=\"DetailUpdateOrder(" + dt[0].ipid + ",'" + dt[0].Name + "',$(this));\" class=\"adr_shopping_button popup\" ><i class=\"adricon\"></i>Cho vào giỏ hàng</a>";
                    // ltMuahang.Text = "<a Class=\"orders\" onclick=\"UpdateOrder(" + dt[0].ipid + ",'" + dt[0].Name + "')\">Thêm vào giỏ hàng</a>";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        // this.ltimge1.Text = MorePro.ImageDetail(dt[0].Images.ToString());
                        // this.ltimge.Text = MorePro.Image_width_height_gallery(dt[0].Images.ToString(), dt[0].Name.ToString());
                    }
                    string strComment = "";
                    strComment += "<div class=\"likeprodet\">";
                    strComment += "<div class=\"addthis_inline_share_toolbox_fg18\"></div>";
                    strComment += "</div>";
                    ltshares.Text = strComment;
                    //"<div class=\"fb-comments\" data-href=\"" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "\" data-colorscheme=\"light\" data-width=\"950\" data-numposts=\"5\"></div>";
                    //dt = SProducts.NewxTopNewsAfterNews(cid, pid, int.Parse(MorePro.proother()), language);
                    //if (dt.Count > 0)
                    //{
                    //    rpcates.DataSource = dt;
                    //    rpcates.DataBind();
                    //}
                    //else
                    //{
                    List<Entity.Products> dt22 = SProducts.Name_Text("select top " + int.Parse(MorePro.proother()) + " * from products where icid= " + cid + " and ipid!= " + pid + "  and lang= '" + language + "'  and Status=1 order by Create_Date desc");
                    rpcates.DataSource = dt22;
                    rpcates.DataBind();
                    //}
                }
                //#region CookiesPro_sanphamdaxem
                //string ckPro = "";
                //if (MoreAll.MoreAll.GetCookies("CookiesPro").ToString() != null)
                //{
                //    ckPro = MoreAll.MoreAll.GetCookies("CookiesPro").ToString();
                //}
                //if (ckPro != "")
                //{
                //    int[] arrId = ckPro.Split(',').Select(s => int.Parse(s)).ToArray();
                //    if (!arrId.Contains(int.Parse(hdipid.Value.ToString())))
                //    {
                //        ckPro += "," + hdipid.Value.Trim().ToString();
                //    }
                //}
                //else
                //{
                //    ckPro += hdipid.Value.Trim().ToString();
                //}
                //MoreAll.MoreAll.SetCookie("CookiesPro", ckPro, 100);
                //#endregion

            }
            if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.pid))
            {
                SProducts.UpdateViewTimes(this.pid);
                MoreAll.MoreAll.SetCookie("views", this.pid);
            }
        }

        public string Hang(string ID)
        {
            string Width = "";
            List<Entity.Menu> dts = SMenu.capp_Lang_ID_Status(More.HG, language, ID, "1");
            if (dts.Count > 0)
            {
                //  Width += dts[0].Name;
                if (dts[0].Images.Length > 0)
                {
                    Width += "&nbsp;&nbsp;&nbsp;<img style='height: 27px;' src='" + dts[0].Images.ToString() + "'>";
                }
            }
            return Width.ToString();
        }
        public string Viewprodetail()
        {
            string bReturn = "";
            List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
            if (dbPro.Count > 0)
            {
                bReturn += " <a href=\"" + dbPro[0].Images + "\"><img src=\"" + dbPro[0].Images + "\" alt=\"" + dbPro[0].Name + "\"  /></a>";
                if (dbPro[0].Anh.ToString().Length > 5)
                {
                    string[] strArray = dbPro[0].Anh.ToString().Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        bReturn += "<a href=\"" + strArray[i].ToString() + "\"><img alt='" + dbPro[0].Name.ToString() + "'src=\"" + strArray[i].ToString().Replace("uploads", "uploads/_thumbs") + "\"/></a>";
                    }
                }
            }
            return bReturn;
        }

        //public string Viewprodetail()
        //{
        //    string _strProdet = "";
        //    List<Entity.Products> dt = SProducts.GetById(pid);
        //    if (dt.Count > 0)
        //    {
        //        _strProdet += " <a href=\"" + dt[0].Images + "\"><img src=\"" + dt[0].Images + "\" alt=\"" + dt[0].Name + "\"  /></a>";
        //    }
        //    List<Entity.Product_images> lstImage = SProduct_images.GetBy_ipid(pid);
        //    if (lstImage.Count > 0)
        //    {
        //        for (int i = 0; i < lstImage.Count; i++)
        //        {
        //            _strProdet += "<a href=\"" + lstImage[i].Images + "\"><img src=\"" + lstImage[i].Images + "\" alt=\"" + dt[0].Name + "\"    /></a>";
        //        }
        //    }
        //    return _strProdet;
        //}

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }


        protected void lnkaddtocart_Click(object sender, EventArgs e)
        {
            string Kichco = "0";
            string Mausac = "0";
            SessionCarts.ShoppingCart_AddProduct_Sesion(hdipid.Value, Convert.ToInt32(txtproQuantity.Text), Mausac, Kichco);
            Response.Redirect("/gio-hang.html");
        }
    }
}