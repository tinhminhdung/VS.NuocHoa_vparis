<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.Products.Cart" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>

<div id="cph_Main_ContentPane">
    <div id="">
        <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
            <ul>
                <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
                <li class="Last"><span>Quản lý giỏ hàng</span></li>
            </ul>
        </div>
        <div style="clear: both;"></div>
        <div class="widget">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Quản lý giỏ hàng     </h4>
                    </div>
                    <div class="widget-body">

                        <div class="row-fluid">
                            <div class="span6">
                                <div id="sample_1_length" class="dataTables_length">
                                    <div class="frm_search">
                                        <div>
                                            <asp:Literal ID="lttotal1" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="dataTables_filter" id="sample_1_filter">
                                    <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" Width="144px">
                                        <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
                                        <asp:ListItem Value="1">Đơn hàng đã duyệt</asp:ListItem>
                                        <asp:ListItem Value="0">Đơn hàng chưa duyệt</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtkeyword" runat="server" CssClass="txt_csssearch"></asp:TextBox>
                                    <asp:Button ID="btnshow" runat="server" Text="Hiển thị" OnClick="btnshow_Click" CssClass="vadd toolbar btn btn-info"></asp:Button>
                                    <asp:Button ID="btxoa" runat="server" OnClick="btxoa_Click" OnClientClick=" return confirmDelete(this);" Text="Xóa" ToolTip="Xóa những lựa chọn !" CssClass="vadd toolbar btn btn-info" />
                                    <asp:Button ID="lbtExport" runat="server" OnClick="Export_Click" CssClass="vadd toolbar btn btn-info" Text="Export dữ liệu" ToolTip="Export dữ liệu" />
                                </div>
                            </div>
                        </div>
                        <div class="list_item">
                            <asp:Repeater ID="rp_items" runat="server" OnItemCommand="rp_items_ItemCommand">
                                <ItemTemplate>
                                    <tr height="40">
                                        <td style="text-align: center;">
                                            <asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');" /><asp:HiddenField ID="hiID" Value='<%# Eval("ID") %>' runat="server" />
                                        </td>
                                        <td align="left" style="padding-left: 10px; line-height: 22px; color: #646465" width="500px">
                                            <div style="color: #444444; font-weight: bold"><a href="/admin.aspx?u=ChitietDonHang&ID=<%# Eval("ID") %>">Mã đơn hàng: #<%# Eval("ID") %></a> </div>
                                            
                                             Họ và tên:<span style="color: #444444; padding-left: 27px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Name")%></span><br />
                                            Địa chỉ:<span style="color: #444444; padding-left: 40px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Address")%></span><br />
                                            Điện thoại:<span style="color: #444444; padding-left: 22px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Phone")%></span><br />
                                            Email:<span style="color: #444444; padding-left: 15px; font-weight: bold"><%#DataBinder.Eval(Container.DataItem, "Email")%></span><br />
                                     <%--    <div>Hình thức thanh toán: <span style="color: #fff; padding: 3px; font-weight: bold; background: #1a8506; border-radius: 5px; width: 250px"><%#DataBinder.Eval(Container.DataItem, "Phuongthucthanhtoan")%></span></div>--%>
                                       
                                                   <%#MoreAll.MoreAll.TrangThaiChienLuocVaThongThuong(DataBinder.Eval(Container.DataItem, "TrangThaiChienLuocVaThongThuong").ToString())%>

                                        </td>
                                        <td style="text-align: center;">
                                            <%#MoreAll.MorePro.FormatMoney(Eval("Money").ToString())%>
                                        </td>
                                         <td style="text-align: center;">
                                            <%#MoreAll.MorePro.FormatMoney(Eval("TienLoiNhuan").ToString())%>
                                        </td>
                                        <td style="text-align: center;">
                                            <%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%>
                                        </td>
                                          <td style="text-align: center;">
                                            <%#MoreAll.MoreAll.TinhTrangDonHang(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                        </td>
                                        <td style="text-align: center;">
                                            <a href="/admin.aspx?u=ChitietDonHang&ID=<%#DataBinder.Eval(Container.DataItem,"ID")%>"><img src="/Resources/admin/images/chitiet.png" border="0"></a>
                                        </td>
                                        <td style="text-align: center;">
                                             <asp:LinkButton CssClass="active action-link-button" ID="LinkButton2" OnLoad="Delete_Load" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' runat="server"><i class="icon-trash"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <table cellspacing="0" style="border-collapse: collapse; margin-top: 18px" class="table table-striped table-bordered dataTable table-hover">
                                        <tr height="40">
                                            <td class="header">
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></td>
                                            <td class="header">Thông tin khách hàng</td>
                                            <td class="header" style="text-align: center;">Tổng tiền</td>
                                                    <td class="header" style="text-align: center;">Tổng chia hh</td>
                                            <td class="header" style="text-align: center;">Ngày gửi</td>
                                            <td class="header" style="text-align: center;">Tình trạng đơn hàng</td>
                                          <td class="header" style="text-align: center;">Xem chi tiết</td>
                                            <td class="header">Xóa</td>
                                        </tr>
                                </HeaderTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                            <tr height="20">
                                <td style="text-align: center;">
                                    <asp:Literal ID="ltpage" runat="server"></asp:Literal>
                                    <div class="phantrang" style="">
                                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                                            BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                                        </cc1:CollectionPager>
                                    </div>
                                </td>
                        </table>

                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="widget-title">
                        <h4><i class="icon-list-alt"></i>&nbsp;Gửi Email </h4>
                    </div>
                    <div class="widget-body">
                        <div class='frm-add'>
                            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="red"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Tiêu đề</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txttitle" runat="server" Width="350px" CssClass="txt_css"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Tên người nhận</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txttoname" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="height: 24px"></td>
                                    <td style="height: 24px">Email đến</td>
                                    <td style="height: 24px"></td>
                                    <td style="height: 24px">
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="txt_css" Width="350px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>Nội dung<br />
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="3">
                                        <CKEditor:CKEditorControl ID="txtContent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="padding-left: 0px; height: 0px;">
                            <br />
                            <asp:LinkButton ID="btnSend" runat="server" OnClick="btnSend_Click" CssClass="toolbar btn btn-info"> <i class="icon-ok"></i>Gửi mail</asp:LinkButton>
                            <asp:LinkButton ID="btncancel" runat="server" OnClick="btncancel_Click" CssClass="toolbar btn btn-info"> <i class="icon-chevron-left"></i>Hủy</asp:LinkButton>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</div>

<div style="clear: both;"></div>
<asp:HiddenField ID="hdIDGiohang" runat="server" />