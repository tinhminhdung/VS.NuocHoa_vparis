﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.IO;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Admin.Products
{
    public partial class Manufacturer : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (!base.IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btDeleteimages);
                #endregion
                this.UpdateList();
            }
            
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            this.hd_id.Value = this.hd_par_id.Value;
            this.UpdateList();
        }

        protected void btn_Homepage_Click(object sender, EventArgs e)
        {
            this.hd_par_id.Value = "-1";
            this.hd_id.Value = "-1";
            this.UpdateList();
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            // try
            //{
            if (this.txt_title.Text.Trim().Length < 1)
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
            }
            else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
            }
            else
            {
                string sgrnlevel = hidLevel.Value;
                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                #region image
                int vkey = 1;
                string vimg = this.txtvimg.Text;
                string path = "";
                if (this.rdFromComputer.Checked)
                {
                    if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                    {
                        path = Path.GetFileName(this.flimage.PostedFile.FileName);
                        string str6 = "";
                        str6 = Path.GetExtension(path).ToLower();
                        vimg = "/Uploads/pic/prods/" + DateTime.Now.Ticks.ToString() + str6;
                        flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
                    }
                    else
                    {
                        if ((this.txtvimg.Text.Trim().Length > 0))
                        {
                            vimg = this.hdFileName.Value;
                        }
                    }
                    vkey = 0;
                }
                #endregion
                Entity.Menu obj = new Entity.Menu();
                string str5 = this.hd_insertupdate.Value.Trim();
                if (str5 != null)
                {
                    if (!(str5 == "update"))
                    {
                        if (str5 == "insert")
                        {
                            #region Menu
                            string TangName = "";
                            int cong = 0;
                            List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                            int tong = int.Parse(curItem[0].ID.ToString());
                            cong = tong + 1;
                            var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault();
                            TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);
                            #endregion
                            #region MyRegion

                            obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                            obj.capp = More.HA;
                            obj.Type = 0;
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURLNew.NameToTag(this.txt_title.Text.Trim());
                            obj.Link = "";
                            obj.Styleshow = "";
                            obj.Equals = Convert.ToInt16(vkey);
                            obj.Images = vimg;
                            obj.Description = txtcontent.Text;
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 0;
                            obj.Orders = Convert.ToInt16(txt_order.Text);
                            if (sgrnlevel.Length > 0)
                            {
                                obj.Level = sgrnlevel + "00000";
                            }
                            else
                            {
                                obj.Level = "00000";
                            }
                            obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                            obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                            obj.Titleseo = txttitleseo.Text;
                            obj.Meta = txtmeta.Text;
                            obj.Keyword = txtKeyword.Text;
                            obj.Check_01 = 0;
                            obj.Check_02 = 0;
                            obj.Check_03 = 0;
                            obj.Check_04 = 0;
                            obj.Check_05 = 0;
                            obj.Noidung1 = "";
                            obj.Noidung2 = "";
                            obj.Noidung3 = "";
                            obj.Noidung4 = "";
                            obj.Noidung5 = "";
                            obj.Module = 23;
                            obj.TangName = TangName;
                            #endregion
                            SMenu.Insert(obj);
                        }
                    }
                    else
                    {
                        #region Delete
                        if (vimg.Equals(""))
                        {
                            vimg = this.hdFileName.Value;
                        }
                        else
                        {
                            try
                            {
                                if ((this.txtvimg.Text.Trim().Length > 0))
                                {
                                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/news/" + this.hdFileName.Value);
                                }
                                if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                                {
                                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/news/" + this.hdFileName.Value);
                                }
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        #region UpdateMenu
                        string TagName = "";
                        List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                        if (item.Count > 0)
                        {
                            Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                            obk.Name = txt_title.Text;
                            obk.Module = 23;
                            List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                            if (list.Count > 2)
                            {
                                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                            }
                            else
                            {
                                if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                            }
                            obk.TangName = TagName;
                            db.SubmitChanges();
                        }

                        #endregion
                        #region MyRegion
                        obj.ID = Convert.ToInt16(hd_page_edit_id.Value);
                        obj.Parent_ID = Convert.ToInt16(this.hd_id.Value.Trim());
                        obj.capp = More.HA;
                        obj.Type = 0;
                        obj.Lang = lang;
                        obj.Name = txt_title.Text.Trim();
                        obj.Url_Name = RewriteURLNew.NameToTag(this.txt_title.Text.Trim());
                        obj.Link = "";
                        obj.Styleshow = "";
                        obj.Equals = Convert.ToInt16(vkey);
                        obj.Images = vimg;
                        obj.Description = txtcontent.Text;
                        obj.Create_Date = DateTime.Now;
                        obj.Views = 0;
                        obj.ShowID = 0;
                        obj.Orders = Convert.ToInt16(txt_order.Text);
                        obj.Level = sgrnlevel + "00000";
                        obj.News = Convert.ToInt16(chknews.Checked ? "1" : "0");
                        obj.page_Home = Convert.ToInt16(chkTrangChu.Checked ? "1" : "0");
                        obj.Status = Convert.ToInt16(chck_Enable.Checked ? "1" : "0");
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeyword.Text;
                        obj.Check_01 = 0;
                        obj.Check_02 = 0;
                        obj.Check_03 = 0;
                        obj.Check_04 = 0;
                        obj.Check_05 = 0;
                        obj.Noidung1 = "";
                        obj.Noidung2 = "";
                        obj.Noidung3 = "";
                        obj.Noidung4 = "";
                        obj.Noidung5 = "";
                        obj.Module = 23;
                        obj.TangName = TagName;
                        #endregion
                        SMenu.UPDATE(obj);
                    }
                }
                this.UpdateList();
                this.pn_list.Visible = true;
                this.pn_insert.Visible = false;
                this.hd_insertupdate.Value = "";
                this.txt_title.Text = "";
                this.hd_insertupdate.Value = "insert";
                this.hd_id.Value = "-1";
                this.txtvimg.Text = "";
                this.hdFileName.Value = "";
                ltimg.Text = "";
                this.txtcontent.Text = "";
                txttitleseo.Text = "";
                txtmeta.Text = "";
                txtKeyword.Text = "";
                this.lblmsg.Text = "";
                this.lbl_curpage.Text = "";
            }
            // }
            //catch (Exception) { }
        }

        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            ltimg.Text = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeyword.Text = "";
            hidLevel.Value = "";
            lbl_curpage.Text = "";
            hidLevel.Value = "";
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.ltimg.Text = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            hidLevel.Value = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, hd_id.Value).ToString();
            }
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;

            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    List<Entity.Menu> table = SMenu.GETBYID(str2);
                    if (table.Count > 0)
                    {
                        int _cid1 = -1;
                        if (int.TryParse(str2, out _cid1))
                        {
                            string nva1 = "";
                            this.lbl_curpage.Text = More.LoadNav(_cid1, ref nva1);
                        }

                        hidLevel.Value = table[0].Level.Substring(0, table[0].Level.Length - 5);

                        this.pn_list.Visible = false;
                        this.pn_insert.Visible = true;
                        this.hd_insertupdate.Value = "update";
                        this.hd_page_edit_id.Value = str2.Trim();
                        if (table.Count > 0)
                        {
                            hd_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hdid.Value = table[0].ID.ToString().Trim();
                            this.txt_title.Text = table[0].Name.ToString().Trim();
                            this.txt_order.Text = table[0].Orders.ToString().Trim();
                            this.txtcontent.Text = table[0].Description.ToString().Trim();

                            #region Seowwebsite
                            txttitleseo.Text = table[0].Titleseo.ToString().Trim();
                            txtmeta.Text = table[0].Meta.ToString().Trim();
                            txtKeyword.Text = table[0].Keyword.ToString().Trim();
                            #endregion

                            ltimg.Text = MoreImage.Image(table[0].Images.ToString());
                            hdFileName.Value = table[0].Images.ToString();
                            chck_Enable.Checked = (table[0].Status == 1);
                            chknews.Checked = (table[0].News == 1);
                            chkTrangChu.Checked = (table[0].page_Home == 1);

                            if (table[0].Equals.ToString().Trim().Equals("1"))
                            {
                                this.rdFromLinks.Checked = true;
                                this.rdFromComputer.Checked = false;
                                this.LoadView();
                                this.txtvimg.Text = table[0].Images.ToString();
                            }
                            else
                            {
                                this.rdFromComputer.Checked = true;
                                this.rdFromLinks.Checked = false;
                                this.LoadView();
                                this.hdFileName.Value = table[0].Images.ToString();
                            }
                        }
                    }
                    return;
                #endregion
                case "Delete":
                    {
                        try
                        {
                            List<Entity.Products> dtdetail = SProducts.Name_Text("select * from Products where ID_Hang in(" + More.Sub_Menu(More.HA, str2) + ") ");
                            if (dtdetail.Count <= 0)
                            {
                                SMenu.DELETE(More.Sub_Menu(More.HA, str2));
                                SMenu.DELETE(str2);
                                this.UpdateList();
                                this.ltmsg.Text = "";
                            }
                            else
                            {
                                this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                            }
                        }
                        catch (Exception)
                        {
                            this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                        }
                    }
                    return;
                case "ListChildren":
                    this.hd_id.Value = str2;
                    var itemAdd = SMenu.Detail(str2);
                    hidLevel.Value = itemAdd[0].Level;
                    int _cid = -1;
                    if (int.TryParse(str2, out _cid))
                    {
                        string nva = "";
                        this.lbl_curpage.Text = More.LoadNav(_cid, ref nva);
                    }
                    if (hd_id.Value.Equals(""))
                    {
                        this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, "-1").ToString();
                    }
                    else
                    {
                        this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, hd_id.Value).ToString();
                    }
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "insert";
                    this.hd_page_edit_id.Value = "-1";
                    return;
                case "ChangeStatus":
                    string str3;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str3 = "0"; }
                    else { str3 = "1"; }
                    SMenu.UPDATESTATUS(str2, str3);
                    this.UpdateList();
                    return;
                case "News":
                    {
                        string str33;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str33 = "0"; }
                        else { str33 = "1"; }
                        SMenu.Updatemenu(str2, "News", str33);
                        this.UpdateList();
                    }
                    return;
                case "page_Home":
                    {
                        string str344;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str344 = "0"; }
                        else { str344 = "1"; }
                        SMenu.Updatemenu(str2, "page_Home", str344);
                        this.UpdateList();
                    }
                    return;
                case "Tang":
                    SMenu.UPDATEVIEWS_T(str2);
                    this.UpdateList();
                    return;
                case "Giam":
                    SMenu.UPDATEVIEWS_G(str2);
                    this.UpdateList();
                    return;
            }
        }

        private void UpdateList()
        {
            try
            {
                if (this.hd_id.Value.Equals(""))
                {
                    this.hd_id.Value = "-1";
                }
                // List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.HA, this.lang, this.hd_id.Value.Trim());
                List<Entity.Menu> table = SMenu.Name_Text("SELECT * FROM Menu where capp='" + More.HA + "' and lang='" + lang + "' order by level,Orders asc");
                CollectionPager1.DataSource = table;
                CollectionPager1.BindToControl = rp_pagelist;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 20;
                rp_pagelist.DataSource = CollectionPager1.DataSourcePaged;
                rp_pagelist.DataBind();

                if (this.hd_id.Value.Equals("-1"))
                {
                    this.lbl_curpage.Text ="Phân mục gốc";
                }
                else
                {
                    List<Entity.Menu> str = SMenu.Detail(this.hd_id.Value.Trim());
                    if (str.Count > 0)
                    {
                        this.hd_par_id.Value = str[0].Parent_ID.ToString().Trim();
                    }
                }
            }
            catch (Exception) { }
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_pagelist.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        List<Entity.Products> dtdetail = SProducts.Name_Text("select * from Products where ID_Hang in(" + More.Sub_Menu(More.HA, id.Value) + ") ");
                        if (dtdetail.Count <= 0)
                        {
                            SMenu.DELETE_PARENT(More.Sub_Menu(More.HA, id.Value));
                            SMenu.DELETE(id.Value);
                        }
                        else
                        {
                            this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
                        }
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert>Không xóa được,Đang có sản phẩm liên quan</span>";
            }
        }

        protected void rdFromComputer_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        protected void rdFromLinks_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        private void LoadView()
        {
            if (this.rdFromComputer.Checked)
            {
                this.MultiView2.SetActiveView(this.vwFromComputer);
            }
            else
            {
                this.MultiView2.SetActiveView(this.vwFromLinks);
            }
        }

        protected void btDeleteimages_Click(object sender, EventArgs e)
        {
            List<Entity.Menu> table = SMenu.GETBYID(hdid.Value);
            if (table.Count > 0)
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/" + table[0].Images);
            }
            SMenu.Name_Text("update Menu set Images='' where ID=" + hdid.Value + " capp='" + More.HA + "'");
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.ltimg.Text = "";
            this.txtcontent.Text = "";
            this.UpdateList();
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            ltimg.Text = "";
            this.txtcontent.Text = "";
            this.lblmsg.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            hidLevel.Value = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.HA, this.lang, hd_id.Value).ToString();
            }
        }


        protected void txtOrders_TextChanged(object sender, EventArgs e)
        {
            TextBox Orders = (TextBox)sender;
            var b = (HiddenField)Orders.FindControl("hiID");
            SMenu.Name_Text("UPDATE [Menu] SET Orders=" + Orders.Text + " WHERE ID=" + b.Value + " and capp='" + More.HA + "'");
            UpdateList();
            this.ltmsg.Text = "<span class=alert>Cập nhật thứ tự thành công.</span>";
        }
        protected void txtTennhom_TextChanged(object sender, EventArgs e)
        {
            TextBox Nhom = (TextBox)sender;
            var b = (HiddenField)Nhom.FindControl("hiID");
            if (Nhom.Text.Length > 0)
            {
                #region UpdateMenu
                string TagName = "";
                List<Entity.Menu> item = SMenu.GETBYID(b.Value);
                if (item.Count > 0)
                {
                    Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                    obk.Name = Nhom.Text;
                    obk.Module = 23;
                    List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(Nhom.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(Nhom.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(Nhom.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(Nhom.Text); } else { TagName = item[0].TangName; }
                    }
                    obk.TangName = TagName;
                    db.SubmitChanges();
                    UpdateList();
                    this.ltmsg.Text = "<span class=alert>Cập nhật tiêu đề thành công !!</span>";
                }
                #endregion
            }
            else
            {
                UpdateList();
                ltmsg.Text = "<span class=alert>Bạn chưa nhập tiêu đề !!</span>";
            }
        }

    }
}