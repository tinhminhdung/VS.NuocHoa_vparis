<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.Setting" %>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cấu hình hoa hồng lợi nhuận</span></li>
        </ul>
    </div>
    <div style="clear: both;"></div>
    <div class="widget">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-reorder"></i>Cấu hình Hoa Hồng lợi nhuận</h4>
                            </div>
                            <div class="widget-body">
                                <div class='frm-add'>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="400px"></td>
                                            <td></td>
                                            <td>
                                                <strong><font color="#ed1f27"><asp:Literal ID="ltmsg" runat="server"></asp:Literal></font></strong>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình khác </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Số tiền được rút 200.000 VNĐ
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="SoTienDuocRut" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px">Đủ giới thiệu ra 5 F1 thì mới rút tiền
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="RutTien" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Điều kiện lên trưởng nhóm</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px">Điều kiện số 1 lên trưởng nhóm KD
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="DieuKienLenTruongNhomKD" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Điều kiện lên trưởng nhóm KD tính theo tổng số F1)</em></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Điều kiện số 2 lên trưởng nhóm KD
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="CauHinhTVCapDuoi" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Điều kiện lên trưởng nhóm KD phải ít nhất có 25 thành viên cấp dưới đã kích hoạt)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Thưởng tiền nóng tiền khi kiếm dc F1</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Thưởng tiền khi giới thiệu ra 3 F1
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TongSoF1" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Tổng số mấy F1 thì được thưởng tiền)</em></span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px">Tổng số F1 để được thưởng tiền
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TienThuongRa3F1" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Số tiền thưởng khi giới thiệu ra 3 F1)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>


                                         <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Thưởng số VPR-S khi kiếm dc F1</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Thưởng VPR-S khi giới thiệu ra 3 F1
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TongSoF1VPRS" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Tổng số mấy F1 thì được thưởng VPR-S)</em></span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="padding-left: 15px">Tổng số F1 để được thưởng VPR-S
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="VPRSThuongRa3F1" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Số VPR-S thưởng khi giới thiệu ra 3 F1)</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>


                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình Số cổ phần (VPR-S)</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Quy đổi từ (số cổ phần) sang ví (VPR-S) 
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="SoCoPhanVPRS" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Lấy số cổ phần Nhân với số cấu hình này = số cổ phần VPR-S)</em></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Quy đổi từ (Tổng tiền)  sang ví (VPR-S)
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="SoDuVPRS" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Lấy số tiền chia cho số cấu hình này = số cổ phần VPR-S)</em></span>
                                            </td>
                                        </tr>

                                         <tr>
                                            <td style="padding-left: 15px">Bật tắt Khi mua hàng được tặng VPR-S
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" GroupName="VPRS" Text="Bật  " />
                                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="VPRS" Text="Tắt" />
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Bật thì cho phép so sánh tổng tiền của đơn hàng và so sánh cấu hình Lịch sử quy đổi sang VPR-S để cho cổ phần</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình ví vip khi mua hàng</strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Giảm giá % Ví Vip
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="ViVipThuong" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Đơn hàng sẽ giảm giá trừ vào Ví Vip (Ví thưởng))</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Bật tắt mua hàng Ví Vip
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:RadioButton ID="Radio_ViVipCo" runat="server" Checked="true" GroupName="ViVip" Text="Bật  " />
                                                <asp:RadioButton ID="Radio_ViVipKhong" runat="server" GroupName="ViVip" Text="Tắt" />
                                                <span style="font-size: 8pt; color: #ed1c24"><em>(Bật thì cho phép Tổng tiền Sản phẩm chiến lược Trừ % theo cấu hình để trả hoa hồng (Ví thưởng))</em></span>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>


                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Hoa hồng tầng </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trực Tiếp
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtHoaHongTrucTiep" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 1
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang1" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 2
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang2" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 3
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang3" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 4
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang4" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 5
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang5" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 6
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang6" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng F2
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtF2" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng F3
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtF3" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng F4
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtF4" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng F5
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtF5" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr style="display: none">
                                            <td style="padding-left: 15px">Giá trị đơn hàng tối thiểu để rút tiền
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtgiatridonhang" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 294px">
                                                <strong style="text-transform: uppercase">
                                                    <img src="Resources/admin/images/bullet-red.png" border="0" />
                                                    Cấu hình cấp bậc </strong>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trưởng nhóm KD
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TruongNhomKDLN" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trưởng phòng kinh doanh
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TruongPhongKinhDoanhLN" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Giám đốc kinh doanh
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="GiamDocKinhDoanhLN" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Giám đốc kinh doanh Cao cấp
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="GiamDocKinhDoanhCaoCapLN" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click" CssClass="btn btn-primary" Style="background: #ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
