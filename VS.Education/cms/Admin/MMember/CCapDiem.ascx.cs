using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Admin.MMember
{
    public partial class CCapDiem : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        public string IDThanhVien = "";
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
            if (Request["ddlkieuvi"] != null && !Request["ddlkieuvi"].Equals(""))
            {
                ddlkieuvi.SelectedValue = Request["ddlkieuvi"];
            }
            if (Request["ddlKieuCongTru"] != null && !Request["ddlKieuCongTru"].Equals(""))
            {
                ddlKieuCongTru.SelectedValue = Request["ddlKieuCongTru"];
            }

            if (!base.IsPostBack)
            {
                if (Request["IDThanhVien"] != null && !Request["IDThanhVien"].Equals(""))
                {
                    ltname.Text = this.ltshowten.Text = ShowtThanhViensssss(IDThanhVien);
                }
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                #endregion
                if (!Commond.Setting("PageChuyenDiem").Equals(""))
                {
                    ddlPage.SelectedValue = Commond.Setting("PageChuyenDiem");
                }
                if (MoreAll.MoreAll.GetCookie("URole") != null)
                {
                    string strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim();
                    if (strArray.Length > 0)
                    {
                        if (strArray.Contains("|8"))
                        {
                            this.LoadItems();
                        }
                        else if (!strArray.Contains("|8"))
                        {
                            Response.Redirect("/admin.aspx");
                        }
                    }
                }
            }
        }
        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            // try
            //{
            if (this.ltshowten.Text.Trim().Length < 0)
            {
                this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Xin vui lòng kiểm tra dữ liệu đầu vào của bạn</div>"; return;
            }
            else if (txtSoCoin.Text.Trim() == "")
            {
                this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Xin vui lòng Nhập số tiền</div>"; return;
            }
            else if (ddlCongTru.SelectedValue.Trim() == "0")
            {
                this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Xin vui lòng Chọn kiểu Cộng Hay Trừ</div>"; return;
            }
            else
            {
                string sgrnlevel = hidLevel.Value;
                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                CapDiemThanhVien obj = new CapDiemThanhVien();
                string str5 = this.hd_insertupdate.Value.Trim();
                if (str5 != null)
                {
                    if (!(str5 == "update"))
                    {
                        if (str5 == "insert")
                        {
                            string chuoi = "Cộng ví Vip";
                            if (ddlViThuong.SelectedValue == "1")
                            {
                                chuoi = "Cộng ví chính";
                            }
                            if (ddlViThuong.SelectedValue == "3")
                            {
                                chuoi = "Cộng ví VPR-S";
                            }
                            if (ddlCongTru.SelectedValue == "1")
                            {

                                if (ddlViThuong.SelectedValue == "1")
                                {
                                    obj.IDNguoiCap = 0;
                                    obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                    obj.SoTien = txtSoCoin.Text;
                                    obj.NgayCap = DateTime.Now;
                                    obj.MoTa = txtnoidung.Text;
                                    obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                    obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                    obj.KieuVi = 1;
                                    obj.CongTRu = 1;
                                    db.CapDiemThanhViens.InsertOnSubmit(obj);
                                    db.SubmitChanges();
                                    double SoCoin = Convert.ToDouble(txtSoCoin.Text);
                                    CongTien(IDThanhVien, SoCoin.ToString());
                                }
                                else if (ddlViThuong.SelectedValue == "2")
                                {
                                    obj.IDNguoiCap = 0;
                                    obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                    obj.SoTien = txtSoCoin.Text;
                                    obj.NgayCap = DateTime.Now;
                                    obj.MoTa = txtnoidung.Text;
                                    obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                    obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                    obj.KieuVi = 2;
                                    obj.CongTRu = 1;
                                    db.CapDiemThanhViens.InsertOnSubmit(obj);
                                    db.SubmitChanges();
                                    double SoCoin = Convert.ToDouble(txtSoCoin.Text);
                                    CongTienViVip(IDThanhVien, SoCoin.ToString());
                                }
                                else if (ddlViThuong.SelectedValue == "3")
                                {
                                    obj.IDNguoiCap = 0;
                                    obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                    obj.SoTien = txtSoCoin.Text;
                                    obj.NgayCap = DateTime.Now;
                                    obj.MoTa = txtnoidung.Text;
                                    obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                    obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                    obj.KieuVi = 3;
                                    obj.CongTRu = 1;
                                    db.CapDiemThanhViens.InsertOnSubmit(obj);
                                    db.SubmitChanges();
                                    double SoCoin = Convert.ToDouble(txtSoCoin.Text);
                                    CongTienViCoPhanSo(IDThanhVien, SoCoin.ToString());
                                }
                                Response.Write("<script type=\"text/javascript\">alert('Bạn đã cấp tiền thành công (" + chuoi + ") ');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
                            }
                            else
                            {

                                double SoCoin = Convert.ToDouble(txtSoCoin.Text);
                                List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
                                if (iitem.Count > 0)
                                {

                                    if (ddlViThuong.SelectedValue == "1")
                                    {
                                        double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
                                        if (TongSoCoinDaCo >= SoCoin)
                                        {
                                            obj.IDNguoiCap = 0;
                                            obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                            obj.SoTien = txtSoCoin.Text;
                                            obj.NgayCap = DateTime.Now;
                                            obj.MoTa = txtnoidung.Text;
                                            obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                            obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                            obj.KieuVi = 1;
                                            obj.CongTRu = 2;
                                            db.CapDiemThanhViens.InsertOnSubmit(obj);
                                            db.SubmitChanges();
                                            TruTien(IDThanhVien, SoCoin.ToString());
                                            Response.Write("<script type=\"text/javascript\">alert('TRỪ TIỀN VÍ CHÍNH THÀNH CÔNG');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
                                        }
                                        else
                                        {
                                            this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Số tiền không đủ để trừ Ví Chính. vui lòng kiểm tra lại</div>"; return;
                                        }

                                    }
                                    else if (ddlViThuong.SelectedValue == "2")
                                    {
                                        double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViVip);
                                        if (TongSoCoinDaCo >= SoCoin)
                                        {
                                            obj.IDNguoiCap = 0;
                                            obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                            obj.SoTien = txtSoCoin.Text;
                                            obj.NgayCap = DateTime.Now;
                                            obj.MoTa = txtnoidung.Text;
                                            obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                            obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                            obj.KieuVi = 2;
                                            obj.CongTRu = 2;
                                            db.CapDiemThanhViens.InsertOnSubmit(obj);
                                            db.SubmitChanges();
                                            TruTienViVip(IDThanhVien, SoCoin.ToString());
                                            Response.Write("<script type=\"text/javascript\">alert('TRỪ TIỀN VÍ VIP THÀNH CÔNG');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
                                        }
                                        else
                                        {
                                            this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Số tiền không đủ để trừ trong Ví Vip. vui lòng kiểm tra lại</div>"; return;
                                        }

                                    }
                                    else if (ddlViThuong.SelectedValue == "3")
                                    {
                                        double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                                        if (TongSoCoinDaCo >= SoCoin)
                                        {
                                            obj.IDNguoiCap = 0;
                                            obj.IDNguoiNhan = int.Parse(IDThanhVien);
                                            obj.SoTien = txtSoCoin.Text;
                                            obj.NgayCap = DateTime.Now;
                                            obj.MoTa = txtnoidung.Text;
                                            obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                                            obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                                            obj.KieuVi = 3;
                                            obj.CongTRu = 2;
                                            db.CapDiemThanhViens.InsertOnSubmit(obj);
                                            db.SubmitChanges();
                                            TruTienViCoPhanSo(IDThanhVien, SoCoin.ToString());
                                            Response.Write("<script type=\"text/javascript\">alert('TRỪ Điểm Ví VPR-S THÀNH CÔNG');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
                                        }
                                        else
                                        {
                                            this.lblmsg.Text = "<div style=\"color: #fff;font-weight:bold;background: #ffa903;padding: 12px;text-align: center;margin: auto;border-radius: 4px;width: 500px;font-size: 19px;margin-left: 215px;\">Số điểm ví VPR-S không đủ để trừ. vui lòng kiểm tra lại</div>"; return;
                                        }

                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        obj.ID = Convert.ToInt16(hd_page_edit_id.Value);
                        obj.IDNguoiNhan = int.Parse(IDThanhVien);
                        obj.SoTien = txtSoCoin.Text;
                        obj.NgayCap = DateTime.Now;
                        // obj.MoTa = txtMota.Text;
                        obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
                        obj.TrangThai = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                        db.SubmitChanges();
                    }
                }
                this.LoadItems();
                this.pn_list.Visible = true;
                this.pn_insert.Visible = false;
                this.hd_insertupdate.Value = "";
                this.ltshowten.Text = "";
                this.hd_insertupdate.Value = "insert";
                this.hd_id.Value = "-1";
                this.hdFileName.Value = "";
                txtSoCoin.Text = "";
                this.lblmsg.Text = "";
                this.lbl_curpage.Text = "";
            }
            // }
            //catch (Exception) { }
        }
        void CongTien(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
                SMember.Name_Text("update Members set TienHoaHong=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        void CongTienViVip(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViVip);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
                SMember.Name_Text("update Members set ViVip=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        void CongTienViCoPhanSo(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
                SMember.Name_Text("update Members set ViCoPhanSo=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        
        void TruTien(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) - (TongTienNapVao));
                SMember.Name_Text("update Members set TienHoaHong=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        void TruTienViVip(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViVip);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) - (TongTienNapVao));
                SMember.Name_Text("update Members set ViVip=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        void TruTienViCoPhanSo(string IDThanhVien, string SoTien)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                double TongTienNapVao = Convert.ToDouble(SoTien);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) - (TongTienNapVao));
                SMember.Name_Text("update Members set ViCoPhanSo=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
            this.hdFileName.Value = "";

            this.lblmsg.Text = "";

            hidLevel.Value = "";
            lbl_curpage.Text = "";

            txtSoCoin.Text = "";
            hidLevel.Value = "";
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.hdFileName.Value = "";
            txtSoCoin.Text = "";
            this.lblmsg.Text = "";
            this.ltshowten.Text = "";
            hidLevel.Value = "";

        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;

            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    CapDiemThanhVien table = db.CapDiemThanhViens.SingleOrDefault(p => p.ID == int.Parse(str2));
                    if (table != null)
                    {
                        this.pn_list.Visible = false;
                        this.pn_insert.Visible = true;
                        this.hd_insertupdate.Value = "update";
                        this.hd_page_edit_id.Value = str2.Trim();
                        this.hdid.Value = table.ID.ToString().Trim();
                        this.ltshowten.Text = ShowtThanhViens(table.IDNguoiNhan.ToString().Trim());
                        txtSoCoin.Text = table.SoTien.ToString().Trim();
                        // txtMota.Text = table.MoTa.ToString().Trim();
                        chck_Enable.Checked = (table.TrangThai == 1);
                    }
                    return;
                case "Delete":
                    List<CapDiemThanhVien> del = db.CapDiemThanhViens.Where(s => s.ID == int.Parse(str2)).ToList();// xóa nhiều
                    db.CapDiemThanhViens.DeleteAllOnSubmit(del);
                    db.SubmitChanges();
                    this.LoadItems();
                    return;
                #endregion

            }
        }

        private void LoadItems()
        {
            //List<CapDiemThanhVien> table = db.CapDiemThanhViens.Where(s => s.IDNguoiNhan == int.Parse(IDThanhVien)).OrderByDescending(x => x.ID).ToList();
            //CollectionPager1.DataSource = table;
            //CollectionPager1.BindToControl = rp_pagelist;
            //CollectionPager1.MaxPages = 10000;
            //CollectionPager1.PageSize = int.Parse(ddlPage.SelectedValue);
            //rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
            //rp_pagelist.DataBind();

            string sql = "";
            if (ddlKieuCongTru.SelectedValue != "0")
            {
                sql += " and CongTRu=" + ddlKieuCongTru.SelectedValue + "";
            }
            if (ddlkieuvi.SelectedValue != "0")
            {
                sql += " and KieuVi=" + ddlkieuvi.SelectedValue + "";
            }

            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("10");
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<CapDiemThanhVien> iitem = db.ExecuteQuery<CapDiemThanhVien>(@"SELECT * FROM CapDiemThanhVien where  IDNguoiNhan=" + IDThanhVien + " " + sql + " order by ID desc").ToList();
            if (iitem.Count() > 0)
            {
                Tongsobanghi = iitem.Count();
            }
            int PageIndex = (pages - 1);
            int Tongpage = Tongsotrang;
            int StartRecord = PageIndex * Tongpage;
            int EndRecord = StartRecord + Tongpage + 1;
            List<CapDiemThanhVien> dt = db.ExecuteQuery<CapDiemThanhVien>(@"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY ID DESC) AS rowindex ,*  FROM  CapDiemThanhVien  where IDNguoiNhan=" + IDThanhVien + " " + sql + ") AS A WHERE  ( A.rowindex >  " + StartRecord.ToString() + " AND A.rowindex < " + EndRecord + ")").ToList();
            {
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
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=CCapDiem&IDThanhVien=" + IDThanhVien + "&ddlkieuvi=" + ddlkieuvi.SelectedValue + "&ddlKieuCongTru=" + ddlKieuCongTru.SelectedValue + "", Tongsobanghi, pages);
        }
        void Show()
        {
            Response.Redirect("/admin.aspx?u=CCapDiem&IDThanhVien=" + IDThanhVien + "&ddlkieuvi=" + ddlkieuvi.SelectedValue + "&ddlKieuCongTru=" + ddlKieuCongTru.SelectedValue + "");
        }
        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.hdFileName.Value = "";
            txtSoCoin.Text = "";
            this.lblmsg.Text = "";
            hidLevel.Value = "";
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
            if (id.ToString() == "1")
            {
                return "Auto - " + NguoiTao;
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

        protected string ShowtThanhViensssss(string id)
        {
            string str = "";
            List<Entity.Member> dt = SMember.GET_BY_ID(id);
            if (dt.Count >= 1)
            {
                str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
                if (dt[0].HoVaTen.ToString().Length > 0)
                {
                    str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + dt[0].HoVaTen + " - " + dt[0].DienThoai + " </span></a>";
                }
                str += "</span>";

            }
            return str;
        }

        protected void ddlkieuvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }

        protected void ddlKieuCongTru_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show();
        }
    }
}