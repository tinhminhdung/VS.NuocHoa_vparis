using Framework;
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
            FMember item = new FMember();
            System.Threading.Thread.Sleep(1000);
            if (item.Detailemail(this.txtemail.Text.Trim().ToLower()).Rows.Count < 1)
            {
                this.ltmsg.Text = label("login10");
            }
            else
            {
                    List<Entity.Member> table = SMember.Name_Text("select * from Members where Email='" + txtemail.Text.Trim().ToLower() + "' ");
                    if (table.Count > 0)
                    {
                        string info = "Thông tin tài khoản từ web : http://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/" + "<br>Thông tin tài khoản của bạn!<br>Tên đăng nhập: <b>" + table[0].DienThoai.ToString() + " </b><br>Mật khẩu :  <b>" + table[0].PasWord.ToString() + "</b>";
                        string title = "Cập nhật lại mật khẩu!";

                        string email = Email.email();
                        string password = Email.password();
                        int str6 = Convert.ToInt32(Email.port());
                        string host = Email.host();

                        MailUtilities.SendMail("Cập nhật lại mật khẩu!", email, password, table[0].Email.ToString(), host, Convert.ToInt32(str6), title, info);
                        item.Detailemail(table[0].Email.ToString());

                        System.Threading.Thread.Sleep(1000);

                        this.MultiView1.ActiveViewIndex = 1;
                        this.ltresult.Text = label("login14");
                    }
               
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}