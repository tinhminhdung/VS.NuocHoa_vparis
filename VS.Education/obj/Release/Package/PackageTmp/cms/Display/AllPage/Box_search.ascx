<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Box_search.ascx.cs" Inherits="VS.E_Commerce.cms.Display.AllPage.Box_search" %>
<asp:Panel ID="SearchBox" runat="server" DefaultButton="lnksearch">
    <asp:TextBox placeholder="Nhập từ khóa tìm kiếm ... " ID="txtkeyword" class="input-group-field st-default-search-input search-text" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lnksearch" OnClick="lnksearch_Click" class="timkiemsnut" runat="server">Tìm kiếm</asp:LinkButton>
</asp:Panel>
