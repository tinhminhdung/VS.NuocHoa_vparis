﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuPage.ascx.cs" Inherits="VS.E_Commerce.cms.Display.Page.MenuPage" %>
 <%if (Case == "99")
          {%>
            <div id="sub-nav">
                <ul>
                    <%=ShowMenuPage()%>
                </ul>
            </div>
        <%} %>