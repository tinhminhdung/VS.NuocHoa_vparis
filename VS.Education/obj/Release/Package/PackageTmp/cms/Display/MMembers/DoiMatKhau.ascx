<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoiMatKhau.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.DoiMatKhau" %>

<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Đổi mật khẩu</h1>
                <p>Vui lòng điển đẩy đủ thông tin để đổi lại mật khẩu.</p>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div style="padding-left: 20px; padding-left: 140px; clear: both; padding-top: 10px;">
                                <asp:Label ID="ltmsg" runat="server" ForeColor="Red"></asp:Label></div>
                            <div class="frm-add" style="padding: 10px">
                                <div class="gachke">
                                    <div class="tenthanhvien">
                                        <%=label("lt_oldpassword")%>
                                    </div>
                                    <div>
                                        <asp:TextBox CssClass='contact3' ID="txtcurrentpass" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GInfo" ControlToValidate="txtcurrentpass" ErrorMessage="Mật khẩu không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien">
                                        <%=label("lt_newpassword") %>
                                    </div>
                                    <div>
                                        <asp:TextBox CssClass='contact3' ID="txtnewpassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="GInfo" ControlToValidate="txtnewpassword" ErrorMessage="Mật khẩu không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="gachke">
                                    <div class="tenthanhvien" style="">
                                        <%=label("lt_checkpassword")%>
                                    </div>
                                    <div>
                                        <asp:TextBox CssClass='contact3' ID="txtnewpasswordconfirm" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="GInfo" ControlToValidate="txtnewpasswordconfirm" ErrorMessage="Mật khẩu không được để trống !"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                 <div class="gachke">
                                    <div class="tenthanhvien" style="">
                                      &nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div>
                                          <asp:Button ID="btnchangepassword" ValidationGroup="GInfo" runat="server" CssClass="btnadd" style="color:#fff" Text="Đổi mật khẩu" OnClick="btnchangepassword_Click" />
                                    </div>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </section>
        </section>
    </section>
</section>
