<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucTopbarLink.ascx.cs" Inherits="WebUserControl_WucTopbarLink" %>

<div style="padding-left:10px; color:#999;">
    <span style="float:left;">
        <a href="<%=GB_SitePath %>/Default.aspx">首页</a> &nbsp; | &nbsp;
<%--
        
        <a href="<%=GB_SitePath %>/User/Login.aspx">登录</a> &nbsp; | &nbsp;
        <a href="<%=GB_SitePath %>/User/Register.aspx">注册</a> &nbsp; | &nbsp;  
        --%>
        
        <%=GetUserLoginInfo() %>
        
        <a href="#">设为首页</a> &nbsp;&nbsp; | &nbsp;
        <a href="#">收藏本站</a> &nbsp; | &nbsp;
        <a href="#">订阅本站</a> &nbsp; | &nbsp;
        <a href="#" style="cursor:help;">使用帮助</a> &nbsp;
    </span>
    <span style="float:right">
        快乐网(www.kuaile.us) - 我们一起分享！
    </span>
</div>
