<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Manage_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    <style type="text/css"> 
    /*
        @Description : 登录页面
        @Author      : Foolin
        @Created on  : 2010-11-25
    */
    .loginForm {
	    margin:20px auto;
	    width:300px;
	    line-height:25px;
	    font-size: 14px;
	    border:#E3E3E3 5px solid;
	    padding:5px;
	    background:#F7F7F7;
	    background:#F3F3F3;
	    text-align:center;
    }
    .loginForm table{
	    border-collapse:collapse;
    }
    .loginForm table td{
	    border:#FFF 2px solid;
	    padding:5px;
    }
     
    .input{
	    border:#aaa dashed 1px;
	    font-family:Tahoma, Geneva, sans-serif;
	    font-size:15px;
	    font-weight:bold;
	    height:25px;
	    line-height:25px;
	    color:#090;
	    padding:2px 5px;
	    background:#faffbd;
    }
    .btn{
	    line-height:22px;
	    padding:3px 10px;
	    height:40px;
	    width:100px;
	    font-size:14px;
    }
     
    .txtL{ text-align:left;}
    .txtR{ text-align:right;}
    .title{ font-size:14px; font-weight:bold; color:#666;}
    .footer{
	    margin:5px auto;
	    font-size:12px;
	    text-align:center;
	    line-height:22px;
	    color:#666;
    }
    .footer a{color:#666;}
    a {color:#000;text-decoration:none;}
    a:hover{ color:#F00; text-decoration:underline;}

    </style> 
    <script type="text/javascript">
        if (top.location != location) top.location.href = location.href;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
	<div class="loginForm"> 
        <table width="100%"> 
          <tr> 
            <td colspan="2" class="title">快乐.我们一起分享！</td> 
          </tr> 
          <tr> 
            <td class="txtR">用户名：</td> 
            <td class="txtL">
                <asp:TextBox ID="txbUserName" CssClass="input" Width="180" runat="server"></asp:TextBox> 
            </td> 
          </tr> 
          <tr> 
            <td class="txtR">密&nbsp;&nbsp;码：</td> 
            <td class="txtL">
                <asp:TextBox ID="txbPassWord"  CssClass="input" Width="180" runat="server" TextMode="Password"></asp:TextBox> 
            </td> 
          </tr> 
          <tr> 
            <td colspan="2">
                <asp:Button ID="btnLogin" CssClass="btn"  runat="server" Text="登录" 
                    onclick="btnLogin_Click" />
            </td> 
          </tr>
<%--          <tr> 
            <td colspan="2">
                <div style="font-size:12px;">
                    
                </div>
            </td> 
          </tr> --%>
        </table> 
    </div> 
    
    <div class="footer"> 
    	 <br /> 
    	&copy  2010  快乐网(www.kuaile.us) 版权所有<br /> 
    </div>
    
    </div>
    </form>
</body>
</html>
