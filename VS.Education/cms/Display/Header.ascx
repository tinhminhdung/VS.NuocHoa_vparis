<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Header" %>
<%@ Register Src="~/cms/Display/AllPage/Box_search.ascx" TagPrefix="uc1" TagName="Box_search" %>
<%@ Register Src="~/cms/Display/Menu_Xo.ascx" TagPrefix="uc1" TagName="Menu_Xo" %>
<%@ Register Src="~/cms/Display/Page/MenuTop.ascx" TagPrefix="uc1" TagName="MenuTop" %>
<%@ Register Src="~/cms/Display/MMembers/XinChao.ascx" TagPrefix="uc1" TagName="XinChao" %>


<header class="header">
  <div class="topbar-mobile hidden-lg hidden-md text-center text-md-left">
    <div class="container">
      <i class="fa fa-mobile" style="font-size: 20px; display: inline-block; position: relative; transform: translateY(2px); margin-right: 5px;"></i>Hotline: <span>
        <a href="tel:<%=MoreAll.Other.Hotline().Replace(".", "").Replace(",", "") %>""><%=MoreAll.Other.Hotline() %></a>
      </span>
    </div>
  </div>
  <div class="topbar ">
    <div class="container">
      <div>
        <div class="row">
          <div class="col-sm-6 col-md-6 a-left">
            <ul class="list-inline f-left">
              <li>
                <p><%=MoreAll.Other.Giatri("txtSologan") %></p>
              </li>
            </ul>
          </div>
          <div class="col-sm-6 col-md-6">
            <div class="social-icons hidden-sm hidden-xs">
             <%=Advertisings.Ad_vertisings.Advertisings_A_Images("3") %>
            </div>
              <div style=" clear:both"></div>
              <uc1:XinChao runat="server" id="XinChao" />
          </div>
        </div>
      </div>
    </div>
  </div>

    <div style="clear:both"></div>
  <div class="container">
    <div class="header-content clearfix a-center">
      <div class="d-lg-flex align-items-center">
           <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
        <div class="logo Destop">
          <%=MoreAll.Banner.Banners() %>
        </div>
          <div class="logo Mobile">
          <%=Advertisings.Ad_vertisings.Advertisings_A_Images("7") %>
        </div>


               </div>
          <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="header-content-search hidden-xs hidden-sm">
                 <div class="header_search">
                    <div class="input-group search-bar d-flex" role="search">
                        <uc1:Box_search runat="server" ID="Box_search" />
                    </div>
                </div>
                </div>
                   <div class="header-content-medium hidden-sm hidden-xs">
          <div class="Giohang ">
             <a class="" href="/gio-hang.html">
                  <span class="giohang"> <i class="fa fa-shopping-bag"></i>Giỏ hàng <%--<span class="soluonggiohang"><%=Services.SessionCarts.LoadCart() %></span>--%></span>
                </a>
          </div>
        </div>
        </div>
        
          </div>
      </div>
    </div>
    <div class="menu-bar hidden-md hidden-lg">
        <div class="menu-button"><img src='/Resources/assets/menu-bar709e.png' alt='menu bar' /></div>
    </div>
    <div class="icon-cart-mobile hidden-md hidden-lg f-left absolute">
      <div class="icon relative">
           <a class="" href="/gio-hang.html">
        <i class="fa fa-shopping-bag"></i>
    <%--    <span class="cartCount count_item_pr"><%=Services.SessionCarts.LoadCart() %></span>--%>
                  </a>
      </div>
    </div>
  </div>
  <nav class="Destop">
    <div class="container">
      <div>
        <div class="row">
          <div class="col-lg-3 col-md-4 col-sm-12 col-xs-12 vertical-menu-home padding-small aside-vetical-menu">
            <div id="section-verticalmenu" class="block block-verticalmenu float-vertical float-vertical-left">
              <div class="bg-vertical"></div>
              <h4 class="block-title float-vertical-button">
                <span class="verticalMenu-toggle"></span>
                <span class="verticalMenu-text">Danh mục sản phẩm</span>
              </h4>
              <div class="block_content aside-content ">
                <div id="verticalmenu" class="verticalmenu nav-category " role="navigation">
                  <ul class="nav vertical-nav">
                          <uc1:Menu_Xo runat="server" id="Menu_Xo" />
                  </ul>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-9 col-md-8 col-sm-12 col-xs-12 p-0 nav-menu-main hidden-sm hidden-xs">
            <div class="Menu">
                <ul>
                <uc1:MenuTop runat="server" ID="MenuTop" />
                    </ul>
        </div>
      </div>
    </div>
          </div>
        </div>
  </nav>
</header>


<div class="Mobile">

<nav>
<ul data-breakpoint="1025" class="flexnav">
<uc1:MenuTop runat="server" ID="MenuTop1" />
</ul>
</nav>
</div>
<%--<div id="menu_home" class="Mobile">
  <ul>
       <%=Advertisings.Ad_vertisings.Showicon1("5") %>
       <%=Advertisings.Ad_vertisings.Showicon2("6") %>
  </ul>
</div>--%>

