using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class DanhSachThanhVien : System.Web.UI.UserControl
    {
        public int i = 1;
        string nav = "";
        string Loc = "";
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        string ID = MoreAll.MoreAll.GetCookies("MembersID").ToString();
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
                if (Request["ID"] != null && !Request["ID"].Equals(""))
                {
                    ID = Request["ID"];
                    Loc += "&ID=" + ID;
                }
                List<Entity.Member> dt = SMember.Name_Text("SELECT * FROM Members  WHERE ID = " + ID + " ");
                if (dt.Count > 0)
                {
                    string Mtr = "|" + dt[0].MTRee.ToString();
                    if (Mtr.Contains("|" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "|"))
                    {
                        ltphanmuc.Text = LoadNav(int.Parse(ID.ToString()));
                        LoadItems();
                    }
                    else
                    {
                        WebMsgBox.Show("Bạn ko có quyền xem ID này. Vì ID này không nằm trong hệ thống của bạn");

                    }
                }
            }
        }
        public void LoadItems()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                int Tongsobanghi = 0;
                Int16 pages = 1;
                int Tongsotrang = int.Parse("10");
                if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
                {
                    pages = Convert.ToInt16(Request.QueryString["page"].Trim());
                }
                List<Member> iitem = db.ExecuteQuery<Member>(@"SELECT * FROM Members where 1=1 and GioiThieu=" + ID + " order by ID desc").ToList();
                if (iitem.Count() > 0)
                {
                    Tongsobanghi = iitem.Count();
                }
                int PageIndex = (pages - 1);
                int Tongpage = Tongsotrang;
                int StartRecord = PageIndex * Tongpage;
                int EndRecord = StartRecord + Tongpage + 1;
                List<Member> dt = db.ExecuteQuery<Member>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID DESC) AS rowindex ,*  FROM  Members  where 1=1 and GioiThieu=" + ID + ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
                {
                    rp_items.DataSource = dt;
                    rp_items.DataBind();
                }
                if (Tongsobanghi % Tongsotrang > 0)
                {
                    Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
                }
                else
                {
                    Tongsobanghi = Tongsobanghi / Tongsotrang;
                }
                ltpage.Text = Commond.PhantrangAdmin("/danh-sach-thanh-vien.html?ID=" + ID + "", Tongsobanghi, pages);
            }
        }
        private string LoadNav(int ID)
        {
            try
            {
                var item = db.Members.FirstOrDefault(s => s.ID == ID);
                if (item != null)
                {
                    nav = "<span> <i class=\"fa fa-angle-right\"></i> </span> <a href=\"/Danh-sach-thanh-vien.html?ID=" + item.ID + "\">" + item.HoVaTen + "</a>" + nav;
                    if (item.GioiThieu >= int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()))
                    {
                        LoadNav(Convert.ToInt32(item.GioiThieu));
                    }
                }
            }
            catch (Exception)
            { }
            return nav;
        }

        public string TongThanhVien_Tree(string id)
        {
            string str = "0";
            try
            {
                var dt = db.S_Members_List_TongThanhVien_Tree(int.Parse(id)).ToList();
                if (dt.Count > 0)
                {
                    str = dt[0].Tong.ToString();
                }
            }
            catch (Exception)
            { }
            Double Tong = 0;
            if (str != "0")
            {
                Tong = Convert.ToDouble(str) - 1;
            }
            return Tong.ToString();
        }

        protected void lnkxuatExel_Click(object sender, EventArgs e)
        {
            string Namefile = "DanhSachThanhVien" + DateTime.Now;
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment;filename=" + Namefile + ".xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            StringBuilder sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            sb.Append("<table border='1' bgcolor='#ffffff' bordercolor='#dedede' cellspacing='0' cellpadding='0' style='font-size:12px; font-family:Arial; background:white;'>");
            sb.Append("<tr>");
            sb.Append("  <th style=\"width:50px; vertical-align:middle; height: 22px;\">");
            sb.Append("    <b>STT</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:50px; vertical-align:middle;\">");
            sb.Append("    <b>ID</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Họ và tên</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;\">");
            sb.Append("    <b>Địa chỉ</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:250px; vertical-align:middle;\">");
            sb.Append("    <b>Điện thoại</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Email</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Kích Hoạt</b>");
            sb.Append("  </th>");


            sb.Append("</tr>");
            List<Entity.Member> dt = SMember.Name_Text("SELECT * FROM Members as con WHERE ((MTRee LIKE N'%|'+CONVERT(varchar," + MoreAll.MoreAll.GetCookies("MembersID") + ")+'|%')) ORDER BY ID DESC");
            if (dt.Count > 0)
            {
                int i = 1;
                foreach (var item in dt)
                {
                    sb.Append("<tr>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + i++ + "</td>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle;text-align: left;\"><a href=\"#" + item.ID + "\">" + item.ID + "</a></td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: left;\">" + item.HoVaTen + "</td>");
                    sb.Append("    <td style=\"width:250px; vertical-align:middle;text-align: left;\">" + item.DiaChi + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: left;\">" + item.DienThoai + "</td>");
                    sb.Append("    <td style=\"width:520px; vertical-align:middle; text-align: left;\">" + item.Email + "</td>");
                    if (item.TrangThai == 0)
                    {
                        sb.Append("<td style=\"width:150px; vertical-align:middle;text-align: left;\">Bị khóa</td>");
                    }
                    else
                    {
                        sb.Append("<td style=\"width:150px; vertical-align:middle;text-align: left;\">Đang hoạt động</td>");
                    }
                    sb.Append("  </tr>");
                }
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

    }
}