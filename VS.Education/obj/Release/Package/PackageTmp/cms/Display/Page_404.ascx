<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Page_404.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Page_404" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading relative">
                <h1 class="title-head page_title">
                    <asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <div class="News-content">
                        <div class="contents">
                            <%=MoreAll.Other.Giatri("Loi404")%>
                        </div>
                    </div>
                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>


