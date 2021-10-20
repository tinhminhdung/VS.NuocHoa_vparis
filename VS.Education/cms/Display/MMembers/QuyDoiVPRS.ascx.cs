using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class QuyDoiVPRS : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MoreAll.MoreAll.GetCookies("Members") != "")
            {
                Member table = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (table != null)
                {
                    if (table.TienHoaHong.ToString() == "0")
                    {
                        ltTongtien.Text = "0";
                        hdtongtien.Value = "0";
                    }
                    else
                    {
                        ltTongtien.Text = MoreAll.MorePro.Detail_Price(table.TienHoaHong.ToString());
                        hdtongtien.Value = table.TienHoaHong;
                    }

                    if (table.CoPhan.ToString() == "0")
                    {
                        ltCoPhan.Text = "0";
                        hdtongcophan.Value = "0";
                    }
                    else
                    {
                        ltCoPhan.Text = table.CoPhan;
                        hdtongcophan.Value = table.CoPhan;

                    }
                }
            }
        }

        protected void btQuyDoiTien_Click(object sender, EventArgs e)
        {
            double TongTienNapVao = Convert.ToDouble(TongTienQuyDoi.Text);
            double CoPhanSSS = Convert.ToDouble(hdtongtien.Value);
            if (TongTienNapVao > CoPhanSSS)
            {
                Response.Write("<script type=\"text/javascript\">alert('Số tiền quy đổi không đủ. vui lòng kiểm tra lại');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
            }
            LichSuQuyDoiSoCoPhan obj = new LichSuQuyDoiSoCoPhan();
            obj.IDThanhVien = int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString());
            obj.SoTien = TongTienQuyDoi.Text;
            obj.NgayCap = DateTime.Now;
            obj.MoTa = "Quy đổi ví tiền sang VPR-S";
            obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
            obj.TrangThai = 1;
            obj.KieuVi = 1;
            db.LichSuQuyDoiSoCoPhans.InsertOnSubmit(obj);
            db.SubmitChanges();

            // trừ ví tiền 
            // chia cho số tiền trong cấu hình và lưu vào ViCoPhanSo 
            Double CauHinh = Convert.ToDouble(Commond.Setting("SoDuVPRS"));
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].TienHoaHong);
                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) - (TongTienNapVao));
                SMember.Name_Text("update Members set TienHoaHong=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");


                double ViCoPhanSo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                double Chialai = TongTienNapVao / CauHinh;
                double ConglaiViCP = ((ViCoPhanSo) + (Chialai));
                SMember.Name_Text("update Members set ViCoPhanSo=" + ConglaiViCP.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }

            Response.Write("<script type=\"text/javascript\">alert('QUY ĐỔI TỪ VÍ TIỀN SANG VPR-S THÀNH CÔNG');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
        }

        protected void btQuyDoiCoPhan_Click(object sender, EventArgs e)
        {

            double TongTienNapVao = Convert.ToDouble(TongCoPhan.Text);
            double CoPhanSSS = Convert.ToDouble(hdtongcophan.Value);
            if (TongTienNapVao > CoPhanSSS)
            {
                Response.Write("<script type=\"text/javascript\">alert('Số cổ phần quy đổi không đủ. vui lòng kiểm tra lại');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
            }
            LichSuQuyDoiSoCoPhan obj = new LichSuQuyDoiSoCoPhan();
            obj.IDThanhVien = int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString());
            obj.SoTien = TongCoPhan.Text;
            obj.NgayCap = DateTime.Now;
            obj.MoTa = "Quy đổi Số Cổ phần sang VPR-S";
            obj.NguoiTao = MoreAll.MoreAll.GetCookies("UName").ToString();
            obj.TrangThai = 1;
            obj.KieuVi = 2;
            db.LichSuQuyDoiSoCoPhans.InsertOnSubmit(obj);
            db.SubmitChanges();

            // trừ ví tiền 
            // chia cho số tiền trong cấu hình và lưu vào ViCoPhanSo 
            Double CauHinh = Convert.ToDouble(Commond.Setting("SoCoPhanVPRS"));
            List<Entity.Member> iitem = SMember.Name_Text("select * from Members where ID=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            if (iitem.Count > 0)
            {
                double TongSoCoinDaCo = Convert.ToDouble(iitem[0].CoPhan);

                double Conglai = 0;
                Conglai = ((TongSoCoinDaCo) - (TongTienNapVao));
                SMember.Name_Text("update Members set CoPhan=" + Conglai.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");


                double ViCoPhanSo = Convert.ToDouble(iitem[0].ViCoPhanSo);
                double Chialai = TongTienNapVao * CauHinh;
                double ConglaiViCP = ((ViCoPhanSo) + (Chialai));
                SMember.Name_Text("update Members set ViCoPhanSo=" + ConglaiViCP.ToString() + "  where ID=" + iitem[0].ID.ToString() + "");
            }
            Response.Write("<script type=\"text/javascript\">alert('QUY ĐỔI TỪ CỔ PHẦN SANG VPR-S THÀNH CÔNG');window.location.href='" + Request.RawUrl.ToString() + "'; </script>");
        }
    }
}