﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Admin
{
    public partial class main : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            // try
            //{
            #region Case
            string u = Request.QueryString["u"];
            switch (u)
            {
                case "LichSuQuyDoiSoCoPhan":
                    phcontrol.Controls.Add(LoadControl("MMember/MLichSuQuyDoiSoCoPhan.ascx"));
                    break;
                    
                case "KhoangGia":
                    phcontrol.Controls.Add(LoadControl("MMember/ManagementPrice.ascx"));
                    break;
                case "LScapdiem":
                    phcontrol.Controls.Add(LoadControl("MMember/MLSCCapDiem.ascx"));
                    break;
                case "CCapDiem":
                    phcontrol.Controls.Add(LoadControl("MMember/CCapDiem.ascx"));
                    break;
                case "LoiNhuan":
                    phcontrol.Controls.Add(LoadControl("MMember/LoiNhuanMuaBan.ascx"));
                    break;
                case "ChitietDonHang":
                    phcontrol.Controls.Add(LoadControl("products/DetailCart.ascx"));
                    break;
                case "MLichSuRutTien":
                    phcontrol.Controls.Add(LoadControl("MMember/MLichSuRutTien.ascx"));
                    break;
                case "HoaHong":
                    phcontrol.Controls.Add(LoadControl("MMember/MHoaHong.ascx"));
                    break;
                case "Settinghh":
                    phcontrol.Controls.Add(LoadControl("MMember/Setting.ascx"));
                    break;
                case "Settingchienluoc":
                    phcontrol.Controls.Add(LoadControl("MMember/Setting_SPChienLuoc.ascx"));
                    break;

                case "301":
                    phcontrol.Controls.Add(LoadControl("Redirect301/StatusCode.ascx"));
                    break;
                case "info":
                    phcontrol.Controls.Add(LoadControl("NewsFooter/Control.ascx"));
                    break;
                case "Dichvu":
                    phcontrol.Controls.Add(LoadControl("DDichvu/DDichvu.ascx"));
                    break;
                case "Gioithieu":
                    phcontrol.Controls.Add(LoadControl("GioiThieu/GioiThieu.ascx"));
                    break;
                case "Thanhvien":
                    phcontrol.Controls.Add(LoadControl("MMember/AMembers.ascx"));
                    break;
                case "faq":
                    phcontrol.Controls.Add(LoadControl("Faq/Control.ascx"));
                    break;
                case "Sitemap":
                    phcontrol.Controls.Add(LoadControl("Sitemap/Control.ascx"));
                    break;
                case "Album":
                    phcontrol.Controls.Add(LoadControl("Album/Control.ascx"));
                    break;
                case "Marketing":
                    phcontrol.Controls.Add(LoadControl("Marketing/Control.ascx"));
                    break;
                case "Tienich":
                    phcontrol.Controls.Add(LoadControl("Tienich/Control.ascx"));
                    break;
                case "Video":
                    phcontrol.Controls.Add(LoadControl("Video/Control.ascx"));
                    break;
                case "Download":
                    phcontrol.Controls.Add(LoadControl("Download/Control.ascx"));
                    break;
                case "Contacts":
                    phcontrol.Controls.Add(LoadControl("Contacts/Control.ascx"));
                    break;
                case "Advertisings":
                    phcontrol.Controls.Add(LoadControl("Advertisings/Control.ascx"));
                    break;
                case "pro":
                    phcontrol.Controls.Add(LoadControl("products/Control.ascx"));
                    break;
                case "carts":
                    phcontrol.Controls.Add(LoadControl("products/Cart.ascx"));
                    break;
                case "news":
                    phcontrol.Controls.Add(LoadControl("CNews/Control.ascx"));
                    break;
                case "set":
                    phcontrol.Controls.Add(LoadControl("settings/Control.ascx"));
                    break;
                case "WebAnalytics":
                    phcontrol.Controls.Add(LoadControl("WebAnalytics/Control.ascx"));
                    break;
                case "Page":
                    phcontrol.Controls.Add(LoadControl("Page/Menu_Page.ascx"));
                    break;
                case "AdminUser":
                    phcontrol.Controls.Add(LoadControl("AdminUser/AdminUser.ascx"));
                    break;
                case "":
                default:
                    phcontrol.Controls.Add(LoadControl("settings/Control.ascx"));
                    break;
            }
            #endregion
            if (!base.IsPostBack)
            {
                #region Role
                if (MoreAll.MoreAll.GetCookies("URole") != null)
                {
                    string[] strArray = MoreAll.MoreAll.GetCookies("URole").ToString().Trim().Split(new char[] { '|' });
                    Reset_Checkbox();
                    if (strArray.Length > 0)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Equals("1"))
                            {
                                set.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("2"))
                            {
                                News.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("3"))
                            {
                                Products.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("4"))
                            {
                                AdminUser.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("5"))
                            {
                                Contacts.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("6"))
                            {
                                Advertisings.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("7"))
                            {
                                MLichSuRutTien.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("8"))
                            {
                                Video.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("9"))
                            {
                                // Tienich.Style.Add("display", "block");
                              
                            }
                            if (strArray[i].ToString().Equals("10"))
                            {
                                CauHinhHoaHOng.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("11"))
                            {
                                Thanhvien.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("12"))
                            {
                                LoiNhuan.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("13"))
                            {
                                HoaHong.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("14"))
                            {

                            }
                            if (strArray[i].ToString().Equals("15"))
                            {

                            }
                            if (strArray[i].ToString().Equals("16"))
                            {
                                Page.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("17"))
                            {
                                carts.Style.Add("display", "block");
                                giohang.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("18"))
                            {

                            }
                            if (strArray[i].ToString().Equals("19"))
                            {
                                LScapdiem.Style.Add("display", "block");
                            }
                            if (strArray[i].ToString().Equals("20"))
                            {

                            }
                            if (strArray[i].ToString().Equals("21"))
                            {
                                Settingchienluoc.Style.Add("display", "block");
                            }
                        }
                    }
                }
                #endregion
            }
            // }
            //catch (Exception) { }
        }

        protected void Reset_Checkbox()
        {
            #region ResetCheckbox
            //try
            {
                Settingchienluoc.Style.Add("display", "none");
                LScapdiem.Style.Add("display", "none");


                #region HoaHong
                if ((Request["u"] == "HoaHong"))
                {
                    User.Style.Add("background", "#ff9c00");
                    HoaHong.Style.Add("display", "none");
                }
                HoaHong.Style.Add("display", "none");
                #endregion

                #region LoiNhuan
                if ((Request["u"] == "LoiNhuan"))
                {
                    User.Style.Add("background", "#ff9c00");
                    LoiNhuan.Style.Add("display", "none");
                }
                LoiNhuan.Style.Add("display", "none");
                #endregion

                #region MLichSuRutTien
                if ((Request["u"] == "MLichSuRutTien"))
                {
                    User.Style.Add("background", "#ff9c00");
                    MLichSuRutTien.Style.Add("display", "none");
                }
                MLichSuRutTien.Style.Add("display", "none");
                #endregion

                #region CauHinhHoaHOng
                if ((Request["u"] == "Settinghh"))
                {
                    User.Style.Add("background", "#ff9c00");
                    CauHinhHoaHOng.Style.Add("display", "none");
                }
                CauHinhHoaHOng.Style.Add("display", "none");
                #endregion


                #region pro
                if ((Request["u"] == "pro"))
                {
                    Products.Style.Add("background", "#ff9c00");
                    Products.Style.Add("display", "none");
                }
                Products.Style.Add("display", "none");
                #endregion

                #region carts
                if ((Request["u"] == "carts"))
                {
                    carts.Style.Add("background", "#ff9c00");
                    carts.Style.Add("display", "none");
                    giohang.Style.Add("display", "none");
                }
                carts.Style.Add("display", "none");
                giohang.Style.Add("display", "none");
                #endregion

                #region Thanhvien
                if ((Request["u"] == "Thanhvien"))
                {
                    User.Style.Add("background", "#ff9c00");
                    Thanhvien.Style.Add("display", "none");
                }
                Thanhvien.Style.Add("display", "none");
                #endregion

                #region AdminUser
                if ((Request["su"] == "AdminUser"))
                {
                    User.Style.Add("background", "#ff9c00");
                    AdminUser.Style.Add("display", "none");
                }
                AdminUser.Style.Add("display", "none");
                #endregion

                #region News
                if ((Request["u"] == "news"))
                {
                    News.Style.Add("background", "#ff9c00");
                    News.Style.Add("display", "none");
                }
                News.Style.Add("display", "none");
                #endregion

                #region set
                if ((Request["u"] == "set"))
                {
                    Quantri.Style.Add("background", "#ff9c00");
                    set.Style.Add("display", "none");
                }
                set.Style.Add("display", "none");
                #endregion

                #region Advertisings
                if ((Request["u"] == "Advertisings"))
                {
                    Danhmuc.Style.Add("background", "#ff9c00");
                    Advertisings.Style.Add("display", "none");
                }
                Advertisings.Style.Add("display", "none");
                #endregion

                #region Contacts
                if ((Request["u"] == "Contacts"))
                {
                    Quantri.Style.Add("background", "#ff9c00");
                    Contacts.Style.Add("display", "none");
                }
                Contacts.Style.Add("display", "none");
                #endregion

                #region Video
                if ((Request["u"] == "Video"))
                {
                    Video.Style.Add("background", "#ff9c00");
                    Video.Style.Add("display", "none");
                }
                Video.Style.Add("display", "none");
                #endregion

                //#region Tienich
                //if ((Request["u"] == "Tienich"))
                //{
                //    Danhmuc.Style.Add("background", "#ff9c00");
                //    Tienich.Style.Add("display", "none");
                //}
                //Tienich.Style.Add("display", "none");
                //#endregion

                #region Marketing
                if ((Request["u"] == "Marketing"))
                {
                    Quantri.Style.Add("background", "#ff9c00");
                    Marketing.Style.Add("display", "none");
                }
                Marketing.Style.Add("display", "none");
                #endregion

                #region Album
                if ((Request["u"] == "Album"))
                {
                    Album.Style.Add("background", "#ff9c00");
                    Album.Style.Add("display", "none");
                }
                Album.Style.Add("display", "none");
                #endregion

                //#region faq
                //if ((Request["u"] == "faq"))
                //{
                //    // faq.Style.Add("background", "#ff9c00");
                //    faq.Style.Add("display", "none");
                //}
                //faq.Style.Add("display", "none");
                //#endregion

                #region Page
                if ((Request["u"] == "Page"))
                {
                    Danhmuc.Style.Add("background", "#ff9c00");
                    Page.Style.Add("display", "none");
                }
                Page.Style.Add("display", "none");
                #endregion

            }
            // catch (Exception) { }
            #endregion
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_exit_Click(object sender, EventArgs e)
        {
            #region Exit
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            MoreAll.MoreAll.SetCookie("URole", "", -1);
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            Response.Redirect(Request.Url.ToString());
            #endregion
        }

        private void Refresh()
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lnknew_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=news");
        }

        protected void lnkpro_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=pro");
        }

        //protected void lnksettings_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin.aspx?u=set");
        //}

        protected void lnkAdvertisings_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Advertisings");
        }

        protected void lnklienhe_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Contacts");
        }

        protected void lnkDownloadFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Download");
        }

        protected void lnkVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Video");
        }

        protected void lnkTienich_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Tienich");
        }

        protected void lnkMarketing_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Marketing");
        }

        protected void lnkAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Album");
        }

        protected void lnkWebAnalytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=WebAnalytics");
        }

        protected void lnkhompage_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void lnkmenuchinh_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Page");
        }

        protected void lnkSitemap_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Sitemap");
        }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Lnkfaq_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=faq");
        }
        protected void lnkGioithieu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Gioithieu");
        }
        protected void ltthanhvien_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Thanhvien");
        }
        protected void lnkDichvu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Dichvu");
        }
        protected void lnkthongtin_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=info");
        }
        protected string returnCSS(string ctrol)
        {
            string su = "";
            if (Request["su"] != null && !Request["su"].Equals(""))
            {
                su = Request["su"];
            }
            if ((su != "") && su.Equals(ctrol))
            {
                return "";
            }
            return "";
        }
        protected string TContac()
        {
            string str = "0";
            List<Entity.Contacts> tong = SContacts.Name_Text("SELECT * FROM Contacts where istatus=0 and lang='" + lang + "'");
            if (tong.Count > 0)
            {
                str = tong.Count.ToString();
            }
            return str;
        }
        protected string TCarts()
        {
            string str = "0";
            List<Entity.Carts> tong = SCarts.Name_Text("SELECT * FROM Carts where Status=0 and lang='" + lang + "'");
            if (tong.Count > 0)
            {
                str = tong.Count.ToString();
            }
            return str;
        }
    }
}