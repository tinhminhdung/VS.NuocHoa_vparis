<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AMembers.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.MMember.AMembers" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Danh sách Thành viên</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
            <asp:Literal ID="ltthongbao" runat="server"></asp:Literal>
     <div class="row-fluid">
                <div class="span12">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Danh sách Thành viên</h4>
                        </div>
               <div class="widget-body">
                <div class="row-fluid">
                    <div class="span9">
                        <div id="sample_1_length" class="dataTables_length">
                         <div class="frm_search">
                    <div>
                        <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch" Width="400px"></asp:TextBox>
                        <asp:LinkButton ID="lnksearch" runat="server" OnClick="lnksearch_Click" CssClass="vadd toolbar btn btn-info" style="margin-top: -9px;">  <i class="icon-search"></i>&nbsp;Tìm kiếm</asp:LinkButton>
                    </div>
                    <div style="margin-top: 10px;">
                
                         <asp:DropDownList ID="ddlMuaHang" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlMuaHang_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="-1">= Tất cả trạng thái mua hàng =</asp:ListItem>
                                                    <asp:ListItem Value="0">Chưa mua</asp:ListItem>
                                                    <asp:ListItem Value="1">Đã mua</asp:ListItem>
                                                </asp:DropDownList>

                         <asp:DropDownList ID="ddlcapdo" runat="server" AutoPostBack="true" CssClass="txt" OnSelectedIndexChanged="ddlcapdo_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="-1">= Tất cả cấp bậc =</asp:ListItem>
                                                    <asp:ListItem Value="1">Trưởng nhóm KD</asp:ListItem>
                                                    <asp:ListItem Value="2">Tp Kinh doanh</asp:ListItem>
                                                    <asp:ListItem Value="3">Giám đốc KD</asp:ListItem>
                                                    <asp:ListItem Value="4">Giám đốc KD Cao cấp</asp:ListItem>
                                                </asp:DropDownList>

                        <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt"  OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt"
                            OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="NgayTao">S.xếp:Ngày cập nhật</asp:ListItem>
                            <asp:ListItem Value="ID">S.xếp:Tăng dần</asp:ListItem>
                            <asp:ListItem Value="HoVaTen">S.xếp:Tên (ABC)</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlordertype" runat="server" AutoPostBack="True" CssClass="txt" OnSelectedIndexChanged="ddlordertype_SelectedIndexChanged">
                            <asp:ListItem Value="desc">Giảm dần</asp:ListItem>
                            <asp:ListItem Value="asc">Tăng dần</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                        </div>
                    </div><div class="span3">
                        <div class="dataTables_filter" id="sample_1_filter">
                       <asp:LinkButton ID="bthienthi" runat="server"  OnClick="btndisplay_Click" CssClass="vadd toolbar btn btn-info"> <i class=" icon-folder-close"></i>&nbsp;Hiện thị</asp:LinkButton>
                        <asp:LinkButton ID="btDeleteall" ToolTip="Xóa những lựa chọn !" OnClientClick=" return confirmDelete(this);" runat="server" OnClick="btxoa_Click"  CssClass="vadd toolbar btn btn-info"><i class="icon-trash"></i>&nbsp;Xóa</asp:LinkButton>
                        </div>
                    </div>
                </div>
<div  class="list_item">
   <div style=" color:red; font-weight:bold">Tổng thành viên: <asp:Literal ID="lttong" runat="server"></asp:Literal></div>
<asp:Repeater id="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"  OnItemDataBound="rp_items_ItemDataBound">
     <HeaderTemplate>
          <table class="table table-striped table-bordered" id="sample_1">
         <tr>
             <th class="hidden-phone"><input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></th>
             <th class="hidden-phone">Họ và tên</th>
               <th class="hidden-phone">Thông tin</th>
             <th class="hidden-phone">Ngày tạo</th>
             <th class="hidden-phone">Trạng thái</th>
             <th class="hidden-phone">Trạng thái</th>
<%--             <th class="hidden-phone">Hiệu chỉnh</th>--%>
          
        </tr>
	</HeaderTemplate>
	<ItemTemplate>
	<tr class="odd gradeX">
           <td style="text-align: center;"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" /></td>
            <td align=left style=" padding-left:10px; line-height:22px; color:#646465" width=450px>
              Họ và tên:<span style="color:#444444; padding-left:27px;font-weight:bold"><%#Eval("HoVaTen") %></span><br />
                 <span style="color:red; font-weight:bold;">Mật khẩu: <a data-tooltip="sticky<%#Eval("id") %>" target="_blank" title="Click vào để đăng nhập nhanh" href="/Autologon.aspx?ID=<%# Eval("ID") %>&U1=<%# Eval("Key") %>&U2=<%# Eval("PasWord") %>""><%# Eval("PasWord") %></a></span><br />
                Địa chỉ:<span style="color:#444444; padding-left:40px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "DiaChi")%></span><br />
                Điện thoại:<span style="color:#444444; padding-left:22px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "DienThoai")%></span><br />
                Email:<span style="color:#444444; padding-left:15px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />

                 Người giới thiệu:<span style="color: red; padding-left: 15px; font-weight: bold"><a target="_blank" href="/admin.aspx?u=Thanhvien&IDThanhVien=<%# Eval("GioiThieu") %>"><%#Commond.ShowThanhVien(DataBinder.Eval(Container.DataItem, "Gioithieu").ToString())%></a></span><br />
                <a title="Cấp điểm cho thành viên" href="admin.aspx?u=CCapDiem&IDThanhVien=<%#Eval("ID").ToString()%>" style="color:red; font-weight:bold">>>>Cấp điểm</a>

                  <div class="bordes">Ví VPR-S: <%#(Eval("ViCoPhanSo").ToString())%></div>
                   <div class="bordes" style=" background:red">Tổng F1 mua hàng VPR-S: <%#(Eval("F1MuaHangThuongSoCoPhan").ToString())%></div>
                <div class="bordess"><%#(Eval("MTRee").ToString())%></div>
             </td>
            <td style="line-height:22px;color:#646465;text-align: center;" width=280px>
                <div class="bordes">Số dư: <%#MoreAll.MorePro.Detail_Price(Eval("TienHoaHong").ToString())%></div>
                <div class="bordes">Đã rút: <%#MoreAll.MorePro.Detail_Price(Eval("TongTienDaRut").ToString())%></div>

                 <div class="bordes">Vi Víp: <%#MoreAll.MorePro.Detail_Price(Eval("ViVip").ToString())%></div>
                <div class="bordes">Vi Víp đã mua hàng: <%#MoreAll.MorePro.Detail_Price(Eval("ViVipDaMuaHang").ToString())%></div>

                    <div class="bordes">Tổng tiền đã mua hàng: <%#MoreAll.MorePro.Detail_Price(Eval("TongTienDaMuaHang").ToString())%></div>
                  <div class="bordes" style=" background:red">Tổng F1 đang mua hàng: <%#(Eval("F1MuaHangDeTinhThuong").ToString())%></div>
                  <div class="bordes" title="Trạng thái mua hàng chiến lược và lợi nhuận để đếm cho F1 để F1 hưởng hoa hồng giới thiệu ra 3F1">Trạng thái mua hàng : <%#MoreAll.MoreAll.TrangThaiMuaHang((Eval("TrangThaiF1MuaHang").ToString()))%></div>
                <div class="bordes" title="Phải có 1 đơn sản phẩm chiến lược thì mới hưởng được hoa hồng (Trạng thái kích hoạt để hưởng hoa hồng)">Trạng thái mua hàng chiến lược: <%#MoreAll.MoreAll.TrangThaiMuaHang((Eval("TrangThaiMuaHang").ToString()))%></div>
                <div class="bordes" title="Số tiền mua hàng phải >= số tiền trong cấu hình thì mới được rút tiền">Trạng thái giá trị đơn hàng để rút tiền: <%#MoreAll.MoreAll.TrangThaiGiatriDonHang(Eval("TrangThaiMuaHangDatTongTien").ToString())%></div>
                <div class="bordes" title="Tổng F1 đã kích / Tổng số">Tổng trực tiếp: <%#CapBac.ThanhVienGioiTHieu(Eval("ID").ToString())%> /<%#CapBac.ThanhVienGioiTHieuChuaKich(Eval("ID").ToString())%></div>
           <%--    <div class="bordes" title="Số tầng hiện tại / Tổng tầng hiện tại">Tầng số : <%#Commond.Demchuoi(Eval("SoNguPhan").ToString())%> /  <%#Commond.Sotanglonnhat(Eval("SoNguPhan").ToString())%></div>
               <div class="bordes" title="Số thứ tự / Tổng số người">Số thứ tự : <%#Commond.SoThuTuThanhVien(Eval("ID").ToString())%> /  <%#Commond.TongSoNguoiHienTai(Eval("ID").ToString())%></div>
          --%>
                 <div class="bordes" title="Đã kích / Tổng">Tổng thành viên trong đội nhóm: <%#TongThanhVienBenDuoi(Eval("ID").ToString())%></div>
                

                
                
                 </td>
         <td style="text-align: center;">
             <%#MoreAll.MoreAll.FormatDate(Eval("NgayTao").ToString())%>
             <br />
              <div style="clear:both; height:20px"></div>
             <div style=" color:red; font-weight:bold">Cấp bậc</div>
               <asp:DropDownList ID="ddlLevelThanhVien" style="width: 180px;" runat="server" OnSelectedIndexChanged="ddlLevelThanhVien_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Chọn cấp bậc --</asp:ListItem>
                                                    <asp:ListItem Value="1">Trưởng nhóm KD</asp:ListItem>
                                                    <asp:ListItem Value="2">Tp Kinh doanh</asp:ListItem>
                                                    <asp:ListItem Value="3">Giám đốc KD</asp:ListItem>
                                                    <asp:ListItem Value="4">Giám đốc KD Cao cấp</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hdCapBac" Value='<%#Eval("CapBac") %>' runat="server" />

             <div style="clear:both; height:20px"></div>
             <div style=" color:red; font-weight:bold">Số cổ phần</div>
              <asp:TextBox ID="txtCoPhan" Style="border: 1px solid #d7d7d7; border-radius: 3px; text-align: center" Text='<%#DataBinder.Eval(Container.DataItem, "CoPhan")%>' CssClass="txt_css" Width="100px" runat="server" OnTextChanged="txtCoPhan_TextChanged" AutoPostBack="true"></asp:TextBox>

           </td>
           <td style="text-align: center;">
               <%#Status(Eval("TrangThai").ToString())%>
           </td>
           <td style="text-align: center;">
            <asp:LinkButton  CssClass="active action-link-button" ID="LinkButton2" runat="server" CommandName="lock"  CommandArgument='<%#Eval("ID")%>'  OnLoad="Lock_Load" Visible='<%#EnableLock(Eval("TrangThai").ToString())%>'><span style="font-size:14px">[Lock]</span></asp:LinkButton>
            <asp:LinkButton CssClass="active action-link-button" ID="LinkButton5" runat="server" CommandName="unlock"  CommandArgument='<%#Eval("ID")%>' Visible='<%#EnableUnLock(Eval("TrangThai").ToString())%>'><span style="font-size:14px">[Unlock]</span></asp:LinkButton>
           </td>
         <td style="text-align: center; display:none">
           <asp:LinkButton CssClass="active action-link-button" ID="LinkButton6" runat="server" CommandArgument='<%#Eval("ID")%>' CommandName="delete" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
         </td>
     </tr>
	</ItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>
 </div>
 <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
<tr height="20">
    <td align=right>
        <asp:Literal ID="ltpage" runat="server"></asp:Literal>
        <div class="phantrang" style=" ">
        <cc1:CollectionPager id="CollectionPager1" runat="server"  BackNextDisplay="HyperLinks" BackNextLocation="Split"
            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True"  IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers" 
            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
        </cc1:CollectionPager>
        </div>
    </td>
    </tr>
</table>
                   </div>
                        </div>
                    </div>
         </div>

    </div>