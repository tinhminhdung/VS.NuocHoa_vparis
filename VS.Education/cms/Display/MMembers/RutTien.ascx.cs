using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class RutTien : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btrutien.UniqueID;
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                ShowInfo();
            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
        }
        private void ShowInfo()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    //if (table.TongTrucTiep >= 5)
                    //{
                    //    Response.Write("<script type=\"text/javascript\">alert('Bạn phải đủ giới thiệu ra 5 F1 thì mới rút được điểm, và tối thiểu phải có đơn hàng có giá trị : 2,5 triệu.');window.location.href='/vi-diem.html'; </script>");
                    //}
                    hdid.Value = table.ID.ToString();
                    hdmobile.Value = table.DienThoai.ToString();
                    hdemail.Value = table.Email.ToString();
                    hdaddress.Value = table.DiaChi.ToString();
                    if (table.TienHoaHong.ToString() != "0")
                    {
                        lttongtien.Text = MoreAll.MorePro.Detail_Price(table.TienHoaHong.ToString());
                    }
                    else
                    {
                        lttongtien.Text = "0";
                    }
                }
            }
        }
        protected void btrutien_Click(object sender, EventArgs e)
        {
            #region Trừ tiền trong ví
            Member iitem = db.Members.SingleOrDefault(p => p.ID == int.Parse(hdid.Value));
            if (iitem != null)
            {
                double ConglaiCoin = 0;
                double TongSoCoinDaCo = Convert.ToDouble(iitem.TienHoaHong);
                double TongTienCanRutCoin = Convert.ToDouble(txtsotiencanrut.Text);
                double TongTrucTiep = Convert.ToDouble(iitem.TongTrucTiep);

                double RutTien = Convert.ToDouble(Commond.Setting("RutTien"));
                double SoTienDuocRut = Convert.ToDouble(Commond.Setting("SoTienDuocRut"));

                #region Chỉ được rút tiền khi điểm lớn hơn hoặc = 200 điểm
                if (TongSoCoinDaCo <= SoTienDuocRut)
                {
                    ltmsg.Text = "<div class=\"ruttienthongbaos\">Chỉ được rút tiền khi điểm lớn hơn hoặc bằng " + SoTienDuocRut + " VNĐ.</div>";
                    return;
                }
                #endregion
                if (RutTien > TongTrucTiep)
                {
                    ltmsg.Text = ("<script type=\"text/javascript\">alert('Bạn phải đủ giới thiệu ra " + RutTien + " F1 thì mới rút được điểm.');window.location.href='/rut-tien.html'; </script>");
                    return;
                }
                //if (iitem.TrangThaiMuaHangDatTongTien == 0)
                //{
                //    ltmsg.Text = ("<script type=\"text/javascript\">alert('Tài khoản của bạn phải có đơn hàng có giá trị : " + Commond.Setting("txtgiatridonhang") + " triệu trở lên thì mới rút được tiền.');window.location.href='/rut-tien.html'; </script>");
                //    return;
                //}

                // double QuYVNDRaCoin = (TongTienCanRutCoin) / 1000;
                if (TongSoCoinDaCo >= TongTienCanRutCoin)
                {
                    if (TongSoCoinDaCo.ToString() != "0")// Nếu trong ví có lớn hơn 0 đồng thì cộng tiếp
                    {
                        ConglaiCoin = ((TongSoCoinDaCo) - (TongTienCanRutCoin));
                        iitem.TienHoaHong = ConglaiCoin.ToString();
                        db.SubmitChanges();
                    }
                    if (TongSoCoinDaCo.ToString() != "0")// Nếu trong ví có lớn hơn 0 đồng thì cộng tiếp
                    {
                        LichSuRutTien obj = new LichSuRutTien();
                        obj.IDThanhVien = int.Parse(hdid.Value);
                        obj.TongTienTrongVi = "";// iitem.TongTienCongLai;
                        obj.SoTienCanRut = txtsotiencanrut.Text;
                        obj.SoCoin = ConglaiCoin.ToString();
                        obj.TenNganHang = txttennganhang.Text;
                        obj.HoVaTen = txthovaten.Text;
                        obj.SoTaiKHoan = txtsotaikhoan.Text;
                        obj.ChiNhanh = txtchinhanh.Text;
                        obj.NoiDungChuyenTien = txtnoidungchuyentien.Text;
                        obj.GhiChu = "";
                        obj.TrangThai = 0;
                        obj.NgayTao = DateTime.Now;
                        obj.NgayDuyet = "";
                        obj.NguoiDuyet = "";
                        db.LichSuRutTiens.InsertOnSubmit(obj);
                        db.SubmitChanges();

                        CongTienDaRut(hdid.Value, TongTienCanRutCoin.ToString());

                        ltmsg.Text = "";
                        ltmsg.Text += "<div class=\"thongbaos\">Bạn đã gửi yêu cầu rút tiền thành công.</div> ";
                        ltmsg.Text += "<div class=\"thongbaos\">Số tiền đã rút :" + txtsotiencanrut.Text + " điểm</div>";

                        ltmsg.Text = ("<script type=\"text/javascript\">alert('Bạn đã gửi yêu cầu rút tiền thành công..');window.location.href='/rut-tien.html'; </script>");

                        // Sent Mail
                        string content = System.IO.File.ReadAllText(Server.MapPath("~/cms/Display/SentMail/RutTien.html"));
                        content = content.Replace("{{CustomerName}}", txthovaten.Text);
                        content = content.Replace("{{Phone}}", hdmobile.Value);
                        content = content.Replace("{{Email}}", hdemail.Value);
                        content = content.Replace("{{Address}}", hdaddress.Value);
                        content = content.Replace("{{Total}}", txtsotiencanrut.Text);

                        content = content.Replace("{{Tennganhang}}", txttennganhang.Text);
                        content = content.Replace("{{Sotaikhoan}}", txtsotaikhoan.Text);
                        content = content.Replace("{{Chinhanh}}", txtchinhanh.Text);
                        content = content.Replace("{{Noidung}}", txtnoidungchuyentien.Text);
                        // content = content.Replace("{{Ghichu}}", txtghichu.Text);

                        //emailnhanthongbaorutien
                        try
                        {
                            var EmailContTy = Commond.Setting("Emailden");
                            // var emailnhanthongbaorutien = Commond.Setting("emailnhanthongbaorutien");
                            if (!EmailContTy.Equals(""))
                                new MailHelper().SendMail(EmailContTy, "Thành viên " + txthovaten.Text + " rút tiền trên hệ thống V-Paris", content);
                            //if (!emailnhanthongbaorutien.Equals(""))
                            // new MailHelper().SendMail(emailnhanthongbaorutien, "Thành viên " + txthovaten.Text + " rút tiền trên hệ thống V-Paris", content);
                        }
                        catch (Exception)
                        { }


                        txtsotiencanrut.Text = "";
                        txttennganhang.Text = "";
                        txthovaten.Text = "";
                        txtsotaikhoan.Text = "";
                        txtchinhanh.Text = "";
                        txtnoidungchuyentien.Text = "";
                        ShowInfo();
                    }
                }
                else
                {
                    ltmsg.Text = "<div class=\"thongbaos\">Số tiền không đủ để thanh toán</div> ";
                    return;
                }
            }
            #endregion
        }

        void CongTienDaRut(string IDThanhVien, string TongRut)
        {
            #region Cộng điểm theo hoa hồng
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem != null)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TongTienDaRut);
                double TongRuts = Convert.ToDouble(TongRut);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) + (TongRuts));
                SMember.Name_Text("update Members set TongTienDaRut=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            #endregion
        }
        protected void bthuy_Click(object sender, EventArgs e)
        {
            txtsotiencanrut.Text = "";
            txttennganhang.Text = "";
            txthovaten.Text = "";
            txtsotaikhoan.Text = "";
            txtchinhanh.Text = "";
            txtnoidungchuyentien.Text = "";
            ltmsg.Text = "";
        }
    }
}