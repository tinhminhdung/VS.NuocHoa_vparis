using MoreAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class MHoaHong : System.Web.UI.UserControl
    {
        public int i = 1;
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (!base.IsPostBack)
            {
                #region UpdatePanel
                #endregion
                this.DropDownList3.Items.Clear();
                this.DropDownList3.Items.Insert(0, new ListItem("Tất cả các năm", "0"));
                for (int i = 2018; i < (DateTime.Now.Year + 1); i++)
                {
                    this.DropDownList3.Items.Add(new ListItem("Năm " + i.ToString(), i.ToString()));
                }
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.DropDownList3, "0");

                if (Request["ngay"] != null && !Request["ngay"].Equals(""))
                {
                    DropDownList1.SelectedValue = Request["ngay"];
                }
                if (Request["thang"] != null && !Request["thang"].Equals(""))
                {
                    DropDownList2.SelectedValue = Request["thang"];
                }
                if (Request["nam"] != null && !Request["nam"].Equals(""))
                {
                    DropDownList3.SelectedValue = Request["nam"];
                }
                if (Request["type"] != null && !Request["type"].Equals(""))
                {
                    ddlkieu.SelectedValue = Request["type"];
                }
            }


            ShowInfo();
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                LoadItems();
            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
        }
        private void ShowInfo()
        {
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    hdid.Value = table.ID.ToString();
                }
            }
        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        private void LoadItems()
        {
            string sql = "";
            if (Request["nam"] != null && !Request["nam"].Equals("0"))
            {
                sql += " and year(NgayTao)=" + Request["nam"] + "";
            }
            if (Request["thang"] != null && !Request["thang"].Equals("0"))
            {
                sql += " and month(NgayTao)=" + Request["thang"] + "";
            }
            if (Request["ngay"] != null && !Request["ngay"].Equals("0"))
            {
                sql += " and day(NgayTao)=" + Request["ngay"] + "";
            }
            if (hdid.Value != "0")
            {
                sql += " and IDThanhVienHuong=" + hdid.Value + "";
            }
            if (ddlkieu.SelectedValue != "0")
            {
                sql += " and KieuHoaHong=" + ddlkieu.SelectedValue + "";
            }
            else
            {
                sql += " and KieuHoaHong in (1,2,10)";
            }
            List<HoaHong> table = db.ExecuteQuery<HoaHong>(@"SELECT * FROM HoaHong where 1=1 " + sql + " order by NgayTao desc").ToList();
            CollectionPager1.DataSource = table;
            CollectionPager1.BindToControl = rp_pagelist;
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = int.Parse("20");
            rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
            rp_pagelist.DataBind();
            if (!hdid.Value.Equals("0"))
            {
                double num = 0.0;
                double coin = 0.0;
                for (int i = 0; i < table.Count; i++)
                {
                    coin += Convert.ToDouble(table[i].SoTienDuocHuong.ToString());
                }
                ltCoin.Text = "Tổng tiền: " + MoreAll.MorePro.Detail_Price(coin.ToString());
            }
        }

        protected void ddlthanhvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            Show();
        }

        void Show()
        {
            Response.Redirect("/hoa-hong.html?ngay=" + DropDownList1.SelectedValue + "&thang=" + DropDownList2.SelectedValue + "&nam=" + DropDownList3.SelectedValue + "&type=" + ddlkieu.SelectedValue + "");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void ddlkieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void XuatExel_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (Request["nam"] != null && !Request["nam"].Equals("0"))
            {
                sql += " and year(NgayTao)=" + Request["nam"] + "";
            }
            if (Request["thang"] != null && !Request["thang"].Equals("0"))
            {
                sql += " and month(NgayTao)=" + Request["thang"] + "";
            }
            if (Request["ngay"] != null && !Request["ngay"].Equals("0"))
            {
                sql += " and day(NgayTao)=" + Request["ngay"] + "";
            }
            if (hdid.Value != "0")
            {
                sql += " and IDThanhVienHuong=" + hdid.Value + "";
            }
            if (ddlkieu.SelectedValue != "0")
            {
                sql += " and KieuHoaHong=" + ddlkieu.SelectedValue + "";
            }
            else
            {
                sql += " and KieuHoaHong in (1,2)";
            }
            List<HoaHong> dt = db.ExecuteQuery<HoaHong>(@"SELECT * FROM HoaHong where 1=1 " + sql + " order by NgayTao desc").ToList();

            string Namefile = "HoaHong_" + DateTime.Now;
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
            sb.Append("  <th style=\"width:520px; vertical-align:middle;\">");
            sb.Append("    <b>Kiểu Hoa Hồng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Người tham gia</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:400px; vertical-align:middle;\">");
            sb.Append("    <b>Người được hưởng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:250px; vertical-align:middle;\">");
            sb.Append("    <b>% Hoa Hồng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Điểm thưởng</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Ngày tạo</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Trạng thái</b>");
            sb.Append("  </th>");
            sb.Append("</tr>");
            if (dt.Count > 0)
            {
                int i = 1;
                foreach (var item in dt)
                {
                    sb.Append("<tr>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + i++ + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: left;\">" + item.KieuHH.ToString() + "</td>");
                    sb.Append("    <td style=\"width:400px; vertical-align:middle; text-align: left;\">" + Commond.ShowThanhVien_Display(item.IDThanhVienMua.ToString()) + "</td>");
                    sb.Append("    <td style=\"width:250px; vertical-align:middle;text-align: left;\">" + Commond.ShowThanhVien_Display(item.IDThanhVienHuong.ToString()) + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: left;\">" + item.PhanTram + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle; text-align: left;\">" + item.SoTienDuocHuong + " điểm</td>");
                    sb.Append("<td style=\"width:150px; vertical-align:middle;text-align: left;\">" + MoreAll.FormatDateTime.FormatDates(item.NgayTao) + "</td>");
                    sb.Append("<td style=\"width:150px; vertical-align:middle;text-align: left;\">Đã duyệt</td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
    }
}