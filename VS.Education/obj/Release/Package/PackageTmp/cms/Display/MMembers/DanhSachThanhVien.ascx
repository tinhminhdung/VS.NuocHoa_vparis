<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachThanhVien.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.DanhSachThanhVien" %>
<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title" style=" margin-bottom:10px">Danh sách thành viên cấp dưới</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="">
 <asp:LinkButton ID="lnkxuatExel" runat="server" OnClick="lnkxuatExel_Click" CssClass="vadd toolbar btn btn-info"> Xuất Exel</asp:LinkButton>
<div style="clear: both; height:5px"></div>
<div class="phanmucc"><b>phân mục cấp:</b> <asp:Literal ID="ltphanmuc" runat="server"></asp:Literal></div>
<div style="clear: both; height:5px"></div>
<div class="my-account">
    <div class="dashboard">
        <div class="recent-orders">
            <div class="table-responsive tab-all" style="overflow-x: auto;">
                  <table class="table table-striped table-bordered table-advance table-hover table table-cart lichsumuahang">
                    <thead class="thead-default">
                        <tr>
                            <th>STT</th>
                            <th>Thành viên</th>
                            <th style=" width: 200px; ">Địa chỉ</th>
                             <th style=" width: 200px; ">Điện thoại</th>
                             <th style=" width: 200px; ">Email</th>
                             <th>Ngày đăng ký</th>
                              <th>Tổng thành viên</th>
                             <th>Chi tiết</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rp_items" runat="server" >
                            <ItemTemplate>
                                <tr class="first odd">
                                    <td style="text-align: center"><%= i++ %></td>
                                    <td style="text-align: center"><%#Eval("HoVaTen") %></td>
                                    <td style="text-align: center"><%#Eval("DiaChi") %></td>
                                        <td style="text-align: center"><%#Eval("DienThoai") %></td>
                                    <td style="text-align: center"><%#Eval("Email") %></td>
                                    <td style="text-align: center"><%#Eval("NgayTao") %> </td>
                                      <td style="text-align: center"><%#TongThanhVien_Tree(Eval("id").ToString())%></td> 
                                    <td style="text-align: center"> 
                                         <a style="color:red" href="/Danh-sach-thanh-vien.html?ID=<%#DataBinder.Eval(Container.DataItem,"id")%>">[Chi tiết]</a>
                                     </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="text-xs-right">
            </div>
              <asp:Literal ID="ltShow" runat="server"></asp:Literal>
        <div style="clear: both;"></div>
        <div class="pager">
             <asp:Literal ID="ltpage" runat="server"></asp:Literal>
        </div>
            <div class="phantrang" style="">
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextDisplay="HyperLinks" BackNextLocation="Split"
                    BackText="<<" ShowFirstLast="True" ResultsLocation="Bottom" PagingMode="QueryString" MaxPages="50" FirstText="Trang đầu" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="font-weight: bold;color:red" LabelText="" LastText="Cuối cùng" NextText=">>" PageNumbersDisplay="Numbers"
                    ResultsFormat="Hiển thị từ  {0} Đến {1} (của {2})" ResultsStyle="padding-bottom:5px;padding-top:14px;font-weight: bold;" ShowLabel="False" ShowPageNumbers="True" BackNextStyle="font-weight: bold; margin: 14px;" ControlCssClass="" ControlStyle="" UseSlider="True" PageNumbersSeparator="">
                </cc1:CollectionPager>
            </div>
        </div>
    </div>
</div>
     <input id="hd_id" type="hidden" size="1" name="Hidden2" runat="server">
<asp:HiddenField ID="hdid" runat="server" />
                                  </div>
            </section>
        </section>
    </section>
</section>
