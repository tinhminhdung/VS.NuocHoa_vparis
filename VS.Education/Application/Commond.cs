using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VS.E_Commerce;

public class Commond
{

    public static string TangSoCoPhanKhiDatHang(string TongTienDatHangs, string IDThanhVien)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        Double TongTienDatHang = Convert.ToDouble(TongTienDatHangs);
        List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.KG, "VIE", "-1");
        foreach (var item in table)
        {
            Double Tu = Convert.ToDouble(item.Link);
            Double Den = Convert.ToDouble(item.Styleshow);
            string CoPhan = item.Description;
            if (TongTienDatHang >= Tu && TongTienDatHang < Den)
            {
                CapDiemThanhVien obj = new CapDiemThanhVien();
                obj.IDNguoiCap = 0;
                obj.IDNguoiNhan = int.Parse(IDThanhVien);
                obj.SoTien = CoPhan;
                obj.NgayCap = DateTime.Now;
                obj.MoTa = "Tặng vào ví khi mua hàng VPR-S";
                obj.NguoiTao = "Auto";
                obj.TrangThai = 1;
                obj.KieuVi = 1;
                obj.CongTRu = 1;
                db.CapDiemThanhViens.InsertOnSubmit(obj);
                db.SubmitChanges();
                double SoCoin = Convert.ToDouble(CoPhan);
                #region Cộng
                List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDThanhVien.ToString() + "");
                if (iitem.Count > 0)
                {
                    double TongSoCoinDaCo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                    double TongTienNapVao = Convert.ToDouble(CoPhan);
                    double Conglai = 0;
                    Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
                    SMember.Name_Text("update Members set ViCoPhanSo=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
                }
                #endregion
                return CoPhan;
            }
        }
        return "0";

    }

    public static string ShowTrangThaiMuaHang(string IDThanhVien)
    {
        List<Entity.Member> dt = SMember.Name_Text("select * from Members where Id=" + IDThanhVien + " and TrangThaiMuaHang=1");
        if (dt.Count > 0)
        {
            return "1";
        }
        return "0";

    }
    public static string ThemHoaHong(string KieuHoaHong, string KieuHH, string TienDonHang, string SoTienDuocHuong, string PhanTram, string IDThanhVienMua, string IDThanhVienHuong, string IDDonHang)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        List<Entity.Member> F1 = SMember.Name_Text("select * from Members  where ID=" + IDThanhVienHuong.ToString() + "");//DaKichHoat
        if (F1.Count() > 0)
        {
            #region HoaHongThanhVien
            HoaHong obj = new HoaHong();
            obj.KieuHoaHong = int.Parse(KieuHoaHong);
            obj.KieuHH = KieuHH;
            obj.TienDonHang = TienDonHang;
            obj.SoTienDuocHuong = SoTienDuocHuong;
            obj.PhanTram = PhanTram;
            obj.IDThanhVienMua = int.Parse(IDThanhVienMua);
            obj.IDThanhVienHuong = int.Parse(IDThanhVienHuong);
            obj.NgayTao = DateTime.Now;
            obj.IDDonHang = Convert.ToInt32(IDDonHang);
            db.HoaHongs.InsertOnSubmit(obj);
            db.SubmitChanges();
            #endregion
            CongTien(IDThanhVienHuong, SoTienDuocHuong);
        }
        return "";
    }

    public static string CongTien(string IDUserNguoiDuocHuong, string SoTienDuocHuong)
    {
        #region Cộng điểm theo hoa hồng
        List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + IDUserNguoiDuocHuong.ToString() + "");
        if (iitem.Count > 0)
        {
            double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
            double TongTienNapVao = Convert.ToDouble(SoTienDuocHuong);
            double Conglai = 0;
            Conglai = ((TongSoCoinDaCo) + (TongTienNapVao));
            SMember.Name_Text("update Members set TienHoaHong=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
        }
        #endregion

        CapBac.NangCapbac(IDUserNguoiDuocHuong);
        return "";
    }

    public static string ShowCapBac(string id)
    {
        string str = "";
        if (id == "1")
        {
            str = "-" + "[Level 1]";
        }
        else if (id == "2")
        {
            str = "-" + "[Level 2]";
        }
        else if (id == "3")
        {
            str = "-" + "[Level 3]";
        }
        else if (id == "4")
        {
            str = "-" + "[Level 4]";
        }
        return str;
    }
    public static string ShowTrangThai()
    {
        string Chuoi = "2";
        if (System.Web.HttpContext.Current.Session["cart"] != null)
        {
            DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    return dtcart.Rows[i]["TrangThai"].ToString();
                }
            }
        }
        return Chuoi;
    }

    public static string Tinh_TienLoiNhuan(string GiaBan, string GiaNhap)
    {
        //Giá đại lý - giá công ty=16
        // 158-142=16
        if (GiaBan.Length > 0 && GiaNhap.Length > 0)
        {
            if (Convert.ToDouble(GiaBan.ToString()) > Convert.ToDouble(GiaNhap.ToString()))
            {
                double GiaNhaps = Convert.ToDouble(GiaNhap.ToString());
                double GiaBans = Convert.ToDouble(GiaBan.ToString());
                double Tong = (GiaBans - GiaNhaps);
                if (Tong != 0)
                {
                    return Tong.ToString();
                }
            }
        }
        return "0";
    }
    public static string LoadProductList(IEnumerable<Entity.Products> product)
    {
        string str = "";
        foreach (Entity.Products item in product)
        {
            str += " <div class=\"col-xs-6 col-xss-6 col-lg-4\">";
            str += " <div class=\"product-box product-box-theme\">";
            str += " <div class=\"variants margin-bottom-0\">";
            str += " <div class=\"product-thumbnail\">";
            str += "     <a href='/" + item.TangName + ".html' title=\"" + item.Name + "\">" + MoreAll.MorePro.Image_Title_Alt(item.ImagesSmall.ToString(), item.Name.ToString(), item.Name.ToString()) + "</a>";
            str += " </div>";
            str += " <div class=\"product-info\">";
            str += "     <h3 class=\"product-name\">";
            str += "         <a href='/" + item.TangName + ".html' title=\"" + item.Name + "\">" + MoreAll.MorePro.Substring_Title(item.Name.ToString()) + "</a>";
            str += "     </h3>";
            str += "     <div class=\"price-box clearfix\">";
            str += "         <div class=\"special-price\">";
            str += "             <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(item.Price.ToString()) + "</span>";
            str += "         </div>";
            str += "     </div>";
            str += "     <div class=\"\">";
            str += "         <a class=\"btn-buy btn-cart btn btn-primary \" href=\"javascript:void(0)\" onclick=\"UpdateOrder(" + item.ipid + ",'" + item.Name + "'," + item.News + ")\" title=\"Đặt hàng\">+ Vào giỏ hàng </a>";
            str += "     </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
        }
        return str;
    }


    public static string LoadProductList_Home(IEnumerable<Entity.Products> product)
    {
        string str = "";
        foreach (Entity.Products item in product)
        {
            str += " <div class=\"col-xs-6 col-xss-6 col-lg-3\">";
            str += " <div class=\"product-box product-box-theme\">";
            str += " <div class=\"variants margin-bottom-0\">";
            str += " <div class=\"product-thumbnail\">";
            str += "     <a href='/" + item.TangName + ".html' title=\"" + item.Name + "\">" + MoreAll.MorePro.Image_Title_Alt(item.ImagesSmall.ToString(), item.Name.ToString(), item.Name.ToString()) + "</a>";
            str += " </div>";
            str += " <div class=\"product-info\">";
            str += "     <h3 class=\"product-name\">";
            str += "         <a href='/" + item.TangName + ".html' title=\"" + item.Name + "\">" + MoreAll.MorePro.Substring_Title(item.Name.ToString()) + "</a>";
            str += "     </h3>";
            str += "     <div class=\"price-box clearfix\">";
            str += "         <div class=\"special-price\">";
            str += "             <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(item.Price.ToString()) + "</span>";
            str += "         </div>";
            str += "     </div>";
            str += "     <div class=\"\">";
            str += "         <a class=\"btn-buy btn-cart btn btn-primary \" href=\"javascript:void(0)\" onclick=\"UpdateOrder(" + item.ipid + ",'" + item.Name + "'," + item.News + ")\" title=\"Đặt hàng\">+ Vào giỏ hàng </a>";
            str += "     </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
            str += " </div>";
        }
        return str;
    }


    public static string Demchuoi(string chuoi)// đầu vào là mã ngũ phân
    {
        // Số tầng hiện tại
        string str; /* Khai bao mot chuoi */
        int l = 0;
        str = chuoi;
        foreach (char chr in str)
        {
            l += 1;
        }
        return l.ToString();
    }
    public static string Sotanglonnhat(string chuoi)// đầu vào là mã ngũ phân
    {
        // Số thứ tự lớn nhất
        // Tổng tầng hiện tại
        List<Entity.Member> dt = SMember.Name_Text("select top 1 * from Members order by SoNguPhan desc");
        if (dt.Count >= 1)
        {
            return Demchuoi(dt[0].SoNguPhan.ToString());
        }
        return "0";
    }
    public static string SoThuTuThanhVien(string IDThanhVien)// đầu vào là mã ngũ phân
    {
        // Số thứ tự lớn nhất
        // Tổng tầng hiện tại
        List<Entity.EEThuTuVong> dt = SThuTuVong.Name_Text("select top 1 * from ThuTuVong where IDThanhVien=" + IDThanhVien + "");
        if (dt.Count >= 1)
        {
            return dt[0].ThuTuSet.ToString();
        }
        return "0";
    }
    public static string TongSoNguoiHienTai(string IDThanhVien)
    {
        // Tổng số người lớn nhất
        List<Entity.EEThuTuVong> dt = SThuTuVong.Name_Text("select top 1 * from ThuTuVong order by ThuTuSet desc");
        if (dt.Count >= 1)
        {
            return dt[0].ThuTuSet.ToString();
        }
        return "0";
    }

    public static string ShowThapPhan(int n)
    {
        int i, j, k, binno = 0, dn;
        dn = n;
        i = 1;
        for (j = 1; j > 0; j = n)
        {
            k = n % 5;
            if (k == 0)
            {
                k = 5;
                n = (n / 5) - 1;
            }
            else
            {
                n = n / 5;
            }
            binno = binno + (k) * i;
            i = i * 10;
            j = n;
        }
        // return dn + "-" + binno + "<br>";
        return binno.ToString();
    }

    public static string SetDuoiBang1(int n)// đầu vào là mã ngũ phân
    {
        int duoi = 0;
        duoi = n % 10;
        return duoi.ToString();
    }

    public static string CatDuoi(int n)// dao vào là mã ngũ phân
    {
        int duoi = 0;
        duoi = n / 10;
        return duoi.ToString();
    }


    public static string ShowMTree(string id)
    {
        string str = "";
        try
        {
            if (id != "0" || id != "")
            {
                List<Entity.Member> dt = SMember.GET_BY_ID(id);
                if (dt.Count >= 1)
                {
                    str = dt[0].MTRee;
                }
            }
        }
        catch (Exception)
        { }
        return str;
    }


    public static bool Check(object String)
    {
        return ((String != null) && (String.ToString().Trim().Length > 0));
    }
    public static DateTime ConvertStringToDate(string Date, string FromFormat)
    {
        return DateTime.ParseExact(Date, FromFormat, null);
    }
    public static string FormatDate(object date)
    {
        if (date != null)
        {
            if (date.ToString().Trim().Length > 0 && date != null)
            {
                if (DateTime.Parse(date.ToString()).Year != 1900)
                {
                    DateTime dNgay = Convert.ToDateTime(date.ToString());
                    return ((DateTime)dNgay).ToString("yyyy-MM-dd");
                }
            }

        }
        return "";
    }
    public static string SearchThanhVien(string keyword)
    {
        string str = "0";
        List<Entity.Member> dt = SMember.Name_Text("select * from Members where (HoVaTen like N'%" + keyword + "%')");
        if (dt.Count >= 1)
        {
            for (int i = 0; i < dt.Count; i++)
            {
                str = str + "," + dt[i].ID.ToString();
            }
        }
        return str.Replace("0,", "");
    }
    public static string ShowThanhVien(string id)
    {
        string str = "";
        List<Entity.Member> dt = SMember.GET_BY_ID(id);
        if (dt.Count >= 1)
        {
            str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
            if (dt[0].HoVaTen.ToString().Length > 0)
            {
                str += "<a target=\"_blank\" href=\"/admin.aspx?u=Thanhvien&IDThanhVien=" + dt[0].ID.ToString() + "\"><span style='color:red'>" + dt[0].HoVaTen + Commond.ShowCapBac(dt[0].CapBac.ToString()) + "</span></a>";
            }
            str += "</span><br>";
            if (dt[0].DienThoai.ToString().Length > 0)
            {
                str += dt[0].DienThoai;
            }
        }
        else
        {
            str = "Không tìm thấy thành viên";
        }
        return str;
    }
    public static string ShowThanhVien_Display(string id)
    {
        string str = "";
        List<Entity.Member> dt = SMember.GET_BY_ID(id);
        if (dt.Count >= 1)
        {
            str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
            if (dt[0].HoVaTen.ToString().Length > 0)
            {
                str += dt[0].HoVaTen;
            }
            str += "</span><br>";
            if (dt[0].DienThoai.ToString().Length > 0)
            {
                str += dt[0].DienThoai;
            }
        }
        else
        {
            str = "Không tìm thấy thành viên";
        }
        return str;
    }
    public static string PhantrangAdmin(string Url, int Tongsobanghi, int pages)
    {
        string str = "<div class='PhantrangAD'>";
        if (Tongsobanghi > 1)
        {
            str += "<a href='" + Url + "&page=1'><< Trang đầu</a>";
            int startPage;
            if (Tongsobanghi <= 7)
                startPage = 1;
            else if (pages <= 4)
                startPage = 1;
            else if ((Tongsobanghi - pages) >= 3)
                startPage = pages - 3;
            else startPage = Tongsobanghi - 6;
            if (startPage > 1)
                str += string.Format("<a class=\"aso\">...</a>");
            for (int i = startPage; i <= (Tongsobanghi <= 7 ? Tongsobanghi : startPage + 6); i++)
            {
                if (i == pages)
                {
                    str += "<a class='pageactive' href=\"" + Url + "&page=" + i + "\">" + i + "</a>";
                }
                else
                {
                    str += "<a class='page' href=\"" + Url + "&page=" + i + "\">" + i + "</a>";
                }
            }
            if ((Tongsobanghi - pages > 3) && (Tongsobanghi > 7))
                str += string.Format("<a class=\"aso\">...</a>");
            str += "<a href='" + Url + "&page=" + Tongsobanghi + "'>Cuối cùng >></a>";
        }
        str += "</div>";
        return str;
    }
    public static string Phantrang(string Url, int Tongsobanghi, int pages)
    {
        string str = "<div class='Phantrang'>";
        if (Tongsobanghi > 1)
        {
            str += "<a href='" + Url + "?page=1'><< Trang đầu</a>";
            int startPage;
            if (Tongsobanghi <= 7)
                startPage = 1;
            else if (pages <= 4)
                startPage = 1;
            else if ((Tongsobanghi - pages) >= 3)
                startPage = pages - 3;
            else startPage = Tongsobanghi - 6;
            if (startPage > 1)
                str += string.Format("<a class=\"aso\">...</a>");
            for (int i = startPage; i <= (Tongsobanghi <= 7 ? Tongsobanghi : startPage + 6); i++)
            {
                if (i == pages)
                {
                    str += "<a class='pageactive' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
                }
                else
                {
                    str += "<a class='page' href=\"" + Url + "?page=" + i + "\">" + i + "</a>";
                }
            }
            if ((Tongsobanghi - pages > 3) && (Tongsobanghi > 7))
                str += string.Format("<a class=\"aso\">...</a>");
            str += "<a href='" + Url + "?page=" + Tongsobanghi + "'>Cuối cùng >></a>";
        }
        str += "</div>";
        return str;
    }

    public static string Setting(string giatri)
    {
        DatalinqDataContext db = new DatalinqDataContext();
        string item = "";
        CauHinh str = db.CauHinhs.SingleOrDefault(p => p.Properties == giatri && p.Lang == MoreAll.MoreAll.Language);
        if (str != null)
        {
            item = str.Value;
        }
        return item.ToString();
    }
}
