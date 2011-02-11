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
        <a href="#">收藏</a> &nbsp; | &nbsp;
         <a href="#">RSS</a>
    </span>
    <span style="float:right">
        快乐网(www.kuaile.us)——快乐.我们一起分享！
    </span>
</div>
