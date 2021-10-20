using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Admin.MMember
{
    public partial class AMembers : System.Web.UI.UserControl
    {
        private string status = "-1";
        private string IDThanhVien = "0";
        DatalinqDataContext db = new DatalinqDataContext();
        private string lang = Captionlanguage.Language;
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
            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                status = Request["st"];
            }
            if (!base.IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                }
                if (Request["us"] != null && !Request["us"].Equals(""))
                {
                    ddlorderby.SelectedValue = Request["us"];
                }
                if (Request["ds"] != null && !Request["ds"].Equals(""))
                {
                    ddlordertype.SelectedValue = Request["ds"];
                }
                //if (Request["kw"] != null && !Request["kw"].Equals(""))
                //{
                //    txtkeyword.Text = Request["kw"];
                //    Session["keyword"] = txtkeyword.Text;
                //}
                //else
                //{
                //    Session["keyword"] = "";
                //}
                if (Request["IDThanhVien"] != null && !Request["IDThanhVien"].Equals(""))
                {
                    IDThanhVien = Request["IDThanhVien"];
                }
                if (Request["sao"] != null && !Request["sao"].Equals(""))
                {
                    ddlcapdo.SelectedValue = Request["sao"];
                }
                if (Request["mua"] != null && !Request["mua"].Equals(""))
                {
                    ddlMuaHang.SelectedValue = Request["mua"];
                }
                else
                {
                    Session["keyword"] = "";
                }
                if (Session["keyword"] != null && !Session["keyword"].Equals(""))
                {
                    txtkeyword.Text = Session["keyword"].ToString();
                }

                this.ddlstatus.Items.Add(new ListItem("Tất cả các mục", "-1"));
                this.ddlstatus.Items.Add(new ListItem("Kích hoạt", "1"));
                this.ddlstatus.Items.Add(new ListItem("Chưa kích hoạt", "0"));
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
                this.LoadItems();
            }
        }
        protected void btndisplay_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            if (txtkeyword.Text.Length > 0)
            {
                Session["keyword"] = txtkeyword.Text;
            }
            else
            {
                Session["keyword"] = "";
            }
            LoadItems();
            LoadRequest();
        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn x\x00f3a th\x00e0nh vi\x00ean n\x00e0y?')";
        }
        protected bool EnableLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecUnLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecLock(string status)
        {
            return status.Equals("2");
        }
        protected bool EnableUnLock(string status)
        {
            return status.Equals("0");
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        public void LoadItems()
        {
            int Tongsobanghi = 0;
            Int16 pages = 1;
            int Tongsotrang = int.Parse("30");
            if ((Request.QueryString["page"] != null) && (Request.QueryString["page"] != ""))
            {
                pages = Convert.ToInt16(Request.QueryString["page"].Trim());
            }
            List<Entity.Member> iitem = SMember.CATEGORY_PHANTRANG1(ddlMuaHang.SelectedValue, ddlcapdo.SelectedValue, IDThanhVien, txtkeyword.Text.Replace("&nbsp;", ""), ddlstatus.SelectedValue);
            if (iitem.Count() > 0)
            {
                lttong.Text = iitem.Count().ToString();
                Tongsobanghi = iitem.Count();
                //foreach (var itemd in iitem)
                //{
                //    CapBac.NangCapbac(itemd.ID.ToString());
                //}
            }
            List<Entity.Member> dt = SMember.CATEGORY_PHANTRANG2(ddlMuaHang.SelectedValue, ddlcapdo.SelectedValue, IDThanhVien, txtkeyword.Text.Replace("&nbsp;", ""), ddlstatus.SelectedValue, (pages - 1), Tongsotrang);
            if (dt.Count >= 1)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            if (Tongsobanghi % Tongsotrang > 0)
            {
                Tongsobanghi = (Tongsobanghi / Tongsotrang) + 1;
            }
            else
            {
                Tongsobanghi = Tongsobanghi / Tongsotrang;
            }
            ltpage.Text = Commond.PhantrangAdmin("/admin.aspx?u=Thanhvien&mua=" + ddlMuaHang.SelectedValue + "&sao=" + ddlcapdo.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "", Tongsobanghi, pages);
        }
        protected void Lock_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn kh\x00f3a t\x00e0i khoản n\x00e0y?')";
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    SMember.DELETE(e.CommandArgument.ToString().Trim());
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "lock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "0");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "unlock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "1");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;

            }
        }
        protected string Status(string status)
        {
            if (status.Equals("1"))
            {
                return "Đang hoạt động";
            }
            return "Đ\x00e3 kh\x00f3a";
        }
        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected string Enablechon(string chon)
        {
            if (chon.Equals("1"))
            {
                return "Thành viên";
            }
            return "Nội bộ";
        }
        private void UpdateStatus(string un, string status)
        {
            SMember.UPDATE_STATUS(un, status);
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Thanhvien&mua=" + ddlMuaHang.SelectedValue + "&sao=" + ddlcapdo.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "");
        }
        protected void ddlLevelThanhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlLevelThanhVien = (DropDownList)sender;
            var id = (HiddenField)ddlLevelThanhVien.FindControl("hiID");
            List<Entity.Member> list = SMember.Name_Text("select * from Members where ID=" + id.Value + "  ");
            if (list.Count > 0)
            {
                SMember.Name_Text("update Members set CapBac =" + ddlLevelThanhVien.SelectedValue + " where ID=" + id.Value + "");
                ltthongbao.Text = "<script type=\"text/javascript\">alert('Cập nhật cấp bậc thành công, Cho Thành Viên: (" + list[0].HoVaTen + ").');window.location.href='/admin.aspx?u=Thanhvien&mua=" + ddlMuaHang.SelectedValue + "&sao=" + ddlcapdo.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "'; </script></div>";
            }
        }
        protected void rp_items_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                DropDownList ddlLevelThanhVien = (DropDownList)Repeater1.Items[i].FindControl("ddlLevelThanhVien");
                HiddenField id = (HiddenField)Repeater1.Items[i].FindControl("hdCapBac");
                if (id.Value != "0")
                {
                    ddlLevelThanhVien.SelectedValue = id.Value;
                }
            }
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)Repeater1.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SMember.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception)
            {

            }
        }
        protected void txtCoPhan_TextChanged(object sender, EventArgs e)
        {
            TextBox CoPhan = (TextBox)sender;
            var b = (HiddenField)CoPhan.FindControl("hiID");
            SMember.Name_Text("UPDATE [Members] SET CoPhan='" + CoPhan.Text + "' WHERE ID=" + b.Value + " ");
            this.ltthongbao.Text = "<span class=alert>Cập nhật số cổ phần thành công.</span>";
        }
        protected void ddlcapdo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }

        protected void ddlMuaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        public static string TongThanhVienBenDuoi(string ID)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            string chuoitong = "";
            try
            {
                var tongthanhvien = db.TongThanhVienBenDuoi(int.Parse(ID.ToString())).ToList();
                if (tongthanhvien.Count > 0)
                {
                    chuoitong = tongthanhvien[0].COUNT.ToString();
                }
                else
                {
                    chuoitong = "0";
                }
            }
            catch (Exception)
            { }

            string chuoi2 = "";
            try
            {
                var tongthanhvien = db.TongThanhVienBenDuoi_kichhoat(int.Parse(ID.ToString())).ToList();
                if (tongthanhvien.Count > 0)
                {
                    chuoi2 = tongthanhvien[0].COUNT.ToString();
                }
                else
                {
                    chuoi2 = "0";
                }
            }
            catch (Exception)
            { }
            return chuoi2 + "/" + chuoitong;

        }

       
    }
}