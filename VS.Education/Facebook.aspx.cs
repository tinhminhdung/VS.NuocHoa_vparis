using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using Framework;
using Services;
using MoreAll;

namespace VS.E_Commerce
{
    public partial class Facebook : System.Web.UI.Page
    {
        private DatalinqDataContext db = new DatalinqDataContext();
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
            if (!base.IsPostBack)
            { }
            string url = Request.Url.AbsoluteUri;
            if (url.Contains("access_token"))
            {
                string accessToken = Request.QueryString["access_token"];
                string requestUrl = "https://graph.facebook.com/me?access_token=" + accessToken + "&fields=email,name,birthday,locale,gender,photos";
                WebClient client = new WebClient();
                string userInformation = client.DownloadString(requestUrl);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var user = jss.Deserialize<FacebookUserInfo>(userInformation);
                if (user != null)
                {
                    MoreAll.MoreAll.SetCookie("Members", MoreAll.AddURL.SeoURL(user.name.ToString()), 5000);
                    Session["FaceBook"] = user.id + ";" + user.name + ";" + user.email + ";" + user.birthday + ";" + user.locale + ";" + user.gender + ";" + user.photos;
                    //Session["FaceBook"].ToString().Split(';')[0];
                    user lstU = db.users.SingleOrDefault(p => p.IDFaceBook_Google == user.id.ToString());
                    if (lstU != null)
                    {
                        lstU.vuserun = MoreAll.AddURL.SeoURL(user.name.ToString());
                        lstU.vfname = user.name.Trim().ToLower();
                        lstU.vlname = user.name.Trim().ToLower();
                        db.SubmitChanges();
                    }
                    else
                    {
                        Fusers item = new Fusers();
                        string validatekey = DateTime.Now.Ticks.ToString();
                        user obj = new user();
                        obj.vuserun = MoreAll.AddURL.SeoURL(user.name.ToString());
                        obj.vuserpwd = "";
                        obj.vfname = user.name.Trim().ToLower();
                        obj.vlname = user.name.Trim().ToLower();
                        obj.igender = 0;
                        try
                        {
                            obj.dbirthday = Convert.ToDateTime(user.birthday);
                        }
                        catch (Exception)
                        {
                            obj.dbirthday = DateTime.Now;
                        }
                        obj.vidcard = "0";
                        obj.vaddress = "";
                        obj.vphone = "";
                        obj.vemail = user.email.Trim().ToLower();
                        obj.iregionid = int.Parse("0");
                        obj.vavatar = "";
                        obj.vavatartitle = "";
                        obj.dcreatedate = DateTime.Now;
                        obj.dlastvisited = DateTime.Now;
                        obj.vvalidatekey = validatekey;
                        obj.istatus = 1;
                        obj.lang = language;
                        obj.IDFaceBook_Google = user.id.ToString();
                        db.users.InsertOnSubmit(obj);
                        db.SubmitChanges(); 
                        
                    }
                }
                //Dong trang dang nhap
                Response.Redirect("Close.aspx");
            }
            else if (url.Contains("error"))
            {
                Response.Write("Có lỗi trong quá trình đăng nhập. <a href=\"javascript:window.close();\">Đóng cửa sổ</a>");
            }
        }
    }
}