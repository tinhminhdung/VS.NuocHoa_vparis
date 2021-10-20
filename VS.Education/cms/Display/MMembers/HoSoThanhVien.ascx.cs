using Framework;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class HoSoThanhVien : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
                try
                {
                    ShowHoSo();
                }
                catch (Exception)
                { }
            }
        }
        private void ShowHoSo()
        {
            if (MoreAll.MoreAll.GetCookies("MembersID").ToString() != "")
            {
                Member dt = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                if (dt != null)
                {
                    txtname.Text = dt.HoVaTen;
                    txtaddress.Text = dt.DiaChi;
                    // ViewBag.Email = dt.Email;
                    txtphone.Text = dt.DienThoai;
                    txtemail.Text = dt.Email;
                    // ViewBag.NgaySinh = dt.NgaySinh;
                    hdid.Value = dt.ID.ToString();
                    //if (dt.AnhDaiDien.Length > 0)
                    //{
                    //    ViewBag.AnhDaiDiens = dt.AnhDaiDien;
                    //    ViewBag.Avata = " <img src=\"" + dt.AnhDaiDien + "\" style=\" width:100px\" />";
                    //}
                }
            }

        }
        //private void LoadInfo()
        //{
        //    try
        //    {
        //        Fusers item = new Fusers();
        //        DataTable table = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
        //        if (table.Rows.Count > 0)
        //        {
        //            if (table.Rows[0]["vavatar"].ToString().Length < 1)
        //            {
        //                this.ltimg.Text = "<img src='/Uploads/pic/avatar/no_avatar.png' class=admavatarimg>";
        //            }
        //            else
        //            {
        //                this.ltimg.Text = "<img src='/Uploads/pic/avatar/" + table.Rows[0]["vavatar"].ToString() + "' class=admavatarimg>";
        //            }
        //            this.hdimg.Value = table.Rows[0]["vavatar"].ToString();
        //        }
        //    }
        //    catch (Exception) { }
        //}
        protected void btnsave_Click(object sender, EventArgs e)
        {
            DatalinqDataContext db = new DatalinqDataContext();

            //if (this.flavatar.HasFile)
            //{
            //    if ((this.flavatar.PostedFile.ContentLength / 0x400) > 0x400)
            //    {
            //        this.ltmsg.Text = "Cập nhật với dung lượng 1 M";
            //        return;
            //    }
            //    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
            //    string extension = Path.GetExtension(Path.GetFileName(this.flavatar.PostedFile.FileName));
            //    if (this.hdimg.Value.Length > 0)
            //    {
            //        try
            //        {
            //            File.Delete(utlitities.APPL_PHYSICAL_PATH + "/Uploads/pic/avatar/" + this.hdimg.Value);
            //        }
            //        catch (Exception)
            //        {
            //        }
            //    }
            //    string str = DateTime.Now.Ticks.ToString() + extension;
            //    this.hdimg.Value = str;
            //    try
            //    {
            //        this.flavatar.PostedFile.SaveAs(utlitities.APPL_PHYSICAL_PATH + "/Uploads/pic/avatar/" + str);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            //if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
            //{
            //    FMember item = new FMember();
            //    DataTable dts = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
            //    if (dts.Rows.Count > 0)
            //    {
            //        Entity.users obj = new Entity.users();
            //        obj.vuserun = dts.Rows[0]["vuserun"].ToString();
            //        obj.vavatar = this.hdimg.Value;
            //        obj.vavatartitle = "";
            //        Susers.users_update_updateavatar(obj);
            //    }
            //}
            //this.ltmsg.Text = "";

            //user data = db.users.SingleOrDefault(p => p.iuser_id == int.Parse(hdid.Value));
            //data.iuser_id = int.Parse(hdid.Value);
            //data.vuserun = MoreAll.MoreAll.GetCookies("Members").ToString();
            //data.vfname = this.txtname.Text;
            //data.vlname = this.txtname.Text;
            //data.igender = 0;
            //data.dbirthday = Convert.ToDateTime(this.txtbirthday.Text);
            //data.vaddress = this.txtaddress.Text;
            //data.vphone = this.txtphone.Text;
            //data.vavatartitle = "";
            //data.vemail = txtemail.Text;
            //db.SubmitChanges();

            List<Entity.Member> list = SMember.Name_Text("select * from Members  where Email='" + txtemail.Text.Trim().ToLower() + "' and ID!=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            List<Entity.Member> listDienThoai = SMember.Name_Text("select * from Members  where DienThoai='" + txtphone.Text.Trim().ToLower() + "' and ID!=" + MoreAll.MoreAll.GetCookies("MembersID").ToString() + "");
            ServerInfoUtlitities utlitities = new ServerInfoUtlitities();

            if (txtname.Text.Trim().Length < 0)
            {
                ltmsg.Text = "Vui lòng điền đầy đủ họ và tên";
            }
            else if (txtphone.Text.Trim().Length < 0)
            {
                ltmsg.Text = "Vui lòng điền điện thoại";
            }
            else if (MoreAll.RegularExpressions.phone(txtphone.Text.Trim()))
            {
                ltmsg.Text = "Điện thoại không đúng định dạng";
            }
            else if (listDienThoai.Count > 0)
            {
                ltmsg.Text = "Điện thoại đã tồn tại trong hệ thống";
            }
            else if (txtaddress.Text.Trim().Length < 0)
            {
                ltmsg.Text = "Vui lòng điền địa chỉ";
            }
            else if (!MoreAll.RegularExpressions.IsValidEmail(txtemail.Text.Trim()))
            {
                ltmsg.Text = "Email không đúng định dạng";
            }
            else if (txtemail.Text.Trim().Length < 0)
            {
                ltmsg.Text = "Vui lòng điền email";
            }
            else if (list.Count > 0)
            {
                ltmsg.Text = "Email đã tồn tại trong hệ thống";
            }
            else
            {
                Member obj = db.Members.SingleOrDefault(p => p.ID == int.Parse(MoreAll.MoreAll.GetCookies("MembersID").ToString()));
                obj.HoVaTen = txtname.Text;
                obj.GioiTinh = 0;
                obj.NgaySinh = "";
                obj.DiaChi = txtaddress.Text;
                obj.DienThoai = txtphone.Text;
                obj.Email = txtemail.Text;
                //if (_FileName.Length > 0)
                //{
                //    obj.AnhDaiDien = "/Uploads/avatar/" + _FileName;
                //}
                obj.Lang = language;
                db.SubmitChanges();
                ltmsg.Text = "Thông tin đã được thay đổi";
                ShowHoSo();
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}