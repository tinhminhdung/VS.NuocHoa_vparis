<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cart.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Cart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="/cms/Display/Products/Resources/Giohang.css" rel="stylesheet" type="text/css" />
<link href="/Resources/ShopCart/css/Stylecart.css" rel="stylesheet" />
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>

<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Giỏ hàng</h1>

<%--                <br />
                <br />
                ShowTrangThai: <%=Commond.ShowTrangThai() %>
                <br />
                <br />
                <span class='Chuaxuly'>Lợi nhuận 0</span>
                <br />
                <span class='Daxuly'>Chiến lược 1</span>
                <br />--%>

            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <asp:Panel ID="pnmessage" runat="server">
                        <div class="modalbodys cart_body">
                            <i class="icon_cart"></i>
                            <h2><%=label("giohang1")%></h2>
                            <p><%=label("giohang2")%></p>
                            <a class="adrbutton" href="/"><%=label("giohang3")%></a>

                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <div class="modalbodys cart_body">
                            <i class="icon_cart"></i>
                            <asp:Literal ID="lblKQ" runat="server"></asp:Literal>
                            <br />
                            <h2><%=label("giohang1")%></h2>
                            <p><%=label("giohang2")%></p>
                            <a class="adrbutton" href="/"><%=label("giohang3")%></a>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnOrder" runat="server" Visible="false">
                        <div class='frm_cart scollgiohang'>
                            <table cellpadding="0" cellspacing="0" class="dcart scoll" width="100%" bgcolor="#FFFFFF" bordercolor="#C3C3C3">
                                <tr>
                                    <td height="30" colspan="8" class="TitleItem" style="text-align: left"><%=label("l_have")%> <span style="color: #F00; font-weight: bold;">
                                        <asp:Literal ID="ltProdinCart" runat="server"></asp:Literal></span> <%=label("lproductsincart")%></td>
                                </tr>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="ItemDataBound_RP">
                                    <HeaderTemplate>
                                        <tr class="procart">
                                            <td align="left"><strong>STT</strong></td>
                                            <td align="left"><strong><%=label("l_images") %></strong></td>
                                            <td align="center"><strong><%=label("lt_firstname") %></strong></td>
                                            <td align="center"><strong><%=label("lprice") %></strong></td>
                                            <td align="center"><strong><%=label("lquantity") %></strong></td>
                                            <td align="center"><strong><%=label("l_tomoney") %></strong></td>
                                            <td align="center"><strong>Xóa</strong></td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td height="30" align="center" class="TitleItem">
                                                <asp:Label ID="lb_tt" runat="server"></asp:Label></td>
                                            <td align="left" class="TitleItem">
                                                <img src="<%#Eval("Vimg")%>" style="width: 77px; height: auto; border: solid 1px #d7d7d7" />
                                                <%#Mausac(Eval("Mausac").ToString())%>
                                                <%#Kichthuoc(Eval("Kichco").ToString())%>
                                            </td>
                                            <td align="left" class="TitleItem"><strong><%#Eval("Name")%></strong></td>
                                            <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Price").ToString())%> </td>
                                            <td align="center" class="TitleItem">
                                                <asp:HiddenField ID="hiID" Value='<%# Eval("PID") %>' runat="server" />
                                                <asp:TextBox ID="txtxQuantity" Style="width: 40px; border: 1px solid #d7d7d7; text-align: center;" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Money").ToString())%>
                                               
                                            </td>
                                            <td align="center">
                                                <asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load" CssClass="lnk" CommandArgument='<%#Eval("PID")%>' runat="server"><span class="cmdxoa"></span></asp:LinkButton></td>
                                        </tr>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr style="background: #fff5ee;">
                                            <td height="30" align="center" class="TitleItem">
                                                <asp:Label ID="lb_tt" runat="server"></asp:Label></td>
                                            <td align="left" class="TitleItem">
                                                <img src="<%#Eval("Vimg")%>" style="width: 77px; height: auto; border: solid 1px #d7d7d7" />
                                                <%#Mausac(Eval("Mausac").ToString())%>
                                                <%#Kichthuoc(Eval("Kichco").ToString())%>
                                            </td>
                                            <td align="center" class="TitleItem"><strong><%#Eval("Name")%></strong></td>
                                            <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Price").ToString())%> </td>
                                            <td align="center" class="TitleItem">
                                                <asp:HiddenField ID="hiID" Value='<%# Eval("PID") %>' runat="server" />
                                                <asp:TextBox ID="txtxQuantity" Style="width: 40px; border: 1px solid #d7d7d7; text-align: center;" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity")%>' CssClass="txt_css" Width="40px" runat="server" OnTextChanged="txtxQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td align="center" class="TitleItem"><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Money").ToString())%>
                                            </td>
                                            <td align="center">
                                                <asp:LinkButton ID="LinkButton4" CommandName="delete" OnLoad="Delete_Load" CssClass="lnk" CommandArgument='<%#Eval("PID")%>' runat="server"><span class="cmdxoa"></span></asp:LinkButton></td>
                                        </tr>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td height="30" colspan="5" align="right" class="TitleItem"><strong style="float: right; font-weight: bold; padding-right: 10px;">Tổng phải thanh toán:</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <asp:Literal ID="ltTotalOrder" runat="server"></asp:Literal>
                                    </strong></td>
                                </tr>
                                <tr>
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:red">Tổng Tiền Ví Chính:</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:red"><asp:Literal ID="ltvitien" runat="server"></asp:Literal></span>
                                    </strong></td>
                                </tr>
                                   <asp:Panel ID="Panel3"  Visible="false" runat="server">
                                 <tr>
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:red">Tổng Tiền Ví Thưởng:</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:red"><asp:Literal ID="ltViVip" runat="server"></asp:Literal></span>
                                    </strong></td>
                                </tr>
                            
                                </asp:Panel>
                                    
                                 <tr style=" background: #ffcb03; ">
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:#000">Tổng tiền trừ ví chính: </strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:#000"><asp:Literal ID="ltTruViChinh" runat="server"></asp:Literal> </span>
                                    </strong></td>
                                </tr>
                                 <tr style=" background: #ed1c24; ">
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:#fff">Tổng tiền Ví chính còn lại:</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:#fff"><asp:Literal ID="ltconlai" runat="server"></asp:Literal> </span>
                                    </strong></td>
                                </tr>


                                    <asp:Panel ID="Panel2"  Visible="false" runat="server">
                                 <tr style=" background: #ffcb03; ">
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:#000">Số tiền chiết khấu vào ví thưởng :</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:#000"><asp:Literal ID="ltTruViVip" runat="server"></asp:Literal></span>
                                    </strong></td>
                                </tr>
<tr style=" background: #ed1c24; ">
                                    <td height="30" colspan="5" align="right" class="TitleItem">

                                        <strong style="float: right; font-weight: bold; padding-right: 10px; color:#fff">Số tiền chiết khấu còn lại :</strong></td>
                                    <td colspan="3" align="center" class="TitleItem"><strong>
                                        <span style=" color:#fff"><asp:Literal ID="ltvivipconlai" runat="server"></asp:Literal></span>
                                    </strong></td>
                                </tr>

                                </asp:Panel>
                            </table>
                        </div>
                        <div style="white-space: 100%">
                            <div class="bacoc">
                                <span class="order-header"><%=label("giohang4") %></span>
                                <div class="maunen">
                                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                    <div class='frm-contact'>
                                        <div style="width: 100%">
                                            <div style="float: left; width: 100%">
                                                <div class="labelll">
                                                    <%=label("lt_fullname")%>:
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="txtName" CssClass="CSTextBox" ValidationGroup="cart" runat="server" Width="222px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="cart" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 100%">
                                                <div class="labelll">
                                                    <%=label("l_address")%>:
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="txtAddress" CssClass="CSTextBox" ValidationGroup="cart" runat="server" Width="222px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="cart" ControlToValidate="txtAddress" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 100%">
                                                <div class="labelll">
                                                    <%=label("l_phone")%>:
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="txtPhone" CssClass="CSTextBox" ValidationGroup="cart" runat="server" Width="124px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="cart" ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtPhone">
                                                    </cc1:FilteredTextBoxExtender>
                                                </div>
                                            </div>

                                            <div style="float: left; width: 100%">
                                                <div class="labelll">
                                                    <%=label("l_email")%>:
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="txtEmail" CssClass="CSTextBox" ValidationGroup="cart" runat="server" Width="222px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div style="float: left; width: 100%">
                                                <div class="labelll">
                                                    <%=label("l_content")%>:
                                                </div>
                                                <div style="float: left">
                                                    <asp:TextBox ID="txtnoidung" CssClass="CSTextBox" runat="server" ValidationGroup="cart" Width="264px" Height="87px" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                           
                            <div style="width: 100%; float: left">
                                  <asp:Literal ID="ltthongbao" runat="server"></asp:Literal>
                                <asp:Button ID="btnSendOrder" ValidationGroup="cart" CssClass="btnaddxanh" runat="server" Text="Đặt hàng" OnClick="btnSendOrder_Click" />
                                <asp:Button ID="_btctnew" CssClass="btnadd" runat="server" Text="Mua thêm" OnClick="_btctnew_Click" />
                                <asp:Button ID="btnCancelOrder" CssClass="btnadd" runat="server" Text="Hủy đặt hàng" OnClick="btnCancelOrder_Click" />
                            </div>

                            <div style="color: #333; float: left; font: 400 14px/22px arial; padding-top: 10px; width: 98%;">
                                <asp:Literal ID="txtgiohang" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>


<script type="text/javascript">
    $(document).ready(function () {
        $('input[type="submit"]').click(function () {
            $('#loadingAjax').addClass('loading');
            document.getElementById("overlay").style.display = "block";
            setTimeout(function () {
                document.getElementById("overlay").style.display = "none";
                $('#loadingAjax').removeClass('loading');
            }, 90000);
        });
    });
</script>

<div id="loadingAjax" style="display: none">
    <div class="inner">
        <img src="/Resources/images/ajax-loader_2.gif">
        <p style="color: #fbff0f; font-size: 19px;">Đơn hàng đang được cập nhật lên hệ thống</p>
        <p style="color: #fbff0f;">Vui lòng không tắt trình duyệt hoặc tắt máy cho đến khi đơn hàng được cập nhật thành công. </p>
        <p style="color: #fbff0f;">Xin cảm ơn</p>
    </div>
</div>

  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-body">
          <%=Commond.Setting("DatHangThieuTien")%>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" style="background:red;font-size: 12px;padding: 10px;" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    
<asp:HiddenField ID="hdTTConLaiViChinh" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdTTThanhToanMuaHang" Visible="false" Value="0" runat="server" />

<asp:HiddenField ID="hdTTViViConLai" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="dhTTViVipThanhToanMuaHang" Visible="false"  Value="0" runat="server" />



<asp:HiddenField ID="hdViVip" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdViVipDaMuaHang" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdTongTienDaMuaHang" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdTienHoaHong" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdtongtien" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdTienLoiNhuan" Visible="false" Value="0" runat="server" />
<asp:HiddenField ID="hdIDThanhVien" Visible="false" runat="server" />
