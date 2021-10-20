<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GioiThieu.ascx.cs" Inherits="VS.E_Commerce.cms.Display.GioiThieu.GioiThieu" %>
<div class="col-right">
      <div class="hd-content-page-child">
         <span><a href="/">Trang chủ</a></span> <a>Giới thiệu</a>
         <div class="cart">
             <div class="inner-cart">
                 <a href="/gio-hang.html">Giỏ hàng (<%=Services.SessionCarts.LoadCart() %>)</a>
             </div>
         </div>
      </div>
<div class="News-content">
<div class="title"><asp:Literal ID="lttitle" runat="server"></asp:Literal></div>
<div><asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
<div class="des-news"><asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
<div class="Other"><asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>
<div style=" height:10px"></div>
<div class="list-more-news">
<asp:Repeater ID="rpitems2" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="/<%#Eval("TangName")%>.html><%#Eval("Title")%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 
<div class="list-more-news">
<asp:Repeater ID="rpitems" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintieptheo")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="/<%#Eval("TangName")%>.html><%#Eval("Title")%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div>
 </div>
</div>
</div>
