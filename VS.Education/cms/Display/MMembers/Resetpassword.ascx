<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Resetpassword.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.Resetpassword" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Lấy lại mật khẩu</h1>
                <p>Chúng tôi sẽ gửi thông tin lấy lại mật khẩu vào email đăng ký tài khoản của bạn</p>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                    <div class="frm-add">
                                        <div style="width: 100%; margin-left: 20px">
                                            <div style="padding-left: 20px; padding-left: 20px; clear: both; padding-top: 10px;">
                                                <asp:Label ID="ltmsg" runat="server" ForeColor="Red"></asp:Label></div>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                                <ProgressTemplate>
                                                    <img src="/Resources/admin/images/loading.gif" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <div>
                                                <div class="labelll">
                                                    Email của bạn:
                                                </div>
                                                <div>
                                                    <asp:TextBox ID="txtemail" runat="server" ValidationGroup="GInfo" class="textarea"></asp:TextBox>
                                                    <span style="font-size: 7pt; color: #ff7f50; font-family: Tahoma">*</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtemail" Display="Dynamic" ErrorMessage="Email không được để trống !" SetFocusOnError="True" ValidationGroup="GInfo"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RequiredFieldValidator4" ValidationGroup="GInfo" runat="server" ControlToValidate="txtemail" ErrorMessage="Vui lòng nhập một địa chỉ email hợp lệ." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="valRegExResource1"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-left: 20px; padding-left: 20px; clear: both; padding-top: 10px;">
                                        <asp:Button ID="btnresets" ValidationGroup="GInfo" runat="server" CssClass="btnadd" OnClick="btnregisters_Click" Text="Lấy lại mật khẩu" />
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <div style="line-height: 22px; padding: 10px">
                                        <div>
                                            <asp:Literal ID="ltresult" runat="server"></asp:Literal></div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnresets" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </section>
        </section>
    </section>
</section>
