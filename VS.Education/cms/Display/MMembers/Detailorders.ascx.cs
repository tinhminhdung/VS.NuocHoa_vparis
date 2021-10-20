using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class Detailorders : System.Web.UI.UserControl
    {
        public int i = 1;
        DatalinqDataContext db = new DatalinqDataContext();
        string ID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (Request["ID"] != null && !Request["ID"].Equals(""))
                {
                    ID = Request["ID"];
                }
            }
            ShowInfo();
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                ShowProducts();
            }
            else
            {
                Response.Redirect("/dang-nhap.html");
            }
        }
        private void ShowInfo()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    hdid.Value = table.ID.ToString();
                }
            }
        }
        private void ShowProducts()
        {
            string sql = "select * from Carts where IDThanhVien=" + hdid.Value + " and ID=" + ID + "";
            List<LCart> dt = db.ExecuteQuery<LCart>(@"" + sql + "").ToList();
            if (dt != null)
            {
                try
                {
                    ltmadonhang.Text = dt[0].ID.ToString();
                    ltngaydathang.Text = dt[0].Create_Date.ToString();
                    lttrangthai.Text = ShowTrangThai(dt[0].Status.ToString());
                    lthovaten.Text = dt[0].Name.ToString();
                    ltdiachi.Text = dt[0].Address.ToString();
                    ltdienthoai.Text = dt[0].Phone.ToString();
                    lttongtien.Text = MoreAll.MorePro.Detail_Price(dt[0].Money.ToString());
                    lttongtienbangchu.Text = MoreAll.Hamdoisorachu.So_chu(Convert.ToDouble(dt[0].Money.ToString()));

                    List<Entity.CartDetail> table = SCartDetail.Detail_ID_Cart(dt[0].ID.ToString());
                    this.rpcartdetail.DataSource = table;
                    this.rpcartdetail.DataBind();
                }
                catch (Exception)
                { }
            }
        }
        public string ShowTrangThai(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "Đơn hàng đã thanh toán";
            }
            else if (enable.Trim().Equals("1"))
            {
                return "Đơn hàng đã duyệt";
            }
            else if (enable.Trim().Equals("2"))
            {
                return "Đơn hàng đang chờ xử lý";
            }
            else if (enable.Trim().Equals("3"))
            {
                return "Đơn hàng đang vận chuyển";
            }
            return "";
        }
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

    }
}