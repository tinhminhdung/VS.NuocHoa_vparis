<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="VS.E_Commerce.cms.Display.News.Category1" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container">
    <div class="row">
        <section class="main_container collection col-lg-9 col-lg-push-3">
            <div class="box-heading relative">
                <h1 class="title-head page_title"> <asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="row">
                    <asp:Repeater ID="rpcates" runat="server">
                        <ItemTemplate>
                            <div class="col-xs-12 col-sm-6">
                                <article class="blog-item">
                                    <div class="blog-item-thumbnail">
                                        <a href="<%#Eval("TangName")%>.html"><%#MoreAll.MoreNews.Image_Title_Alt(Eval("ImagesSmall").ToString(), Eval("Title").ToString(), Eval("Title").ToString())%></a>
                                        <div class="post-time">
                                            <span class="ngay"><%#MoreAll.MoreAll.Date_ngay(Eval("Create_Date").ToString())%></span>
                                            <br>
                                            <span class="thang"><%#MoreAll.MoreAll.Date_Thang(Eval("Create_Date").ToString())%></span>
                                        </div>
                                    </div>
                                    <div class="blog-item-info">
                                        <h3 class="blog-item-name">
                                            <a href="<%#Eval("TangName")%>.html"><%#MoreAll.MoreNews.Substring_Title(Eval("Title").ToString())%></a>
                                        </h3>
                                        <div class="is-divider"></div>
                                        <p class="blog-item-summary"><%#MoreAll.MoreNews.Substring_Mota(Eval("Brief").ToString())%></p>
                                    </div>
                                </article>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="lterr" runat="server"></asp:Literal>
                    <div class="pager" style="margin-left: 10px; margin-right: 10px; color: #999;">
                        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                            BackText="◄" ShowFirstLast="True" ResultsLocation="None" PagingMode="PostBack" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;color:red" LabelText="" LastText="Cuối cùng" NextText="►" PageNumbersDisplay="Numbers"
                            ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="FONT-WEIGHT: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="&nbsp;">
                        </cc1:CollectionPager>
                    </div>

                </div>
            </section>
        </section>
        <uc1:Lefmenu runat="server" ID="Lefmenu" />
    </div>
</div>




