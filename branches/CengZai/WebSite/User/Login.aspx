﻿<%@ Page Title="用户登录" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/user.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .loginForm {
    }
    .loginForm dt,.loginForm dd{
	    margin:3px 0;
	    padding:3px;
    }
    .loginForm .btn{
	    padding:10px 15px;
    }
    .loginForm .input
    {
	    height:25px;
	    line-height:25px;
	    font-weight:bold;
	    color:#F60;
	    color:#095;
	    padding:2px 3px;
	    width:200px;
	    font-size:14pt;
	    background:#fffceb;
	    border:1px solid #ccc;
    }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

 		<div class="partMain part">
        	
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
           <div class="formWrap">
           
                <div class="title">用户登录</div>
                <div class="intro">曾在（CengZai.com），一个交流真实情感的社区，致力于挽救爱情和婚姻，让有情人幸福！</div>
   
        	    <div style="padding-left:30px">
                    <dl class="loginForm font14">
                        <dt> 邮箱</dt>
                        <dd><asp:TextBox ID="tbEmail" CssClass="input" runat="server"></asp:TextBox> <a href="ReSendActiveEmail.aspx" class="font12">尚未激活？</a> </dd>
                        <dt> 密码</dt>
                        <dd> <asp:TextBox ID="tbPassword" CssClass="input" TextMode="Password" runat="server"></asp:TextBox> <a href="FindPassword.aspx" class="font12">忘记密码？</a></dd>
                        <dt> 验证码</dt>
                        <dd> <asp:TextBox ID="tbVerifyCode" CssClass="input" Width="80px" runat="server"></asp:TextBox> <img id="imgRegChkCode" src="<%= ResolveClientUrl("~/Handle/VerifyCode.ashx")%>?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgRegChkCode')" />
          	                <a href="javascript:refreshCode('#imgRegChkCode')">看不清？</a> </dd>
                        <dd> 
                            <asp:Button ID="btnLogin" CssClass="btn" runat="server" Text="登录" onclick="btnLogin_Click" /> </dd>
                        <dd> <br />尚未注册？ <span> <a href="Register.aspx">点击这里进行注册</a>  </dd>
                    </dl>
                    

               </div>  
               
               
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- partMain End -->
        
        <div class="partSider part">


            <!--栏目-->
           <div class="box"> 
               <div class="title">加入曾在网：</div>
                <div class="content"> 
                    <%--<span style="font-size:14px; font-weight:bold">加入曾在网：</span>--%>
                    <ul style="color:#333">
                        <li> √&nbsp; 匿名倾述感情，寻求一对一的求助</li>
                        <li> √&nbsp; 倾听别人的爱情，帮助渡过爱情难关</li>
                        <li> √&nbsp; 学习爱情经验，让爱情永远幸福</li>
                        <li> √&nbsp; 一些事，一些情，听听情感的故事</li>
                        <li> √&nbsp; 给暗恋已久的Ta写情书、表白</li>
                        <li> √&nbsp; 加入匿名游戏，捉弄好友</li>
                        <li><b>还在等什么？快快加入吧！</b></li>
                        <li> &nbsp;</li>
                    </ul>
                	<div class="reg"><a href="Register.aspx" class="btnRegister"></a></div> 
                	<br />
                </div>
            </div>
			
        </div>
        <!-- partSider End -->
        <div class="clear"></div>

        </span>

</asp:Content>
