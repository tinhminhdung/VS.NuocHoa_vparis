<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="XinChao.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.XinChao" %>
<asp:Panel ID="Panel1" runat="server">
    <a href="/dang-nhap.html">Đăng nhập</a>  |  <a href="/dang-ky.html">Đăng ký</a>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
    <div class="dropdowndestop">
        <div onclick="ShowthanhvienDT()" class="sdropbtn">
            <b class="thanhvienxcc">Xin Chào: 
                <asp:Literal ID="ltwelcome" runat="server"></asp:Literal></b> |
            <asp:LinkButton ID="lnkdangxuat" Style="color: #ed1c24" runat="server" OnClick="lnkdangxuat_Click"> Thoát</asp:LinkButton>
        </div>
        <asp:Literal ID="ltThanhvienaglang" runat="server"></asp:Literal>
        <div id="myDropdownDestop" class="dropdowndestop-content" style="display: none">
            <div><a href="/Vi-diem.html"><i class="fa fa-credit-card"></i>Ví tiền của bạn </a></div>
            <div><a href="/rut-tien.html"><i class="fa fa-credit-card"></i>Rút điểm</a></div>
            <div><a href="/lich-su-cap-diem.html"><i class="fa fa-gift"></i>Lịch sử cấp điểm</a></div>
            <div><a href="/lich-su-rut-tien.html"><i class="fa fa-credit-card"></i>Lịch sử rút điểm</a></div>
            <div><a href="/lich-su-mua-hang.html"><i class="fa fa-clock-o"></i>Lịch sử mua hàng </a></div>
            <div><a href="/hoa-hong.html"><i class="fa fa-gift"></i>Danh sách hoa hồng</a></div>
            <div><a href="/ls-quy-doi-vi-vprs.html"><i class="fa fa-gift"></i>Lịch sử quy đổi ví VPR-S</a></div>
            <div><a href="/quy-doi-vi-vprs.html"><i class="fa fa-gift"></i>Quy đổi ví VPR-S</a></div>
            <div><a href="/danh-sach-thanh-vien.html"><i class="fa fa-gift"></i>Danh sách thành viên</a></div>
            <div><a href="/link-affiliate.html"><i class="fa fa-share-alt"></i>Link giới thiêụ</a></div>
            <div><a href="/ho-so-thanh-vien.html"><i class="fa fa-user"></i>Quản lý hồ sơ</a></div>
            <div><a href="/thay-doi-mat-khau.html"><i class="fa fa-cogs"></i>Đổi mật khẩu</a></div>
            <div>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-cogs"></i>   [Đăng xuất]</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Panel>
