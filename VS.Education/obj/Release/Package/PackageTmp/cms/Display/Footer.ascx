<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Footer" %>
<%@ Register Src="~/cms/Display/Page/MenuBottom.ascx" TagPrefix="uc1" TagName="MenuBottom" %>
<%@ Register Src="~/cms/Display/AllPage/Box_Facebook.ascx" TagPrefix="uc1" TagName="Box_Facebook" %>
<%@ Register Src="~/cms/Display/AllPage/Box_Hotline.ascx" TagPrefix="uc1" TagName="Box_Hotline" %>


<footer class="footer">
    <div class="content">
        <div class="site-footer">
            <div class="footer-inner padding-top-35 pb-lg-5">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-lg-5">
                            <div class="footer-widget contact active">
							<br/><br/>
                                <h3 class="hastog"><span>Liên hệ</span></h3>
                                <ul class="list-menu list-showroom">
                                    <div class="chantrang"> <asp:Literal ID="ltfootercontent" runat="server"></asp:Literal></div>
                                </ul>
                            </div>
                        </div>
                        <uc1:MenuBottom runat="server" ID="MenuBottom" />

                        <div class="col-xs-12 col-sm-6 col-lg-3">
                            <div class="footer-widget">

                                <h3 class="margin-bottom-20 hastog" style='display:none'><span>Kết nối với chúng tôi</span></h3>
                                <div class="list-menu">

                                    <div class="footerText">
                                        <uc1:Box_Facebook runat="server" ID="Box_Facebook" />
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</footer>
<uc1:Box_Hotline runat="server" ID="Box_Hotline" />
