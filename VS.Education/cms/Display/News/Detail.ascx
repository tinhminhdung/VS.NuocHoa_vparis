<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.News.Detail1" %>

<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading relative"  style=" display:none">
                <h2 class="title-head page_title"> <asp:Literal ID="ltcatename" runat="server"></asp:Literal></h2>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
<div class="News-content">
<div class="title"><h1><asp:Literal ID="lttitle" runat="server"></asp:Literal></h1></div>
<div><asp:Literal ID="ltFacebook" runat="server"></asp:Literal></div>
<div class="des-news"><asp:Literal ID="ltdesc" runat="server"></asp:Literal></div>
<div class="Other"><asp:Literal ID="ltTinlienquan" runat="server"></asp:Literal></div>
<div class="contents">    
<asp:Literal ID="ltcontent" runat="server"></asp:Literal>
<div style=" text-align:left; padding-bottom:20px ; padding-top:10px">
<asp:Literal ID="ltchiase" runat="server"></asp:Literal>
</div>
<div style=" height:10px"></div>
<%if(MoreAll.Other.Giatri("Comment")=="1"){ %>
<div class="shares">
    <div class="fb-comments" data-href="<%=MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) %>" data-width="100%" data-numposts="5" data-colorscheme="light"></div>
</div>
<%} %>

<div style=" height:10px"></div>
<div class="list-more-news">
<asp:Repeater ID="rpitems2" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintruoc")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="<%#Eval("TangName")%>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div> 
<div class="list-more-news">
<asp:Repeater ID="rpitems" runat="server">
<HeaderTemplate>
<div class="title-more-news"><%=label("cactintieptheo")%></div>
</HeaderTemplate>
<ItemTemplate>
<div><a href="<%#Eval("TangName")%>.html" title="<%#Eval("Title")%>"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a></div>                                                                                            
</ItemTemplate>
</asp:Repeater>
</div>
 </div>
</div>

                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>


