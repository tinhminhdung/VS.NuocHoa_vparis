<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Affiliate.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.Affiliate" %>
<script src="https://sp.zalo.me/plugins/sdk.js"></script>

<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title">Link Affiliate</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="">
                    <div class="form-group">
                        <div class="leftForm">
                            <b>
                                <p><i class="fa fa-share-alt" style="color:red" aria-hidden="true"></i> Link giới thiệu đăng ký thành viên</p>
                            </b>
                        </div>
                        <div style="clear: both;"></div>
                        <div class="thongbao1" style="display: none;">
                            <center>Đã coppy</center>
                        </div>

                        <div class="leftForm rightForm">
                            <asp:TextBox class="form-control" ID="txtlinkgioithieu"  data-clipboard-action="copy" data-clipboard-target="#Control1_Control_All1_ctl00_txtlinkgioithieu" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Literal ID="ltshare" runat="server"></asp:Literal>
                    </div>
                </div>
            </section>
        </section>
    </section>
</section>
<script src="/Resources/js/clipboard.min.js"></script>
<script language="JavaScript" type="text/javascript">
    var clipboard = new Clipboard('#Control1_Control_All1_ctl00_txtlinkgioithieu');
    clipboard.on('success', function (e) {
        $('.thongbao1').show();
        setTimeout(function () {
            $('.thongbao1').hide();
        }, 1000);
    });
</script>
