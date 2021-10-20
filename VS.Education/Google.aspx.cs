using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace VS.E_Commerce
{
    public partial class Google : System.Web.UI.Page
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string GoogleID = "";
        string GoogleEmail = "";
        string GoogleName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["GoogleID"] != null && !Request["GoogleID"].Equals(""))
            {
                GoogleID = Request["GoogleID"];
            }
            if (Request["GoogleEmail"] != null && !Request["GoogleEmail"].Equals(""))
            {
                GoogleEmail = Request["GoogleEmail"];
            }
            if (Request["GoogleName"] != null && !Request["GoogleName"].Equals(""))
            {
                GoogleName = Request["GoogleName"];
            }
            if (!IsPostBack)
            {
                System.Web.HttpContext.Current.Session["Google"] = GoogleID + ";" + GoogleEmail + ";" + GoogleName;

                try
                {
                    if (Session["Google"] != null)
                    {


                        //Session["SessionName"] = SessionName;
                        //Session["SessionEmail"] = SessionEmail;
                        // Session["SessionID"] = ID;
                        // tbMember lstU = db.tbMembers.SingleOrDefault(p => p.IDFacebook == ID);
                        //if (lstU == null)
                        //{
                        //    tbMember obj = new tbMember();
                        //    obj.uID = common.killChars(SessionName);
                        //    obj.uPas = vmmsclass.Encodingvmms.Encode("");
                        //    obj.Email = common.killChars(SessionEmail);
                        //    obj.Add = common.killChars("");
                        //    obj.Tell = common.killChars("");
                        //    obj.Fax = common.killChars("");
                        //    obj.Counts = 0;
                        //    obj.Active = 1;
                        //    obj.IDFacebook = ID;
                        //    db.tbMembers.InsertOnSubmit(obj);
                        //    db.SubmitChanges();
                        //}
                        //else
                        //{
                        //    lstU.uID = common.killChars(SessionName);
                        //    db.SubmitChanges();
                        //}
                        //  Session.Remove("um");
                    }
                    Response.Redirect("/");
                }
                catch (Exception)
                {
                    Response.Write("Có lỗi trong quá trình đăng nhập. <a href=\"javascript:window.close();\">Đóng cửa sổ</a>");
                }
            }
        }

        [WebMethod]
        public static string LogonGoogle(string ID, string FullName, string Email, string Image)
        {
            System.Web.HttpContext.Current.Session["Google"] = ID + ";" + FullName + ";" + Email + ";" + Image;
            return "";
        }
    }
}