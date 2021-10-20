using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.ECommerce_MVC.cms.Admin.MMember
{
    public partial class Setting : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnsetup.UniqueID;
            if (!base.IsPostBack)
            {
                this.binddata();
            }
        }

        private void binddata()
        {
            try
            {
                #region Setting
                string ViVip = "";
                string VPRS = "";
                List<Entity.Setting> str = SSetting.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "HoaHongTrucTiep")
                        {
                            this.txtHoaHongTrucTiep.Text = its.Value;
                        }
                        if (its.Properties == "Tang1")
                        {
                            this.txtTang1.Text = its.Value;
                        }
                        if (its.Properties == "Tang2")
                        {
                            this.txtTang2.Text = its.Value;
                        }
                        if (its.Properties == "Tang3")
                        {
                            this.txtTang3.Text = its.Value;
                        }
                        if (its.Properties == "Tang4")
                        {
                            this.txtTang4.Text = its.Value;
                        }
                        if (its.Properties == "Tang5")
                        {
                            this.txtTang5.Text = its.Value;
                        }
                        if (its.Properties == "Tang6")
                        {
                            this.txtTang6.Text = its.Value;
                        }


                        if (its.Properties == "SoTienDuocRut")
                        {
                            this.SoTienDuocRut.Text = its.Value;
                        }
                        if (its.Properties == "RutTien")
                        {
                            this.RutTien.Text = its.Value;
                        }


                        if (its.Properties == "txtF2")
                        {
                            this.txtF2.Text = its.Value;
                        }
                        if (its.Properties == "txtF3")
                        {
                            this.txtF3.Text = its.Value;
                        }
                        if (its.Properties == "txtF4")
                        {
                            this.txtF4.Text = its.Value;
                        }
                        if (its.Properties == "txtF5")
                        {
                            this.txtF5.Text = its.Value;
                        }
                        if (its.Properties == "txtgiatridonhang")
                        {
                            this.txtgiatridonhang.Text = its.Value;
                        }
                        if (its.Properties == "TruongPhongKinhDoanhLN")
                        {
                            this.TruongPhongKinhDoanhLN.Text = its.Value;
                        }
                        if (its.Properties == "GiamDocKinhDoanhLN")
                        {
                            this.GiamDocKinhDoanhLN.Text = its.Value;
                        }
                        if (its.Properties == "GiamDocKinhDoanhCaoCapLN")
                        {
                            this.GiamDocKinhDoanhCaoCapLN.Text = its.Value;
                        }
                        if (its.Properties == "TruongNhomKDLN")
                        {
                            this.TruongNhomKDLN.Text = its.Value;
                        }
                        if (its.Properties == "DieuKienLenTruongNhomKD")
                        {
                            this.DieuKienLenTruongNhomKD.Text = its.Value;
                        }
                        if (its.Properties == "CauHinhTVCapDuoi")
                        {
                            this.CauHinhTVCapDuoi.Text = its.Value;
                        }

                        if (its.Properties == "TongSoF1")
                        {
                            this.TongSoF1.Text = its.Value;
                        }
                        if (its.Properties == "TienThuongRa3F1")
                        {
                            this.TienThuongRa3F1.Text = its.Value;
                        }
                        if (its.Properties == "ViVipThuong")
                        {
                            this.ViVipThuong.Text = its.Value;
                        }
                        if (its.Properties == "BatTatViVip")
                        {
                            ViVip = its.Value;
                        }
                        if (its.Properties == "VPRS")
                        {
                            VPRS = its.Value;
                        }

                        if (its.Properties == "SoCoPhanVPRS")
                        {
                            SoCoPhanVPRS.Text = its.Value;
                        }
                        if (its.Properties == "SoDuVPRS")
                        {
                            SoDuVPRS.Text = its.Value;
                        }




                        if (its.Properties == "VPRSThuongRa3F1")
                        {
                            VPRSThuongRa3F1.Text = its.Value;
                        }
                        if (its.Properties == "TongSoF1VPRS")
                        {
                            TongSoF1VPRS.Text = its.Value;
                        }




                        #region MyRegion
                        if (VPRS.Equals("0"))
                        {
                            this.RadioButton1.Checked = false;
                            this.RadioButton2.Checked = true;
                        }
                        else if (VPRS.Equals("1"))
                        {
                            this.RadioButton1.Checked = true;
                            this.RadioButton2.Checked = false;
                        }
                        #endregion

                        #region MyRegion
                        if (ViVip.Equals("0"))
                        {
                            this.Radio_ViVipCo.Checked = false;
                            this.Radio_ViVipKhong.Checked = true;
                        }
                        else if (ViVip.Equals("1"))
                        {
                            this.Radio_ViVipCo.Checked = true;
                            this.Radio_ViVipKhong.Checked = false;
                        }
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            btnsetup_Click(sender, e);
        }
        protected void btnsetup_Click(object sender, EventArgs e)
        {
            try
            {

                #region ViVip
                int ViVip = 0;
                if (this.Radio_ViVipCo.Checked)
                {
                    ViVip = 1;
                }
                #endregion

                #region VPRS
                int VPRS = 0;
                if (this.RadioButton1.Checked)
                {
                    VPRS = 1;
                }
                #endregion

                #region Setting
                if (Page.IsValid)
                {
                    #region Setting
                    Entity.Setting obj = new Entity.Setting();
                    obj.Lang = lang;
                    obj.Properties = "HoaHongTrucTiep";
                    obj.Value = txtHoaHongTrucTiep.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang1";
                    obj.Value = txtTang1.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang2";
                    obj.Value = txtTang2.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang3";
                    obj.Value = txtTang3.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang4";
                    obj.Value = txtTang4.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang5";
                    obj.Value = txtTang5.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang6";
                    obj.Value = txtTang6.Text;
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "txtF2";
                    obj.Value = txtF2.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF3";
                    obj.Value = txtF3.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF4";
                    obj.Value = txtF4.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF5";
                    obj.Value = txtF5.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtgiatridonhang";
                    obj.Value = txtgiatridonhang.Text;
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "SoTienDuocRut";
                    obj.Value = SoTienDuocRut.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "RutTien";
                    obj.Value = RutTien.Text;
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "TruongPhongKinhDoanhLN";
                    obj.Value = TruongPhongKinhDoanhLN.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "GiamDocKinhDoanhLN";
                    obj.Value = GiamDocKinhDoanhLN.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "GiamDocKinhDoanhCaoCapLN";
                    obj.Value = GiamDocKinhDoanhCaoCapLN.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "TruongNhomKDLN";
                    obj.Value = TruongNhomKDLN.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "DieuKienLenTruongNhomKD";
                    obj.Value = DieuKienLenTruongNhomKD.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "CauHinhTVCapDuoi";
                    obj.Value = CauHinhTVCapDuoi.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "TongSoF1";
                    obj.Value = TongSoF1.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "TienThuongRa3F1";
                    obj.Value = TienThuongRa3F1.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "ViVipThuong";
                    obj.Value = ViVipThuong.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "BatTatViVip";
                    obj.Value = ViVip.ToString();
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "VPRS";
                    obj.Value = VPRS.ToString();
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "SoCoPhanVPRS";
                    obj.Value = SoCoPhanVPRS.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "SoDuVPRS";
                    obj.Value = SoDuVPRS.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "VPRSThuongRa3F1";
                    obj.Value = VPRSThuongRa3F1.Text;
                    SSetting.UPDATE(obj);


                    obj.Lang = lang;
                    obj.Properties = "TongSoF1VPRS";
                    obj.Value = TongSoF1VPRS.Text;
                    SSetting.UPDATE(obj);


                    #endregion
                }
                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                #endregion
            }
            catch (Exception) { }
        }
    }
}