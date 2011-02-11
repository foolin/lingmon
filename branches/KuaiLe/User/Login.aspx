<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" Title="用户登录—快乐网(www.kuaile.us)" %>

<%@ Register src="../WebUserControl/WucUserLogin.ascx" tagname="WucUserLogin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .loginArea
        {
        	padding:20px 50px 20px;
        	border:dashed 1px #ccc;
        }
        .loginArea dl
        {
        	
        }
        .loginArea dt,.loginArea dd
        {
        	margin:0;
        	padding:3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
    <div class="loginArea">
        <div style="font-size:16px; font-weight:bold;text-indent:5em; border-bottom:dashed 1px #ccc; padding-bottom:10px;">
            用户登录</div>
        <uc1:WucUserLogin ID="WucUserLogin1" runat="server" />
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
    aaa 
</asp:Content>

