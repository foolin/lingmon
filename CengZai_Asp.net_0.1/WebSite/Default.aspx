<%@ Page Title="曾在网-让有情人幸福！挽救爱情和婚姻的情感网站" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="WebUserControls/wucMenu.ascx" tagname="wucMenu" tagprefix="uc1" %>

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
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">
 		<div class="partMain part">
        	
			<div class="intro">
				<b>曾在网（CengZai.com）</b>—您身边的情感朋友，让您找回曾经的甜蜜和幸福！一个致力于解决年轻一代的婚恋矛盾，挽救爱情或婚姻的情感网站，让爱情走得更远！<br />
				
            	<h3>加入曾在你可以：</h3>
            	<ul>
                	<li><b>个人空间</b>：发布心情、日志、连接、图片、音乐、视频等，分享您和Ta的幸福爱情。</li>
                    <li><b>匿名求助</b>：想倾诉情感但又怕泄漏隐私？一对一匿名交流，让陌生人来助你解“情”结。</li>
					<li><b>互动问答</b>：有情感问题？寻求众多“情圣”来回答，选取您认为最优答案。</li>
                    <li><b>情感百科</b>：专业的情感词条、丰富的情感知识，助你恋爱幸福和甜蜜。</li>
                    <li><b>情感故事</b>：每段恋情背后都有一段故事，或是浪漫，或是悲伤，齐来分享，一起聆听。</li>
                    <li><b>E网情深</b>：暗恋不敢表白？我们提供一个爱的表白平台，让您大胆地说出您对Ta的爱。</li>
                    <li><b>互动游戏</b>：抢座位，定时匿名贴纸条给对方，N天才显示您的名字，与好友互动和传情。</li>
                </ul>
            </div>
            
            <div class="advance">
            	<h3>我们努力并进步着：</h3>
            	<ul class="font12">
                	<li>2011年4月27日 设计曾在网的首页Demo。</li>
                	<li>2011年4月26日 设计数据库。</li>
                    <li>2011年4月25日 编写设计文档。</li>
                    <li>2011年4月27日 设计曾在网的首页Demo。</li>
                </ul>
            </div>
            
            
        </div>
        <!-- partMain End -->
        
        <div class="partSider part">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
            <!--栏目-->
            <div class="box">
                <div class="title">用户登录</div> 
                <div class="content"> 
                    <dl class="login font14">
                        
                        <dt> 邮箱  <a href="ReSendActiveEmail.aspx" class="font12" style="float:right; margin-right:60px;">尚未激活?</a> </dt>
                        <dd><asp:TextBox ID="tbEmail" CssClass="input" Width="150" runat="server"></asp:TextBox></dd>
                        <dt> 密码  <a href="FindPassword.aspx" class="font12" style="float:right; margin-right:60px;">忘记密码?</a></dt>
                        <dd> <asp:TextBox ID="tbPassword" CssClass="input" Width="150"  TextMode="Password" runat="server"></asp:TextBox></dd>
                        <dt> 验证码</dt>
                        <dd> <asp:TextBox ID="tbVerifyCode" CssClass="input" Width="80px" runat="server"></asp:TextBox> <img id="imgRegChkCode" src="<%= ResolveClientUrl("~/Handle/VerifyCode.ashx")%>?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgRegChkCode')" />
          	                <a href="javascript:refreshCode('#imgRegChkCode')" class="font12">看不清？</a> </dd>
                        <dd> 
                            <asp:Button ID="btnLogin" CssClass="btn" runat="server" Text="登录" 
                                onclick="btnLogin_Click" /> </dd>
                        
                        <dd> <div style="line-height:10px;">&nbsp;</div>  </dd>
                        <dd class="hr"></dd>
                        
                        <dd> <div style="line-height:10px;">&nbsp;</div>  </dd>
                        <dd> <div style="line-height:30px;">加入曾在，让爱情走得更远...</div></dd>
                        <dd> <div class="reg"><a href="User/Register.aspx" class="btnRegister"></a></div>  </dd>
                        
                    </dl>
                </div>
            </div> 
            
            </ContentTemplate>
            </asp:UpdatePanel>
            
            <!--栏目-->
<!--            <div class="box"> 
               <div class="title">快速注册</div>
                <div class="content"> 
                	<dl class="login">
                        <dt>邮箱</dt>
                        <dd> <input type="text" value="" name="txtEmail" id="txtEmail" /> </dd>
                        <dt>密码</dt>
                        <dd> <input type="text" value="" name="txtPassword" id="txtPassword" /> </dd>
                        <dt>重复密码</dt>
                        <dd> <input type="text" value="" name="txtPassword" id="txtPassword" /> </dd>
                        <dt>验证码</dt>
                        <dd> <input type="text" value="" name="txtPassword" id="txtPassword" /> 3326 </dd>
                        <dd> <input type="button" class="btn" name="btnRegister" value="立即注册"/> </dd>
                    </dl>
                </div>
            </div> -->
			
        </div>
        <!-- partSider End -->
        <div class="clear"></div>
</asp:Content>

