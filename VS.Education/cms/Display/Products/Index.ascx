<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Index.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Index" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading kv-title-head relative">
                <h1 class="title-head margin-top-0 margin-bottom-0"><asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
            </div>
            <div class="category-products products">
                <section class="products-view products-view-grid">
                    <div class="row">
                        <div class="News-content">
                            <div class="contents">
                                <asp:Literal ID="ltcontent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        
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
                        <div style="clear: both"></div>
                        <asp:Literal ID="lterr" runat="server"></asp:Literal>
                        <div class="pager" style="margin-left: 10px; margin-right: 10px; color: #999;">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                                BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers"
                                ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
                            </cc1:CollectionPager>
                        </div>


                    </div>
                    <div class="text-center"></div>
                </section>
            </div>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>
