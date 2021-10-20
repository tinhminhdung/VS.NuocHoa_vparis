using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using Entity;
using System.Data;
using Framwork;
using FlexCel.XlsAdapter;
using FlexCel.Core;
using System.Text;
using VS.E_Commerce;

namespace VS.ECommerce_MVC.cms.Admin.Products
{
    public partial class DetailCart : System.Web.UI.UserControl
    {
        private string status = "1";
        public int i = 1;
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        private string ID = "0";
        public string DuyetDonHang = "0";
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
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("9"))
                        {
                            DuyetDonHang = "1";
                        }
                    }
                }
            }
            if (!base.IsPostBack)
            {
                if (Request["ID"] != null && !Request["ID"].Equals(""))
                {
                    ID = Request["ID"];
                }
                ChitietDonhang(ID);
            }
        }
        void ChitietDonhang(string id)
        {
            List<Entity.CartDetail> table = SCartDetail.Detail_ID_Cart(id);
            this.rpcartdetail.DataSource = table;
            this.rpcartdetail.DataBind();
            List<LCart> dt1 = db.LCarts.Where(s => s.ID == int.Parse(id)).ToList();
            if (dt1.Count > 0)
            {
                ltmadonhang.Text = dt1[0].ID.ToString();
                ltname.Text = ShowtThanhVien2(dt1[0].IDThanhVien.ToString(), dt1[0].Name.ToString());
                // ltname.Text = dt1[0].Name.ToString();
                ltdienthoai.Text = dt1[0].Phone.ToString();
                ltemail.Text = dt1[0].Email.ToString();
                ltdiachi.Text = dt1[0].Address.ToString();
                lttong.Text = MoreAll.MorePro.Detail_Price(dt1[0].Money.ToString());
                //if (dt1[0].TrangThaiChienLuocVaThongThuong.ToString() == "1")
                //{
                ltloinhuan.Text = MoreAll.MorePro.Detail_Price(dt1[0].TienLoiNhuan.ToString());
                ltvietchu.Text = ConvertSoRaChu(Convert.ToDouble(dt1[0].TienLoiNhuan.ToString()));
                //}
                //else
                //{
                //    ltloinhuan.Text = MoreAll.MorePro.Detail_Price(dt1[0].Money.ToString());
                //    ltvietchu.Text = ConvertSoRaChu(Convert.ToDouble(dt1[0].Money.ToString()));
                //}

                ltViVip.Text = MoreAll.MorePro.Detail_Price(dt1[0].ViVipMuaHang.ToString());
                ltViChinh.Text = MoreAll.MorePro.Detail_Price(dt1[0].ViChinhMuaHang.ToString());
                lthinhthucgiaohang.Text = dt1[0].Phuongthucthanhtoan.ToString();
                ltthanhtoan.Text = dt1[0].Hinhthucvanchuyen.ToString();
                ltghichu.Text = dt1[0].Contents;

                hdIDGiohang.Value = dt1[0].ID.ToString();
                hdtongtien.Value = dt1[0].Money.ToString();
                hdTienLoiNhuan.Value = dt1[0].TienLoiNhuan.ToString();
                hdtongtienchienluoc.Value = dt1[0].Money.ToString();
                hdIDThanhVien.Value = dt1[0].IDThanhVien.ToString();

                if (dt1[0].Status.ToString() == "0")
                {
                    //if (dt1[0].TrangThaiChienLuocVaThongThuong.ToString() == "0")
                    // {
                    btduyet.Visible = true;
                    // }
                    // else
                    // {
                    //  btduyetChienLuoc.Visible = true;
                    // }
                }
                else
                {
                    btduyet.Visible = false;
                    // btduyetChienLuoc.Visible = false;
                }
            }
        }
        protected string ShowtThanhVien2(string id, string Name)
        {
            string str = "";
            List<Entity.Member> dt = SMember.GET_BY_ID(id);
            if (dt.Count >= 1)
            {
                str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + Name + "</span></a>";
                return str;
            }
            return "<b>" + Name + " /(Thành viên này đã bị xóa)</b>";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }


        protected string Thanhtoan(string ID)
        {
            LCart abc = db.LCarts.SingleOrDefault(p => p.ID == int.Parse(ID));
            if (abc.StatusGiaoDich.ToString().Equals("1"))
            {
                return "color:#fff; padding:3px; font-weight:bold; background:#fe0505; border-radius:5px; width:250px";
            }
            return "color:#fff; padding:3px; font-weight:bold; background:#ff619c; border-radius:5px; width:250px";
        }
        protected string Soluong(string ID_Cart)
        {
            string totalvnd = "0";
            List<Entity.CartDetail> cartdetail = SCartDetail.Detail_ID_Cart(ID_Cart);
            if (cartdetail.Count > 0)
            {
                if (cartdetail.Count > 0)
                {
                    double num = 0.0;
                    for (int i = 0; i < cartdetail.Count; i++)
                    {
                        num += Convert.ToDouble(cartdetail[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                }
            }
            return totalvnd;
        }
        #region Hàm đổi số ra chữ
        private string Chu(string gNumber)
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
        private string Donvi(string so)
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
        private string Tach(string tach3)
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
        public string ConvertSoRaChu(double gNum)
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
        protected string Quantity(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Quantity.ToString();
            }
            return str.ToString();
        }
        protected string Code(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        protected string Name(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Name.ToString();
            }
            return str.ToString();
        }


        // chi tiết giỏ hàng


        protected string Anh(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Images.ToString();
            }
            return str.ToString();
        }
        protected string Codes(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        protected string Kho(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str = dt[0].Quantity.ToString();
            }
            return str.ToString();
        }
        protected string Kichthuoc(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += dt[0].Name.ToString();
            }
            return str.ToString();
        }
        protected string Mausac(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.GETBYID(id);
            if (dt.Count > 0)
            {
                str += "<img src=\"" + dt[0].Images.ToString() + "\" style=\"width:28px; height:28px;border:solid 1px #d7d7d7\" />";
            }
            return str.ToString();
        }

        protected void btduyet_Click(object sender, EventArgs e)
        {
            //    #region Sét số tầng =0
            //    SetViTriTang("1");
            //    #endregion
            //  string TienDauVao = hdTienLoiNhuan.Value;
            //  string IDCart = hdIDGiohang.Value;
            // string IDThanhVien = hdIDThanhVien.Value;
            // Double Money = Convert.ToDouble(TienDauVao.ToString());

            //    Double TongTien = 0;
            //    List<Entity.Member> dt = SMember.Name_Text("select * from Members where Id=" + IDThanhVien);
            //    if (dt.Count > 0)
            //    {
            //        #region 1.Sét số tự tăng cho thành viên này  2.Chuyển thành mã Ngũ Phân  và lưu vào bảng chính nó OK, 3 . lưu ngũ phân vào bảng tạm CatDuoiID_bangTam
            //        SetThuTu(IDThanhVien.ToString());
            //        #endregion

            //        #region Chia Hoa Hồng Các Tầng
            //        for (int i = 0; i < 6; i++)
            //        {
            //            // Double SetDuoiBang = Convert.ToDouble(Commond.SetDuoiBang1(Convert.ToInt32(Commond.Setting("CatDuoiID_bangTam"))));
            //            //// if (SetDuoiBang == 1)
            //            //// {
            //            // Sét tầng xem tầng có nhỏ hơn <=6 ko, nếu có thì cộng tầng thêm 1 và chia hoa hồng
            //            string ThuTuTang = Commond.Setting("ViTriTang");
            //            if (Convert.ToInt32(ThuTuTang) < 7)// < 7 tầng là 6 tầng
            //            {
            //                Double ViTriTang = Convert.ToDouble(Commond.Setting("ViTriTang")) + 1;
            //                SetViTriTang(ViTriTang.ToString());

            //                #region 3.Cắt đuôi và lưu vào CatDuoiID
            //                //Tìm thằng bên trên bằng cách cắt đuôi ngũ phân
            //                CatDuoi(Commond.Setting("CatDuoiID_bangTam"));// Sét ID được hưởng hoa hồng vào bảng tạm
            //                #endregion

            //                //Tang1
            //                #region Nếu tầng là 1
            //                if (Convert.ToInt32(ThuTuTang) == 1)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang1"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                //Tang2
            //                #region Nếu tầng là 2
            //                if (Convert.ToInt32(ThuTuTang) == 2)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang2"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                //Tang3
            //                #region Nếu tầng là 3
            //                if (Convert.ToInt32(ThuTuTang) == 3)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang3"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                //Tang4
            //                #region Nếu tầng là 4
            //                if (Convert.ToInt32(ThuTuTang) == 4)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang4"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                //Tang5
            //                #region Nếu tầng là 5
            //                if (Convert.ToInt32(ThuTuTang) == 5)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang5"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }
            //                    }
            //                }
            //                #endregion

            //                //Tang6
            //                #region Nếu tầng là 6
            //                if (Convert.ToInt32(ThuTuTang) == 6)
            //                {
            //                    List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
            //                    if (NN.Count > 0)
            //                    {
            //                        double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang6"));//MoreAll.Other.Giatri("HoaHongF7")
            //                        if (HoaHongTang1Den4 > 0)
            //                        {
            //                            double TongHH = (Money * HoaHongTang1Den4) / 100;
            //                            Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
            //                            TongTien += TongHH;
            //                        }

            //                    }
            //                }
            //                #endregion
            //            }
            //            else
            //            {
            //                break;
            //            }
            //            // }
            //        }
            //        #endregion

            //        #region Sét số tầng =0
            //        SetViTriTang("1");
            //        #endregion

            //        #region Tìm cha cho HH TT
            //        List<Entity.Member> F1 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + "  ");
            //        if (F1.Count > 0)
            //        {
            //            if (F1[0].TrangThaiMuaHang.ToString() != "0")
            //            {
            //                // Tìm cha cho HH TT
            //                double HoaHongTT = Convert.ToDouble(MoreAll.Other.Giatri("HoaHongTrucTiep"));//
            //                if (HoaHongTT > 0)
            //                {
            //                    double TongHHTT = (Money * HoaHongTT) / 100;
            //                    Commond.ThemHoaHong("2", "Hoa Hồng bán hàng", TienDauVao.ToString(), TongHHTT.ToString(), HoaHongTT.ToString(), IDThanhVien.ToString(), F1[0].ID.ToString(), IDCart);
            //                    TongTien += TongHHTT;
            //                }
            //            }
            //            List<Entity.Member> F2 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + " ");
            //            if (F2.Count > 0)
            //            {
            //                if (F2[0].GioiThieu.ToString() != "0" && F2[0].TrangThaiMuaHang.ToString() != "0")
            //                {
            //                    // Tìm cha cho HH TT
            //                    double HoaHongTTF2 = Convert.ToDouble(MoreAll.Other.Giatri("txtF2"));//
            //                    if (HoaHongTTF2 > 0)
            //                    {
            //                        double TongHHTTF2 = (Money * HoaHongTTF2) / 100;
            //                        Commond.ThemHoaHong("2", "Doanh số nhóm 2", TienDauVao.ToString(), TongHHTTF2.ToString(), HoaHongTTF2.ToString(), IDThanhVien.ToString(), F2[0].GioiThieu.ToString(), IDCart);
            //                        TongTien += TongHHTTF2;
            //                    }
            //                }
            //                List<Entity.Member> F3 = SMember.Name_Text("select * from Members where Id=" + F2[0].GioiThieu.ToString() + "");
            //                if (F3.Count > 0)
            //                {
            //                    if (F3[0].GioiThieu.ToString() != "0" && F3[0].TrangThaiMuaHang.ToString() != "0")
            //                    {
            //                        // Tìm cha cho HH TT
            //                        double HoaHongTTF3 = Convert.ToDouble(MoreAll.Other.Giatri("txtF3"));//
            //                        if (HoaHongTTF3 > 0)
            //                        {
            //                            double TongHHTTF3 = (Money * HoaHongTTF3) / 100;
            //                            Commond.ThemHoaHong("2", "Doanh số nhóm 3", TienDauVao.ToString(), TongHHTTF3.ToString(), HoaHongTTF3.ToString(), IDThanhVien.ToString(), F3[0].GioiThieu.ToString(), IDCart);
            //                            TongTien += TongHHTTF3;
            //                        }
            //                    }
            //                    List<Entity.Member> F4 = SMember.Name_Text("select * from Members where Id=" + F3[0].GioiThieu.ToString() + " ");
            //                    if (F4.Count > 0)
            //                    {
            //                        if (F4[0].GioiThieu.ToString() != "0" && F4[0].TrangThaiMuaHang.ToString() != "0")
            //                        {
            //                            // Tìm cha cho HH TT
            //                            double HoaHongTTF4 = Convert.ToDouble(MoreAll.Other.Giatri("txtF4"));//
            //                            if (HoaHongTTF4 > 0)
            //                            {
            //                                double TongHHTTF4 = (Money * HoaHongTTF4) / 100;
            //                                Commond.ThemHoaHong("2", "Doanh số nhóm 4", TienDauVao.ToString(), TongHHTTF4.ToString(), HoaHongTTF4.ToString(), IDThanhVien.ToString(), F4[0].GioiThieu.ToString(), IDCart);
            //                                TongTien += TongHHTTF4;
            //                            }
            //                        }
            //                        List<Entity.Member> F5 = SMember.Name_Text("select * from Members where Id=" + F4[0].GioiThieu.ToString() + " ");
            //                        if (F5.Count > 0)
            //                        {
            //                            if (F5[0].GioiThieu.ToString() != "0" && F5[0].TrangThaiMuaHang.ToString() != "0")
            //                            {
            //                                // Tìm cha cho HH TT
            //                                double HoaHongTTF5 = Convert.ToDouble(MoreAll.Other.Giatri("txtF5"));//
            //                                if (HoaHongTTF5 > 0)
            //                                {
            //                                    double TongHHTTF5 = (Money * HoaHongTTF5) / 100;
            //                                    Commond.ThemHoaHong("2", "Doanh số nhóm 5", TienDauVao.ToString(), TongHHTTF5.ToString(), HoaHongTTF5.ToString(), IDThanhVien.ToString(), F5[0].GioiThieu.ToString(), IDCart);
            //                                    TongTien += TongHHTTF5;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        #endregion

            //        #region Đếm F1 cho người giới thiệu
            //        List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where ID =" + IDThanhVien.ToString() + "");
            //        if (tb1.Count() > 0)
            //        {
            //            if (tb1[0].TrangThaiMuaHang.ToString() == "0")
            //            {
            //                SMember.Name_Text("update Members set TongTrucTiep=TongTrucTiep+1  where ID=" + tb1[0].GioiThieu.ToString() + "");
            //                ///SMember.Name_Text("update Members set TrangThaiMuaHang=1  where ID=" + IDThanhVien.ToString() + ""); Thành viên mua thông thường thì không cho chuỷen trạng thái hưởng hoa hồng
            //            }
            //            Double Tongtiens = Convert.ToDouble(TienDauVao.ToString());
            //            Double Giatridonhang = Convert.ToDouble(Commond.Setting("txtgiatridonhang"));
            //            if (Tongtiens >= Giatridonhang)
            //            {
            //                SMember.Name_Text("update Members set TrangThaiMuaHangDatTongTien=1  where ID=" + IDThanhVien.ToString() + "");
            //            }
            //        }
            //        #endregion

            //        SCarts.Name_Text("update Carts set Status=1 where ID=" + hdIDGiohang.Value + "");

            //        #region Vi Loi Nhuan sau khi da chia HH
            //        try
            //        {
            //            Double TongTiens = Convert.ToDouble(TongTien.ToString());
            //            Double TongTienss = Convert.ToDouble(TienDauVao.ToString());
            //            Double TongCong = (TongTienss - TongTiens);

            //            LoiNhuanMuaBan abln = new LoiNhuanMuaBan();
            //            abln.IDThanhVienMua = int.Parse(IDThanhVien.ToString());
            //            abln.IDDonHang = int.Parse(hdIDGiohang.Value);
            //            abln.MoTa = "";
            //            abln.NgayTao = DateTime.Now;
            //            abln.TongTien = TienDauVao.ToString();
            //            abln.TongTienCon = TongCong.ToString();
            //            abln.TongTienDaChia = TongTien.ToString();
            //            abln.MTreeIDThanhVienMua = Commond.ShowMTree(IDThanhVien.ToString());
            //            db.LoiNhuanMuaBans.InsertOnSubmit(abln);
            //            db.SubmitChanges();
            //        }
            //        catch (Exception)
            //        { }
            //        #endregion

            //    }
            //    Response.Write("<script type=\"text/javascript\">alert('Duyệt đơn hàng thành công.');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
            //    // base.Response.Redirect(base.Request.Url.ToString().Trim());
            //    return;


            SCarts.Name_Text("update Carts set Status=1 where ID=" + hdIDGiohang.Value + "");
            Response.Write("<script type=\"text/javascript\">alert('Duyệt đơn hàng thành công.');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
        }

        public void SetThuTu(string IDThanhVien)
        {
            #region kiểm tra số ngũ phân khác 6 thì mới cho sét thứ tự vòng
            // Khi thành viên mua lại thì vẫn cho hoa hồng bt và sẽ ko sinh ra thứ tự mới ở bảng ThuTuVong
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
            if (iitem.Count > 0)
            {
                if (iitem[0].SoNguPhan.ToString() == "6")
                {
                    List<Entity.EEThuTuVong> dtdetail = SThuTuVong.Name_Text("select top 1 * from ThuTuVong order by ThuTuSet desc");
                    if (dtdetail.Count > 0)
                    {
                        Double Tong = Convert.ToDouble(dtdetail[0].ThuTuSet.ToString()) + 1;
                        #region Lưu số ngũ phân vào bảng tạm cắt đuổi
                        Entity.Setting objs = new Entity.Setting();
                        objs.Lang = "VIE";
                        objs.Properties = "CatDuoiID_bangTam";
                        objs.Value = Commond.ShowThapPhan(Convert.ToInt32(Tong));
                        SSetting.UPDATE(objs);
                        #endregion

                        #region 2.Chuyển thành mã Ngũ Phân
                        SMember.Name_Text("update Members set SoNguPhan=" + Commond.ShowThapPhan(Convert.ToInt32(Tong)) + "  where ID=" + IDThanhVien.ToString() + "");
                        #endregion

                        ThuTuVong obj = new ThuTuVong();
                        obj.IDThanhVien = int.Parse(IDThanhVien.ToString());
                        obj.ThuTuSet = Convert.ToInt32(Tong.ToString());
                        db.ThuTuVongs.InsertOnSubmit(obj);
                        db.SubmitChanges();
                    }
                }
                else
                {
                    #region Lưu số ngũ phân vào bảng tạm cắt đuổi
                    Entity.Setting objs = new Entity.Setting();
                    objs.Lang = "VIE";
                    objs.Properties = "CatDuoiID_bangTam";
                    objs.Value = iitem[0].SoNguPhan.ToString();
                    SSetting.UPDATE(objs);
                    #endregion
                }
            }
            #endregion

        }

        void SetViTriTang(string ViTriTangs)
        {
            #region Lưu số ngũ phân vào bảng tạm cắt đuổi
            Entity.Setting objs = new Entity.Setting();
            objs.Lang = "VIE";
            objs.Properties = "ViTriTang";
            objs.Value = ViTriTangs;
            SSetting.UPDATE(objs);
            #endregion
        }


        // Mỗi 1 lần cắt sẽ chia HH cho 1 người , sẽ for cùng hàm ở trên 10 lần
        public static string CatDuoi(string IDThanhVien)// Cắt đuôi Ngũ Phân , Để tìm ra ngũ phân người trên cho hoa hồng--> Đây chính là ID thành viên sẽ được hưởng Hoa Hồng Tầng
        {
            Double SoNguPhan_IDHuong = 0;// Số Ngũ phân chính là số ID sẽ được hưởng vd: ID số 19 ngũ phân sẽ thành 34 là ID được hưởng
            List<Entity.Member> NP = SMember.Name_Text("select * from Members where SoNguPhan=" + IDThanhVien);
            if (NP.Count > 0)
            {
                int SoNguPhan = NP[0].SoNguPhan;
                SoNguPhan_IDHuong = SoNguPhan / 10;

                //#region Lấy ra ID người được hưởng HH
                //Entity.Setting obj = new Entity.Setting();
                //obj.Lang = "VIE";
                //obj.Properties = "IDHuongHoaHong";
                //obj.Value = NP[0].ID.ToString();
                //SSetting.UPDATE(obj);
                //#endregion

                Entity.Setting obj = new Entity.Setting();
                #region Lấy ra người bên trên ngũ phân và cập nhật CatDuoiID--> Đây chính là ID thành viên sẽ được hưởng Hoa Hồng Tầng
                obj.Lang = "VIE";
                obj.Properties = "CatDuoiID_bangTam";
                obj.Value = SoNguPhan_IDHuong.ToString();
                SSetting.UPDATE(obj);
                #endregion
            }
            return SoNguPhan_IDHuong.ToString();
        }

        //protected void btduyetChienLuoc_Click(object sender, EventArgs e)
        //{
        //    //#region Sét số tầng =0
        //    //SetViTriTang("1");
        //    //#endregion
        //    string TienDauVao = hdtongtienchienluoc.Value;// Lấy tiền của giá bán để chia lợi nhuận
        //    string IDCart = hdIDGiohang.Value;
        //    string IDThanhVien = hdIDThanhVien.Value;
        //    Double Money = Convert.ToDouble(TienDauVao.ToString());

        //    //Double TongTien = 0;
        //    //List<Entity.Member> dt = SMember.Name_Text("select * from Members where Id=" + IDThanhVien);
        //    //if (dt.Count > 0)
        //    //{
        //    //    #region 1.Sét số tự tăng cho thành viên này  2.Chuyển thành mã Ngũ Phân  và lưu vào bảng chính nó OK, 3 . lưu ngũ phân vào bảng tạm CatDuoiID_bangTam
        //    //    SetThuTu(IDThanhVien.ToString());
        //    //    #endregion

        //    //    #region Chia Hoa Hồng Các Tầng
        //    //    for (int i = 0; i < 6; i++)
        //    //    {
        //    //        // Double SetDuoiBang = Convert.ToDouble(Commond.SetDuoiBang1(Convert.ToInt32(Commond.Setting("CatDuoiID_bangTam"))));
        //    //        //// if (SetDuoiBang == 1)
        //    //        //// {
        //    //        // Sét tầng xem tầng có nhỏ hơn <=6 ko, nếu có thì cộng tầng thêm 1 và chia hoa hồng
        //    //        string ThuTuTang = Commond.Setting("ViTriTang");
        //    //        if (Convert.ToInt32(ThuTuTang) < 7)// < 7 tầng là 6 tầng
        //    //        {
        //    //            Double ViTriTang = Convert.ToDouble(Commond.Setting("ViTriTang")) + 1;
        //    //            SetViTriTang(ViTriTang.ToString());

        //    //            #region 3.Cắt đuôi và lưu vào CatDuoiID
        //    //            //Tìm thằng bên trên bằng cách cắt đuôi ngũ phân
        //    //            CatDuoi(Commond.Setting("CatDuoiID_bangTam"));// Sét ID được hưởng hoa hồng vào bảng tạm
        //    //            #endregion

        //    //            //Tang1
        //    //            #region Nếu tầng là 1
        //    //            if (Convert.ToInt32(ThuTuTang) == 1)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang1ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }
        //    //                }
        //    //            }
        //    //            #endregion

        //    //            //Tang2
        //    //            #region Nếu tầng là 2
        //    //            if (Convert.ToInt32(ThuTuTang) == 2)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang2ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }
        //    //                }
        //    //            }
        //    //            #endregion

        //    //            //Tang3
        //    //            #region Nếu tầng là 3
        //    //            if (Convert.ToInt32(ThuTuTang) == 3)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang3ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }
        //    //                }
        //    //            }
        //    //            #endregion

        //    //            //Tang4
        //    //            #region Nếu tầng là 4
        //    //            if (Convert.ToInt32(ThuTuTang) == 4)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang4ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }
        //    //                }
        //    //            }
        //    //            #endregion

        //    //            //Tang5
        //    //            #region Nếu tầng là 5
        //    //            if (Convert.ToInt32(ThuTuTang) == 5)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang5ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }
        //    //                }
        //    //            }
        //    //            #endregion

        //    //            //Tang6
        //    //            #region Nếu tầng là 6
        //    //            if (Convert.ToInt32(ThuTuTang) == 6)
        //    //            {
        //    //                List<Entity.Member> NN = SMember.Name_Text("select * from Members where SoNguPhan=" + Commond.Setting("CatDuoiID_bangTam"));
        //    //                if (NN.Count > 0)
        //    //                {
        //    //                    double HoaHongTang1Den4 = Convert.ToDouble(MoreAll.Other.Giatri("Tang6ChienLuoc"));//MoreAll.Other.Giatri("HoaHongF7")
        //    //                    if (HoaHongTang1Den4 > 0)
        //    //                    {
        //    //                        double TongHH = (Money * HoaHongTang1Den4) / 100;
        //    //                        Commond.ThemHoaHong("1", "Hoa Hồng tri ân " + ThuTuTang + "", TienDauVao.ToString(), TongHH.ToString(), HoaHongTang1Den4.ToString(), IDThanhVien.ToString(), NN[0].ID.ToString(), IDCart);
        //    //                        TongTien += TongHH;
        //    //                    }

        //    //                }
        //    //            }
        //    //            #endregion
        //    //        }
        //    //        else
        //    //        {
        //    //            break;
        //    //        }
        //    //        // }
        //    //    }
        //    //    #endregion

        //    //    #region Sét số tầng =0
        //    //    SetViTriTang("1");
        //    //    #endregion

        //    //    #region Tìm cha cho HH TT
        //    //    List<Entity.Member> F1 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + "  ");
        //    //    if (F1.Count > 0)
        //    //    {
        //    //        if (F1[0].TrangThaiMuaHang.ToString() != "0")
        //    //        {
        //    //            // Tìm cha cho HH TT
        //    //            double HoaHongTT = Convert.ToDouble(MoreAll.Other.Giatri("HoaHongTrucTiepChienLuoc"));//
        //    //            if (HoaHongTT > 0)
        //    //            {
        //    //                double TongHHTT = (Money * HoaHongTT) / 100;
        //    //                Commond.ThemHoaHong("2", "Hoa Hồng bán hàng", TienDauVao.ToString(), TongHHTT.ToString(), HoaHongTT.ToString(), IDThanhVien.ToString(), F1[0].ID.ToString(), IDCart);
        //    //                TongTien += TongHHTT;
        //    //            }
        //    //        }
        //    //        List<Entity.Member> F2 = SMember.Name_Text("select * from Members where Id=" + dt[0].GioiThieu.ToString() + " ");
        //    //        if (F2.Count > 0)
        //    //        {
        //    //            if (F2[0].GioiThieu.ToString() != "0" && F2[0].TrangThaiMuaHang.ToString() != "0")
        //    //            {
        //    //                // Tìm cha cho HH TT
        //    //                double HoaHongTTF2 = Convert.ToDouble(MoreAll.Other.Giatri("txtF2ChienLuoc"));//
        //    //                if (HoaHongTTF2 > 0)
        //    //                {
        //    //                    double TongHHTTF2 = (Money * HoaHongTTF2) / 100;
        //    //                    Commond.ThemHoaHong("2", "Doanh số nhóm 2", TienDauVao.ToString(), TongHHTTF2.ToString(), HoaHongTTF2.ToString(), IDThanhVien.ToString(), F2[0].GioiThieu.ToString(), IDCart);
        //    //                    TongTien += TongHHTTF2;
        //    //                }
        //    //            }
        //    //            List<Entity.Member> F3 = SMember.Name_Text("select * from Members where Id=" + F2[0].GioiThieu.ToString() + "");
        //    //            if (F3.Count > 0)
        //    //            {
        //    //                if (F3[0].GioiThieu.ToString() != "0" && F3[0].TrangThaiMuaHang.ToString() != "0")
        //    //                {
        //    //                    // Tìm cha cho HH TT
        //    //                    double HoaHongTTF3 = Convert.ToDouble(MoreAll.Other.Giatri("txtF3ChienLuoc"));//
        //    //                    if (HoaHongTTF3 > 0)
        //    //                    {
        //    //                        double TongHHTTF3 = (Money * HoaHongTTF3) / 100;
        //    //                        Commond.ThemHoaHong("2", "Doanh số nhóm 3", TienDauVao.ToString(), TongHHTTF3.ToString(), HoaHongTTF3.ToString(), IDThanhVien.ToString(), F3[0].GioiThieu.ToString(), IDCart);
        //    //                        TongTien += TongHHTTF3;
        //    //                    }
        //    //                }
        //    //                List<Entity.Member> F4 = SMember.Name_Text("select * from Members where Id=" + F3[0].GioiThieu.ToString() + " ");
        //    //                if (F4.Count > 0)
        //    //                {
        //    //                    if (F4[0].GioiThieu.ToString() != "0" && F4[0].TrangThaiMuaHang.ToString() != "0")
        //    //                    {
        //    //                        // Tìm cha cho HH TT
        //    //                        double HoaHongTTF4 = Convert.ToDouble(MoreAll.Other.Giatri("txtF4ChienLuoc"));//
        //    //                        if (HoaHongTTF4 > 0)
        //    //                        {
        //    //                            double TongHHTTF4 = (Money * HoaHongTTF4) / 100;
        //    //                            Commond.ThemHoaHong("2", "Doanh số nhóm 4", TienDauVao.ToString(), TongHHTTF4.ToString(), HoaHongTTF4.ToString(), IDThanhVien.ToString(), F4[0].GioiThieu.ToString(), IDCart);
        //    //                            TongTien += TongHHTTF4;
        //    //                        }
        //    //                    }
        //    //                    List<Entity.Member> F5 = SMember.Name_Text("select * from Members where Id=" + F4[0].GioiThieu.ToString() + " ");
        //    //                    if (F5.Count > 0)
        //    //                    {
        //    //                        if (F5[0].GioiThieu.ToString() != "0" && F5[0].TrangThaiMuaHang.ToString() != "0")
        //    //                        {
        //    //                            // Tìm cha cho HH TT
        //    //                            double HoaHongTTF5 = Convert.ToDouble(MoreAll.Other.Giatri("txtF5ChienLuoc"));//
        //    //                            if (HoaHongTTF5 > 0)
        //    //                            {
        //    //                                double TongHHTTF5 = (Money * HoaHongTTF5) / 100;
        //    //                                Commond.ThemHoaHong("2", "Doanh số nhóm 5", TienDauVao.ToString(), TongHHTTF5.ToString(), HoaHongTTF5.ToString(), IDThanhVien.ToString(), F5[0].GioiThieu.ToString(), IDCart);
        //    //                                TongTien += TongHHTTF5;
        //    //                            }
        //    //                        }
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //    #endregion

        //    //    #region Đếm F1 cho người giới thiệu
        //    //    List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where ID =" + IDThanhVien.ToString() + "");
        //    //    if (tb1.Count() > 0)
        //    //    {
        //    //        if (tb1[0].TrangThaiMuaHang.ToString() == "0")
        //    //        {
        //    //            SMember.Name_Text("update Members set TongTrucTiep=TongTrucTiep+1  where ID=" + tb1[0].GioiThieu.ToString() + "");
        //    //            SMember.Name_Text("update Members set TrangThaiMuaHang=1  where ID=" + IDThanhVien.ToString() + "");

        //    //            // Thành viên mua  CHIẾN LƯỢC  THÌ MỚI THAY ĐỔI TRẠNG THÁI VÀ CHO hoa hồng
        //    //        }
        //    //        Double Tongtiens = Convert.ToDouble(TienDauVao.ToString());
        //    //        Double Giatridonhang = Convert.ToDouble(Commond.Setting("txtgiatridonhang"));
        //    //        if (Tongtiens >= Giatridonhang)
        //    //        {
        //    //            SMember.Name_Text("update Members set TrangThaiMuaHangDatTongTien=1  where ID=" + IDThanhVien.ToString() + "");
        //    //        }
        //    //    }
        //    //    #endregion

        //    //    SCarts.Name_Text("update Carts set Status=1 where ID=" + hdIDGiohang.Value + "");

        //    //    #region Vi Loi Nhuan sau khi da chia HH
        //    //    try
        //    //    {
        //    //        Double TongTiens = Convert.ToDouble(TongTien.ToString());
        //    //        Double TongTienss = Convert.ToDouble(TienDauVao.ToString());
        //    //        Double TongCong = (TongTienss - TongTiens);

        //    //        LoiNhuanMuaBan abln = new LoiNhuanMuaBan();
        //    //        abln.IDThanhVienMua = int.Parse(IDThanhVien.ToString());
        //    //        abln.IDDonHang = int.Parse(hdIDGiohang.Value);
        //    //        abln.MoTa = "";
        //    //        abln.NgayTao = DateTime.Now;
        //    //        abln.TongTien = TienDauVao.ToString();
        //    //        abln.TongTienCon = TongCong.ToString();
        //    //        abln.TongTienDaChia = TongTien.ToString();
        //    //        abln.MTreeIDThanhVienMua = Commond.ShowMTree(IDThanhVien.ToString());
        //    //        db.LoiNhuanMuaBans.InsertOnSubmit(abln);
        //    //        db.SubmitChanges();
        //    //    }
        //    //    catch (Exception)
        //    //    { }
        //    //    #endregion

        //    //}
        //    SCarts.Name_Text("update Carts set Status=1 where ID=" + hdIDGiohang.Value + "");
        //    Response.Write("<script type=\"text/javascript\">alert('Duyệt đơn hàng thành công.');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
        //    return;
        //}

        //void Commond.ThemHoaHong(string KieuHoaHong, string KieuHH, string TienDonHang, string SoTienDuocHuong, string PhanTram, string IDThanhVienMua, string IDThanhVienHuong, string ThuTuVongQuay, string SoLanVongQuay, string IDDonHang)
        //{
        //    List<Entity.Member> F1 = SMember.Name_Text("select * from Members  where ID=" + IDThanhVienHuong.ToString() + "");//DaKichHoat
        //    if (F1.Count() > 0)
        //    {
        //        #region Đếm Số lần tham gia vòng chơi
        //        SMember.Name_Text("update Members set SoLanThamGia=SoLanThamGia+1  where ID=" + IDThanhVienHuong.ToString() + "");
        //        #endregion

        //        #region HoaHongThanhVien
        //        HoaHong obj = new HoaHong();
        //        obj.KieuHoaHong = int.Parse(KieuHoaHong);
        //        obj.KieuHH = KieuHH;
        //        obj.TienDonHang = TienDonHang;
        //        obj.SoTienDuocHuong = SoTienDuocHuong;
        //        obj.PhanTram = PhanTram;
        //        obj.IDThanhVienMua = int.Parse(IDThanhVienMua);
        //        obj.IDThanhVienHuong = int.Parse(IDThanhVienHuong);
        //        obj.ThuTuVongQuay = int.Parse(ThuTuVongQuay);
        //        obj.SoLanVongQuay = int.Parse(SoLanVongQuay);
        //        obj.NgayTao = DateTime.Now;
        //        obj.IDDonHang = Convert.ToInt32(IDDonHang);
        //        db.HoaHongs.InsertOnSubmit(obj);
        //        db.SubmitChanges();
        //        #endregion
        //        CongTien(IDThanhVienHuong, SoTienDuocHuong);
        //    }
        //}
        //void CongTien(string IDUserNguoiDuocHuong, string SoTienDuocHuong)
        //{
        //    #region Cộng điểm theo hoa hồng
        //    List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDUserNguoiDuocHuong.ToString() + "");
        //    if (iitem != null)
        //    {
        //        double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
        //        double TongTienNapVao = Convert.ToDouble(SoTienDuocHuong);
        //        double Conglai = 0;
        //        Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
        //        SMember.Name_Text("update Members set TienHoaHong=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
        //    }
        //    #endregion
        //}
    }
}