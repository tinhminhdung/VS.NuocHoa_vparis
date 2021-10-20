using Framework;
using MoreAll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class DoiMatKhau : System.Web.UI.UserControl
    {
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
            if (!base.IsPostBack)
            {
                txtcurrentpass.Focus();
                btnchangepassword.Text = this.label("lt_changepassword");
            }
        }
        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (((this.txtcurrentpass.Text.Trim().Length < 1) || (this.txtnewpassword.Text.Length < 1)) || (this.txtnewpasswordconfirm.Text.Length < 1))
                {
                    this.ltmsg.Text = label("matkhau1");
                }
                else if (this.txtnewpassword.Text.Trim().Length < 3)
                {
                    this.ltmsg.Text = label("matkhau2");
                }
                else if (!this.txtnewpassword.Text.Equals(this.txtnewpasswordconfirm.Text))
                {
                    this.ltmsg.Text = label("matkhau2");
                }
                else
                {
                    if (MoreAll.MoreAll.GetCookie("Members") != null)
                    {
                        Member itel = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()) && p.PasWord == this.txtcurrentpass.Text.Trim());
                        if (itel == null)
                        {
                            this.ltmsg.Text = label("matkhau3");
                        }
                        else
                        {
                            Member abc = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                            abc.PasWord = this.txtnewpassword.Text.Trim();
                            db.SubmitChanges();
                            this.ltmsg.Text = label("matkhau4");
                        }
                    }
                    else
                    {
                        base.Response.Redirect(MoreAll.MoreAll.RequestUrl(Request.Url.ToString()));
                    }
                }
            }
            catch (Exception) { }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}