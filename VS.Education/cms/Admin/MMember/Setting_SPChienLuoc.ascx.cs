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
    public partial class Setting_SPChienLuoc : System.Web.UI.UserControl
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
                List<Entity.Setting> str = SSetting.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Entity.Setting its in str)
                    {
                        if (its.Properties == "HoaHongTrucTiepChienLuoc")
                        {
                            this.txtHoaHongTrucTiep.Text = its.Value;
                        }
                        if (its.Properties == "Tang1ChienLuoc")
                        {
                            this.txtTang1.Text = its.Value;
                        }
                        if (its.Properties == "Tang2ChienLuoc")
                        {
                            this.txtTang2.Text = its.Value;
                        }
                        if (its.Properties == "Tang3ChienLuoc")
                        {
                            this.txtTang3.Text = its.Value;
                        }
                        if (its.Properties == "Tang4ChienLuoc")
                        {
                            this.txtTang4.Text = its.Value;
                        }
                        if (its.Properties == "Tang5ChienLuoc")
                        {
                            this.txtTang5.Text = its.Value;
                        }
                        if (its.Properties == "Tang6ChienLuoc")
                        {
                            this.txtTang6.Text = its.Value;
                        }
                        if (its.Properties == "txtF2ChienLuoc")
                        {
                            this.txtF2.Text = its.Value;
                        }
                        if (its.Properties == "txtF3ChienLuoc")
                        {
                            this.txtF3.Text = its.Value;
                        }
                        if (its.Properties == "txtF4ChienLuoc")
                        {
                            this.txtF4.Text = its.Value;
                        }
                        if (its.Properties == "txtF5ChienLuoc")
                        {
                            this.txtF5.Text = its.Value;
                        }

                        if (its.Properties == "TruongPhongKinhDoanhCL")
                        {
                            this.TruongPhongKinhDoanhCL.Text = its.Value;
                        }
                        if (its.Properties == "GiamDocKinhDoanhCL")
                        {
                            this.GiamDocKinhDoanhCL.Text = its.Value;
                        }
                        if (its.Properties == "GiamDocKinhDoanhCaoCapCL")
                        {
                            this.GiamDocKinhDoanhCaoCapCL.Text = its.Value;
                        }
                        if (its.Properties == "TruongNhomKDCL")
                        {
                            this.TruongNhomKDCL.Text = its.Value;
                        }

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
                #region Setting
                if (Page.IsValid)
                {
                    #region Setting
                    Entity.Setting obj = new Entity.Setting();
                    obj.Lang = lang;
                    obj.Properties = "HoaHongTrucTiepChienLuoc";
                    obj.Value = txtHoaHongTrucTiep.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang1ChienLuoc";
                    obj.Value = txtTang1.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang2ChienLuoc";
                    obj.Value = txtTang2.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang3ChienLuoc";
                    obj.Value = txtTang3.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang4ChienLuoc";
                    obj.Value = txtTang4.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang5ChienLuoc";
                    obj.Value = txtTang5.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Tang6ChienLuoc";
                    obj.Value = txtTang6.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF2ChienLuoc";
                    obj.Value = txtF2.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF3ChienLuoc";
                    obj.Value = txtF3.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF4ChienLuoc";
                    obj.Value = txtF4.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtF5ChienLuoc";
                    obj.Value = txtF5.Text;
                    SSetting.UPDATE(obj);



                    obj.Lang = lang;
                    obj.Properties = "TruongPhongKinhDoanhCL";
                    obj.Value = TruongPhongKinhDoanhCL.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "GiamDocKinhDoanhCL";
                    obj.Value = GiamDocKinhDoanhCL.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "GiamDocKinhDoanhCaoCapCL";
                    obj.Value = GiamDocKinhDoanhCaoCapCL.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "TruongNhomKDCL";
                    obj.Value = TruongNhomKDCL.Text;
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