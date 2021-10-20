<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Detail" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<link href="/cms/Display/Products/Resources/Style.css" rel="stylesheet" type="text/css" />
<script src="../../../Resources/js/jquery-1.7.1.min.js" type="text/javascript"></script>
<h2 style="display: none">
    <asp:Literal ID="ltcatename" runat="server"></asp:Literal></h2>
<section class="product ">
    <div class="container">
        <div class="row">

            <div class="main_container collection col-lg-9 col-lg-push-3">
                <div class="details-product">
                    <div class="tongctiet">
                        <div class="lefctiet">
                            <div class="sp-loading">
                                <img src="/Resources/images/sp-loading.gif" alt=""><br>
                                LOADING IMAGES
                            </div>
                            <div class="sp-wrap">
                                <%=Viewprodetail()%>
                            </div>
                        </div>
                        <div class="rightct">
                            <div class="prodetail">
                                <div class="ptitle">
                                    <h1>
                                        <asp:Literal ID="ltname" runat="server"></asp:Literal></h1>
                                </div>
                                <div class="dptime">
                                    <div class="dptime">
                                        <span>Cập nhật cuối lúc: <b>
                                            <asp:Literal ID="ltdate" runat="server"></asp:Literal></b></span> ,
    <span style="margin-left: 12px;">Đã xem: <b>
        <asp:Literal ID="ltxem" runat="server"></asp:Literal></b> lượt</span>
                                    </div>

                                    <div class="clear"></div>
                                    <div class="pdid">
                                        Mã sản phẩm: <span class="prdid">
                                            <asp:Literal ID="ltcode" runat="server"></asp:Literal></span>
                                    </div>
                                    <div class="pdid" style="display: none">
                                        Thương hiệu: <span class="prdid">
                                            <asp:Literal ID="ltthuonghieu" runat="server"></asp:Literal></span>
                                    </div>
                                    <p class="price_old" style="display: none">
                                        Giá thị trường: <span>
                                            <asp:Literal ID="ltpriceoll" runat="server"></asp:Literal>
                                            đ</span>
                                    </p>
                                    <div class="price">
                                        <span class="newprice"><span>Giá:</span>
                                            <asp:Literal ID="ltprice" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                    <div class="clear"></div>

                                    <div class="pdid boders">
                                        <asp:Literal ID="ltdesc" runat="server"></asp:Literal>
                                    </div>

                                    <div class="tonnng">
                                        <p class="prod_text">
                                            <span>Số lượng:</span>
                                            <asp:TextBox ID="txtproQuantity" Style="width: 49px;height: 43px;margin-top: 3px;text-align: center;border: 1px solid #000000;" Text="1" runat="server">1</asp:TextBox>
                                        </p>
                                        <div class="frmbuy">
                                            <asp:Panel ID="Panel1"  runat="server">
                                            <asp:LinkButton CssClass="btn-style-buynow" ID="lnkaddtocart" runat="server" OnClick="lnkaddtocart_Click">Đặt hàng ngay</asp:LinkButton>
                                            </asp:Panel>
                                             <asp:Panel ID="Panel2" Visible="false" runat="server">
                                                 <a class="btn-style-buynow" onclick="ThongBaos()">Đặt hàng ngay</a>
                                             </asp:Panel>
                                        </div>
                                    </div>

                                    <div class="clear" style="clear: both; height: 5px"></div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear" style="clear: both; height: 5px"></div>
                    <asp:Literal ID="ltshares" runat="server"></asp:Literal>
                    <div class="clear" style="clear: both; height: 5px"></div>

                    <div class="Chitietsp">Chi tiết sản phẩm</div>
                    <div class="dangky">
                        <div class="trai"></div>
                        <div class="phai"></div>
                    </div>
                    <div class="News-content">
                        <asp:Literal ID="ltdetail" runat="server"></asp:Literal>
                    </div>
                    <%if (MoreAll.Other.Giatri("Commentsp") == "1")
                      { %>
                    <div class="shares">
                        <div class="fb-comments" data-href="<%=MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) %>" data-width="100%" data-numposts="5" data-colorscheme="light"></div>
                    </div>
                    <%} %>

                    <div class="clear"></div>

                </div>
            </div>
            <uc1:Lefmenu runat="server" ID="Lefmenu" />
        </div>
    </div>

    <section class="section featured-product wow fadeInUp mb-4">
        <div class="container">
            <div>
                <div class="title">
                    <h2 class="margin-bottom-20">
                        <a href="#" title="Sản phẩm liên quan">Sản phẩm liên quan</a>
                    </h2>
                </div>
                <div class="category-products products">
                    <section class="products-view products-view-grid">
                        <div class="row">

                            <asp:Repeater ID="rpcates" runat="server">
                                <ItemTemplate>
                                    <div class="col-xs-6 col-xss-6 col-sm-4 col-md-4 col-lg-4">
                                        <div class="product-box product-box-theme">
                                            <div class="variants margin-bottom-0">
                                                <div class="product-thumbnail">
                                                    <a href='/<%#Eval("TangName")%>.html' title="<%#Eval("Name")%>"><%#MoreAll.MorePro.Image_Title_Alt(Eval("ImagesSmall").ToString(), Eval("Name").ToString(), Eval("Name").ToString())%></a>
                                                </div>
                                            </div>

                                            <div class="product-info">
                                                <h3 class="product-name">
                                                    <a href='/<%#Eval("TangName")%>.html' title="<%#Eval("Name")%>"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></a>
                                                </h3>
                                                <div class="price-box clearfix">
                                                    <div class="special-price">
                                                        <span class="price product-price"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%></span>
                                                    </div>
                                                </div>
                                                <div class="hidden-xs">
                                                    <a class="btn-buy btn-cart btn btn-primary " href="/cms/display/Products/AddToCart.aspx?ipid=<%#Eval("ipid")%>" title="Đặt hàng">+ Vào giỏ hàng </a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </section>
                </div>
            </div>
            <!-- /.home-owl-carousel -->
        </div>
    </section>
</section>



<asp:HiddenField ID="hdTrangThai" Value="1" runat="server" />
<asp:HiddenField ID="hdCurAmount" Value="1" runat="server" />
<asp:HiddenField ID="hdipid" Value="1" runat="server" />

<asp:Literal ID="ltmsg" runat="server"></asp:Literal>


<script> function ThongBaos() { $.toast({ heading: 'Thông báo', text: 'Thông báo vui lòng không đặt mua chung sản phẩm chiến lược và sản phẩm thông thường.<br /> Bạn đặt mua đơn sản phẩm chiến lược riêng và sản phẩm thông thường riêng', showHideTransition: 'fade', icon: 'error' }) }</script>