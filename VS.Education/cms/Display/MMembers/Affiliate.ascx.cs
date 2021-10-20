using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class Affiliate : System.Web.UI.UserControl
    {
        string ssl = "http://";
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
        private void ShowInfo()
        {
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://";
            }
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    if (table.TrangThai == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Bạn không thể sử dụng tính năng này. Yêu cầu kích hoạt tài khoản thành viên.');window.location.href='/vi-tien.html'; </script>");
                    }
                    // hdid.Value = table.iuser_id.ToString();
                    txtlinkgioithieu.Text = ssl + Request.Url.Host + "?link=" + table.DienThoai.ToString() + "";
                    ltshare.Text = "<div class=\"zalo-share-button\" data-href=\"https://" + Request.Url.Host + "?link=" + table.DienThoai.ToString() + "\"  data-oaid=\"3853758560685742933\" data-layout=\"1\" data-color=\"blue\" data-customize=false></div>";
                }
            }
        }
    }
}