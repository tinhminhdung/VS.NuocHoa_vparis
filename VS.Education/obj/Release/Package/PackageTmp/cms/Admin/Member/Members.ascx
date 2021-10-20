﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Members.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.Member.Members" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<script type="text/javascript" src="/cms/Admin/Member/Horver/js/JScript1.js"></script>
<script type="text/javascript" src="/cms/Admin/Member/Horver/js/stickytooltip.js"></script>
<link rel="stylesheet" type="text/css" href="/cms/Admin/Member/Horver/js/stickytooltip.css" />
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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
     <div class="row-fluid">
                <div class="span12">
                    <div class="widget">
                        <div class="widget-title">
                            <h4><i class="icon-reorder"></i>Danh sách thư viện</h4>
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
                        <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="true" CssClass="txt"  OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlorderby" runat="server" AutoPostBack="true" CssClass="txt"
                            OnSelectedIndexChanged="ddlorderby_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="dcreatedate">S.xếp:Ngày cập nhật</asp:ListItem>
                            <asp:ListItem Value="iuser_id">S.xếp:Tăng dần</asp:ListItem>
                            <asp:ListItem Value="vlname">S.xếp:Tên (ABC)</asp:ListItem>
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
<asp:Repeater id="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
     <HeaderTemplate>
          <table class="table table-striped table-bordered" id="sample_1">
         <tr>
             <th class="hidden-phone"><input id="chkAll" onclick="javascript: SelectAllCheckboxes(this, 1);" type="checkbox" /></th>
             <th class="hidden-phone">Họ và tên</th>
             <th class="hidden-phone">Tài khoản</th>
             <th class="hidden-phone">Ngày tạo</th>
             <th class="hidden-phone">Trạng thái</th>
             <th class="hidden-phone">Trạng thái</th>
             <th class="hidden-phone">Hiệu chỉnh</th>
          
        </tr>
	</HeaderTemplate>
	<ItemTemplate>
	<tr class="odd gradeX">
           <td style="text-align: center;"><asp:CheckBox ID="chkid" runat="server" onclick="javascript:changeColor(this,'white');"/><asp:HiddenField ID="hiID" Value='<%# Eval("iuser_id") %>' runat="server" /></td>
            <td align=left style=" padding-left:10px; line-height:22px; color:#646465" width=450px>
                Họ và tên:<span style="color:#444444; padding-left:27px;font-weight:bold"><a data-tooltip="sticky<%#Eval("iuser_id") %>" href="#"><%#Eval("vfname") %></a></span><br />
                Địa chỉ:<span style="color:#444444; padding-left:40px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "vaddress")%></span><br />
                Điện thoại:<span style="color:#444444; padding-left:22px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "vphone")%></span><br />
                Email:<span style="color:#444444; padding-left:15px;font-weight:bold"><%#DataBinder.Eval(Container.DataItem, "vemail")%></span><br />
            </td>
            <td style="text-align: center;">
             <%#Eval("vuserun") %>
           </td>
           <td style="text-align: center;">
             <%#MoreAll.MoreAll.FormatDate(Eval("dlastvisited").ToString())%>
           </td>
           <td style="text-align: center;">
               <%#Status(Eval("istatus").ToString())%>
           </td>
           <td style="text-align: center;">
            <asp:LinkButton  CssClass="active action-link-button" ID="LinkButton2" runat="server" CommandName="lock"  CommandArgument='<%#Eval("iuser_id")%>'  OnLoad="Lock_Load" Visible='<%#EnableLock(Eval("istatus").ToString())%>'><span style="font-size:14px">[Lock]</span></asp:LinkButton>
            <asp:LinkButton CssClass="active action-link-button" ID="LinkButton5" runat="server" CommandName="unlock"  CommandArgument='<%#Eval("iuser_id")%>' Visible='<%#EnableUnLock(Eval("istatus").ToString())%>'><span style="font-size:14px">[Unlock]</span></asp:LinkButton>
           </td>
         <td style="text-align: center;">
           <asp:LinkButton CssClass="active action-link-button" ID="LinkButton6" runat="server" CommandArgument='<%#Eval("iuser_id")%>' CommandName="delete" OnLoad="Delete_Load"><i class="icon-trash"></i></asp:LinkButton>
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
</ContentTemplate>
</asp:UpdatePanel>
    </div>