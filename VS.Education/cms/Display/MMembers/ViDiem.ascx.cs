using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class ViDiem : System.Web.UI.UserControl
    {
        string ssl = "http://";
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
        private void ShowInfo()
        {
            if (Commond.Setting("SSL").Equals("1"))
            {
                ssl = "https://";
            }

            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    if (table.TienHoaHong.ToString() == "0")
                    {
                        lttongtien.Text = "0";
                    }
                    else
                    {
                        lttongtien.Text = MoreAll.MorePro.Detail_Price(table.TienHoaHong.ToString());
                    }

                    if (table.TongTienDaRut.ToString() == "0")
                    {
                        lttongtiendarut.Text = "0";
                    }
                    else
                    {
                        lttongtiendarut.Text = MoreAll.MorePro.Detail_Price(table.TongTienDaRut.ToString());
                    }

                    //  ltttongF1.Text = table.TongTrucTiep.ToString();
                    List<Entity.Member> dtde = SMember.Name_Text("select  * from Members  where GioiThieu=" + table.ID.ToString() + " and TrangThaiMuaHang=1");
                    if (dtde.Count > 0)
                    {
                        ltttongF1.Text = dtde.Count.ToString();
                    }
                    else
                    {
                        ltttongF1.Text = "0";
                    }
                    List<Entity.Member> dtde3 = SMember.Name_Text("select  * from Members  where GioiThieu=" + table.ID.ToString() + " and TrangThaiMuaHang=0");
                    if (dtde3.Count > 0)
                    {
                        ltttongF11.Text = dtde3.Count.ToString();
                    }
                    else
                    {
                        ltttongF11.Text = "0";
                    }


                    string chuoitong = "";
                    try
                    {
                        var tongthanhvien = db.TongThanhVienBenDuoi(int.Parse(table.ID.ToString())).ToList();
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
                        var tongthanhvien = db.TongThanhVienBenDuoi_kichhoat(int.Parse(table.ID.ToString())).ToList();
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
                    lttongthanhvien.Text = chuoi2 + "/" + chuoitong;

                    #region CapBac
                    if (table.CapBac.ToString() == "0")
                    {
                        ltcapbac.Text = "Thành viên";
                    }
                    if (table.CapBac.ToString() == "1")
                    {
                        ltcapbac.Text = "Trưởng nhóm KD";
                    }
                    if (table.CapBac.ToString() == "2")
                    {
                        ltcapbac.Text = "Trưởng phòng KD";
                    }
                    if (table.CapBac.ToString() == "3")
                    {
                        ltcapbac.Text = "Giám đốc KD";
                    }
                    if (table.CapBac.ToString() == "4")
                    {
                        ltcapbac.Text = "Giám đốc KD cấp cao";
                    }
                    #endregion

                    ltcophan.Text = table.CoPhan;


                    if (table.ViVip.ToString() == "0")
                    {
                        ltvivip.Text = "0";
                    }
                    else
                    {
                        ltvivip.Text = MoreAll.MorePro.Detail_Price(table.ViVip.ToString());
                    }

                    ltViCoPhanSo.Text = table.ViCoPhanSo;
                    if (table.TrangThai == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Bạn không thể sử dụng tính năng này. Yêu cầu kích hoạt tài khoản thành viên.');window.location.href='/vi-tien.html'; </script>");
                    }
                    // hdid.Value = table.iuser_id.ToString();
                    txtlinkgioithieu.Text = ssl + Request.Url.Host + "?link=" + table.DienThoai.ToString() + "";
                    // ltshare.Text = "<div class=\"zalo-share-button\" data-href=\"https://" + Request.Url.Host + "?link=" + table.ID.ToString() + "\"  data-oaid=\"3853758560685742933\" data-layout=\"1\" data-color=\"blue\" data-customize=false></div>";
                }
            }
        }
    }
}