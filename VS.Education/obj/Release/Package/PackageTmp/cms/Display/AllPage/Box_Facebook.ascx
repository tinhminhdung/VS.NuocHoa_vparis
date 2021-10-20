<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Box_Facebook.ascx.cs" Inherits="VS.E_Commerce.cms.Display.AllPage.Box_Facebook" %>
<div class="facebook">
    <iframe src="https://www.facebook.com/plugins/likebox.php?href=<%=MoreAll.Other.Facebook() %>&amp;width=<%=MoreAll.Other.Giatri("txtfbwidth")%>&amp;height= <%=MoreAll.Other.Giatri("txtfbheight")%>&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;show_border=true&amp;header=true" scrolling="no" frameborder="0" style="border: none; overflow: hidden; width: <%=MoreAll.Other.Giatri("txtfbwidth")%>px; height: <%=MoreAll.Other.Giatri("txtfbheight")%>px; margin-bottom: 8px;" allowtransparency="true"></iframe>
</div>
