using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class Login : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnlogin.UniqueID;
            if (!base.IsPostBack)
            {
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if ((this.txt_Uname.Text.Trim().Length < 1) || (this.txt_password.Text.Trim().Length < 1))
            {
                this.ltmsg.Text = "Tài khoản không đúng hoặc chưa được kích hoạt"; return;
            }
            else
            {
                List<Entity.Member> table = SMember.Name_Text("select * from Members where DienThoai='" + txt_Uname.Text.Trim().ToLower() + "' and PasWord='" + (txt_password.Text.Trim().ToLower()) + "' and TrangThai=1");
                if (table.Count > 0)
                {
                    MoreAll.MoreAll.SetCookie("Members", txt_Uname.Text.Trim().ToLower(), 5000);
                    MoreAll.MoreAll.SetCookie("MembersID", table[0].ID.ToString(), 5000);
                    CapBac.NangCapbac(table[0].ID.ToString());
                    if (HttpContext.Current.Request["ReturnUrl"] != null && !HttpContext.Current.Request["ReturnUrl"].Equals(""))
                    {
                        Response.Redirect(HttpContext.Current.Request["ReturnUrl"].ToString());
                    }
                    else
                    {
                        // Response.Redirect("/Vi-diem.html");
                        Response.Redirect("/");
                    }
                }
                else
                {
                    this.ltmsg.Text = "Tài khoản không đúng hoặc chưa được kích hoạt"; return;
                }
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}