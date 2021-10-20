<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MLichSuQuyDoiSoCoPhan.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.MLichSuQuyDoiSoCoPhan" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Lịch sử Quy đổi từ ví chính và từ số cổ phần sang ví VPR-S</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">

<div class="list_item">
    <asp:Repeater ID="rp_pagelist" runat="server" >
        <ItemTemplate>
            <tr>
                <td style="text-align: center;">
                    <%#ShowtThanhVien(DataBinder.Eval(Container.DataItem, "IDThanhVien").ToString())%>
                </td>
              
                <td style="text-align: center;">
                    <%#MoreAll.MorePro.FormatMoney_VND_KieuVi(DataBinder.Eval(Container.DataItem, "SoTien").ToString(),DataBinder.Eval(Container.DataItem, "KieuVi").ToString() )%>
                </td>
                 <td style="text-align: center;">
                       <%#MoreAll.MoreAll.KieuViQuyDoi(DataBinder.Eval(Container.DataItem, "KieuVi").ToString())%>
                 </td>
                <%-- <td style="text-align: center;">
                   <%#(DataBinder.Eval(Container.DataItem, "MoTa").ToString())%>
                </td>--%>
                <td style="text-align: center;">
                    <%#DataBinder.Eval(Container.DataItem, "NgayCap")%>
                </td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
           <table class="table table-striped table-bordered table-advance table-hover table table-cart lichsumuahang">
                <tbody>
                    <tr class="trHeader" style="height: 25px">
                        <th style="font-weight: bold;text-align: center;">Tên thành viên</th>
                        <th style="font-weight: bold;text-align: center;">Số tiền / cổ phần</th>
                             <th style="font-weight: bold;text-align: center;">Loại ví</th>
                   <%--        <th style="font-weight: bold;text-align: center;">Nội dung</th>--%>
                        <th style="font-weight: bold;text-align: center;">Ngày cấp</th>
                    </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
<div style="color: red; text-align: right; padding-top: 7px; font-weight: 600; display:none">
<asp:Literal ID="ltCoin" runat="server"></asp:Literal>
</div>
</div>
 </div>
<div class="phantrang" style="">
    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
        BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
        ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
    </cc1:CollectionPager>
</div>
<asp:HiddenField ID="hdid" runat="server" />

                </section>
            </section>
        </section>
</section>
