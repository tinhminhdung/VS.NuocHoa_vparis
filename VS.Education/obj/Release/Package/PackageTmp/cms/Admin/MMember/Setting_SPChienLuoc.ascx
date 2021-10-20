<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Setting_SPChienLuoc.ascx.cs" Inherits="VS.ECommerce_MVC.cms.Admin.MMember.Setting_SPChienLuoc" %>
<div id="cph_Main_ContentPane">
    <div class="Block Breadcrumb ui-widget-content ui-corner-top ui-corner-bottom" id="Breadcrumb">
        <ul>
            <li class="SecondLast"><a href="/admin.aspx"><i style="font-size: 14px;" class="icon-home"></i>Trang chủ</a></li>
            <li class="Last"><span>Cấu hình hoa hồng chiến lược</span></li>
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
                                <h4><i class="icon-reorder"></i>Cấu hình hoa hồng chiến lược</h4>
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
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trực Tiếp
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtHoaHongTrucTiep" runat="server" CssClass="txt" Width="50px">10</asp:TextBox>
                                            </td>
                                        </tr>
                                      <tr style="display:none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 1
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang1" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr style="display:none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 2
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang2" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display:none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 3
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang3" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display:none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 4
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang4" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr style="display:none">
                                            <td style="padding-left: 15px">Hoa Hồng Tầng 5
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="txtTang5" runat="server" CssClass="txt" Width="50px">120</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display:none">
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

                                        
                                         <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trưởng nhóm KD
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TruongNhomKDCL" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Trưởng phòng kinh doanh
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="TruongPhongKinhDoanhCL" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Giám đốc kinh doanh
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="GiamDocKinhDoanhCL" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td style="padding-left: 15px">Hoa Hồng Giám đốc kinh doanh Cao cấp
                                            </td>
                                            <td></td>
                                            <td>
                                                <asp:TextBox ID="GiamDocKinhDoanhCaoCapCL" runat="server" CssClass="txt" Width="50px">5</asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr style="height: 7px;">
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td></td>
                                            <td>
                                                <asp:LinkButton ID="btnsetup" runat="server" OnClick="btnsetup_Click"  CssClass="btn btn-primary"  style="background:#ed1c24"> <i class="icon-save"></i> Cập nhật </asp:LinkButton>
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
