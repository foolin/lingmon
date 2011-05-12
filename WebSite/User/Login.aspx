﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .intro,.advance{
	    padding:10px;
	    font-size:14px;
    }
    .login {
	    text-indent:1em;
    }
    .login dt,.login dd{
	    margin:0;
	    padding:3px;
    }
    .btn{
	    padding:10px 15px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
        <div class="menu">
        	<a href="#Defaut.aspx" class="on">首页</a> | 
            <a href="#Blog">个人空间</a> | 
            <a href="#Help">情感求助</a> | 
            <a href="#Ask">情感问答</a> | 
            <a href="#Wiki">情感百科</a> | 
            <a href="#Story">情感故事</a> | 
            <a href="#I2U">爱情表白</a> | 
            <a href="#Game">匿言游戏</a> | 
            <a href="#Suggest">提交建议</a>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

 		<div class="partMain part">
        	
        	<div style="padding-left:30px">
                    
                    <dl class="login font14">
                        <dt>邮箱</dt>
                        <dd> <input type="text" class="input" value="" name="txtEmail" id="Text4" /> </dd>
                        <dt>密码</dt>
                        <dd> <input type="text" class="input" value="" name="txtPassword" id="Text5" /> </dd>
                        <dt>验证码</dt>
                        <dd> <input type="text" class="input" value="" name="txtPassword" id="Text6" /> 3326 </dd>
                        <dd> <input type="button" class="btn" name="btnLogin" id="Button2" value="登录"/> </dd>
                        <dd> 忘记密码？ <a href="#">点击这里找回</a> </dd>
                        <dd> 尚未注册？ <span class="font14"> <a href="Register.aspx">点击这里进行注册</a> </span> </dd>
                    </dl>
                    
            </div>
            
        </div>
        <!-- partMain End -->
        
        <div class="partSider part">


            <!--栏目-->
           <div class="box"> 
               <div class="title">尚未有帐号？</div>
                <div class="content"> 
                	<div class="reg"><a href="Register.aspx" class="btnRegister"></a></div> 
                </div>
            </div>
			
        </div>
        <!-- partSider End -->
        <div class="clear"></div>

</asp:Content>

