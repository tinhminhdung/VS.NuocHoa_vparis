<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuyDoiVPRS.ascx.cs" Inherits="VS.E_Commerce.cms.Display.MMembers.QuyDoiVPRS" %>
<section class="container">
    <section class="">
        <section class="main_container ">
            <div class="box-heading relative">
            </div>
            <section class="list-blogs blog-main ">
                <div class="">

                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                    <div class="congtongvuietien">

                        <div class="col-xs-12 col-sm-12 col-md-6 " id="TongTienQuyDoiss">
                            <div class="card">
                                <div class="card-body">
                                    <div class="row Quydoi">
                                        <div class="col mt-0">
                                            <h5 class="card-title" style=" color:#ed1c24; text-align:center">QUY ĐỔI TỪ VÍ CHÍNH SANG VÍ VPR-S</h5>
                                        </div>
                                        <div class="col-auto Tongcccc">
                                           <div  class="uiddd">Số tiền hiện tại: <asp:Literal ID="ltTongtien" runat="server"></asp:Literal> VNĐ</div>
                                           <div  class="uiddd" style=" color:red">     Số tiền cần quy đổi: <asp:TextBox ID="TongTienQuyDoi" placeholder="Nhập số tiền cần quy đổi"  CssClass="TongTienQuyDoi required" runat="server"></asp:TextBox></div>
                                            <div  class="uiddd"><asp:Button OnClientClick="return SendTuVan();" ID="btQuyDoiTien" OnClick="btQuyDoiTien_Click" class="btnaddqq" runat="server" Text="Quy đổi tiền" /></div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                           <div class="col-xs-12 col-sm-12 col-md-6 " id="TongTienQuyDoiCP">
                            <div class="card">
                                <div class="card-body">
                                      <div class="row Quydoicp">
                                        <div class="col mt-0">
                                            <h5 class="card-title" style=" color:#ed1c24; text-align:center">QUY ĐỔI TỪ SỐ CỔ PHẦN SANG VÍ VPR-S</h5>
                                        </div>
                                        <div class="col-auto Tongcccc">
                                           <div  class="uidddcp">Số cổ phần hiện tại: <asp:Literal ID="ltCoPhan" runat="server"></asp:Literal> cổ phần</div>
                                           <div  class="uidddcp" style=" color:red"> Số cổ phần quy đổi: <asp:TextBox ID="TongCoPhan" placeholder="Nhập cổ phần cần quy đổi"  CssClass="TongTienQuyDoi required" runat="server"></asp:TextBox></div>
                                            <div  class="uidddcp"><asp:Button OnClientClick="return CPSendTuVan();" ID="btQuyDoiCoPhan" OnClick="btQuyDoiCoPhan_Click" class="btnaddqq" runat="server" Text="Quy đổi cổ phần" /></div>
                                        </div>
                                    </div>
                                   
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

<style>
    .Quydoi{ background:#a9cde7}
</style>

<br /><br /><br />
<asp:HiddenField ID="hdtongtien" Visible="false" Value="0" runat="server" />

<asp:HiddenField ID="hdtongcophan" Visible="false" Value="0" runat="server" />
 <script type="text/javascript">
     function SendTuVan() {
         var obError = undefined;
         $("#TongTienQuyDoiss .required").each(function () {
             $(this).removeClass("boxFocus");
             if (obError == undefined && $(this).val() === '') {
                 obError = $(this);
                 return false;
             }
         });

         if (obError != undefined) {
             obError.focus();
             obError.addClass("boxFocus");
             alert("Vui lòng nhập số tiền cần quy đổi");
             return false;
         }

     };
     function CPSendTuVan() {
         var obError = undefined;
         $("#TongTienQuyDoiCP .required").each(function () {
             $(this).removeClass("boxFocus");
             if (obError == undefined && $(this).val() === '') {
                 obError = $(this);
                 return false;
             }
         });

         if (obError != undefined) {
             obError.focus();
             obError.addClass("boxFocus");
             alert("Vui lòng nhập số cổ phần cần quy đổi");
             return false;
         }

     };
     
    </script>
