<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiaHoaHongCapBac.aspx.cs" Inherits="VS.E_Commerce.ChiaHoaHongCapBac" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=Commond.ShowTrangThai() %>
          <br />
        ccc:<%=CapBac.Kiemtratongcapbac("20") %>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" OnClick="Button1_Click1" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
