<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucTopbarLink.ascx.cs" Inherits="WebUserControl_WucTopbarLink" %>

<div style="padding-left:10px; color:#999;">
    <span style="float:left;">
        <a href="<%=GB_SitePath %>/Default.aspx">首页</a> &nbsp; | &nbsp;
<%--
        
        <a href="<%=GB_SitePath %>/User/Login.aspx">登录</a> &nbsp; | &nbsp;
        <a href="<%=GB_SitePath %>/User/Register.aspx">注册</a> &nbsp; | &nbsp;  
        --%>
        
        <%=GetUserLoginInfo() %>
        
        <a href="#" onclick="javascript:this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.kuaile.us/');return(false);">设为首页</a> &nbsp;&nbsp; | &nbsp;
        <a href="#" onclick="javascript:try{ window.external.AddFavorite('http://www.kuaile.us/','快乐网—我们一起分享'); } catch(e){ (window.sidebar)?window.sidebar.addPanel('快乐网—我们一起分享','http://www.kuaile.us/',''):alert('请使用按键 Ctrl+d，收藏快乐网'); }">收藏本站</a> &nbsp; | &nbsp;
        <a href="<%=GB_SitePath %>/Rss.aspx" target="_blank">RSS订阅</a> &nbsp; | &nbsp;
        <a href="<%=GB_SitePath %>/Help/" style="cursor:help;">使用帮助</a> &nbsp;
    </span>
    <span style="float:right">
        快乐网(www.kuaile.us) - 我们一起分享！
    </span>
</div>
