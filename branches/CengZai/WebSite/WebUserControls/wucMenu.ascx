<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMenu.ascx.cs" Inherits="UserControls_wucMenu" %>
        <div class="menu">
        	<a href="<%= ResolveClientUrl("~/Default.aspx")%>">首页</a> | 
            <a href="<%= ResolveClientUrl("~/Home")%>">个人空间</a> | 
            <a href="<%= ResolveClientUrl("~/Help")%>">情感求助</a> | 
            <a href="<%= ResolveClientUrl("~/Ask")%>">情感问答</a> | 
            <a href="<%= ResolveClientUrl("~/Wiki")%>">情感百科</a> | 
            <a href="<%= ResolveClientUrl("~/Story")%>">情感故事</a> | 
            <a href="<%= ResolveClientUrl("~/Letter")%>">爱情表白</a> | 
            <a href="<%= ResolveClientUrl("~/About")%>">随便逛逛</a>
        </div>