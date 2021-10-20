using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.MMembers
{
    public partial class Register : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        private static Random random = new Random();
        string info = "0";
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
            if (Request["info"] != null && !Request["info"].Equals(""))
            {
                info = Request["info"];
            }
            if (!base.IsPostBack)
            {
                SetCapCha();
                try
                {
                    if (info != "")// trường hợp có coupon và không có link ?aff
                    {
                        List<Entity.Member> iEmail = SMember.Name_Text("select * from Members  where DienThoai='" + info + "' and TrangThai=1");//and iuser_id !=" + MoreAll.MoreAll.GetCookies("MembersID") + " 
                        if (iEmail.Count > 0)
                        {
                            txtnguoigioithieu.Text = iEmail[0].DienThoai.ToString();
                            ltgoithieu.Text = "Người giới thiệu: " + iEmail[0].HoVaTen.ToString();
                            txtnguoigioithieu.Style.Add("pointer-events", "none");
                            txtnguoigioithieu.Style.Add("opacity", "0.6");
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.txtemail.Text = "";
            this.txtHoVaTen.Text = "";
            this.txt_add.Text = "";
            this.txt_phone.Text = "";
            this.ltmsg.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Nhap = txtcapcha.Text.Trim();
            if (Session["RandomCapCha"].ToString() != Nhap)
            {
                ltmsg.Text = "Mã bảo vệ chưa chính xác";
            }
            else
            {
                List<Entity.Member> list = SMember.Name_Text("select * from Members  where Email='" + txtemail.Text.Trim().ToLower() + "'");
                List<Entity.Member> listDienThoai = SMember.Name_Text("select * from Members  where DienThoai='" + txt_phone.Text.Trim().ToLower() + "'");
                if (MoreAll.RegularExpressions.phone(txt_phone.Text.Trim().ToLower()))
                {
                    this.ltmsg.Text = "Điện thoại không đúng định dạng";
                }

                else if (listDienThoai.Count > 0)
                {
                    this.ltmsg.Text = "Điện thoại đã tồn tại trong hệ thống";
                }
                else if (list.Count > 0)
                {
                    this.ltmsg.Text = "Email đã tồn tại trong hệ thống";
                }
                else
                {
                    //System.Threading.Thread.Sleep(1000);
                    //#region Senmail
                    //if (!Commond.Setting("Emailden").Equals(""))
                    //    Senmail(txtHoTen, txtaddress, txtphone, txtemail, txttieude, txtcontent);
                    //#endregion

                    string Nguoigioithieu = "0";
                    string VTree = "0";
                    if (txtnguoigioithieu.Text.Trim().Length > 0)
                    {
                        if (txtemail.Text.Trim() != txtnguoigioithieu.Text.Trim() || txt_phone.Text.Trim() != txtnguoigioithieu.Text.Trim())
                        {
                            List<Entity.Member> iEmail = SMember.Name_Text("select * from Members  where DienThoai='" + txtnguoigioithieu.Text.Trim().ToLower() + "'");// and DuyetTienDanap=1/  //and iuser_id !=" + MoreAll.MoreAll.GetCookies("MembersID") + " 
                            if (iEmail.Count > 0)
                            {
                                Nguoigioithieu = iEmail[0].ID.ToString();
                                VTree = iEmail[0].MTRee.ToString();
                            }
                            else
                            {
                                this.ltmsg.Text = " Người giới thiệu không tồn tại hoặc chưa được kích hoạt trong hệ thống.";
                                return;
                            }
                        }
                    }
                    String mtree = "|0|";
                    if (Nguoigioithieu != "0")
                    {
                        mtree = VTree;
                    }
                    String mtrees = mtree;

                    string validatekey = DateTime.Now.Ticks.ToString();
                    Member obj = new Member();
                    obj.PasWord = txtpassword.Text;
                    obj.HoVaTen = txtHoVaTen.Text;
                    obj.GioiTinh = 0;
                    obj.NgaySinh = DateTime.Now.ToString("dd/MM/yyyy");
                    obj.DiaChi = txt_add.Text;
                    obj.DienThoai = txt_phone.Text;
                    obj.Email = txtemail.Text;
                    obj.AnhDaiDien = "";
                    obj.NgayTao = DateTime.Now;
                    obj.Key = validatekey;
                    obj.TrangThai = 1;
                    obj.Lang = language;
                    if (Nguoigioithieu == "0")
                    {
                        obj.MTRee = "|0|";
                    }
                    else
                    {
                        obj.MTRee = mtrees.Replace("|0|", "|");
                    }
                    obj.GioiThieu = int.Parse(Nguoigioithieu);
                    obj.TienHoaHong = "0";
                    obj.SoNguPhan = 6;
                    obj.TrangThaiMuaHang = 0;
                    obj.TongTrucTiep = 0;
                    obj.TongTienDaRut = "0";
                    obj.TrangThaiMuaHangDatTongTien = 0;
                    obj.CapBac = int.Parse("0");
                    obj.CoPhan = "0";
                    obj.TongTienDaMuaHang = "0";
                    obj.F1MuaHangDeTinhThuong = 0;
                    obj.TrangThaiF1MuaHang = 0;
                    obj.ViVip = "0";
                    obj.ViVipDaMuaHang = "0";
                    obj.ViCoPhanSo = "0";
                    obj.F1MuaHangThuongSoCoPhan = 0;
                    obj.TrangThaiF1MuaHangSoCoPhan = 0;
                    db.Members.InsertOnSubmit(obj);
                    db.SubmitChanges();

                    List<Entity.Member> Them = SMember.Name_Text("select top 1 * from Members order by ID desc");
                    if (Them.Count > 0)
                    {
                        string Cay = mtrees.Replace("|0|", "|") + Them[0].ID.ToString() + "|";
                        SMember.Name_Text("UPDATE [Members] SET MTRee='" + Cay + "' WHERE ID =" + Them[0].ID.ToString() + "");
                    }
                    // this.ltmsg.Text = "Đăng ký tài khoản thành công";
                    MultiView1.ActiveViewIndex = 1;
                    SetCapCha();
                    //  WebMsgBox.Show("Cập nhật thành công.");
                }
            }
        }
        public void SetCapCha()
        {
            string hash = RandomString(6);
            ltshowcapcha.Text = hash;
            Session["RandomCapCha"] = hash;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdsfghjklqwertyuiopzxcvbnm0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected bool checkspace(string text)
        {
            string[] arrtxt = text.Split(' ');
            if (arrtxt.Count() > 1)
            {
                return true;
            }
            return false;
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;
            return input.Any(c => c > MaxAnsiCode);
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}