using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Web.Security;
using System.Data;
using Framework;
using Entity;
using Services;

namespace VS.E_Commerce.cms.Display.Members
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
                this.ltmsg.Text = label("login1");
            }
            else
            {
                Fusers item = new Fusers();
                List<Entity.users> table = Susers.Name_Text("select * from users where vuserun='" + this.txt_Uname.Text.Trim().ToLower() + "' and vuserpwd='" + (this.txt_password.Text.Trim().ToLower()) + "' and istatus=1");
                if (table.Count < 1)
                {
                    this.ltmsg.Text = label("login2");
                }
                else
                {
                    #region Cookie
                    FormsAuthentication.SetAuthCookie(txt_Uname.Text, false);
                    #region Cookie
                    MoreAll.MoreAll.SetCookie("Members", txt_Uname.Text, 5000);
                    #endregion
                    if (Request.QueryString["su"] != "Login")
                    {
                        Response.Redirect(Request.Url.AbsolutePath);
                    }
                    else
                    {
                        Response.Redirect("/");
                    }
                    #endregion
                }
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}