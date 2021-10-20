<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichSuDatHang.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.LichSuDatHang" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Lịch sử mua hàng</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">


<div class="dataTables_filter" id="sample_1_filter" style="display:none">
    <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" Width="144px">
        <asp:ListItem Value="-1" Selected="True">Tất cả các mục</asp:ListItem>
        <asp:ListItem Value="1">Đơn hàng đã duyệt</asp:ListItem>
        <asp:ListItem Value="0">Đơn hàng chưa duyệt</asp:ListItem>
        <asp:ListItem Value="2">Đơn hàng đang chờ xử lý</asp:ListItem>
        <asp:ListItem Value="3">Đơn hàng đang vận chuyển</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtkeyword" runat="server" CssClass="form-control" ></asp:TextBox>
    <asp:Button ID="btnshow" runat="server" Text="Hiển thị" OnClick="btnshow_Click" CssClass="vadd toolbar btn btn-info"></asp:Button>
</div>


<div class="my-account">
    <div class="dashboard">
        <div class="recent-orders">
            <div class="table-responsive tab-all" style="overflow-x: auto;">
                <table class="table table-cart lichsumuahang">
                    <thead class="thead-default">
                        <tr>
                            <th style=" text-align: center">Đơn hàng</th>
                            <th style=" text-align: center">Ngày</th>
                            <th style=" text-align: center">Địa chỉ</th>
                            <th style=" text-align: center">Giá trị đơn hàng</th>
                            <th style=" text-align: center">Trạng thái</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rp_items" runat="server">
                            <ItemTemplate>
                                <tr class="first odd">
                                    <td style="text-align: center"><a href="/account/orders/<%#Eval("ID") %>">#<%#Eval("ID") %></a></td>
                                    <td style="text-align: center"><%#MoreAll.MoreAll.FormatDate(DataBinder.Eval(Container.DataItem, "Create_Date").ToString())%></td>
                                    <td style="text-align: center"><%#Eval("Address") %></td>
                                    <td style="text-align: center"><span class="price"><%#MoreAll.MorePro.Detail_Price(Eval("Money").ToString())%>₫</span></td>
                                    <td style="text-align: center">
                                        <%#ShowTrangThai(Eval("Status").ToString()) %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="text-xs-right">
            </div>
            <div class="phantrang" style="">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                    BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                    ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                </cc1:CollectionPager>
            </div>
        </div>
    </div>

</div>
<asp:HiddenField ID="hdid" runat="server" />
                              </div>
            </section>
        </section>
    </section>
</section>
