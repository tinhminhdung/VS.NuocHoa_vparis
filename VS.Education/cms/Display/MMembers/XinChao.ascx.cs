using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class XinChao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MoreAll.MoreAll.GetCookies("Members").ToString() != "")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                //  ltstyle.Text = "<style>.ViewThanhVien{ display:block}</style>";

                List<Entity.Member> table = SMember.Name_Text("select * from Members where ID=" + MoreAll.MoreAll.GetCookies("MembersID") + " and TrangThai=1 ");
                if (table.Count > 0)
                {
                    this.ltwelcome.Text = this.ltwelcome.Text = table[0].HoVaTen;
                    CapBac.NangCapbac(table[0].ID.ToString());
                    //if (table[0].vavatar.Length > 0)
                    //{
                    //    // ltlavata2.Text = 
                    //    ltimg.Text = " <img class=\"user-avatar-medium Aavatar\" src=\"/Uploads/avatar//" + table[0].vavatar.ToString() + "\">";
                    //}
                    //else
                    //{
                    //    //  ltlavata2.Text = 
                    //    ltimg.Text = " <img class=\"user-avatar-medium\" src=\"/Resources/assets/user-icon0596.png\">";
                    //}
                }
            }
            else
            {
                //  ltcssstyle.Text = "<style>.giacuahang{ display:none!important}.AnGiathanhvienfree_daily{ display:block !important}</style>";
                // ltstyle.Text = "<style>.ViewThanhVien{ display:none}</style>";
                this.ltwelcome.Text = "";
                //  ltxinchao.Text = "";
                //ltlavata2.Text =
                // ltimg.Text = " <img class=\"user-avatar-medium\" src=\"/Resources/assets/user-icon0596.png\">";
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Members", "", -1);
            MoreAll.MoreAll.SetCookie("MembersID", "", -1);
            Response.Redirect("/");
        }

        protected void lnkdangxuat_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Members", "", -1);
            MoreAll.MoreAll.SetCookie("MembersID", "", -1);
            Response.Redirect("/");
        }
    }
}