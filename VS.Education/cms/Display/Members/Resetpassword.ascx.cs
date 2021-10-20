using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Framework;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Resetpassword : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnresets.UniqueID;
            if (!IsPostBack)
            {
                btnresets.Text = label("login9");
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnresets);
                #endregion
            }
        }
        protected void btnregisters_Click(object sender, EventArgs e)
        {
            Fusers item = new Fusers();
            System.Threading.Thread.Sleep(1000);
            if (item.Detailemail(this.txtemail.Text.Trim().ToLower()).Rows.Count < 1)
            {
                this.ltmsg.Text = label("login10");
            }
            else
            {
                try
                {
                    string hash = DateTime.Now.Ticks.ToString();
                    item.Update_validatekey_byemail(this.txtemail.Text.Trim().ToLower(), hash);
                    string title = "";
                    string body = "";
                    title = label("login11");
                    body = (label("login12") + "<br><br>") + label("login13") + "<br><br>";
                    string str4 = "http://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/xac-nhan/" + hash + "/password.aspx";
                    string str9 = body;
                    body = str9 + "<a href='" + str4 + "'  target='_blank'>" + str4 + "</a>";

                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();

                    System.Threading.Thread.Sleep(1000);

                    MailUtilities.SendMail(label("login11") + "! ", email, password, this.txtemail.Text, host, Convert.ToInt32(port), title, body);
                    this.MultiView1.ActiveViewIndex = 1;
                    this.ltresult.Text = label("login14");
                }
                catch (Exception ex)
                {
                    this.ltresult.Text = "Có lỗi xảy ra khi gửi mail" + ex;
                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}