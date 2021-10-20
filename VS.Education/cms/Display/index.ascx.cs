using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Data;
using Advertisings;

namespace VS.E_Commerce.cms.Display
{
    public partial class index : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        public int i = 1;
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
                ltShowNhomsanpham.Text = MoreAll.MoreAll.GetCache("ShowNhomsanpham", HttpContext.Current.Cache["ShowNhomsanpham"] != null ? "" : ShowNhomsanpham());
                ltrpsanphammoi.Text = MoreAll.MoreAll.GetCache("SanPhamMoiTop", HttpContext.Current.Cache["SanPhamMoiTop"] != null ? "" : SanPhamMoiTop());
                ltrpsanphamhot.Text = MoreAll.MoreAll.GetCache("SanPhamHotTop", HttpContext.Current.Cache["SanPhamHotTop"] != null ? "" : SanPhamHotTop());
                ltrpsanphamnoibat.Text = MoreAll.MoreAll.GetCache("SanPhamNoiBatTop", HttpContext.Current.Cache["SanPhamNoiBatTop"] != null ? "" : SanPhamNoiBatTop());
                ltrpsanphamkhuyenmai.Text = MoreAll.MoreAll.GetCache("SanPhamKhuyenMaiTop", HttpContext.Current.Cache["SanPhamKhuyenMaiTop"] != null ? "" : SanPhamKhuyenMaiTop());

                ltsanphammoi.Text = MoreAll.MoreAll.GetCache("SanPhamMoi", HttpContext.Current.Cache["SanPhamMoi"] != null ? "" : SanPhamMoi());
                ltsanphamxemnhieu.Text = MoreAll.MoreAll.GetCache("SanPhamXemNhieu", HttpContext.Current.Cache["SanPhamXemNhieu"] != null ? "" : SanPhamXemNhieu());
                ltsanphamMuaNhieu.Text = MoreAll.MoreAll.GetCache("SanPhamNhieuNguoiMua", HttpContext.Current.Cache["SanPhamNhieuNguoiMua"] != null ? "" : SanPhamNhieuNguoiMua());
                ltCamNhanKhachHang.Text = MoreAll.MoreAll.GetCache("CamNhanKhachHang", HttpContext.Current.Cache["CamNhanKhachHang"] != null ? "" : Ad_vertisings.CamNhanKhachHang("8"));
                ltrpNews.Text = MoreAll.MoreAll.GetCache("Newsss", HttpContext.Current.Cache["Newsss"] != null ? "" : Newsss());
            }
        }
        protected string Newsss()
        {
            string str = "";
            List<Entity.News> dt = SNews.Name_Text("select  * from  News where  new=1 and lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                foreach (var item in dt)
                {
                    str += "<article class=\"blog-item text-center\">";
                    str += "<div>";
                    str += "<div class=\"blog-item-thumbnail\">";
                    str += "<a href=\"/" + item.TangName + ".html\" title=\"" + item.Title + "\">" + MoreAll.MoreImage.Image_width_height_Title_Alt(item.ImagesSmall.ToString(), "383", "287", item.Title.ToString(), item.Title.ToString()) + "</a>";
                    str += "</div>";
                    str += "<div class=\"blog-item-info m-4\">";
                    str += " <h3 class=\"blog-item-name\">";
                    str += "<a href=\"/" + item.TangName + ".html\" title=\"" + item.Title + "\">" + MoreAll.MoreNews.Substring_Title(item.Title.ToString()) + "</a>";
                    str += "</h3>";
                    str += " <p class=\"blog-item-summary\">" + MoreAll.MoreNews.Substring_Mota(item.Brief.ToString()) + "</p>";
                    str += " <a class=\"btn\" href=\"/" + item.TangName + ".html\" title=\"" + item.Title + "\">" + label("l_viewdetail") + "</a>";
                    str += " </div>";
                    str += " </div>";
                    str += "  </article>";
                }
            }
            return str.ToString();
        }


        protected string SanPhamMoiTop()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("select top 6 * from  products where  News=1 and lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += Commond.LoadProductList(dt);
            }
            return str.ToString();
        }
        protected string SanPhamHotTop()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("select top 6 * from  products where  Check_01=1 and lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += Commond.LoadProductList(dt);
            }
            return str.ToString();
        }
        protected string SanPhamNoiBatTop()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("select top 6 * from  products where  Check_02=1 and lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += Commond.LoadProductList(dt);
            }
            return str.ToString();
        }
        protected string SanPhamKhuyenMaiTop()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("select top 6 * from  products where  Check_03=1 and lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += Commond.LoadProductList(dt);
            }
            return str.ToString();
        }
        protected string ShowNhomsanpham()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Pages_Home(More.PR, language, "1");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    str += "<section class=\"awe-section-3 \" id=\"awe-section-3\">";
                    str += " <div class=\"section section-collection section-collection-4 section_collection_tab_sidebar pt-5 pb-5\">";
                    str += " <div class=\"container\">";
                    str += " <div class=\"collection-border\">";
                    str += " <div class=\"collection-main\">";
                    str += " <div class=\"row \">";
                    str += " <div class=\"col-lg-12 col-sm-12\">";

                    str += " <div class=\"e-tabs not-dqtab ajax-tab-4\" data-section=\"ajax-tab-4\" data-view=\"owl-1\">";
                    str += " <div class=\"row row-noGutter\">";
                    str += " <div class=\"col-sm-12\">";
                    str += " <div class=\"content row \">";
                    str += " <div class=\"tintuc\">";
                    str += " <div class=\"sectiontitle\">";
                    str += " <h2 class=\"tabnhe\"><a href=\"/" + item.TangName + ".html\">" + item.Name + "</a></h2>";
                    str += " <span class=\"xemtheem\"><a href=\"/" + item.TangName + ".html\">>> Xem thêm </a></span>";
                    str += " </div>";
                    str += " </div>";
                    str += " <div class=\"products products-view-grid\">";
                    List<Entity.Products> table = SProducts.GetTopProductInCategory(MorePro.HomePage(), item.ID.ToString(), More.Sub_Menu(More.PR, item.ID.ToString()));
                    if (table.Count >= 1)
                    {
                        str += Commond.LoadProductList_Home(table);
                    }
                    str += "</div>";
                    str += "</div>";
                    str += " </div>";
                    str += "  </div>";
                    str += " </div>";
                    str += " </div>";

                    str += " </div>";
                    str += " </div>";
                    str += "</div>";
                    str += "</div>";
                    str += "</div>";
                    str += "</section>";
                }
            }
            return str;
        }

        protected string SanPhamMoi()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("SELECT  top 5 * FROM products  where  Lang='" + language + "'  and Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += "<div class=\"area-col\">";
                str += "  <div class=\"aside-title\">";
                str += "    <h2 class=\"title-head\">";
                str += "      <a href=\"#\" title=\"Sản phẩm mới\">Sản phẩm mới</a>";
                str += "    </h2>";
                str += "  </div>";
                str += "  <div class=\"aside-content related-product\">";
                foreach (Entity.Products item in dt)
                {
                    str += "    <div class=\"product-mini-item clearfix  \">";
                    str += "      <div class=\"product-img relative\">";
                    str += "        <a href=\"" + item.TangName + ".html\">";
                    str += "          <img src=\"" + item.ImagesSmall + "\" alt=\"" + item.Name + "\"> </a>";
                    str += "      </div>";
                    str += "      <div class=\"product-info\">";
                    str += "        <h3>";
                    str += "          <a href=\"" + item.TangName + ".html\" title=\"" + item.Name + "\" class=\"product-name\">" + item.Name + "</a>";
                    str += "        </h3>";
                    str += "        <div class=\"price-box\">";
                    str += "          <div class=\"special-price\">";
                    str += "            <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(item.Price) + "</span>";
                    str += "          </div>";
                    str += "        </div>";
                    str += "      </div>";
                    str += "    </div>";
                }
                str += "  </div>";
                str += "</div>";
            }
            return str.ToString();
        }
        protected string SanPhamXemNhieu()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("SELECT  top 5 * FROM products  where  Lang='" + language + "'  and Status=1 order by Views desc");
            if (dt.Count > 0)
            {
                str += "<div class=\"area-col\">";
                str += "  <div class=\"aside-title\">";
                str += "    <h2 class=\"title-head\">";
                str += "      <a href=\"#\" title=\"Sản phẩm xem nhiều\">Sản phẩm xem nhiều</a>";
                str += "    </h2>";
                str += "  </div>";
                str += "  <div class=\"aside-content related-product\">";
                foreach (Entity.Products item in dt)
                {
                    str += "    <div class=\"product-mini-item clearfix  \">";
                    str += "      <div class=\"product-img relative\">";
                    str += "        <a href=\"" + item.TangName + ".html\">";
                    str += "          <img src=\"" + item.ImagesSmall + "\" alt=\"" + item.Name + "\"> </a>";
                    str += "      </div>";
                    str += "      <div class=\"product-info\">";
                    str += "        <h3>";
                    str += "          <a href=\"" + item.TangName + ".html\" title=\"" + item.Name + "\" class=\"product-name\">" + item.Name + "</a>";
                    str += "        </h3>";
                    str += "        <div class=\"price-box\">";
                    str += "          <div class=\"special-price\">";
                    str += "            <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(item.Price) + "</span>";
                    str += "          </div>";
                    str += "        </div>";
                    str += "      </div>";
                    str += "    </div>";
                }
                str += "  </div>";
                str += "</div>";
            }
            return str.ToString();
        }
        protected string SanPhamNhieuNguoiMua()
        {
            string str = "";
            List<Entity.Products> dt = SProducts.Name_Text("SELECT  top 5 * FROM products  where  Lang='" + language + "'  and Check_04=1  and Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                str += "<div class=\"area-col\">";
                str += "  <div class=\"aside-title\">";
                str += "    <h2 class=\"title-head\">";
                str += "      <a href=\"#\" title=\"Sản phẩm mua nhiều\">Sản phẩm mua nhiều</a>";
                str += "    </h2>";
                str += "  </div>";
                str += "  <div class=\"aside-content related-product\">";
                foreach (Entity.Products item in dt)
                {
                    str += "    <div class=\"product-mini-item clearfix  \">";
                    str += "      <div class=\"product-img relative\">";
                    str += "        <a href=\"" + item.TangName + ".html\">";
                    str += "          <img src=\"" + item.ImagesSmall + "\" alt=\"" + item.Name + "\"> </a>";
                    str += "      </div>";
                    str += "      <div class=\"product-info\">";
                    str += "        <h3>";
                    str += "          <a href=\"" + item.TangName + ".html\" title=\"" + item.Name + "\" class=\"product-name\">" + item.Name + "</a>";
                    str += "        </h3>";
                    str += "        <div class=\"price-box\">";
                    str += "          <div class=\"special-price\">";
                    str += "            <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(item.Price) + "</span>";
                    str += "          </div>";
                    str += "        </div>";
                    str += "      </div>";
                    str += "    </div>";
                }
                str += "  </div>";
                str += "</div>";
            }
            return str.ToString();
        }
        protected List<Entity.Products> NewProductInNoibat(string icid)
        {
            return SProducts.Name_Text("select top " + MoreAll.Other.Giatri("txtnoibat") + " * from  products where News=1 and icid in (" + More.Sub_Menu(More.PR, icid) + ") and Status=1 order by Create_Date desc");
        }
        protected List<Entity.Products> NewProductInCate(string icid)
        {
            return SProducts.GetTopProductInCategory(MorePro.HomePage(), icid, More.Sub_Menu(More.PR, icid));
        }
        protected string Showtab(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and news=1 and Lang='" + language + "'  and Parent_ID=" + id + "  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    str += "<li class=\"tab-link \"><a  href=\"/" + item.TangName.ToString() + ".html\"> <span>" + item.Name.ToString() + "</span></a></li>";
                }
            }
            return str.ToString();
        }
        protected string Showtab2(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and news=1 and Lang='" + language + "'  and Parent_ID=" + id + "  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    str += "<li class=\"tab-link tab-title hidden-sm hidden-md hidden-lg current tab-titlexs\"><a  href=\"/" + item.TangName.ToString() + ".html\"> <span>" + item.Name.ToString() + "</span></a></li>";
                }
            }
            return str.ToString();
        }
        protected string ShowDanhsachsanpham(string id)
        {
            List<Entity.Products> dt = SProducts.GetTopProductInCategory(MorePro.HomePage(), id, More.Sub_Menu(More.PR, id));
            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            String str = "";
            String show = "";
            for (int i = 0; i < dt.Count; i++)
            {
                str += "<div class=\"product-box product-box-theme\">";
                str += "        <div class=\"variants margin-bottom-0\" >";
                str += "            <div class=\"product-thumbnail\">";
                str += "                <a href=\"/" + dt[i].TangName + ".html\" title=\"" + dt[i].Name + "\">";
                str += MoreAll.MorePro.Image_Title_Alt(dt[i].ImagesSmall.ToString(), dt[i].Name.ToString(), dt[i].Name.ToString());
                str += "                </a>";
                str += "            </div>";
                str += "            <div class=\"product-info\">";
                str += "                <h3 class=\"product-name\">";
                str += "                    <a href=\"/" + dt[i].TangName + ".html\" title=\"" + dt[i].Name + "\">" + dt[i].Name + "</a>";
                str += "                </h3>";
                str += "                <div class=\"price-box clearfix\">";
                str += "                    <div class=\"special-price\">";
                str += "                        <span class=\"price product-price\">" + MoreAll.MorePro.FormatMoney(dt[i].Price.ToString()) + "</span>";
                str += "                    </div>";
                str += "                </div>";
                str += "                <div class=\"\">";
                str += "                    <a class=\"btn-buy btn-cart btn btn-primary \" href=\"/cms/display/Products/AddToCart.aspx?ipid=" + dt[i].ipid.ToString() + "\" title=\"Đặt hàng\">+ Vào giỏ hàng </a>";
                str += "                </div>";
                str += "            </div>";
                str += "        </div>";
                str += "    </div>";

                if ((i + 1) % 2 == 0)
                {
                    str = "<div class=\"item\">" + str + "</div>";
                    show += str.ToString();
                    str = "";
                }
                else if (i == (dt.Count - 1))
                {
                    str = "<div class=\"item\">" + str + "</div>";
                    show += str.ToString();
                }
            }
            return show;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}