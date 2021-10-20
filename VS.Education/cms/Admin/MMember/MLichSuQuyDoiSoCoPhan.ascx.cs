using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using MoreAll;
using Entity;
using System.Text;

namespace VS.E_Commerce.cms.Admin.MMember
{
    public partial class MLichSuQuyDoiSoCoPhan : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        public string IDThanhVien = "";
        DateTime fDate, tDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["IDThanhVien"] != null && !Request["IDThanhVien"].Equals(""))
            {
                IDThanhVien = Request["IDThanhVien"];
            }
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
                this.Page.Form.Enctype = "multipart/form-data";
                #endregion

                if (!Commond.Setting("PageChuyenDiem").Equals(""))
                {
                    ddlPage.SelectedValue = Commond.Setting("PageChuyenDiem");
                }
                if (Request["Tu"] != null && !Request["Tu"].Equals(""))
                {
                    txtNgayThangNam.Text = Request["Tu"];
                }
                if (Request["Den"] != null && !Request["Den"].Equals(""))
                {
                    txtDenNgayThangNam.Text = Request["Den"];
                }
                if (Request["kw"] != null && !Request["kw"].Equals(""))
                {
                    txtkeyword.Text = Request["kw"];
                }
                //if (MoreAll.MoreAll.GetCookie("URole") != null)
                //{
                //    string strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim();
                //    if (strArray.Length > 0)
                //    {
                //        if (strArray.Contains("|23"))
                //        {
                this.LoadItems();
                //        }
                //        else if (!strArray.Contains("|23"))
                //        {
                //            Response.Redirect("/admin.aspx");
                //        }
                //    }
                //}
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
        protected string SearchThanhVien(string keyword)
        {
            string str = "0";
            List<Entity.Member> dt = SMember.Name_Text("select * from Members where (Hovaten like N'%" + keyword + "%')");
            if (dt.Count >= 1)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    str = str + "," + dt[i].ID.ToString();
                }
            }
            return str.Replace("0,", "");
        }
        public static string LocDate_NgayThangNam(string date)
        {
            return " and ( day(NgayCap)=" + Convert.ToDateTime(date).ToString("dd") + " and MONTH(NgayCap)=" + Convert.ToDateTime(date).ToString("MM") + "  and  year(NgayCap)=" + Convert.ToDateTime(date).ToString("yyyy") + " )";
        }
        public void LoadItems()
        {
            string sql = "";
            if (Commond.Check(txtNgayThangNam.Text))
                fDate = Commond.ConvertStringToDate(txtNgayThangNam.Text, "dd/MM/yyyy");
            if (Commond.Check(txtDenNgayThangNam.Text))
                tDate = Commond.ConvertStringToDate(txtDenNgayThangNam.Text, "dd/MM/yyyy");

            if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text != "")
            {
                sql += " AND NgayCap IS NOT NULL AND ((DATEADD(dd,-31,NgayCap)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayCap>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000') AND NgayCap <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999')";
            }
            else if (txtNgayThangNam.Text == "" && txtDenNgayThangNam.Text != "")
            {
                sql += " AND NgayCap IS NOT NULL AND NgayCap <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999'";
            }
            else if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text == "")
            {
                sql += " AND NgayCap IS NOT NULL AND (DATEADD(dd,-31,NgayCap)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayCap>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000')";
            }
            if (txtkeyword.Text != "")
            {
                sql += " and IDThanhVien in (" + SearchThanhVien(txtkeyword.Text.Trim().Replace("&nbsp;", "")) + ") ";
            }

            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse(ddlPage.SelectedValue);
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<LichSuQuyDoiSoCoPhan> iitem = db.ExecuteQuery<LichSuQuyDoiSoCoPhan>(@"SELECT * FROM LichSuQuyDoiSoCoPhan where 1=1 " + sql + " order by NgayCap desc").ToList();
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
                //double num = 0.0;
                //double coin = 0.0;
                //for (int i = 0; i < iitem.Count; i++)
                //{
                //    coin += Convert.ToDouble(iitem[i].SoTien.ToString());
                //}
               // ltCoinPage.Text = MorePro.FormatMoney_NO(coin.ToString());
            }
            int PageIndex = (pages - 1);
            int Tongpage = Tongsotrang;
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            List<LichSuQuyDoiSoCoPhan> dt = db.ExecuteQuery<LichSuQuyDoiSoCoPhan>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY NgayCap DESC) AS rowindex ,*  FROM  LichSuQuyDoiSoCoPhan  where 1=1 " + sql + " ) AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
            //if (dt.Count >= 1)
            {
                //double num = 0.0;
                //double coin = 0.0;
                //for (int i = 0; i < dt.Count; i++)
                //{
                //    coin += Convert.ToDouble(dt[i].SoTien.ToString());
                //}
                //ltCoin.Text = MorePro.FormatMoney_NO(coin.ToString());

                rp_pagelist.DataSource = dt;
                rp_pagelist.DataBind();
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=LichSuQuyDoiSoCoPhan&kw=" + txtkeyword.Text + "&Tu=" + txtNgayThangNam.Text + "&Den=" + txtDenNgayThangNam.Text + "", Tongsobanghi, pages);
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoreAll.MoreAll.Update_setting("PageChuyenDiem", ddlPage.SelectedValue);
            Response.Redirect(Request.RawUrl.ToString());
        }

        protected string ShowtThanhVien(string id, string NguoiTao)
        {
            string str = "";
            if (id.ToString() == "0")
            {
                return "Admin - " + NguoiTao;
            }
            List<Entity.Member> dt = SMember.GET_BY_ID(id);
            if (dt.Count >= 1)
            {
                str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
                if (dt[0].HoVaTen.ToString().Length > 0)
                {
                    str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + dt[0].HoVaTen + "</span></a>";
                }
                str += "</span><br>";
                if (dt[0].DienThoai.ToString().Length > 0)
                {
                    str += dt[0].DienThoai;
                }
            }
            return str;
        }
        protected string ShowtThanhViens(string id)
        {
            string str = "";
            List<Entity.Member> dt = SMember.GET_BY_ID(id);
            if (dt.Count >= 1)
            {
                str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
                if (dt[0].HoVaTen.ToString().Length > 0)
                {
                    str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + dt[0].HoVaTen + " </span></a>";
                }
                str += "</span><br>";
                if (dt[0].DienThoai.ToString().Length > 0)
                {
                    str += dt[0].DienThoai;
                }
            }
            return str;
        }
        void Show()
        {
            Response.Redirect("/admin.aspx?u=LScapdiem&kw=" + txtkeyword.Text + "&Tu=" + txtNgayThangNam.Text + "&Den=" + txtDenNgayThangNam.Text + "");
        }

        protected void lnksearch_Click(object sender, EventArgs e)
        {
            Show();
        }

        protected void txtNgayThangNam_TextChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void txtDenNgayThangNam_TextChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void lnkxuatExel_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (Commond.Check(txtNgayThangNam.Text))
                fDate = Commond.ConvertStringToDate(txtNgayThangNam.Text, "dd/MM/yyyy");
            if (Commond.Check(txtDenNgayThangNam.Text))
                tDate = Commond.ConvertStringToDate(txtDenNgayThangNam.Text, "dd/MM/yyyy");

            if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text != "")
            {
                sql += " AND NgayCap IS NOT NULL AND ((DATEADD(dd,-31,NgayCap)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayCap>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000') AND NgayCap <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999')";
            }
            else if (txtNgayThangNam.Text == "" && txtDenNgayThangNam.Text != "")
            {
                sql += " AND NgayCap IS NOT NULL AND NgayCap <='" + Commond.FormatDate(tDate.Date) + " 23:59:59.999'";
            }
            else if (txtNgayThangNam.Text != "" && txtDenNgayThangNam.Text == "")
            {
                sql += " AND NgayCap IS NOT NULL AND (DATEADD(dd,-31,NgayCap)>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000' OR NgayCap>='" + Commond.FormatDate(fDate.Date) + " 00:00:00.000')";
            }
            if (txtkeyword.Text != "")
            {
                sql += " and IDThanhVien in (" + SearchThanhVien(txtkeyword.Text.Trim().Replace("&nbsp;", "")) + ") ";
            }

            string Namefile = "QuyDoiSoCoPhan" + DateTime.Now;
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
            sb.Append("  <th style=\"width:400px; vertical-align:middle;\">");
            sb.Append("    <b>Tên thành viên</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:250px; vertical-align:middle;\">");
            sb.Append("    <b>Số Cổ phần / điểm</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Ngày cấp</b>");
            sb.Append("  </th>");
            sb.Append("  <th style=\"width:150px; vertical-align:middle;\">");
            sb.Append("    <b>Mô tả</b>");
            sb.Append("  </th>");
            sb.Append("</tr>");
            List<LichSuQuyDoiSoCoPhan> dt = db.ExecuteQuery<LichSuQuyDoiSoCoPhan>(@"SELECT * FROM LichSuQuyDoiSoCoPhan where 1=1 " + sql + " order by NgayCap desc").ToList();
            if (dt.Count > 0)
            {
                int i = 1;
                foreach (var item in dt)
                {
                    sb.Append("<tr>");
                    sb.Append("    <td style=\"width:50px; vertical-align:middle; height: 22px; text-align: center;\">" + i++ + "</td>");
                    sb.Append("    <td style=\"width:400px; vertical-align:middle;text-align: left;\">" + item.NguoiTao + "</td>");
                    sb.Append("    <td style=\"width:400px; vertical-align:middle; text-align: left;\">" + ShowtThanhViens(item.IDThanhVien.ToString()) + "</td>");
                    sb.Append("    <td style=\"width:250px; vertical-align:middle;text-align: left;\">" + item.SoTien + "</td>");
                    sb.Append("    <td style=\"width:150px; vertical-align:middle;text-align: left;\">" + item.NgayCap + "</td>");
                    sb.Append("    <td style=\"width:520px; vertical-align:middle; text-align: left;\">" + item.MoTa + "</td>");
                    sb.Append("  </tr>");
                }
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        protected void ddlvidiem_TextChanged(object sender, EventArgs e)
        {
            Show();
        }
    }
}