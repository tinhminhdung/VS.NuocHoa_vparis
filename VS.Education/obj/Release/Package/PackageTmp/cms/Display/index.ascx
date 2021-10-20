<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="index.ascx.cs" Inherits="VS.E_Commerce.cms.Display.index" %>
<%@ Register Src="~/cms/Display/Menu_Xo.ascx" TagPrefix="uc1" TagName="Menu_Xo" %>
<section class="awe-section-1" id="awe-section-1">
    <div class="section_category_slider">
        <div class="container">
            <h2 class="hidden">Slider and Category</h2>
            <div class="row">
                <div class="col-lg-3 col-md-4 mb-5 hidden-xs hidden-sm aside-vetical-menu">
                    <aside class="blog-aside">
                        <div class="aside-content">
                            <div class="nav-category verticalmenu">
                                <ul class="nav vertical-nav">
                                    <uc1:Menu_Xo runat="server" ID="Menu_Xo" />
                                </ul>
                            </div>
                        </div>
                    </aside>
                </div>
                <div class="col-lg-9 col-md-9 col-xs-12 mt-4 wrap-slider-section">
                    <div class="home-slider owl-carousel" data-lg-items='1' data-md-items='1' data-sm-items='1' data-xs-items="1" data-margin='0' data-nav="true" data-dot="true">
                        <%=Advertisings.Ad_vertisings.ShowBanner("1") %>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</section>

<section class="awe-section-2" id="awe-section-2">
    <div class="section section-collection section-collection-3 section_collection_tab pt-4 pb-2">
        <div class="container">
            <div class="collection-border">
                <div class="collection-main">
                    <div class="row ">
                        <div class="col-lg-12 col-sm-12">
                            <div class="e-tabs not-dqtab ajax-tab-3" data-section="ajax-tab-3" data-view="grid_8">
                                <div class="row row-noGutter">
                                    <div class="col-sm-12">
                                        <div class="content">
                                            <div class="section-title">
                                                <ul class="tabs tabs-title ajax clearfix">
                                                    <li class="tab-link has-content" data-tab="tab-1" data-url="/san-pham-moi">
                                                        <span>Sản phẩm chiến lược</span>
                                                    </li>

                                                    <li class="tab-link has-content" data-tab="tab-2" data-url="/san-pham-hot">
                                                        <span>Sản phẩm hot</span>
                                                    </li>

                                                    <li class="tab-link has-content" data-tab="tab-3" data-url="/san-pham-noi-bat">
                                                        <span>Sản phẩm nổi bật</span>
                                                    </li>

                                                    <li class="tab-link has-content" data-tab="tab-4" data-url="/san-pham-khuyen-mai">
                                                        <span>Sản phẩm khuyến mại</span>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div>
                                                <div class="tab-1 tab-content">
                                                    <div class="products">
                                                        <div class="row">
                                                            <asp:Literal ID="ltrpsanphammoi" runat="server"></asp:Literal>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="tab-2 tab-content">
                                                    <div class="products">
                                                        <div class="row">
                                                            <asp:Literal ID="ltrpsanphamhot" runat="server"></asp:Literal>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="tab-3 tab-content">
                                                    <div class="products">
                                                        <div class="row">
                                                             <asp:Literal ID="ltrpsanphamnoibat" runat="server"></asp:Literal>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="tab-4 tab-content">
                                                    <div class="products">
                                                        <div class="row">
                                                            <asp:Literal ID="ltrpsanphamkhuyenmai" runat="server"></asp:Literal>
                                                          
                                                        </div>
                                                    </div>
                                                </div>
                                                <script>
                                                </script>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<asp:Literal ID="ltShowNhomsanpham" runat="server"></asp:Literal>
<section class="awe-section-6" id="awe-section-6">
    <div class="section section_testimonial" style="background-image: url(/Resources/images/sec_testimonial_image.jpg)">
        <div class="container">
            <div class="section-content">
                <div class="testimonial-slider owl-carousel" data-lg-items='1' data-md-items='1' data-sm-items='1' data-xs-items="1" data-dot="true" data-nav="true">
                    <asp:Literal ID="ltCamNhanKhachHang" EnableViewState="false" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</section>

<section class="awe-section-7" id="awe-section-7">
    <div class="section section_collection_3_col">
        <div class="container">
            <div class="d-md-flex justify-content-md-between">
                <asp:Literal ID="ltsanphammoi" EnableViewState="false" runat="server"></asp:Literal>
                <asp:Literal ID="ltsanphamxemnhieu" EnableViewState="false"  runat="server"></asp:Literal>
                <asp:Literal ID="ltsanphamMuaNhieu" EnableViewState="false" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</section>

<section class="awe-section-8" id="awe-section-8">
    <div class="section section_blog pt-4 pb-4">
        <div class="container">
            <div class="section-title">
                <h2>
                    <a href="/tin-tuc-new.html">Tin mới nhất</a>
                </h2>
            </div>
            <div class="section-content">
                <div class="blog-slider owl-carousel" data-lg-items='3' data-md-items='3' data-sm-items='2' data-xs-items="2" data-nav="true">
                    <asp:Literal ID="ltrpNews" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
</section>
