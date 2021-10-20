<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detailorders.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.Detailorders" %>
    <section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
    <h1 class="title-head page_title">Lịch sử mua hàng</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
<section class="login page_order_account">
    <div class="">
        <div class="">
            <div class="col-xs-12 col-sm-12 col-md-12 top_order_title">
                <h1 class="title-headding order-headding">Đơn hàng #<asp:Literal ID="ltmadonhang" runat="server"></asp:Literal></h1>
                <span class="note order_date"><i>Ngày tạo —
                    <asp:Literal ID="ltngaydathang" runat="server"></asp:Literal></i>
                    <a href="/lich-su-mua-hang.html"><i class="fa fa-arrow-left" aria-hidden="true"></i>&nbsp;Quay lại trang tài khoản</a>
                </span>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 body_order">
                <div id="order_payment" class="span12 box-address margin-top-20">
                    <div class="box-header">
                        <h2 class="title-head">Địa chỉ giao hàng</h2>
                        <br />
                        <p>
                            <span class="note">Trạng thái thanh toán:</span>
                            <i i="" class="status_pending">
                                <asp:Literal ID="lttrangthai" runat="server"></asp:Literal>
                            </i>
                        </p>
                    </div>
                    <div class="address note">
                        <p><i class="fa fa-user"></i>
                            <asp:Literal ID="lthovaten" runat="server"></asp:Literal></p>
                        <p>
                            <i class="fa fa-map-marker"></i>
                            <asp:Literal ID="ltdiachi" runat="server"></asp:Literal>
                        </p>
                        <p><i class="fa fa-phone"></i>
                            <asp:Literal ID="ltdienthoai" runat="server"></asp:Literal></p>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="table-responsive-block margin-top-20 table-responsive">
                    <table id="order_details" class="table table-cart lichsumuahang">
                        <thead class="thead-default">
                            <tr>
                                <th style="border-bottom: none; text-align:center">STT</th>
                                     <th style="border-bottom: none; text-align:center">Mã sản phẩm</th>
                                <th style="border-bottom: none; text-align:center">Sản phẩm</th>
                           
                                <th style="border-bottom: none; text-align:center">Giá</th>
                                <th style="border-bottom: none; text-align:center">Số lượng</th>
                                <th style="border-bottom: none; text-align:center">Tổng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpcartdetail" runat="server">
                                <ItemTemplate>
                                    <tr style="height: 20px" class="tr_while" onmouseover="this.className='tr_while_over'" onmouseout="this.className='tr_while'">
                                        <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%=i++ %></td>
                                        <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#Codes(Eval("ipid").ToString())%></td>
                                        <td style="padding-left: 5px; text-align: left !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Name")%></td>
                                        <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#MoreAll.MorePro.Detail_Price(Eval("Price").ToString())%> <%=MoreAll.Other.Giatri("Dongiapro") %></td>
                                        <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#DataBinder.Eval(Container.DataItem,"Quantity")%></td>
                                        <td style="padding-left: 5px; text-align: center !important" class="cartadmin"><%#MoreAll.MorePro.Detail_Price(Eval("Money").ToString())%> <%=MoreAll.Other.Giatri("Dongiapro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-xs-12 oder_total_monney">
                <table class="table  totalorders">
                    <tfoot>

                        <tr class="order_summary note" style="color: red;">
                            <td class="fix-width-200" colspan="">Tổng tiền bằng chữ:</td>
                            <td class="total money right"><strong style="color: #fe3232"><asp:Literal ID="lttongtienbangchu" runat="server"></asp:Literal></strong></td>
                        </tr>

                        <tr class="order_summary order_total">
                            <td class="fix-width-200">Tổng tiền:</td>
                            <td class="right"><strong><asp:Literal ID="lttongtien" runat="server"></asp:Literal> ₫ </strong></td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
</section>
<asp:HiddenField ID="hdid" runat="server" />


          </div>
            </section>
        </section>
    </section>
</section>
