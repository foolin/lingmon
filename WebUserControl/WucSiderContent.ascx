<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucSiderContent.ascx.cs" Inherits="WebUserControl_WucSiderContent" %>

<%@ Register src="../WebUserControl/WucUserLogin.ascx" tagname="WucUserLogin" tagprefix="uc1" %>
<%@ Register src="../WebUserControl/WucSiderContact.ascx" tagname="WucSiderContact" tagprefix="uc2" %>

    <div class="loginForm column">
        <div class="title">用户登录</div>
        <div class="content">
            <uc1:WucUserLogin ID="WucUserLogin1" runat="server" />
        </div>
    </div>
    <div class="loginForm column">
        <div class="title">联系方式</div>
        <div class="content" style="padding:5px; line-height:25px;">
            <uc2:WucSiderContact ID="WucSiderContact1" runat="server" />
        </div>
    </div>


