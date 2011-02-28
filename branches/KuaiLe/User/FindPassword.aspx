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


    <div style="padding:20px;" class="findPasswordArea">
    

        
            <div style="font-size:16px; font-weight:bold;text-indent:0em; border-bottom:solid  1px #ccc; padding-bottom:10px;">
                找回用户密码</div>
            <dl>
                <dt>用户名/邮箱：</dt>
                <dd>  
                    <asp:TextBox ID="tbFpFindValue" runat="server"></asp:TextBox>  <span id="errFpFindValueTips">请输入用户名或邮箱</span></dd>
                <dt>验证码：</dt>
                <dd>
                    <asp:TextBox ID="tbFpChkCode" runat="server"></asp:TextBox>
                    <img id="imgFpChkCode" src="<%= ResolveClientUrl("~/Handle/ChkCodeImage.ashx")%>?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgFpChkCode')" />
          	         <a href="javascript:refreshCode('#imgRegChkCode')">看不清？</a>
                    <span id="errFpChkCode"></span>
                </dd>
                <dd>
                    <asp:Button ID="btnSubmit" CssClass="btn"  runat="server" 
                         Text="提交" 
                        onclick="btnSubmit_Click" />
                    <a href="Login.aspx">返回登录</a></dd>
            </dl>

        
   
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

