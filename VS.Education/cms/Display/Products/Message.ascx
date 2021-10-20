<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Message" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Giỏ hàng</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <div style="line-height: 22px; text-align: center; padding-top: 20px; padding-left: 10px">
                        <asp:Literal ID="ltmessage" runat="server"></asp:Literal>
                    </div>
                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>


