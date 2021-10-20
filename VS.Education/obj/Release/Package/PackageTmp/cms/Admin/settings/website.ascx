<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="website.ascx.cs" Inherits="VS.E_Commerce.cms.Admin.settings.website" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<script src="/Scripts/ckfinder/ckfinder.js" type="text/javascript"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td style="height: 26px">
                    <strong><font color="#ed1f27"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                </td>
            </tr>
              <tr>
                <td>
                </td>
              <td  style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    <strong>Kích hoạt gửi Email</strong>
                </td>
                <td>
                     <asp:RadioButton ID="RadioButton1" runat="server" Text="Tắt" GroupName="Email" Checked="true"></asp:RadioButton>
                     <asp:RadioButton ID="RadioButton2" runat="server" Text="Bật" GroupName="Email"></asp:RadioButton>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    <strong>
                   <%=MoreAll.Other.website() %> == <%=MoreAll.MoreAll.RequestUrl(Request.Url.Authority) %></strong>
                </td>
            </tr>
          <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Website
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtwebsite" runat="server" Width="752px" Height="150px" TextMode="MultiLine"  ></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td>
                </td>
                <td style=" height:10px">
                </td>
                <td>
                </td>
            </tr>
                   <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Redirect website
                </td>
                <td>
                    <asp:TextBox CssClass="txt_css" ID="txtRedirect" runat="server" Width="752px" Height="50px" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                </td>
                    <td style="text-transform: uppercase">
                    <img src="/Resources/admin/images/bullet-red.png" border="0" />
                    <strong>Kích hoạt thông báo</strong>
                </td>
                <td>
                     <asp:RadioButton ID="Thongbao1" runat="server" Text="Không hoạt thông báo vi phạm" GroupName="co" Checked="true"></asp:RadioButton>
                     <asp:RadioButton ID="Thongbao2" runat="server" Text="kích hoạt thông báo vi phạm - lấy nội dung của CKEditor" GroupName="co"></asp:RadioButton>
                     <asp:RadioButton ID="Thongbao3" runat="server" Text="Kích hoạt thông báo vi phạm - lấy nội dung trong code" GroupName="co"></asp:RadioButton>
                </td>
            </tr>
             <tr>
                <td>
                </td>
                <td style="padding-left: 15px">
                 Nọi dung vi phạm
                </td>
                <td>
               <CKEditor:CKEditorControl ID="txtcontent" runat="server" Toolbar="Basic"></CKEditor:CKEditorControl>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnsetup" runat="server" Text="Update" Font-Bold="True" Font-Size="8pt" OnClick="btnsetup_Click" Width="123px"></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>