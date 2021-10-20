<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Box_Hotline.ascx.cs" Inherits="VS.E_Commerce.cms.Display.AllPage.Box_Hotline" %>
<div class="CallHotline">
    <div class="phone_animation">
        <a title="Hotline: <%=MoreAll.Other.Hotline().Replace(".", "").Replace(",", "") %>" href="tel:<%=MoreAll.Other.Hotline().Replace(".", "").Replace(",", "") %>">
            <div class="phone_animation_circle"></div>
            <div class="phone_animation_circle_fill"></div>
            <div class="phone_animation_circle_fill_img"></div>
        </a>
    </div>
</div>
