<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="index.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Allbums.index" %>
<%@ Register Src="~/cms/Display/Lefmenu.ascx" TagPrefix="uc1" TagName="Lefmenu" %>
<div class="container" itemscope="" itemtype="http://schema.org/Blog">
  <div class="row">
    <section class="right-content margin-bottom-50 col-md-9 col-md-push-3">
      <div class="box-heading relative">
        <h1 class="title-head page_title"><asp:Literal ID="ltcatename" runat="server"></asp:Literal></h1>
      </div>
      <section class="list-blogs ">
        <div class="row">
          <asp:Repeater ID="rpcates" runat="server">
            <ItemTemplate>
                <div class="nhomnhe">
                    <h2 class="title"><a href="/<%#Eval("TangName")%>.html"><%#MoreAll.MorePro.Substring_Title(Eval("Name").ToString())%></a></h2>
                </div>
                <div style="clear: both"></div>
                <ul class="Album ">
                    <asp:Repeater ID="Repeater2" DataSource='<%#AlbumInCate(Eval("id").ToString()) %>' runat="server">
                        <ItemTemplate>
                            <li class=" abcolmd">
                                <div class="abitem">
                                    <div class="img">
                                        <a title="<%#(Eval("Title").ToString())%>" href='/<%#Eval("TangName")%>.html'><%#MoreAll.MoreImage.Image_width_height_Title_Alt(Eval("ImagesSmall").ToString(), "195", "146", Eval("Title").ToString(), Eval("Title").ToString())%><div class="imghover"></div>
                                        </a>
                                    </div>
                                    <div class="tiemtitle">
                                        <h2><a title="<%#(Eval("Title").ToString())%>" href='/<%#Eval("TangName")%>.html'><%#Eval("Title") %></a></h2>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div style="clear: both"></div>
            </ItemTemplate>
        </asp:Repeater>
 
          
        </div>
      </section>
      <div class="row">
        <div class="col-xs-12 text-left"> </div>
      </div>
    </section>
    <uc1:Lefmenu runat="server" ID="Lefmenu" />
  </div>
</div>


       
