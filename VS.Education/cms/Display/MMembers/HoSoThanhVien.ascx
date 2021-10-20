<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoSoThanhVien.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.HoSoThanhVien" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Hồ sơ thành viên</h1>
                <p>Cập nhật thông tin để hoàn thiện hồ sơ.</p>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <div class="thongbaoss">
                        <asp:Label ID="ltmsg" runat="server" ForeColor="Red"></asp:Label></div>
                    <div class="frm-add" style="padding: 10px">
                        <div class="gachke">
                            <div class="tenthanhvien"><%=label("l_name")%> :</div>
                            <div>
                                <asp:TextBox CssClass='contact3' ID="txtname" runat="server" Width="358px"></asp:TextBox></div>
                        </div>
                       <%-- <div class="gachke">
                            <div class="tenthanhvien"><%=label("lt_birthday") %></div>
                            <div>
                                <asp:TextBox CssClass='contact3' ID="txtbirthday" runat="server" Width="358px"></asp:TextBox>
                                <span style="font-size: 7pt; font-family: Tahoma">(yyyy-mm-dd)</span><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtbirthday"></cc1:CalendarExtender>
                            </div>
                        </div>--%>
                        <div class="gachke">
                            <div class="tenthanhvien"><%=label("l_address") %></div>
                            <div>
                                <asp:TextBox CssClass='contact3' ID="txtaddress" runat="server" Width="358px"></asp:TextBox></div>
                        </div>
                        <div class="gachke">
                            <div class="tenthanhvien">Email</div>
                            <div>
                                <asp:TextBox CssClass='contact3' ID="txtemail" runat="server" Width="358px"></asp:TextBox></div>
                        </div>
                        <div class="gachke">
                            <div class="tenthanhvien"><%=label("l_phone")%></div>
                            <div>
                                <asp:TextBox CssClass='contact3' ID="txtphone" runat="server" Width="358px"></asp:TextBox></div>
                        </div>
                       <%-- <div class="gachke" style="display: none">
                            <div class="tenthanhvien">Ảnh đại diện</div>
                            <div>
                                <asp:FileUpload ID="flavatar" runat="server" CssClass="contact3" Height="20px" Width="250px" /><br />
                                <div class="adaidien">
                                    <asp:Literal ID="ltimg" runat="server"></asp:Literal></div>
                            </div>
                        </div>--%>
                         <div class="gachke">
                            <div class="tenthanhvien">&nbsp; &nbsp; </div>
                            <div>
                                <asp:Button ID="btnsave" ValidationGroup="GInfo" runat="server" CssClass="btnadd" Text="Cập nhật" style=" color:#fff" OnClick="btnsave_Click" />
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdid" runat="server" />
                    <asp:HiddenField ID="hdimg" runat="server" />
                </div>
            </section>
        </section>
    </section>
</section>
