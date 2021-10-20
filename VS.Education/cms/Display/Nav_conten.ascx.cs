using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display
{
    public partial class Nav_conten : System.Web.UI.UserControl
    {
        string hp = "";
        int iEmptyIndex = 0;
        string nav = "";
        string u = "";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.Language;
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
            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion
            try
            {
                if (Request["e"] != null)
                {
                    if (Request["e"].ToString() == "load")
                    {
                        u = MoreAll.Other.RequestMenu(Request["hp"]);
                    }
                }
            }
            catch
            {
            }
            if (!IsPostBack)
            {
                Nav_Content();
            }
        }

        private void Nav_Content()
        {
            string strReturn = "";
            strReturn += "";
            switch (u)
            {
                case "99":
                    strReturn += LoadNavPage(hp);
                    break;
                case "1":// nhom tin tuc
                    if (int.TryParse(More.TangNameicid(hp), out _cid))
                    {
                        strReturn += "<li><a href=\"/tin-tuc-new.html\">" + label("l_news") + "</a></li>";
                        strReturn += LoadNav(_cid);
                    }
                    break;
                case "3":// nhom chan trang
                    if (int.TryParse(More.TangNameicid(hp), out _cid))
                    {
                        strReturn += LoadNav(_cid);
                    }
                    break;
                case "5":// nhom Album
                    if (int.TryParse(More.TangNameicid(hp), out _cid))
                    {
                        strReturn += "<li><a href=\"/thu-vien-anh.html\">" + label("Thuvienanh") + "</a></li>";
                        strReturn += LoadNav(_cid);
                    }
                    break;
                case "7":// nhom Video
                    if (int.TryParse(More.TangNameicid(hp), out _cid))
                    {
                        strReturn += "<li><a href=\"/thu-vien-video.html\">" + label("Thuvienvideo") + "</a></li>";
                        strReturn += LoadNav(_cid);
                    }
                    break;
                case "20"://// nhom san pham
                    if (int.TryParse(More.TangNameicid(hp), out _cid))
                    {
                        strReturn += "<li><a href=\"/san-pham.html\">" + label("lproducts") + "</a></li>";
                        strReturn += LoadNav(_cid);
                    }
                    break;
                // Chi tiet

                case "2":
                    strReturn += "<li><a href=\"/tin-tuc-new.html\">" + label("l_news") + "</a></li>";
                    strReturn += LoadNavNews();
                    break;
                case "4":
                    strReturn += LoadNavNewsFooter();
                    break;
                case "6":
                    strReturn += "<li><a href=\"/thu-vien-anh.html\">" + label("Thuvienanh") + "</a></li>";
                    strReturn += LoadNavAllbums();
                    break;
                case "8":
                    strReturn += "<li><a href=\"/thu-vien-video.html\">" + label("Thuvienvideo") + "</a></li>";
                    strReturn += LoadNavVideos();
                    break;
                case "21":
                    strReturn += "<li><a href=\"/san-pham.html\">" + label("lproducts") + "</a></li>";
                    strReturn += LoadNavProduts();
                    break;


            }
            if (Request["su"] != null && !Request["su"].Equals(""))
            {
                if (Request["su"].ToString() == "viewcart" || Request["su"].ToString() == "msg" || Request["su"].ToString() == "msg")
                {
                    strReturn += "<li><a href=\"/gio-hang.html\">" + label("lt_cartbox") + "</a></li>";
                }
                if (Request["su"].ToString() == "contact")
                {
                    strReturn += "<li><a href=\"/lien-he.html\">" + label("l_contact") + "</a></li>";
                }
                if (Request["su"].ToString() == "nws")
                {
                    strReturn += "<li><a href=\"/tin-tuc.html\">" + label("l_news") + "</a></li>";
                }
                if (Request["su"].ToString() == "Thuvien")
                {
                    strReturn += "<li><a href=\"/thu-vien-anh.html\">" + label("Thuvienanh") + "</a></li>";
                }
                if (Request["su"].ToString() == "Videos")
                {
                    strReturn += "<li><a href=\"/thu-vien-video.html\">" + label("Thuvienvideo") + "</a></li>";
                }
                if (Request["su"].ToString() == "prd")
                {
                    strReturn += "<li><a href=\"/san-pham.html\">" + label("lproducts") + "</a></li>";
                }
                if (Request["su"].ToString() == "Download")
                {
                    strReturn += "<li><a href=\"/tai-du-lieu.html\">Download</a></li>";
                }
                if (Request["su"].ToString() == "GioiThieu")
                {
                    strReturn += "<li><a href=\"/giai-phap.html\">" + label("giaiphap") + "</a></li>";
                }
                if (Request["su"].ToString() == "Search")
                {
                    strReturn += "<li><a href=\"#\">" + label("l_search") + "</a></li>";
                }
                if (Request["su"].ToString() == "Register")
                {
                    strReturn += "<li><a href=\"/Dang-ky.html\">" + label("Thanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "resetpassword")
                {
                    strReturn += "<li><a href=\"/Lay-mat-khau.html\">Lấy lại mật khẩu</a></li>";
                }
                if (Request["su"].ToString() == "Infos")
                {
                    strReturn += "<li><a href=\"/thong-tin-thanh-vien.html\">" + label("ttthanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "changinfo")
                {
                    strReturn += "<li><a href=\"/xem-thong-tin-thanh-vien.html\">" + label("capthanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "changepass")
                {
                    strReturn += "<li><a href=\"/thay-doi-mat-khau.html\">" + label("thaydoimk") + "</a></li>";
                }
                if (Request["su"].ToString() == "Login")
                {
                    strReturn += "<li><a href=\"/Dang-nhap.html\">" + label("l_login") + "</a></li>";
                }
                if (Request["su"].ToString() == "Banchay")
                {
                    strReturn += "<li><a href=\"/san-pham-ban-chay.html\">" + label("l_prdbestsell") + "</a></li>";
                }
                if (Request["su"].ToString() == "sanphamoi")
                {
                    strReturn += "<li><a href=\"/san-pham-moi.html\">" + label("l_prdnews") + "</a></li>";
                }
                if (Request["su"].ToString() == "affiliate")
                {
                    strReturn += "<li><a href=\"/link-affiliate.html\">Link Affiliate</a></li>";
                }
                if (Request["su"].ToString() == "RutTien")
                {
                    strReturn += "<li><a href=\"/rut-tien.html\">Rút tiền</a></li>";
                }
                if (Request["su"].ToString() == "LichSuMuaHang")
                {
                    strReturn += "<li><a href=\"/lich-su-mua-hang.html\">Lịch sử mua hàng</a></li>";
                }
                if (Request["su"].ToString() == "Detailorders")
                {
                    strReturn += "<li><a href=\"/lich-su-mua-hang.html\">Lịch sử mua hàng</a></li>";
                }
                if (Request["su"].ToString() == "LichSuRutTien")
                {
                    strReturn += "<li><a href=\"/lich-su-rut-tien.html\">Lịch sử rút điểm</a></li>";
                }
                if (Request["su"].ToString() == "ViDiem")
                {
                    strReturn += "<li><a href=\"/Vi-diem.html\">Ví tiền</a></li>";
                }
                if (Request["su"].ToString() == "HoaHong")
                {
                    strReturn += "<li><a href=\"/hoa-hong.html\">Hoa hồng</a></li>";
                }
                if (Request["su"].ToString() == "Danhsachthanhvien")
                {
                    strReturn += "<li><a href=\"/danh-sach-thanh-vien.html\">Danh sách thành viên</a></li>";
                }
                if (Request["su"].ToString() == "LichSuCapDiem")
                {
                    strReturn += "<li><a href=\"/lich-su-cap-diem.html\">Lịch sử cấp điểm</a></li>";
                }
                if (Request["su"].ToString() == "MLichSuQuyDoiSoCoPhan")
                {
                    strReturn += "<li><a href=\"/ls-quy-doi-vi-vprs.html\">LS Quy đổi ví VPR-S</a></li>";
                }
                if (Request["su"].ToString() == "QuyDoiVPRS")
                {
                    strReturn += "<li><a href=\"/quy-doi-vi-vprs.html\"> Quy đổi ví VPR-S</a></li>";
                }
                
                
            }
            ltrnav.Text = strReturn;
        }

        private string LoadNavNews()
        {
            List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavNewsFooter()
        {
            List<Entity.Nfooter> dt = SNfooter.Name_Text("SELECT * FROM [Nfooter]  where TangName='" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavAllbums()
        {
            List<Entity.Album> dt = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName='" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].Menu_ID.ToString()));
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavVideos()
        {
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName='" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].Menu_ID.ToString()));
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavProduts()
        {
            List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNav(int ID)
        {
            var item = db.Menus.FirstOrDefault(s => s.ID == ID);
            if (item != null)
            {
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }
        private string LoadNavPage(string TangName)
        {
            var item = db.Menus.FirstOrDefault(s => s.TangName == TangName & s.capp == More.MN);
            if (item != null)
            {
                nav = "<span> <i class=\"fa fa-angle-right\"></i> </span><li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}