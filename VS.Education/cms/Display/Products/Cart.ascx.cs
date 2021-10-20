using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Services;
using Entity;
using Framwork;
using Framework;
using WebApplication2;
using API_NganLuong;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Cart : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
                if (MoreAll.MoreAll.GetCookies("Members") != "")
                {
                    txtgiohang.Text = MoreAll.Other.GioHang();
                    this.LoadCart();
                    this.btnSendOrder.Text = this.label("l_produc_sder");
                    this._btctnew.Text = this.label("l_produc_Continue_Shopping");
                    this.btnCancelOrder.Text = this.label("l_produc_Cancel_Order");
                    Showthanhvien();
                }
                else
                {
                    Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
                }
            }
        }

        public void Showthanhvien()
        {
            if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
            {
                if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
                {
                    List<Member> dt = db.Members.Where(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString())).ToList();
                    if (dt != null)
                    {
                        txtName.Text = dt[0].HoVaTen;
                        txtAddress.Text = dt[0].DiaChi;
                        txtEmail.Text = dt[0].Email;
                        txtPhone.Text = dt[0].DienThoai;
                        hdIDThanhVien.Value = dt[0].ID.ToString();
                        ltvitien.Text = MorePro.FormatMoney_Cart_Total(dt[0].TienHoaHong);
                        ltViVip.Text = MorePro.FormatMoney_Cart_Total(dt[0].ViVip);
                        hdTienHoaHong.Value = dt[0].TienHoaHong.ToString();
                        hdViVip.Value = dt[0].ViVip.ToString();
                        hdViVipDaMuaHang.Value = dt[0].ViVipDaMuaHang.ToString();

                        hdTongTienDaMuaHang.Value = dt[0].TongTienDaMuaHang.ToString();

                        double TSoTienPhaiThanhToan = Convert.ToDouble(hdtongtien.Value);
                        double TSoTienThanhVien = Convert.ToDouble(dt[0].TienHoaHong.ToString());
                        double BatTatViVip = Convert.ToDouble(Commond.Setting("BatTatViVip"));
                        double ViVipThuong = Convert.ToDouble(Commond.Setting("ViVipThuong"));
                        double ViVip = Convert.ToDouble(dt[0].ViVip.ToString());

                        // if (BatTatViVip == 1)
                        //{

                        if (ViVip > 0)
                        {
                            Panel3.Visible = true;
                        }

                        double tongthanhtoan = 0;
                        double TongPhanTramViVip = (TSoTienPhaiThanhToan * ViVipThuong) / 100;
                        if (ViVip >= TongPhanTramViVip)
                        {
                            tongthanhtoan = (TSoTienThanhVien + TongPhanTramViVip) - TSoTienPhaiThanhToan;
                        }
                        else
                        {
                            tongthanhtoan = (TSoTienThanhVien) - TSoTienPhaiThanhToan;
                        }
                        double TongTTKOTRU = (TSoTienThanhVien) - tongthanhtoan;
                        ltconlai.Text = MorePro.FormatMoney_Cart_Total(tongthanhtoan.ToString());
                        ltTruViChinh.Text = MorePro.FormatMoney_Cart_Total(TongTTKOTRU.ToString());

                        hdTTConLaiViChinh.Value = tongthanhtoan.ToString();
                        hdTTThanhToanMuaHang.Value = TongTTKOTRU.ToString();

                        if (ViVip >= TongPhanTramViVip)
                        {
                            Panel2.Visible = true;
                            ltTruViVip.Text = MorePro.FormatMoney_Cart_Total(TongPhanTramViVip.ToString());
                            dhTTViVipThanhToanMuaHang.Value = TongPhanTramViVip.ToString();

                            double VipConlai = (ViVip) - TongPhanTramViVip;
                            ltvivipconlai.Text = MorePro.FormatMoney_Cart_Total(VipConlai.ToString());
                            hdTTViViConLai.Value = VipConlai.ToString();
                        }
                        else
                        {
                            ltTruViVip.Text = "0";
                            dhTTViVipThanhToanMuaHang.Value = "0";
                            hdTTViViConLai.Value = hdViVipDaMuaHang.Value;
                        }

                        if (tongthanhtoan >= 0)
                        {
                        }
                        else
                        {
                            btnSendOrder.Visible = false;
                            ltthongbao.Text = "<a data-toggle=\"modal\" data-target=\"#myModal\" class='Dathangthongbao'>Đặt hàng</a>";
                        }
                        //    }
                        //    else
                        //    {
                        //        double tongthanhtoan = (TSoTienThanhVien) - TSoTienPhaiThanhToan;
                        //        double TongTTKOTRU = (TSoTienThanhVien) - tongthanhtoan;
                        //        ltconlai.Text = MorePro.FormatMoney_Cart_Total(tongthanhtoan.ToString());
                        //        ltTruViChinh.Text = MorePro.FormatMoney_Cart_Total(TongTTKOTRU.ToString());

                        //        Double TongTien = Convert.ToDouble(hdtongtien.Value);
                        //        Double TienHoaHong = Convert.ToDouble(dt[0].TienHoaHong);
                        //        if (TongTien > TienHoaHong)
                        //        {
                        //            btnSendOrder.Visible = false;
                        //            ltthongbao.Text = "<a data-toggle=\"modal\" data-target=\"#myModal\" class='Dathangthongbao'>Đặt hàng</a>";
                        //        }
                        //    }
                    }
                }
            }
        }
        protected void ItemDataBound_RP(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemIndex != -1) && (e.Item.ItemType != ListItemType.Separator))
            {
                Label lb_tt = (Label)e.Item.FindControl("lb_tt");
                lb_tt.Text = (e.Item.ItemIndex + 1).ToString();
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        private void LoadCart()
        {
            try
            {
                double LoiNhuan = 0.0;
                if (Session["cart"] != null)
                {
                    DataTable dtcart = (DataTable)Session["cart"];
                    if (dtcart.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dtcart;
                        Repeater1.DataBind();
                        string inumofproducts = "";
                        string totalvnd = "";
                        if (dtcart.Rows.Count > 0)
                        {
                            double num = 0.0;

                            int num2 = 0;
                            for (int i = 0; i < dtcart.Rows.Count; i++)
                            {
                                num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                                num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                                LoiNhuan += Convert.ToInt32(dtcart.Rows[i]["TienLoiNhuan"].ToString());
                            }
                            totalvnd = num.ToString();
                            inumofproducts = num2.ToString();
                        }
                        this.ltTotalOrder.Text = MorePro.FormatMoney_Cart_Total(totalvnd.ToString());

                        hdtongtien.Value = totalvnd.ToString();
                        this.ltProdinCart.Text = inumofproducts;
                        hdTienLoiNhuan.Value = LoiNhuan.ToString();
                        float total = 0;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            total += Convert.ToSingle(dtcart.Rows[i]["Money"]);
                        }
                        // Response.Write("LoiNhuan:" + LoiNhuan.ToString());
                        this.pnOrder.Visible = true;
                        this.pnmessage.Visible = false;

                        Showthanhvien();
                    }
                    else
                    {
                        this.pnOrder.Visible = false;
                        this.pnmessage.Visible = true;
                    }
                }
                else
                {
                    this.pnOrder.Visible = false;
                    this.pnmessage.Visible = true;
                }
            }
            catch (Exception)
            {
                Response.Redirect("/gio-hang.html");
            }
        }
        protected void lnkdeletecart_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
            base.Response.Redirect("/Message.html");
        }

        protected void btnSendOrder_Click(object sender, EventArgs e)
        {
            //  try
            //{
            btnCancelOrder.Enabled = false;
            System.Threading.Thread.Sleep(1000);
            if (this.txtName.Text.Length < 1)
            {
                this.lblMsg.Text = "Bạn phải nhập họ t\x00ean!!!";
            }
            else if (this.txtAddress.Text.Length < 1)
            {
                this.lblMsg.Text = "Bạn phải nhập địa chỉ!!!";
            }
            else if (this.txtPhone.Text.Length < 1)
            {
                this.lblMsg.Text = "Bạn phải nhập số điện thoại li\x00ean hệ!!!";
            }
            else if (this.txtEmail.Text.Length < 1)
            {
                this.lblMsg.Text = "Bạn phải nhập địa chỉ email!!!";
            }
            else if (!ValidateUtilities.IsValidEmail(this.txtEmail.Text.Trim()))
            {
                this.lblMsg.Text = "Địa chỉ email kh\x00f4ng hợp lệ!!!";
            }
            else
            {
                #region giaohangtannoi
                string chuoi1 = "";
                string chuoi2 = "";
                Session["Phuongthucvanchuyen"] = chuoi1;
                Session["Hinhthucthanhtoan"] = chuoi2;
                #endregion
                try
                {
                    if (!MoreAll.Other.Giatri("Emailden").Equals(""))
                        Senmail();
                }
                catch (Exception)
                { }


                ThanhtoanGiohang();
            }


            //}
            //catch (Exception)
            //{
            //    this.lblMsg.Text = "Sự cố lỗi xẩy ra liên quan tới Email của hệ thống chưa chính xác, Bạn có thể liên hệ với quản trị viên websie";
            //}
        }

        protected void ThanhtoanGiohang()
        {
            try
            {
                #region Giỏ hàng
                // 1. them gio hang
                string inumofproducts = "0";
                string totalvnd = "0";
                DataTable dtcart = new DataTable();
                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                        num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                    }
                    totalvnd = num.ToString();
                    inumofproducts = num2.ToString();
                }
                // 2. them chi tiet gio hang
                Carts obj = new Carts();
                string chuoi1 = "";
                string chuoi2 = "";

                double TienDauVaoLN = 0;
                double BatTatViVip = Convert.ToDouble(Commond.Setting("BatTatViVip"));
                if (Commond.ShowTrangThai() == "0")// sản phẩm lợi nhuận
                {
                    TienDauVaoLN = Convert.ToDouble(hdTienLoiNhuan.Value); // Lấy tiền của giá bán để chia lợi nhuận
                }
                else
                {
                    if (BatTatViVip == 1)
                    {
                        TienDauVaoLN = Convert.ToDouble(hdtongtien.Value) - Convert.ToDouble(dhTTViVipThanhToanMuaHang.Value);
                    }
                    else
                    {
                        TienDauVaoLN = Convert.ToDouble(hdtongtien.Value);
                    }
                }

                int cartid = FCarts.Insert(this.txtName.Text.Trim(), this.txtAddress.Text.Trim(), this.txtPhone.Text.Trim(), this.txtEmail.Text.Trim(), this.txtnoidung.Text.Trim(), totalvnd, language, "0", chuoi1, chuoi2, "0", hdIDThanhVien.Value, TienDauVaoLN.ToString(), Commond.ShowTrangThai(), dhTTViVipThanhToanMuaHang.Value, hdTTThanhToanMuaHang.Value);
                CartDetail oj = new CartDetail();
                if (Session["cart"] != null)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        #region MyRegion
                        oj.ID_Cart = int.Parse(cartid.ToString());
                        oj.ipid = int.Parse(dtcart.Rows[i]["PID"].ToString());
                        oj.Price = Convert.ToSingle(dtcart.Rows[i]["Price"].ToString());
                        oj.Quantity = int.Parse(dtcart.Rows[i]["Quantity"].ToString());
                        oj.Money = Convert.ToSingle(dtcart.Rows[i]["Money"].ToString());
                        oj.Mausac = int.Parse(dtcart.Rows[i]["Mausac"].ToString());
                        oj.Kichco = int.Parse(dtcart.Rows[i]["Kichco"].ToString());
                        oj.TienLoiNhuan = int.Parse(dtcart.Rows[i]["TienLoiNhuan"].ToString());
                        #endregion
                        SCartDetail.CartDetail_Insert(oj);
                    }
                }

                #endregion

                #region Thanhtoantien
                double TSoTienPhaiThanhToan = Convert.ToDouble(hdtongtien.Value);
                double TSoTienThanhVien = Convert.ToDouble(hdTienHoaHong.Value);
                double ViVipThuong = Convert.ToDouble(Commond.Setting("ViVipThuong"));
                double ViVip = Convert.ToDouble(hdViVip.Value);

                double TTViVipThanhToanMuaHang = Convert.ToDouble(dhTTViVipThanhToanMuaHang.Value);

                SMember.Name_Text("update Members set TienHoaHong='" + hdTTConLaiViChinh.Value + "'  where ID=" + hdIDThanhVien.Value + "");
                SMember.Name_Text("update Members set ViVip=" + hdTTViViConLai.Value + "  where ID=" + hdIDThanhVien.Value + "");

                // Cộng tổng tiền đã mua hàng
                double TongTienv = Convert.ToDouble(hdTongTienDaMuaHang.Value);
                double ConglaiTMH = ((TongTienv) + (TSoTienPhaiThanhToan)) - TTViVipThanhToanMuaHang;
                SMember.Name_Text("update Members set TongTienDaMuaHang=" + ConglaiTMH.ToString() + "  where ID=" + hdIDThanhVien.Value + "");

                // Cộng tổng tiền đã mua hàng

                double ViVipDaMuaHang = Convert.ToDouble(hdViVipDaMuaHang.Value);

                double ConglaiMHVV = ((TTViVipThanhToanMuaHang) + (ViVipDaMuaHang));
                SMember.Name_Text("update Members set ViVipDaMuaHang=" + ConglaiMHVV.ToString() + "  where ID=" + hdIDThanhVien.Value + "");


                #endregion

                #region Tặng số cổ phần khi đặt hàng , theo cấu hình so sánh khoảng giá tiền khi đặt hàng
                string VPRS = Commond.Setting("VPRS");
                if (VPRS != "0" && VPRS != "")
                {
                    Commond.TangSoCoPhanKhiDatHang(TSoTienPhaiThanhToan.ToString(), hdIDThanhVien.Value);
                }
                #endregion




                if (Commond.ShowTrangThai() == "0")// sản phẩm lợi nhuận
                {
                    // btduyet.Visible = true;
                    #region sản phẩm lợi nhuận
                    string TienDauVao = hdTienLoiNhuan.Value;
                    string IDCart = cartid.ToString();
                    string IDThanhVien = hdIDThanhVien.Value;
                    Double Money = Convert.ToDouble(TienDauVao.ToString());

                    Double TongTien = 0;
                    List<Entity.Member> dt = SMember.Name_Text("select * from Members where Id=" + IDThanhVien);
                    if (dt.Count > 0)
                    {
                        #region Tìm cha cho HH TT
                        List<Entity.Member> F1 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + "  ");
                        if (F1.Count > 0)
                        {
                            if (F1[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F1[0].ID.ToString()) != "0")
                            {
                                // Tìm cha cho HH TT
                                double HoaHongTT = Convert.ToDouble(MoreAll.Other.Giatri("HoaHongTrucTiep"));//
                                if (HoaHongTT > 0)
                                {
                                    double TongHHTT = (Money * HoaHongTT) / 100;
                                    Commond.ThemHoaHong("2", "Hoa Hồng bán hàng", TienDauVao.ToString(), TongHHTT.ToString(), HoaHongTT.ToString(), IDThanhVien.ToString(), F1[0].ID.ToString(), IDCart);
                                    TongTien += TongHHTT;
                                }
                            }
                            List<Entity.Member> F2 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + " ");
                            if (F2.Count > 0)
                            {
                                if (F2[0].GioiThieu.ToString() != "0" && F2[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F2[0].GioiThieu.ToString()) != "0")
                                {
                                    // Tìm cha cho HH TT
                                    double HoaHongTTF2 = Convert.ToDouble(MoreAll.Other.Giatri("txtF2"));//
                                    if (HoaHongTTF2 > 0)
                                    {
                                        double TongHHTTF2 = (Money * HoaHongTTF2) / 100;
                                        Commond.ThemHoaHong("2", "Doanh số nhóm 2", TienDauVao.ToString(), TongHHTTF2.ToString(), HoaHongTTF2.ToString(), IDThanhVien.ToString(), F2[0].GioiThieu.ToString(), IDCart);
                                        TongTien += TongHHTTF2;
                                    }
                                }
                                List<Entity.Member> F3 = SMember.Name_Text("select * from Members where Id=" + F2[0].GioiThieu.ToString() + "");
                                if (F3.Count > 0)
                                {
                                    if (F3[0].GioiThieu.ToString() != "0" && F3[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F3[0].GioiThieu.ToString()) != "0")
                                    {
                                        // Tìm cha cho HH TT
                                        double HoaHongTTF3 = Convert.ToDouble(MoreAll.Other.Giatri("txtF3"));//
                                        if (HoaHongTTF3 > 0)
                                        {
                                            double TongHHTTF3 = (Money * HoaHongTTF3) / 100;
                                            Commond.ThemHoaHong("2", "Doanh số nhóm 3", TienDauVao.ToString(), TongHHTTF3.ToString(), HoaHongTTF3.ToString(), IDThanhVien.ToString(), F3[0].GioiThieu.ToString(), IDCart);
                                            TongTien += TongHHTTF3;
                                        }
                                    }
                                    List<Entity.Member> F4 = SMember.Name_Text("select * from Members where Id=" + F3[0].GioiThieu.ToString() + " ");
                                    if (F4.Count > 0)
                                    {
                                        if (F4[0].GioiThieu.ToString() != "0" && F4[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F4[0].GioiThieu.ToString()) != "0")
                                        {
                                            // Tìm cha cho HH TT
                                            double HoaHongTTF4 = Convert.ToDouble(MoreAll.Other.Giatri("txtF4"));//
                                            if (HoaHongTTF4 > 0)
                                            {
                                                double TongHHTTF4 = (Money * HoaHongTTF4) / 100;
                                                Commond.ThemHoaHong("2", "Doanh số nhóm 4", TienDauVao.ToString(), TongHHTTF4.ToString(), HoaHongTTF4.ToString(), IDThanhVien.ToString(), F4[0].GioiThieu.ToString(), IDCart);
                                                TongTien += TongHHTTF4;
                                            }
                                        }
                                        List<Entity.Member> F5 = SMember.Name_Text("select * from Members where Id=" + F4[0].GioiThieu.ToString() + " ");
                                        if (F5.Count > 0)
                                        {
                                            if (F5[0].GioiThieu.ToString() != "0" && F5[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F5[0].GioiThieu.ToString()) != "0")
                                            {
                                                // Tìm cha cho HH TT
                                                double HoaHongTTF5 = Convert.ToDouble(MoreAll.Other.Giatri("txtF5"));//
                                                if (HoaHongTTF5 > 0)
                                                {
                                                    double TongHHTTF5 = (Money * HoaHongTTF5) / 100;
                                                    Commond.ThemHoaHong("2", "Doanh số nhóm 5", TienDauVao.ToString(), TongHHTTF5.ToString(), HoaHongTTF5.ToString(), IDThanhVien.ToString(), F5[0].GioiThieu.ToString(), IDCart);
                                                    TongTien += TongHHTTF5;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Đếm F1 cho người giới thiệu
                        List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where ID =" + IDThanhVien.ToString() + "");
                        if (tb1.Count() > 0)
                        {
                            if (tb1[0].TrangThaiMuaHang.ToString() == "0")
                            {
                                SMember.Name_Text("update Members set TongTrucTiep=TongTrucTiep+1  where ID=" + tb1[0].GioiThieu.ToString() + "");


                                //Phải mua hàng chiến lược thì mới có thay đổi trạng thái,  Nếu ko mua sản phẩm chiến lược thì chưa dc hưởng hh
                                //SMember.Name_Text("update Members set TrangThaiMuaHang=1  where ID=" + IDThanhVien.ToString() + "");
                            }

                            if (tb1[0].TrangThaiF1MuaHangSoCoPhan.ToString() == "0")
                            {
                                string TongSoF1 = Commond.Setting("TongSoF1VPRS");
                                if (TongSoF1 != "0" && TongSoF1 != "")
                                {
                                    #region Đếm tổng 3 F1 thì cho tiền thưởng nóng 250 K
                                    SMember.Name_Text("update Members set TrangThaiF1MuaHangSoCoPhan=1  where ID=" + IDThanhVien.ToString() + "");
                                    SMember.Name_Text("update Members set F1MuaHangThuongSoCoPhan=F1MuaHangThuongSoCoPhan+1  where ID=" + tb1[0].GioiThieu.ToString() + " ");
                                    CapBac.ThuongNongKhiTimRaF1_CoPhan(tb1[0].GioiThieu.ToString());
                                    #endregion
                                }
                            }


                            if (tb1[0].TrangThaiF1MuaHang.ToString() == "0")
                            {
                                string TongSoF1 = Commond.Setting("TongSoF1");
                                if (TongSoF1 != "0" && TongSoF1 != "")
                                {
                                    #region Đếm tổng 3 F1 thì cho tiền thưởng nóng 250 K
                                    SMember.Name_Text("update Members set TrangThaiF1MuaHang=1  where ID=" + IDThanhVien.ToString() + "");
                                    SMember.Name_Text("update Members set F1MuaHangDeTinhThuong=F1MuaHangDeTinhThuong+1  where ID=" + tb1[0].GioiThieu.ToString() + " ");
                                    CapBac.ThuongNongKhiTimRaF1(tb1[0].GioiThieu.ToString());
                                    #endregion
                                }
                            }


                            Double Tongtiens = Convert.ToDouble(TienDauVao.ToString());
                            Double Giatridonhang = Convert.ToDouble(Commond.Setting("txtgiatridonhang"));
                            if (Tongtiens >= Giatridonhang)
                            {
                                SMember.Name_Text("update Members set TrangThaiMuaHangDatTongTien=1  where ID=" + IDThanhVien.ToString() + "");
                            }
                        }
                        #endregion

                        // SCarts.Name_Text("update Carts set Status=0 where ID=" + cartid.ToString() + "");// = 5 là đã sinh Hoa hồng , admin phải duyệt lại 

                        CapBac.ChiaHoaHongCapBacs(IDThanhVien.ToString(), TienDauVao.ToString(), IDCart.ToString());

                        #region Vi Loi Nhuan sau khi da chia HH
                        //try
                        {
                            Double TongTienHoaHongDaChiaCapBac = Convert.ToDouble(CapBac.KiemTraTongTienHoaHongDaChiaCapBac(IDCart, IDThanhVien));

                            Double TongTiens = Convert.ToDouble(TongTien.ToString());
                            Double TongTienss = Convert.ToDouble(TienDauVao.ToString());
                            Double TongCong = (TongTienss - TongTiens - TongTienHoaHongDaChiaCapBac);
                            Double TongTienDaChia = Convert.ToDouble(TongTien.ToString()) + TongTienHoaHongDaChiaCapBac;

                            LoiNhuanMuaBan abln = new LoiNhuanMuaBan();
                            abln.IDThanhVienMua = int.Parse(IDThanhVien.ToString());
                            abln.IDDonHang = int.Parse(cartid.ToString());
                            abln.MoTa = "";
                            abln.NgayTao = DateTime.Now;
                            abln.TongTien = TienDauVao.ToString();
                            abln.TongTienCon = TongCong.ToString();
                            abln.TongTienDaChia = TongTienDaChia.ToString();
                            abln.MTreeIDThanhVienMua = Commond.ShowMTree(IDThanhVien.ToString());
                            db.LoiNhuanMuaBans.InsertOnSubmit(abln);
                            db.SubmitChanges();

                        }
                        //catch (Exception)
                        { }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    double TienDauVao = 0;
                    if (BatTatViVip == 1)
                    {
                        TienDauVao = Convert.ToDouble(hdtongtien.Value) - Convert.ToDouble(dhTTViVipThanhToanMuaHang.Value);
                    }
                    else
                    {
                        TienDauVao = Convert.ToDouble(hdtongtien.Value);// Lấy tiền của giá bán để chia lợi nhuận
                    }
                    //  btduyetChienLuoc.Visible = true;
                    #region ChienLuoc

                    string IDCart = cartid.ToString();
                    string IDThanhVien = hdIDThanhVien.Value;
                    Double Money = Convert.ToDouble(TienDauVao.ToString());

                    Double TongTien = 0;
                    List<Entity.Member> dt = SMember.Name_Text("select * from Members where Id=" + IDThanhVien);
                    if (dt.Count > 0)
                    {
                        #region Tìm cha cho HH TT
                        List<Entity.Member> F1 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + "  ");
                        if (F1.Count > 0)
                        {
                            if (F1[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F1[0].ID.ToString()) != "0")
                            {
                                // Tìm cha cho HH TT
                                double HoaHongTT = Convert.ToDouble(MoreAll.Other.Giatri("HoaHongTrucTiepChienLuoc"));//
                                if (HoaHongTT > 0)
                                {
                                    double TongHHTT = (Money * HoaHongTT) / 100;
                                    Commond.ThemHoaHong("2", "Hoa Hồng bán hàng", TienDauVao.ToString(), TongHHTT.ToString(), HoaHongTT.ToString(), IDThanhVien.ToString(), F1[0].ID.ToString(), IDCart);
                                    TongTien += TongHHTT;
                                }
                            }
                            List<Entity.Member> F2 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + " ");
                            if (F2.Count > 0)
                            {
                                if (F2[0].GioiThieu.ToString() != "0" && F2[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F2[0].GioiThieu.ToString()) != "0")
                                {
                                    // Tìm cha cho HH TT
                                    double HoaHongTTF2 = Convert.ToDouble(MoreAll.Other.Giatri("txtF2ChienLuoc"));//
                                    if (HoaHongTTF2 > 0)
                                    {
                                        double TongHHTTF2 = (Money * HoaHongTTF2) / 100;
                                        Commond.ThemHoaHong("2", "Doanh số nhóm 2", TienDauVao.ToString(), TongHHTTF2.ToString(), HoaHongTTF2.ToString(), IDThanhVien.ToString(), F2[0].GioiThieu.ToString(), IDCart);
                                        TongTien += TongHHTTF2;
                                    }
                                }
                                List<Entity.Member> F3 = SMember.Name_Text("select * from Members where Id=" + F2[0].GioiThieu.ToString() + "");
                                if (F3.Count > 0)
                                {
                                    if (F3[0].GioiThieu.ToString() != "0" && F3[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F3[0].GioiThieu.ToString()) != "0")
                                    {
                                        // Tìm cha cho HH TT
                                        double HoaHongTTF3 = Convert.ToDouble(MoreAll.Other.Giatri("txtF3ChienLuoc"));//
                                        if (HoaHongTTF3 > 0)
                                        {
                                            double TongHHTTF3 = (Money * HoaHongTTF3) / 100;
                                            Commond.ThemHoaHong("2", "Doanh số nhóm 3", TienDauVao.ToString(), TongHHTTF3.ToString(), HoaHongTTF3.ToString(), IDThanhVien.ToString(), F3[0].GioiThieu.ToString(), IDCart);
                                            TongTien += TongHHTTF3;
                                        }
                                    }
                                    List<Entity.Member> F4 = SMember.Name_Text("select * from Members where Id=" + F3[0].GioiThieu.ToString() + " ");
                                    if (F4.Count > 0)
                                    {
                                        if (F4[0].GioiThieu.ToString() != "0" && F4[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F4[0].GioiThieu.ToString()) != "0")
                                        {
                                            // Tìm cha cho HH TT
                                            double HoaHongTTF4 = Convert.ToDouble(MoreAll.Other.Giatri("txtF4ChienLuoc"));//
                                            if (HoaHongTTF4 > 0)
                                            {
                                                double TongHHTTF4 = (Money * HoaHongTTF4) / 100;
                                                Commond.ThemHoaHong("2", "Doanh số nhóm 4", TienDauVao.ToString(), TongHHTTF4.ToString(), HoaHongTTF4.ToString(), IDThanhVien.ToString(), F4[0].GioiThieu.ToString(), IDCart);
                                                TongTien += TongHHTTF4;
                                            }
                                        }
                                        List<Entity.Member> F5 = SMember.Name_Text("select * from Members where Id=" + F4[0].GioiThieu.ToString() + " ");
                                        if (F5.Count > 0)
                                        {
                                            if (F5[0].GioiThieu.ToString() != "0" && F5[0].TrangThaiMuaHang.ToString() != "0" && Commond.ShowTrangThaiMuaHang(F5[0].GioiThieu.ToString()) != "0")
                                            {
                                                // Tìm cha cho HH TT
                                                double HoaHongTTF5 = Convert.ToDouble(MoreAll.Other.Giatri("txtF5ChienLuoc"));//
                                                if (HoaHongTTF5 > 0)
                                                {
                                                    double TongHHTTF5 = (Money * HoaHongTTF5) / 100;
                                                    Commond.ThemHoaHong("2", "Doanh số nhóm 5", TienDauVao.ToString(), TongHHTTF5.ToString(), HoaHongTTF5.ToString(), IDThanhVien.ToString(), F5[0].GioiThieu.ToString(), IDCart);
                                                    TongTien += TongHHTTF5;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Đếm F1 cho người giới thiệu
                        List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where ID =" + IDThanhVien.ToString() + "");
                        if (tb1.Count() > 0)
                        {
                            if (tb1[0].TrangThaiMuaHang.ToString() == "0")
                            {
                                SMember.Name_Text("update Members set TongTrucTiep=TongTrucTiep+1  where ID=" + tb1[0].GioiThieu.ToString() + "");
                                SMember.Name_Text("update Members set TrangThaiMuaHang=1  where ID=" + IDThanhVien.ToString() + "");
                                // Thành viên mua  CHIẾN LƯỢC  THÌ MỚI THAY ĐỔI TRẠNG THÁI VÀ CHO hoa hồng
                            }

                            if (tb1[0].TrangThaiF1MuaHangSoCoPhan.ToString() == "0")
                            {
                                string TongSoF1 = Commond.Setting("TongSoF1VPRS");
                                if (TongSoF1 != "0" && TongSoF1 != "")
                                {
                                    #region Đếm tổng 3 F1 thì cho tiền thưởng nóng 250 K
                                    SMember.Name_Text("update Members set TrangThaiF1MuaHangSoCoPhan=1  where ID=" + IDThanhVien.ToString() + "");
                                    SMember.Name_Text("update Members set F1MuaHangThuongSoCoPhan=F1MuaHangThuongSoCoPhan+1  where ID=" + tb1[0].GioiThieu.ToString() + " ");
                                    CapBac.ThuongNongKhiTimRaF1_CoPhan(tb1[0].GioiThieu.ToString());
                                    #endregion
                                }
                            }


                            if (tb1[0].TrangThaiF1MuaHang.ToString() == "0")
                            {
                                string TongSoF1 = Commond.Setting("TongSoF1");
                                if (TongSoF1 != "0" && TongSoF1 != "")
                                {
                                    #region Đếm tổng 3 F1 thì cho tiền thưởng nóng 250 K
                                    SMember.Name_Text("update Members set TrangThaiF1MuaHang=1  where ID=" + IDThanhVien.ToString() + "");
                                    SMember.Name_Text("update Members set F1MuaHangDeTinhThuong=F1MuaHangDeTinhThuong+1  where ID=" + tb1[0].GioiThieu.ToString() + " ");
                                    CapBac.ThuongNongKhiTimRaF1(tb1[0].GioiThieu.ToString());
                                    #endregion
                                }
                            }

                            Double Tongtiens = Convert.ToDouble(TienDauVao.ToString());
                            Double Giatridonhang = Convert.ToDouble(Commond.Setting("txtgiatridonhang"));
                            if (Tongtiens >= Giatridonhang)
                            {
                                SMember.Name_Text("update Members set TrangThaiMuaHangDatTongTien=1  where ID=" + IDThanhVien.ToString() + "");
                            }
                        }
                        #endregion

                        // SCarts.Name_Text("update Carts set Status=0 where ID=" + cartid.ToString() + "");
                        CapBac.ChiaHoaHongCapBacs(IDThanhVien.ToString(), TienDauVao.ToString(), IDCart.ToString());

                        #region Vi Loi Nhuan sau khi da chia HH
                        // try
                        {

                            Double TongTienHoaHongDaChiaCapBac = Convert.ToDouble(CapBac.KiemTraTongTienHoaHongDaChiaCapBac(IDCart, IDThanhVien));

                            Double TongTiens = Convert.ToDouble(TongTien.ToString());
                            Double TongTienss = Convert.ToDouble(TienDauVao.ToString());
                            Double TongCong = (TongTienss - TongTiens - TongTienHoaHongDaChiaCapBac);
                            Double TongTienDaChia = Convert.ToDouble(TongTien.ToString()) + TongTienHoaHongDaChiaCapBac;

                            LoiNhuanMuaBan abln = new LoiNhuanMuaBan();
                            abln.IDThanhVienMua = int.Parse(IDThanhVien.ToString());
                            abln.IDDonHang = int.Parse(cartid.ToString());
                            abln.MoTa = "";
                            abln.NgayTao = DateTime.Now;
                            abln.TongTien = TienDauVao.ToString();
                            abln.TongTienCon = TongCong.ToString();
                            abln.TongTienDaChia = TongTienDaChia.ToString();
                            abln.MTreeIDThanhVienMua = Commond.ShowMTree(IDThanhVien.ToString());
                            db.LoiNhuanMuaBans.InsertOnSubmit(abln);
                            db.SubmitChanges();
                        }
                        // catch (Exception)
                        { }
                        #endregion
                    }
                    #endregion
                }
            }
            catch (Exception)
            {
                Response.Redirect("/gio-hang.html");
            }

            System.Web.HttpContext.Current.Session["cart"] = null;
            System.Web.HttpContext.Current.Session["Session_Size"] = null;
            System.Web.HttpContext.Current.Session["Session_MauSac"] = null;
            base.Response.Redirect("/Ordersucess.html");
        }
        protected void Senmail()
        {
            try
            {
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; border-collapse: collapse; width: 569pt;\" width=\"758\">");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; height: 24pt;\"></td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; height: 24pt;\">BẢNG CHI TIẾT ĐƠN HÀNG (" + DateTime.Now + ")</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"32\" style=\"height: 24pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"32\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 12pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 24pt;\"><b>Website</b>: <span style=\"color:red\">" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "</span><br /></td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Khách hàng</b>: " + this.txtName.Text.Trim() + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Địa chỉ</b>: " + this.txtAddress.Text.Trim() + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Điện thoại</b>: " + this.txtPhone.Text.Trim() + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Email</b>: " + this.txtEmail.Text.Trim() + "</td>");
                strb.AppendLine("   </tr>");
                try
                {
                    strb.AppendLine("    <tr height=\"26\" style=\"height: 19.5pt;\">");
                    strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Phương thức vận chuyển</b>: " + Session["Phuongthucvanchuyen"] + "</td>");
                    strb.AppendLine("   </tr>");

                    strb.AppendLine("    <tr height=\"26\" style=\"height: 19.5pt;\">");
                    strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Hình thức vận chuyển</b>: " + Session["Hinhthucthanhtoan"] + "</td>");
                    strb.AppendLine("   </tr>");
                }
                catch (Exception)
                { }
                strb.AppendLine("      <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt;\"><b>Nội dung</b> : " + this.txtnoidung.Text.Trim() + "</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("      <tr height=\"26\" style=\"height: 19.5pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" height=\"26\" style=\"border-style: none; border-color: inherit; border-width: medium; padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left; height: 19.5pt; color:red; font-weight:bold; text-transform:uppercase\">Thông tin đơn hàng:</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"45\" style=\"height: 33.75pt;\">");
                strb.AppendLine("       <td height=\"45\" style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt 1pt 1pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; height: 33.75pt;\">STT</td>");
                strb.AppendLine("       <td  style=\"border-style: solid none; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: inherit; border-width: 1pt medium; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">Mã SP</td>");
                strb.AppendLine("       <td style=\"border-style: solid none solid solid; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: windowtext; border-width: 1pt medium 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 210pt;\" width=\"280\">Tên sản phẩm</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"53\">Số lượng</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"50\">Đ.Vtính</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 100px;\" width=\"65\">Đơn giá</td>");
                strb.AppendLine("       <td style=\"border-style: solid; border-color: windowtext; border-width: 1pt 1pt 1pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 150pt;\">Thành tiền</td>");
                strb.AppendLine("   </tr>");
                DataTable dtcart = new DataTable();
                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (Session["cart"] != null)
                {
                    if (dtcart.Rows.Count > 0)
                    {
                        int j = 1;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            strb.AppendLine("   <tr height=\"28\" style=\"height: 21pt;\">");
                            strb.AppendLine("       <td height=\"28\" style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; height: 21pt;\">" + j++ + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">" + Name_Code(dtcart.Rows[i]["PID"].ToString(), i) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: left;\">" + Name_Product(dtcart.Rows[i]["PID"].ToString(), i) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">" + dtcart.Rows[i]["Quantity"].ToString() + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">VNĐ</td>");
                            strb.AppendLine("       <td  style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 10pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: normal; text-align: center; width: 49pt;\" width=\"65\">" + MorePro.FormatMoney_NO(dtcart.Rows[i]["Price"].ToString()) + "</td>");
                            strb.AppendLine("       <td style=\"border: 1px solid rgb(0, 0, 0); padding: 0px; color: black; font-size: 11pt; font-weight: 400; font-style: normal; text-decoration: none; font-family: Calibri, sans-serif; vertical-align: bottom; white-space: nowrap; text-align: center;\" width=\"76\">" + MorePro.FormatMoney_NO(dtcart.Rows[i]["Money"].ToString()) + "</td>");
                            strb.AppendLine("   </tr>");
                        }
                    }
                }
                string Soluong = "0";
                string Tongtien = "0";
                dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                        num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                    }
                    Tongtien = num.ToString();
                    Soluong = num2.ToString();
                }
                strb.AppendLine("   <tr height=\"33\" style=\"height: 24.75pt;\">");
                strb.AppendLine("       <td height=\"33\" style=\"border-style: solid none solid solid; border-top-color: windowtext; border-right-color: inherit; border-bottom-color: windowtext; border-left-color: windowtext; border-width: 0.5pt medium 0.5pt 1pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; height: 24.75pt;\">&nbsp;</td>");
                strb.AppendLine("       <td  style=\"border: 1px solid rgb(0, 0, 0); font-size: 10pt; font-weight: 700; font-style: normal; text-align: center;\">Tổng cộng</td>");
                strb.AppendLine("       <td  style=\"border: 1px solid rgb(0, 0, 0); font-size: 10pt; font-weight: 700; font-style: normal; text-align: center;\">&nbsp;</td>");
                strb.AppendLine("       <td style=\"border: 0.5pt solid windowtext; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">" + Soluong + "</td>");
                strb.AppendLine("       <td colspan=\"2\" style=\"border: 0.5pt solid windowtext; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center;\">&nbsp;</td>");
                strb.AppendLine("       <td  colspan=\"1\" style=\"border-style: solid; border-color: windowtext; border-width: 0.5pt 1px 0.5pt 0.5pt; padding: 0px; color: black; font-size: 10pt; font-weight: 700; font-style: normal; text-decoration: none; font-family: &quot;Times New Roman&quot;, serif; vertical-align: middle; white-space: nowrap; text-align: center; border-image: initial;\">" + MorePro.FormatMoney_NO(Tongtien) + " VNĐ</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("   <tr height=\"39\" style=\"height: 29.25pt;\">");
                strb.AppendLine("       <td  colspan=\"7\" style=\"font-size: 10pt; font-weight: 700; font-style: normal; border: 1px solid rgb(0, 0, 0);  text-align: center;color:red\">Tổng số tiền (viết bằng chữ): " + ConvertSoRaChu(int.Parse(Tongtien)) + ".</td>");
                strb.AppendLine("   </tr>");
                strb.AppendLine("</table>");

                string email = Email.email();
                string password = Email.password();
                int port = Convert.ToInt32(Email.port());
                string host = Email.host();
                MailUtilities.SendMail("Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, email, password, MorePro.emailpro(), host, port, "Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, strb.ToString());
                // MailUtilities.SendMail("Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, email, password, txtEmail.Text.Trim(), host, port, "Thông tin đặt hàng trên website " + Request.Url.Host + " từ: " + txtName.Text, strb.ToString());
            }
            catch (Exception)
            { }
        }

        public string Name_Product(string pid, int i)
        {
            string code = "";
            DataTable dt = new DataTable();
            SProducts.Detail_ID(dt, pid);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["Name"].ToString();
            }
            return code;
        }
        public string Name_Code(string pid, int i)
        {
            string code = "";
            DataTable dt = new DataTable();
            SProducts.Detail_ID(dt, pid);
            if (dt.Rows.Count > 0)
            {
                code = dt.Rows[0]["Code"].ToString();
            }
            return code;
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('X\x00f3a sản phẩm n\x00e0y?')";
        }

        protected void Empty_Load(object sender, EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Hủy bỏ giỏ h\x00e0ng?')";
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            {
                DataTable dtcart = new DataTable();
                string str = e.CommandName.ToString();
                string pid = e.CommandArgument.ToString();
                string str3 = str;
                if (str3 != null)
                {
                    if (str3 == "Giam")
                    {
                        if ((HttpContext.Current.Request.Form[pid] != null) && ValidateUtilities.IsValidInt(HttpContext.Current.Request.Form[pid].ToString().Trim()))
                        {
                            dtcart = (DataTable)HttpContext.Current.Session["cart"];
                            SessionCarts.Cart_Updatequantity(ref dtcart, pid, HttpContext.Current.Request.Form[pid].ToString().Trim());
                            HttpContext.Current.Session["cart"] = dtcart;
                        }
                    }
                    if (str3 == "delete")
                    {
                        dtcart = (DataTable)HttpContext.Current.Session["cart"];
                        SessionCarts.ShoppingCart_RemoveProduct(e.CommandArgument.ToString());
                        Response.Redirect("/gio-hang.html");
                        HttpContext.Current.Session["cart"] = dtcart;
                    }
                    if (str3 == "update")
                    {
                        if ((HttpContext.Current.Request.Form[pid] != null) && ValidateUtilities.IsValidInt(HttpContext.Current.Request.Form[pid].ToString().Trim()))
                        {
                            dtcart = (DataTable)HttpContext.Current.Session["cart"];
                            SessionCarts.Cart_Updatequantity(ref dtcart, pid, HttpContext.Current.Request.Form[pid].ToString().Trim());
                            HttpContext.Current.Session["cart"] = dtcart;
                        }
                    }
                }
                LoadCart();
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            this.btndelete_Click(sender, e);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["cart"] = null;
            base.Response.Redirect("/Message.html");
        }

        protected void _btctnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void btnext_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected string Kichthuoc(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += "<div class=\"Kichhuoc\"><a class=\"size active\"><span>" + dt[0].Name.ToString() + "</span><div class=\"pl\"><img src=\"/Resources/images/activee.png\" /></div></a></div>";
            }
            return str.ToString();
        }

        protected string Mausac(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += "<div class=\"Mausac\"><a class=\"Color active\"><img src=\"" + dt[0].Images.ToString() + "\" style=\"width:28px; height:28px;border:solid 1px #d7d7d7\" /><div class=\"pl\"><img src=\"/Resources/images/activee.png\" style=' height: 16px !important;width: 18px !important;' /></div></a></div>";
                str += "";
            }
            return str.ToString();
        }

        protected void txtxQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox Quantity = (TextBox)sender;
            var b = (HiddenField)Quantity.FindControl("hiID");
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)HttpContext.Current.Session["cart"];
            SessionCarts.Cart_Updatequantity(ref dtcart, b.Value, Quantity.Text);
            HttpContext.Current.Session["cart"] = dtcart;
            //LoadCart();
            Response.Redirect("/gio-hang.html");
        }

        #region Hàm đổi số ra chữ
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            string Kdonvi = "";
            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
            }
            return Ktach;
        }
        public static string ConvertSoRaChu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";
            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";
            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";
            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();
            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai
            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";
            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";
            return lso_chu.ToString().Trim();
        }
        #endregion

    }
}