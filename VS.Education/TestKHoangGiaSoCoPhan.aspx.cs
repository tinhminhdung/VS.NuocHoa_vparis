using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce
{
    public partial class TestKHoangGiaSoCoPhan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Literal1.Text = "";
            Double TongTienDatHang = Convert.ToDouble(TextBox1.Text);
            List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.KG, "VIE", "-1");
            foreach (var item in table)
            {
                Double Tu = Convert.ToDouble(item.Link);
                Double Den = Convert.ToDouble(item.Styleshow);
                string CoPhan = item.Description;
                if (TongTienDatHang >= Tu && TongTienDatHang < Den)
                {
                    Literal1.Text = CoPhan;
                }
            }
        }
    }
}