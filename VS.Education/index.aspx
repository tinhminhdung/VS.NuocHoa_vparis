<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="utf-8" CodeBehind="index.aspx.cs" Debug="true" Inherits="VS.E_Commerce.index1" ValidateRequest="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never" MaxPageStateFieldLength="40" EnableEventValidation="false" %>

<%@ Register Src="cms/display/Control.ascx" TagName="Control" TagPrefix="uc1" %>
<%@ Register Src="cms/display/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="cms/display/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<%--<%@ OutputCache VaryByParam="none" Duration="1"   %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=MoreAll.Templates.Templates.WebTitle(hp, Modul)%></title>
    <%--<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0">Dùng trường hợp không Zoom được--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="vi" lang="vi-VN">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta name='revisit-after' content='1 days' />
    <meta property="og:type" content="article" />
    <asp:Literal ID="ltFacebook" runat="server"></asp:Literal>
    <meta name="robots" content="index,follow,all" />

    <link href="/Resources/CssChuan/Css_All.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/CssAllPage/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Resources/assets/icon-font.min.css">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,300i,400,400i,500,500i,700,700i&amp;subset=vietnamese" rel="stylesheet">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link href='/Resources/assets/plugin.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/base.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/style.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/module.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/responsive.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/bootstrap-theme709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/style-theme.scss709e.css' rel='stylesheet' type='text/css' />
    <link href='/Resources/assets/responsive-update.scss709e.css' rel='stylesheet' type='text/css' />
    <script src='/Resources/assets/jquery-2.2.3.min709e.js' type='text/javascript'></script>
    <link href="/Resources/MenuChinh/css/Menu.css" rel="stylesheet" />
    <link href="/Resources/css/smoothproducts.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/Responsive/css/flexnav.css" rel="stylesheet" />
    <link href="/Resources/css/Mobile.css" rel="stylesheet" />
</head>
<body>
    <%--End Screen 2 ben --%>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Literal ID="ltShowbody" runat="server"></asp:Literal>
        <uc2:Header ID="Header1" runat="server" />
        <uc1:Control ID="Control1" runat="server" />
        <uc3:Footer ID="Footer1" runat="server" />
        <%=MoreAll.Other.Giatri("Livechat")%>
        <%if (Request["su"] == null && Modul == "")
          {%>
        <h1 style="display: none"><%=MoreAll.Other.Giatri("webname")%></h1>
        <%} %>
        <asp:HiddenField ID="dhShowTrangThai" Value="2" runat="server" />
    </form>
    <script type="text/javascript">
        $(document).ready(function ($) {
            if ($(window).width() >= 768) {
                SalesPop();
            }
        });
        function fisherYates(myArray) {
            var i = myArray.length, j, temp;
            if (i === 0) return false;
            while (--i) {
                j = Math.floor(Math.random() * (i + 1));
                temp = myArray[i];
                myArray[i] = myArray[j];
                myArray[j] = temp;
            }
        }
        var collection = new Array();
        fisherYates(collection);
        function SalesPop() {
            if ($('.jas-sale-pop').length < 0)
                return;
            setInterval(function () {
                $('.jas-sale-pop').fadeIn(function () {
                    $(this).removeClass('slideUp');
                }).delay(10000).fadeIn(function () {
                    var randomTime = ['1 phút', '2 phút', '3 phút', '4 phút', '5 phút', '6 phút', '7 phút', '8 phút', '9 phút', '10 phút', '11 phút', '12 phút', '13 phút', '14 phút', '15 phút', '16 phút', '17 phút', '18 phút', '19 phút', '20 phút', '21 phút', '22 phút', '23 phút', '24 phút', '25 phút', '26 phút', '27 phút', '28 phút', '29 phút', '30 phút', '31 phút', '32 phút', '33 phút', '34 phút', '35 phút', '36 phút', '37 phút', '38 phút', '39 phút', '40 phút', '41 phút', '42 phút', '43 phút', '44 phút', '45 phút', '46 phút', '47 phút', '48 phút', '49 phút', '50 phút', '51 phút', '52 phút', '53 phút', '54 phút', '55 phút', '56 phút', '57 phút', '58 phút', '59 phút', ],
                    randomTimeAgo = Math.floor(Math.random() * randomTime.length),
                    randomProduct = Math.floor(Math.random() * collection.length),
                    randomShowP = collection[randomProduct],
                    TimeAgo = randomTime[randomTimeAgo];
                    $(".jas-sale-pop").html(randomShowP);
                    $('.jas-sale-pop-timeago').text('Một khách hàng vừa đặt mua cách đây ' + TimeAgo);
                    $(this).addClass('slideUp');
                    $('.pe-7s-close').on('click', function () {
                        $('.jas-sale-pop').remove();
                    });
                }).delay(6000);
            }, 6000);
        }
    </script>

    <script src='/Resources/assets/option-selectors709e.js' type='text/javascript'></script>
    <script src='/Resources/assets/api.jquerya87f.js?4' type='text/javascript'></script>
    <script src='/Resources/assets/appear709e.js' type='text/javascript'></script>
    <script src='/Resources/assets/owl.carousel.min709e.js' type='text/javascript'></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--<script src='/Resources/assets/dl_function709e.js' type='text/javascript'></script>--%>
    <%--    <script src='/Resources/assets/dl_api709e.js' type='text/javascript'></script>
    <script src='/Resources/assets/rx-all-min709e.js' type='text/javascript'></script>
    <script src='/Resources/assets/quickview709e.js' type='text/javascript'></script>--%>
    <script src='/Resources/assets/dl_main709e.js' type='text/javascript'></script>
    <script src="/Resources/assets/jquery-ui.min.js"></script>
    <!-- Zoom Products -->
    <script type="text/javascript" src="/Resources/js/smoothproducts.min.js"></script>
    <script type="text/javascript">
        $('.sp-wrap').smoothproducts();
    </script>
    <script src="/Resources/Responsive/js/jquery.flexnav.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".flexnav").flexNav();
        });
    </script>
    <script type="text/javascript" charset="utf-8">
        function Showthanhvien() {
            var hidden = document.getElementById('myDropdown');
            if (hidden.style.display == 'none') {
                hidden.style.display = 'block';
            }
            else {
                hidden.style.display = 'none';
            }
        }
        function ShowthanhvienDT() {
            var hidden = document.getElementById('myDropdownDestop');
            if (hidden.style.display == 'none') {
                hidden.style.display = 'block';
                document.getElementById("overlay").style.display = "block";
            }
            else {
                hidden.style.display = 'none';
                document.getElementById("overlay").style.display = "none";
            }
        }
        $(document).ready(function () {
            $('#overlay').click(function () {
                var hidden = document.getElementById('myDropdownDestop');
                hidden.style.display = 'none';
                document.getElementById("overlay").style.display = "none";
                //  document.getElementById("mySidenav").style.width = "0";
                $('#overlay').fadeOut();
                return false;
            });
        });
    </script>
    <link href="/Resources/css/jquery.toast.css" rel="stylesheet" />
    <script src="/Resources/js/jquery.toast.js"></script>

  
    <script>

        function UpdateOrder(id, name, TrangThaidb) {
            var TrangThai = $('#dhShowTrangThai').val();
            if (TrangThai != 2) {
                if (TrangThaidb != TrangThai) {
                    $.toast({
                        heading: 'Thông báo',
                        text: 'Thông báo vui lòng không đặt mua chung sản phẩm chiến lược và sản phẩm thông thường.<br /> Bạn đặt mua đơn sản phẩm chiến lược riêng và sản phẩm thông thường riêng',
                        showHideTransition: 'fade',
                        icon: 'error'
                    })
                }
                else if (TrangThaidb == TrangThai) {
                    var numPro = "#" + id;
                    $.ajax({
                        type: "POST",
                        url: "/index.aspx/Up_Order",
                        data: "{id:'" + id.toString() + "',quantity:'1'}",
                        contentType: "application/json; charset=utf-8",
                        datatype: "json",
                        async: "true",
                        success: function (response) {
                            ShowTrangThais();
                            $.toast({

                                heading: 'Thông báo',
                                text: '<a href="/gio-hang.html" style="text-decoration: none;">Đã thêm 1 sản phẩm vào giỏ hàng <br /> ' + name + '</a>',
                                showHideTransition: 'fade',
                                icon: 'success'
                            })
                        },
                        error: function (response) {
                            //  alert(response.status + ' ' + response.statusText);
                        },
                        beforeSend: function () {
                            //$body.addClass('loading');
                        },
                        complete: function () {
                            // $body.removeClass("loading");
                        }
                    });
                }
            }
            else {
                var numPro = "#" + id;
                $.ajax({
                    type: "POST",
                    url: "/index.aspx/Up_Order",
                    data: "{id:'" + id.toString() + "',quantity:'1'}",
                    contentType: "application/json; charset=utf-8",
                    datatype: "json",
                    async: "true",
                    success: function (response) {
                        ShowTrangThais();
                        $.toast({
                            heading: 'Thông báo',
                            text: '<a href="/gio-hang.html" style="text-decoration: none;">Đã thêm 1 sản phẩm vào giỏ hàng <br /> ' + name + '</a>',
                            showHideTransition: 'fade',
                            icon: 'success'
                        })
                    },
                    error: function (response) {
                        //  alert(response.status + ' ' + response.statusText);
                    },
                    beforeSend: function () {
                        //$body.addClass('loading');
                    },
                    complete: function () {
                        // $body.removeClass("loading");
                    }
                });
            }
            //    var soluong = 1;
            //    var total = parseInt(soluong) + parseInt($("#Cart")[0].innerHTML);
            //    $("#Cart")[0].innerHTML = total.toString();
        }
        function ShowTrangThais() {
            $.ajax({
                url: '/index.aspx/ShowTrangThai',
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                  // alert(response.d);
                   $('#dhShowTrangThai').val(response.d);
                    // $('#dhShowTrangThai').html(data.d);
                },
                error: function (response) {
                    // alert(response.responseText);
                },
                failure: function (response) {
                    // alert(response.responseText);
                }
            });
        }
    </script>

    <div id="overlay"></div>
</body>
</html>
