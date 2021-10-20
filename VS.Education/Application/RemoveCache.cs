using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class RemoveCache
{
    public static string Home()
    {
        HttpContext.Current.Cache.Remove("Title");
        HttpContext.Current.Cache.Remove("Header");
        return "";
    }
    public static string Menu()
    {
        HttpContext.Current.Cache.Remove("MenuTop");
        HttpContext.Current.Cache.Remove("ShowMenuPage");
        HttpContext.Current.Cache.Remove("MenuBottom");
        return "";
    }
    public static string Products()
    {
        HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        HttpContext.Current.Cache.Remove("SanPhamMoi");
        HttpContext.Current.Cache.Remove("SanPhamXemNhieu");
        HttpContext.Current.Cache.Remove("SanPhamNhieuNguoiMua");
        HttpContext.Current.Cache.Remove("SanPhamMoiTop");
        HttpContext.Current.Cache.Remove("SanPhamNoiBatTop");
        HttpContext.Current.Cache.Remove("SanPhamKhuyenMaiTop");

        

        return "";
    }
    public static string News()
    {
       HttpContext.Current.Cache.Remove("Newsss");
        return "";
    }
    public static string Album()
    {
        //HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        return "";
    }

    public static string NewsFooter()
    {
        //HttpContext.Current.Cache.Remove("ShowNhomsanpham");
        return "";
    }
    public static string QuangCao()
    {
        HttpContext.Current.Cache.Remove("CamNhanKhachHang");
        return "";
    }
}
