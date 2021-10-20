using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework;
using MoreAll;
using Entity;
using Services;

namespace VS.E_Commerce.cms.Admin.settings
{
    public partial class website : System.Web.UI.UserControl
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
        public void binddata()
        {
            FSetting DB = new FSetting();
            List<Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            string Thongbao = "0";
            string Email = "0";

            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "website")
                    {
                        this.txtwebsite.Text = its.Value;
                    }
                    else if (its.Properties == "Show")
                    {
                        this.txtcontent.Text = its.Value;
                    }
                    else if (its.Properties == "Thongbao")
                    {
                        Thongbao = its.Value;
                    }
                    else if (its.Properties == "Email")
                    {
                        Email = its.Value;
                    }
                    else if (its.Properties == "Redirectwebsite")
                    {
                        this.txtRedirect.Text = its.Value;
                    }
                }
            }
            if (Email.Equals("0"))
            {
                this.RadioButton1.Checked = true;
                this.RadioButton2.Checked = false;
            }
            else if (Email.Equals("1"))
            {
                this.RadioButton1.Checked = false;
                this.RadioButton2.Checked = true;
            }
            if (Thongbao.Equals("0"))
            {
                this.Thongbao1.Checked = true;
                this.Thongbao2.Checked = false;
                this.Thongbao3.Checked = false;
            }
            else if (Thongbao.Equals("1"))
            {
                this.Thongbao1.Checked = false;
                this.Thongbao2.Checked = true;
                this.Thongbao3.Checked = false;
            }
            else if (Thongbao.Equals("2"))
            {
                this.Thongbao1.Checked = false;
                this.Thongbao2.Checked = false;
                this.Thongbao3.Checked = true;
            }
            this.btnsetup.Text = "Cập nhật";
        }
        protected void btnsetup_Click(object sender, EventArgs e)
        {
            int Email = 0;
            if (this.RadioButton2.Checked)
            {
                Email = 1;
            }
            int Thongbao = 0;
            if (this.Thongbao2.Checked)
            {
                Thongbao = 1;
            }
            else if (this.Thongbao3.Checked)
            {
                Thongbao = 2;
            }

            if (Page.IsValid)
            {
                Setting obj = new Setting();
                obj.Lang = lang;
                obj.Properties = "website";
                obj.Value = txtwebsite.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Show";
                obj.Value = txtcontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Thongbao";
                obj.Value = Thongbao.ToString();
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Email";
                obj.Value = Email.ToString();
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Redirectwebsite";
                obj.Value = txtRedirect.Text;
                SSetting.UPDATE(obj);

                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}