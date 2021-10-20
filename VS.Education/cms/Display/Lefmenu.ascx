<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Lefmenu.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Lefmenu" %>
<aside class="dqdt-sidebar sidebar left left-content col-lg-3 col-lg-pull-9">
    <aside class="aside-item sidebar-category collection-category">
        <%if (Case == "1" || Case == "2" || Request["su"] == "nws")
          { %>
        <div style="clear: both"></div>
        <div class="aside-title">
            <h2 class="title-head margin-top-0">
                <span>Danh mục tin tức</span>
            </h2>
        </div>
        <div class="Menulef">
            <%=ShowMenuNews() %>
        </div>
        <%}
          else if (Case == "5" || Case == "6" || Request["su"] == "Thuvien")
          {  %>
        <div style="clear: both"></div>
        <div class="aside-title">
            <h2 class="title-head margin-top-0">
                <span>Danh mục thư viện</span>
            </h2>
        </div>
        <div class="Menulef">
            <%=ShowAlbum() %>
        </div>
        <%}
          else if (Case == "7" || Case == "8" || Request["su"] == "Videos")
          {  %>
        <div style="clear: both"></div>
        <div class="aside-title">
            <h2 class="title-head margin-top-0">
                <span>Danh mục video</span>
            </h2>
        </div>
        <div class="Menulef">
            <%=ShowVideo() %>
        </div>
        <%}
          else
          {%>
        <div style="clear: both"></div>
        <div class="aside-title">
            <h2 class="title-head margin-top-0">
                <span>Danh mục sản phẩm</span>
            </h2>
        </div>
        <div class="Menulef">
            <%=ShowMenuProduts() %>
        </div>
        <%} %>
    </aside>
    <div style=" clear:both"></div>
    <div class="blog-aside aside-item">
        <div>
            <div class="aside-title mb-4">
                <h2 class="title-head"><a href="#">Tin mới nhất</a></h2>
            </div>
            <div class="aside-content">
                <div class="blog-list blog-image-list">
                    <asp:Repeater ID="rpcates" runat="server">
                        <ItemTemplate>
                            <div class="loop-blog">
                                <div class="thumb-left">
                                    <a href="/<%#Eval("TangName")%>.html">
                                        <img src="<%#Eval("ImagesSmall") %>" style="width: 100%;" alt="<%#Eval("Title")%>" class="img-responsive">
                                    </a>
                                </div>
                                <div class="name-right">
                                    <h3><a href="/<%#Eval("TangName")%>.html" title="<%#Eval("Title")%>"><%#Eval("Title")%></a></h3>
                                    <div class="post-time">
                                        <%#MoreAll.MoreAll.Date(Eval("Create_Date").ToString())%>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <div class="aside-item aside-mini-list-product mb-5">
        <div>
            <div class="aside-title">
                <h2 class="title-head">
                    <a href="#">Sản phẩm mới nhất</a>
                </h2>
            </div>
            <div class="aside-content related-product">
                <div class="product-mini-lists">
                    <div class="products">
                        <asp:Repeater ID="prPronews" runat="server">
                            <ItemTemplate>

                                <div class="row row-noGutter">
                                    <div class="col-sm-12">
                                        <div class="product-mini-item clearfix ">
                                            <div class="product-img relative">
                                                <a href="/<%#Eval("TangName")%>.html"><%#MoreAll.MoreImage.Image_width_height_Title_Alt(Eval("ImagesSmall").ToString(),"78","67", Eval("Name").ToString(), Eval("Name").ToString())%></a>
                                            </div>
                                            <div class="product-info">
                                                <h3>
                                                    <a href="/<%#Eval("TangName")%>.html" title="<%#Eval("Name")%>" class="product-name"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></a>
                                                </h3>
                                                <div class="price-box">
                                                    <div class="special-price">
                                                        <span class="price product-price"><%#MoreAll.MorePro.FormatMoney(Eval("Price").ToString())%> </span>
                                                    </div>
                                                    <!-- Giá -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <aside class="aside-item banner">
	<div class="aside-content">
		<%=Advertisings.Ad_vertisings.Advertisings_A_Images("2") %>
	</div>
</aside>
</aside>
