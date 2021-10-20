<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViDiem.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.ViDiem" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
                <h1 class="title-head page_title" style="margin-bottom:10px">Ví tiền thành viên</h1>
            </div>
            <section class="list-blogs blog-main ">
                <div class="">

                    <div style="clear: both"></div>
                    <div class="main-item total-point">
                        <label>Affiliate Url: </label>
                        <br />
                         <asp:TextBox class="form-control" ID="txtlinkgioithieu"  runat="server"></asp:TextBox>
                        <div class="affiliate_url_copy" onclick="affiliate_url_copy()">Click to copy</div>
                    </div>
                    <div style="clear: both; height:20px"></div>

                    <asp:Literal ID="ltthongbao" runat="server"></asp:Literal>
                    <div class="congtongvuietien">

                        <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Tổng tiền</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="lttongtien" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Tiền hoa hồng + Tiền tầng  </div>
                                </div>
                            </div>
                        </div>
                           <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Ví thưởng</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="ltvivip" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Sẽ trừ dần vào mua hàng </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Đã rút</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="lttongtiendarut" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Tổng tiền đã rút </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Khách hàng đã mua hàng</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="ltttongF1" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Tổng thành viên trực tiếp </div>
                                </div>
                            </div>
                        </div>

                         <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Khách hàng chưa mua hàng</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="ltttongF11" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Tổng thành viên trực tiếp </div>
                                </div>
                            </div>
                        </div>
                       

                         <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title">Thành viên trong đội nhóm</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="lttongthanhvien" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Thành viên trong đội nhóm</div>
                                </div>
                            </div>
                        </div>

                          <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title" style=" text-align:center">Cấp bậc</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3">
                                        <asp:Literal ID="ltcapbac" runat="server"></asp:Literal></h1>
                                    <div class="mb-0">Cấp bậc kinh doanh</div>
                                </div>
                            </div>
                        </div>

                           <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card" style=" background:#ffbc00">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title" style=" text-align:center">Cổ phần</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" style="color: #fff"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3" style="color:#fff">
                                        <asp:Literal ID="ltcophan" runat="server"></asp:Literal></h1>
                                    <div class="mb-0"  style="color:#fff">Tổng số cổ phần</div>
                                </div>
                            </div>
                        </div>

                         <div class="col-xs-6 col-sm-12 col-md-3 vithanhtoan">
                            <div class="card" >
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col mt-0">
                                            <h5 class="card-title" style=" text-align:center">VPR-S</h5>
                                        </div>
                                        <div class="col-auto">
                                            <div class="avatar">
                                                <div class="avatar-title rounded-circle bg-primary-dark">
                                                    <i class="fa fa-credit-card" ></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <h1 class="display-5 mt-1 mb-3"><asp:Literal ID="ltViCoPhanSo" runat="server"></asp:Literal></h1>
                                  <%--  <div class="mb-0"  style="color:#fff">Tổng số cổ phần</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="clear: both"></div>

                </div>
            </section>
        </section>
    </section>
</section>

<script>
    function affiliate_url_copy() {
        var copyText = document.getElementById("Control1_Control_All1_ctl00_txtlinkgioithieu");
        copyText.select();
        copyText.setSelectionRange(0, 99999);
        document.execCommand("copy");
        alert("Coppy link thành công: " + copyText.value);
    }
</script>
