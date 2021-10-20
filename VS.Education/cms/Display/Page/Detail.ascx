<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Page.Detail" %>

<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <section class="list-blogs blog-main ">
                <div class="row">

                    <div class="News-content">
                        <div class="title">
                            <h1>
                                <asp:Literal ID="lttitle" runat="server"></asp:Literal></h1>
                        </div>
                        <div class="contents">
                            <asp:Literal ID="ltdetail" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>


