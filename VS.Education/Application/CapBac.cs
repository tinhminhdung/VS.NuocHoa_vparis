using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VS.E_Commerce;

public class CapBac
{
    public static string ChiaHoaHongCapBacs(string IDThanhVien, string Tongtien, string IDDonHang)
    {
        string Plevel = "0";
        string chuoi1 = "0";
        string TongLevel = "0";
        System.Web.HttpContext.Current.Session["TongPT"] = "";
        #region Cộng điểm theo hoa hồng

        List<Entity.Member> item = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (item.Count > 0)
        {
            int i = 0;
            string CapBac = item[0].CapBac.ToString();
            SMember.Name_Text("update Members set IDLuuTam='0'  where ID=" + IDThanhVien.ToString() + "");
            string chuyendoi = item[0].MTRee.ToString();
            chuyendoi = chuyendoi.Replace("|", ",") + "0";
            chuyendoi = "0" + chuyendoi;
            chuoi1 = chuyendoi.ToString();
            List<Entity.Member> iitems = SMember.Name_Text("select * from Members where ID in (" + chuyendoi.ToString() + ") and CapBac!=0  and TrangThaiMuaHang=1 order by ID desc ");
            if (iitems.Count > 0)
            {
                foreach (var obj in iitems)
                {
                    Plevel = Plevel + "," + LoaID(IDThanhVien);
                    TongLevel = MinAndMax(Plevel.ToString());
                    Double Stop = Convert.ToDouble(ChiaHH(TongLevel, obj.CapBac.ToString(), IDThanhVien.ToString(), obj.ID.ToString(), Tongtien, IDDonHang));
                    if (Stop == 1)
                    {
                        break;
                    }

                    // kiểm tra trong tổng hh được chia chỉ được = giám đốc kinh doanh cấp cao
                    #region DungChay
                    Double TongHoaHong = Convert.ToDouble(KiemTraTongHoaHongDaChia(IDDonHang));
                    Double DungChay = 0;
                    if (Commond.ShowTrangThai() == "0")// Loi nHuận
                    {
                        DungChay = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapLN"));
                    }
                    else // chiến lươc
                    {
                        DungChay = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapCL"));
                    }
                    if (TongHoaHong >= DungChay)
                    {
                        break;
                    }
                    #endregion

                    // chuoi += "<br /> ID:" + obj.ID.ToString();
                    // i++;
                }
            }

        }
        #endregion
        return "";
    }
    public static string KiemTraTongHoaHongDaChia(string IDDonHang)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        double num = 0.0;
        List<HoaHong> items = db.HoaHongs.Where(s => s.IDDonHang == int.Parse(IDDonHang) && s.KieuHoaHong == 10).ToList();// xóa nhiều
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                num += Convert.ToDouble(items[i].PhanTram.ToString());
            }
        }
        return num.ToString();
    }
    public static string LoaID(string IDThanhVien)
    {
        List<Entity.Member> items = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (items.Count > 0)
        {
            return items[0].IDLuuTam.ToString();
        }
        return "0";
    }
    public static string UpdateLoaID(string Capbac, string IDThanhVien)
    {
        SMember.Name_Text("update Members set IDLuuTam='" + Capbac.ToString() + "'  where ID=" + IDThanhVien.ToString() + "");
        return "";
    }
    public static string ChiaHH(string TongLevel, string TCapBac, string IDThanhVienMuaHang, string IDThanhViens, string Money, string IDCart)
    {
        Double Cap1 = 0;
        Double Cap2 = 0;
        Double Cap3 = 0;
        Double Cap4 = 0;
        if (Commond.ShowTrangThai() == "0")// Loi nHuận
        {
            Cap1 = Convert.ToDouble(Commond.Setting("TruongNhomKDLN"));
            Cap2 = Convert.ToDouble(Commond.Setting("TruongPhongKinhDoanhLN"));
            Cap3 = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhLN"));
            Cap4 = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapLN"));

        }
        else // chiến lươc
        {
            Cap1 = Convert.ToDouble(Commond.Setting("TruongNhomKDCL"));
            Cap2 = Convert.ToDouble(Commond.Setting("TruongPhongKinhDoanhCL"));
            Cap3 = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCL"));
            Cap4 = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapCL"));
        }

        double TienDauVao = Convert.ToDouble(Money);
        Double TongTien = 0;
        string Capbac = "";
        #region hoa hồng
        List<Entity.Member> items = SMember.Name_Text("select * from Members where ID=" + IDThanhViens.ToString() + "");
        if (items.Count > 0)
        {
            double Tongphantram = Convert.ToDouble(items[0].CapBac.ToString());
                //Convert.ToDouble(PhanTramLevel(TongLevel, items[0].CapBac.ToString()));
            if (Tongphantram > 0)
            {
                Double Tru = 0;
                string PhanTram = "0" + System.Web.HttpContext.Current.Session["TongPT"].ToString();
                if (PhanTram != "")
                {
                    string[] strArray = PhanTram.ToString().Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        Tru = Convert.ToDouble(strArray[i].ToString());
                        Tongphantram = (Tongphantram - Tru);
                    }
                   // Tongphantram = PTT;
                }
            }


            //#region Kiểm tra trong db đã đủ 3% (ăn theo cáu hình có % to nhất) chưa nếu đã đủ rồi thì tính trừ cấp dưới
            //#region TongHoaHong
            //Double TongHoaHong = Convert.ToDouble(KiemTraTongHoaHongDaChia(IDCart));
            //Double tong = 0;
            //if (Tongphantram == 1)
            //{
            //    tong = Cap1 + TongHoaHong;
            //}
            //if (Tongphantram == 2)
            //{
            //    tong = Cap2 + TongHoaHong;
            //}
            //if (Tongphantram == 3)
            //{
            //    tong = Cap3 + TongHoaHong;
            //}
            //if (Tongphantram == 4)
            //{
            //    tong = Cap4 + TongHoaHong;
            //}
            //#endregion
            //#region Loi nHuận hay chiến lươc
            //double Chay = 0;
            //if (Commond.ShowTrangThai() == "0")// Loi nHuận
            //{
            //    Chay = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapLN"));
            //}
            //else // chiến lươc
            //{
            //    Chay = Convert.ToDouble(Commond.Setting("GiamDocKinhDoanhCaoCapCL"));
            //}
            //#endregion
            //if (tong > Convert.ToDouble(Chay))
            //{
            //    Double PTT = 0;
            //    Double Tru = 0;
            //    string PhanTram = "0" + System.Web.HttpContext.Current.Session["TongPT"].ToString();
            //    string[] strArray = PhanTram.ToString().Split(new char[] { ',' });
            //    for (int i = 0; i < strArray.Length; i++)
            //    {
            //        Tru = Convert.ToDouble(strArray[i].ToString());
            //        PTT = (Tongphantram - Tru);
            //    }
            //    Tongphantram = PTT;
            //}
            //#endregion

            double PTHH = 0;
            if (Tongphantram > 0)
            {
                System.Web.HttpContext.Current.Session["TongPT"] += "," + Tongphantram;
                #region Tongphantram Mang đi chia
                // số 1,2,3,4 này chính là cấp bậc 1,2,3,4 tương ứng với drop trong quản lý thành viên nhé
                if (Tongphantram == 1)
                {
                    PTHH = Cap1;
                }
                if (Tongphantram == 2)
                {
                    PTHH = Cap2;
                }
                if (Tongphantram == 3)
                {
                    PTHH = Cap3;
                }
                if (Tongphantram == 4)
                {
                    PTHH = Cap4;
                }
                #endregion
                #region TCapBac
                if (TCapBac == "1")
                {
                    Capbac = "Trưởng nhóm kinh doanh";
                }
                if (TCapBac == "2")
                {
                    Capbac = "Trưởng phòng kinh doanh";
                }
                if (TCapBac == "3")
                {
                    Capbac = "Giám đốc kinh doanh";
                }
                if (TCapBac == "4")
                {
                    Capbac = "Giám đốc kinh doanh cấp cao";
                }
                #endregion
                if (PTHH > 0)
                {
                    double TongHHTT = (TienDauVao * PTHH) / 100;
                    Commond.ThemHoaHong("10", Capbac, TienDauVao.ToString(), TongHHTT.ToString(), PTHH.ToString(), IDThanhVienMuaHang.ToString(), items[0].ID.ToString(), IDCart);
                    TongTien += TongHHTT;
                    UpdateLoaID(Tongphantram.ToString(), IDThanhVienMuaHang);
                }
            }
            if (Tongphantram >= 4)
            {
                return "1";
            }
            //if (Tongphantram < 0)
            //{
            //    return "1";
            //}
        }
        #endregion
        return "0";
    }
    public static string PhanTramLevel(string ThanhVienA, string ThanhVienB)
    {
        // Lấy trên trừ dưới level A - level B
        Double CBThanhVienA = Convert.ToDouble(ThanhVienA);
        Double CBThanhVienB = Convert.ToDouble(ThanhVienB);
        double TongCong = Convert.ToDouble(CBThanhVienB - CBThanhVienA);
        return TongCong.ToString();
    }

    #region Tìm giá trị lớn nhất trong level để thưởng cho các đời F1 đến F5
    public static string MinAndMax(string c)
    {
        String intString = c.Replace("99999999999,", "");
        int[] strArray = stringArrayToIntArray(intString);
        int max = strArray[0];
        if (strArray.Length > 0)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] > max)
                {
                    max = strArray[i];
                }
            }
        }
        if (max.ToString() == "0")
        {
            return "0";
        }
        else
        {
            return max.ToString();
        }
        return "0";
    }
    public static int[] stringArrayToIntArray(String intString)
    {
        String[] intStringSplit = intString.Trim().Split(new char[] { ',' });
        int[] result = new int[intStringSplit.Length]; //Used to store our ints

        for (int i = 0; i < intStringSplit.Length; i++)
        {
            result[i] = int.Parse(intStringSplit[i]);
        }
        return result;
    }
    #endregion;

    public static string KiemTraTongTienHoaHongDaChiaCapBac(string IDDonHang, string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        double num = 0.0;
        List<HoaHong> items = db.HoaHongs.Where(s => s.IDDonHang == int.Parse(IDDonHang) && s.KieuHoaHong == 10 && s.IDThanhVienMua == int.Parse(IDThanhVien)).ToList();// xóa nhiều
        if (items.Count > 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                num += Convert.ToDouble(items[i].SoTienDuocHuong.ToString());
            }
        }
        return num.ToString();
    }

    public static bool Kiemtratongcapbac(string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> tb1 = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + " and TrangThaiMuaHang=1 ");
        if (tb1.Count() > 0)
        {
            Double CauHinh = Convert.ToDouble(Commond.Setting("DieuKienLenTruongNhomKD"));
            Double CauHinhTVCapDuoi = Convert.ToDouble(Commond.Setting("CauHinhTVCapDuoi"));
            Double Count = Convert.ToDouble(tb1.Count().ToString());
            if (Count >= CauHinh)
            {
                var tongthanhvien = db.TongThanhVienBenDuoi_kichhoat(int.Parse(IDThanhVien.ToString())).ToList();
                if (tongthanhvien.Count > 0)
                {
                    Double Counttongthanhvien = Convert.ToDouble(tongthanhvien[0].COUNT.ToString());
                    if (Counttongthanhvien >= CauHinhTVCapDuoi)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public static string NangCapbac(string IDThanhVien)
    {
        List<Entity.Member> data = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
        if (data.Count() > 0)
        {
            if (Kiemtratongcapbac(IDThanhVien) == true)
            {
                if (data[0].CapBac.ToString() == "0")
                {
                    SMember.Name_Text("update Members set CapBac='1'  where ID=" + IDThanhVien.ToString() + "");
                }
            }
        }
        ThuongNongKhiTimRaF1(IDThanhVien);
        ThuongNongKhiTimRaF1_CoPhan(IDThanhVien);
        return "";
    }
    public static string ThanhVienGioiTHieu(string IDThanhVien)
    {
        List<Entity.Member> data = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + "  and TrangThaiMuaHang=1");
        if (data.Count() > 0)
        {
            return data.Count().ToString();
        }
        return "0";
    }
    public static string ThanhVienGioiTHieuChuaKich(string IDThanhVien)
    {
        List<Entity.Member> data = SMember.Name_Text("select * from Members where GioiThieu=" + IDThanhVien.ToString() + " ");
        if (data.Count() > 0)
        {
            return data.Count().ToString();
        }
        return "0";
    }

    public static string ThuongNongKhiTimRaF1(string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> data = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + " and TrangThaiMuaHang=1 ");
        if (data.Count() > 0)
        {
            if (data[0].F1MuaHangDeTinhThuong >= Convert.ToDouble(Commond.Setting("TongSoF1")))
            {
                string TienThuongRa3F1 = Commond.Setting("TienThuongRa3F1");
                if (TienThuongRa3F1 != "0" && TienThuongRa3F1 != "")
                {
                    SMember.Name_Text("update Members set F1MuaHangDeTinhThuong=0  where ID=" + IDThanhVien.ToString() + "");

                    CapDiemThanhVien obj = new CapDiemThanhVien();
                    obj.IDNguoiCap = 1;
                    obj.IDNguoiNhan = int.Parse(IDThanhVien);
                    obj.SoTien = TienThuongRa3F1;
                    obj.NgayCap = DateTime.Now;
                    obj.MoTa = "Thưởng khi có " + Commond.Setting("TongSoF1") + " F1";
                    obj.NguoiTao = "Auto";
                    obj.TrangThai = 1;
                    obj.KieuVi = 1;
                    obj.CongTRu = 1;
                    db.CapDiemThanhViens.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    double SoCoin = Convert.ToDouble(TienThuongRa3F1);
                    CongTienThuongNongKhiTimRaF1(IDThanhVien, SoCoin.ToString());
                }
            }
        }
        return "0";
    }


    public static string ThuongNongKhiTimRaF1_CoPhan(string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> data = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + " and TrangThaiMuaHang=1 ");
        if (data.Count() > 0)
        {
            if (data[0].F1MuaHangThuongSoCoPhan >= Convert.ToDouble(Commond.Setting("TongSoF1VPRS")))
            {
                string TienThuongRa3F1 = Commond.Setting("VPRSThuongRa3F1");
                if (TienThuongRa3F1 != "0" && TienThuongRa3F1 != "")
                {
                    SMember.Name_Text("update Members set F1MuaHangThuongSoCoPhan=0  where ID=" + IDThanhVien.ToString() + "");
                    CapDiemThanhVien obj = new CapDiemThanhVien();
                    obj.IDNguoiCap = 1;
                    obj.IDNguoiNhan = int.Parse(IDThanhVien);
                    obj.SoTien = TienThuongRa3F1;
                    obj.NgayCap = DateTime.Now;
                    obj.MoTa = "Thưởng khi có " + Commond.Setting("TongSoF1VPRS") + " F1";
                    obj.NguoiTao = "Auto";
                    obj.TrangThai = 1;
                    obj.KieuVi = 3;
                    obj.CongTRu = 1;
                    db.CapDiemThanhViens.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    double SoCoin = Convert.ToDouble(TienThuongRa3F1);
                    CongTienThuongNongKhiTimRaF1ViCoPhanSo(IDThanhVien, SoCoin.ToString());
                }
            }
        }
        return "0";
    }
    public static void CongTienThuongNongKhiTimRaF1(string IDThanhVien, string SoTien)
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

    public static void CongTienThuongNongKhiTimRaF1ViCoPhanSo(string IDThanhVien, string SoTien)
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
}


