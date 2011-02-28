<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="User_ResetPassword" %>

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
    
            
        <div id="okFindPassword" runat="server">
    
             <div style="font-size:16px; font-weight:bold;text-indent:0em; border-bottom:solid  1px #ccc; padding-bottom:10px;">
                    用户重设用户密码</div>
                <dl>
                    <dt>新密码：</dt>
                    <dd>  
                        <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox> </dd>
                    <dt>重复密码：</dt>
                    <dd> 
                        <asp:TextBox ID="tbRePasword"  TextMode="Password" runat="server"></asp:TextBox> </dd>
                    <dd> 
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="确定" 
                            onclick="btnSubmit_Click" /> <a href="Login.aspx">返回登录</a></dd>
                </dl>
           </div>
           

        
        
        <div id="errFindPassword" runat="server" visible="false" style="line-height:30px;">
            <div style="font-size:16px; font-weight:bold;text-indent:0em; border-bottom:solid  1px #ccc; padding-bottom:10px;">
                    您的找回密码链接无效，请尝试下面的操作提示：</div>
              <dl> 
                <dd>&#8226; 请到您的邮箱中完整复制找回密码邮件中的重置密码链接后，拷贝至浏览器的地址栏中重试一次。</dd> 
                <dd>&#8226; 找回密码邮件的有效期为48小时，如果您没能在有效期内完成密码重置，请<a href="FindPassword.aspx">重新找回密码</a>。</dd> 
                <dd>&#8226; 您也可以重新发送一封找回密码邮件到绑定的邮箱，立即<a href="FindPassword.aspx">重新发送找回密码邮件</a>。</dd> 
              </dl> 
              
              <div style="text-align:right; padding:20px 5px; font-size:14px; font-weight:bold; color:#090;"> 
                快乐网(www.kuaile.us)
              </div>
              <div style="text-align:right">快乐.我们一起分享！ &nbsp;&nbsp;</div>
              
        </div>
        
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

