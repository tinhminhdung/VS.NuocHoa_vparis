using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class LichSuCapDiem : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            { }
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                ShowInfo();
            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                LoadItems();
            }
            else
            {
                Response.Redirect("/dang-nhap.html?ReturnUrl=" + Request.RawUrl.ToString() + "");
            }
        }
        private void ShowInfo()
        {
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    hdid.Value = table.ID.ToString();
                }
            }
        }
        private void LoadItems()
        {
            if (hdid.Value.Count() > 0)
            {
                List<CapDiemThanhVien> table = db.CapDiemThanhViens.Where(s => s.IDNguoiNhan == int.Parse(hdid.Value) && s.CongTRu == 1).OrderByDescending(x => x.ID).ToList();
                if (table.Count > 0)
                {
                    double coin = 0.0;
                    try
                    {
                        for (int i = 0; i < table.Count; i++)
                        {
                            coin += Convert.ToDouble(table[i].SoTien.ToString());
                        }
                    }
                    catch (Exception)
                    { }
                    ltCoin.Text = "Tổng tiền: " + MoreAll.MorePro.FormatMoney_VND(coin.ToString());

                    CollectionPager1.DataSource = table;
                    CollectionPager1.BindToControl = rp_pagelist;
                    CollectionPager1.MaxPages = 10000;
                    CollectionPager1.PageSize = int.Parse("50");
                    rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
                    rp_pagelist.DataBind();
                }
            }
        }
        protected string ShowtThanhVien(string id, string NguoiTao)
        {
            string str = "";
            if (id.ToString() == "0")
            {
                return "Admin - " + NguoiTao;
            }
            if (id.ToString() == "1")
            {
                return "Auto - " + NguoiTao;
            }
            List<Entity.Member> dt = SMember.GET_BY_ID(id);
            if (dt.Count >= 1)
            {
                str += "<span id=" + dt[0].ID.ToString() + " style=\" color:red\">";
                if (dt[0].HoVaTen.ToString().Length > 0)
                {
                    str += dt[0].HoVaTen;
                }
                str += "</span> ";
                if (dt[0].DienThoai.ToString().Length > 0)
                {
                    str += dt[0].DienThoai;
                }
            }
            return str;
        }
    }
}