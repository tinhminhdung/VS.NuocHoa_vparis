using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class LichSuDatHang : System.Web.UI.UserControl
    {
        private string status = "1";
        public int i = 1;
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btnshow.UniqueID;
            if (!base.IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
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
            string sql = "select * from Carts where IDThanhVien=" + hdid.Value + "";
            if (!ddlstatus.SelectedValue.Equals("-1"))
            {
                sql = sql + " and  Status=" + ddlstatus.SelectedValue + " ";
            }
            //if (txtkeyword.Text.Length > 0)
            //{
            //    sql = sql + " and  Name LIKE N'" + Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text) + "' OR Address LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Phone LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Email LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "' OR Money LIKE N'" + Framwork.FCarts.SearchApproximate.Exec(Framwork.FCarts.ConvertVN.Convert(txtkeyword.Text)) + "'";
            //}
            sql = sql + " order by Create_Date desc";
            List<LCart> dt = db.ExecuteQuery<LCart>(@"" + sql + "").ToList();
            CollectionPager1.DataSource = dt;
            CollectionPager1.BindToControl = rp_items;
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = 30;
            rp_items.DataSource = CollectionPager1.DataSourcePaged;
            rp_items.DataBind();

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

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProducts();
            Response.Redirect("/lich-su-mua-hang.html?st=" + ddlstatus.SelectedValue + "");
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            this.ShowProducts();
        }

    }
}