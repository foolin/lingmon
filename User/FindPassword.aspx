<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FindPassword.aspx.cs" Inherits="User_FindPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .findPasswordArea
        {
        	padding:20px 50px 20px;
        	border:dashed 1px #ccc;
        	border-bottom:0;
        }
        .findPasswordArea dl
        {
        	
        }
        .findPasswordArea dt,.findPasswordArea dd
        {
        	margin:0;
        	padding:3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">



    <div style="padding:20px;" class="findPasswordArea" id="Div1" runat="server">
    
        <div style="font-size:16px; font-weight:bold;text-indent:0em; border-bottom:solid  1px #ccc; padding-bottom:10px;">
            找回用户密码</div>
        <dl>
            <dt>用户名：</dt>
            <dd><input type="text" name="emailUserName" id="emailUserName" value="" /><span id="Span1"></span></dd>
            <dd><input type="button" name="btnSubmit" id="Button1" class="btn" value="发送邮件" />  <a href="Login.aspx">返回登录</a></dd>
        </dl>
   
    </div>

    <div style="padding:20px;" class="findPasswordArea" id="findPasswordArea" runat="server">
    
        <div style="font-size:16px; font-weight:bold;text-indent:0em; border-bottom:solid  1px #ccc; padding-bottom:10px;">
            用户重设用户密码</div>
        <dl>
            <dt>用户名：</dt>
            <dd><input type="text" name="findUserName" id="findUserName" value="" /><span id="tipFindUserName"></span></dd>
            <dt>新密码：</dt>
            <dd><input type="password" name="findPassword" id="findPassword" value="" /> <span id="tipFindPassword"></span></dd>
            <dt>重复密码：</dt>
            <dd><input type="password" name="findRePassword" id="findRePassword" value="" /> <span id="tipFindRePassword"></span></dd>
            <dd><input type="button" name="btnSubmit" id="btnSubmit" class="btn" value="确定" />  <a href="Login.aspx">返回登录</a></dd>
        </dl>
   
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

