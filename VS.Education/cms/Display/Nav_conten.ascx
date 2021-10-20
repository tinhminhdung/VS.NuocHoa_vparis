<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav_conten.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Nav_conten" %>
<section class="bread_crumb py-4">
	<div class="container">
		<div class="row">
			<div class="col-xs-12">
				<ul class="breadcrumb">	

					<li class="home">
						<a href="/"><span>Trang chủ</span></a>						
						<span> <i class="fa fa-angle-right"></i> </span>
					</li>
                    <asp:Literal ID="ltrnav" runat="server"></asp:Literal>
					
				</ul>
			</div>
		</div>
	</div>
</section>