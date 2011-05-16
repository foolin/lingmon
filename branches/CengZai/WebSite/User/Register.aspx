<%@ Page Title="用户注册" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.regForm
{
	font-size:14px;
	padding:10px 20px;
	
}
.regForm div,.regForm table
{
	padding:10px;
	margin:10px;
}
.regForm .title
{
	font-size:26px;
	font-family:"幼圆","黑体";
	font-weight:bold;
}
.regForm .intro
{
	color:Gray;
	border:1px dashed #ccc;
	border-bottom:dashed 1px #ccc;
	background:#fafafa;
	font-size:13px;
}
.regForm table
{
	font-size:14px;
}
.regForm table td
{
	padding:8px;
}
.regForm input
{
	height:25px;
	line-height:25px;
	font-weight:bold;
	color:#090;
	color:#F60;
	padding:2px 5px;
	width:200px;
	font-size:14pt;
	background:#fffceb;
	border:1px solid #ccc;
}
.regForm .select
{
	height:25px;
	line-height:25px;
	font-weight:bold;
	color:#F60;
	font-size:14px;
	background:#fffceb;
	border:1px solid #ccc;
}
.regForm .agreement
{
	font-size:12px;
	height:30px;
	display:block;
}
.regForm .agreement input
{
	padding:0;
	height:auto;
	line-height:normal;
	width:auto;
}
.regForm .normal input
{
	padding:0;
	height:auto;
	line-height:normal;
	width:auto;
}
.regForm .btnRegister
{
	width:auto;
	padding:5px;
	line-height:normal;
	height:auto;
}

</style>
<script type="text/javascript" src="../js/cengzai.js"></script>
<script type="text/javascript">
    $(function() {
        $("#<%=tbEmail.ClientID%>").focus(function() {
            $("#tipEmail").removeClass().addClass("tips").html("* 请输入常用邮箱，作为登录帐号。");
        }).blur(function() {
            var email = $(this).val();
            if (!Utils.isEmail(email)) {
                $("#tipEmail").removeClass().addClass("errTips").html("× 邮箱不合法！");
            }
            else {
                $("#tipEmail").removeClass().addClass("tips").html("正在验证邮箱...");
                $.ajax({
                    type: "POST",
                    url: "../Handle/CheckEmail.ashx",
                    data: "email=" + email,
                    success: function(msg) {
                        $("#tipEmail").removeClass().addClass("okTips").html("√ " + msg);
                    },
                    error: function(xhr, textStatus, errorThrown) {
                        $("#tipEmail").removeClass().addClass("errTips").html("× " + xhr.responseText);
                    }
                });

            }
            //$("#tipEmail").removeClass().html("");
        });
        $("#<%=tbPassword.ClientID%>").focus(function() {
            $("#tipPassword").removeClass().addClass("tips").html("* 请输入6-16位的密码，区分大小写。");
        }).blur(function() {
            var pwd = $(this).val() + "";
            if (pwd.length < 6) {
                $("#tipPassword").removeClass().addClass("errTips").html("× 密码不可以小于6位！");
            }
            else if (pwd.length < 6) {
                $("#tipPassword").removeClass().addClass("errTips").html("× 密码不可以大于16位！");
            }
            else {
                $("#tipPassword").removeClass().addClass("okTips").html("√ 密码可以使用");
            }

        });
        $("#<%=tbRePassword.ClientID%>").focus(function() {
            $("#tipRePassword").removeClass().addClass("tips").html("* 请重新输入一遍密码。");
        }).blur(function() {
            var pwd = $("#<%=tbPassword.ClientID%>").val() + "";
            var rePwd = $(this).val() + "";
            if (rePwd.length < 6) {
                $("#tipRePassword").removeClass().addClass("errTips").html("× 密码不可以小于6位！");
                return false;
            }
            else if (pwd != rePwd) {
                $("#tipRePassword").removeClass().addClass("errTips").html("× 两次密码不一致！");
            }
            else {
                $("#tipRePassword").removeClass().addClass("okTips").html("√ 两次密码一致");
            }
        });
        $("#<%=tbNickName.ClientID%>").focus(function() {
            $("#tipNickName").removeClass().addClass("tips").html("* 昵称作为您的显示名称，2-10个字符，可中文。");
        }).blur(function() {
            var nickName = $("#<%=tbNickName.ClientID%>").val() + "";

            if (Utils.charCount(nickName) < 2) {
                $("#tipNickName").removeClass().addClass("errTips").html("× 昵称不可以小于2位！");
                return false;
            }
            if (Utils.charCount(nickName) > 10) {
                $("#tipNickName").removeClass().addClass("errTips").html("× 昵称不可以大于10位！");
                return false;
            }
            else {
                $("#tipNickName").removeClass().addClass("okTips").html("√ 昵称可以使用");
            }
        });
        $("#<%=tbVerifyCode.ClientID%>").focus(function() {
            refreshCode("#imgRegChkCode"); //刷新验证码
            $("#tipVerifyCode").removeClass().addClass("tips").html("* 请输入验证码 ");
        }).blur(function() {
            var verifyCode = $("#<%=tbVerifyCode.ClientID%>").val() + "";
            if (verifyCode.length < 1) {
                $("#tipVerifyCode").removeClass().addClass("errTips").html("× 请输入验证码！");
                return false;
            }
            else {
                $("#tipVerifyCode").removeClass().html("");
            }
        });
        $("#<%=cbAgreement.ClientID%>").click(function() {
            var isCheck = $(this).attr("checked");
            if (!isCheck) {
                $("#tipAgreement").removeClass().addClass("errTips").html("× 必须同意协议才可注册。");
            }
            else {
                $("#tipAgreement").removeClass().html("");
            }
        });
    });


    function CheckForm() {
        var email = $("#<%=tbEmail.ClientID%>").val() + "";
        if (!Utils.isEmail(email)) {
            $("#tipEmail").removeClass().addClass("errTips").html("× 邮箱不符合要求！");
            return false;
        }
        else {
            $("#tipEmail").removeClass().addClass("okTips").html("√ 邮箱符合要求");
        }
        var pwd = $("#<%=tbPassword.ClientID%>").val() + "";
        if (pwd.length < 6 || pwd.length > 16) {
            $("#tipPassword").removeClass().addClass("errTips").html("× 密码不符合要求！");
            return false;
        }
        else {
            $("#tipPassword").removeClass().addClass("okTips").html("√ 密码符合要求");
        }
        var rePwd = $("#<%=tbRePassword.ClientID%>").val() + "";
        if (rePwd.length < 6) {
            $("#tipRePassword").removeClass().addClass("errTips").html("× 密码不可以小于6位！");
            return false;
        }
        else if (rePwd != pwd) {
            $("#tipRePassword").removeClass().addClass("errTips").html("× 两次密码不一致！");
            return false;
        }
        else {
            $("#tipRePassword").removeClass().addClass("okTips").html("√ 两次密码一致");
        }
        var verifyCode = $("#<%=tbVerifyCode.ClientID%>").val() + "";
        if (verifyCode.length < 1) {
            $("#tipVerifyCode").removeClass().addClass("errTips").html("× 请输入验证码！");
            return false;
        }
        else {
            $("#tipVerifyCode").removeClass().html("");
        }
        var isCheck = $("#<%=cbAgreement.ClientID%>").attr("checked");
        if (!isCheck) {
            $("#tipAgreement").removeClass().addClass("errTips").html("× 必须同意协议才能注册！");
            return false;
        }
        else {
            $("#tipAgreement").removeClass().html("");
        }

        return true;
    }
    
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

 		<div class="partMain part">
        	
             <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                 <div class="regForm">
                     <div class="title">注册帐号</div>
                     <div class="intro">注册曾在(CengZai.com)帐号，分享和倾诉情感，找回您和Ta曾经的甜蜜和幸福，让爱情走到最后！</div>
                    <table>
                      <tr>
                        <td class="txtR" style="width:80px;">邮  箱：</td>
                        <td class="txtL" style="width:210px;"> 
                            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox> </td>
                        <td> <span id="tipEmail"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR">密  码：</td>
                        <td class="txtL"> 
                            <asp:TextBox ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox> </td>
                        <td> <span id="tipPassword"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR">重复密码：</td>
                        <td class="txtL"> 
                            <asp:TextBox ID="tbRePassword" TextMode="Password" runat="server"></asp:TextBox> </td>
                        <td> <span id="tipRePassword"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR" style="width:80px;">昵  称：</td>
                        <td class="txtL" style="width:210px;"> 
                            <asp:TextBox ID="tbNickName" runat="server"></asp:TextBox> </td>
                        <td> <span id="tipNickName"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR" style="width:80px;">性  别：</td>
                        <td class="txtL" style="width:210px;"> 
                            <asp:DropDownList ID="ddlSex" CssClass="select"  runat="server">
                                <asp:ListItem Text="女生" Value="2"></asp:ListItem>
                                <asp:ListItem Text="男生" Value="1"></asp:ListItem>
                                <asp:ListItem Text="保密" Value="0"></asp:ListItem>
                            </asp:DropDownList> </td>
                        <td> <span id="tipSex"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR">验证码：</td>
                        <td class="txtL"> 
                            <asp:TextBox ID="tbVerifyCode" Width="80px" runat="server"></asp:TextBox> <img id="imgRegChkCode" src="<%= ResolveClientUrl("~/Handle/VerifyCode.ashx")%>?t=<%=DateTime.Now %>" alt="刷新验证码" style="cursor:pointer;" onclick="refreshCode('#imgRegChkCode')" />
          	 <a href="javascript:refreshCode('#imgRegChkCode')" class="font12">看不清？</a></td>
                        <td> <span id="tipVerifyCode"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR"></td>
                        <td class="txtL"> 
                            <span class="agreement">
                            <asp:CheckBox ID="cbAgreement" Checked="true" runat="server" /> 同意<a href="../Abount/Agreemtment.aspx">《曾在网络服务协议》</a> </span> </td>
                        <td> <span id="tipAgreement"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR"></td>
                        <td class="txtL"> 
                            <asp:ImageButton ID="ibRegister" ImageUrl="~/images/btn_register2.jpg"  OnClientClick="return CheckForm();"
                                Width="195px" Height="51px" runat="server" onclick="ibRegister_Click" /></td>
                        <td>  </td>
                      </tr>
                    </table>
                
                 </div>
             </ContentTemplate>
             </asp:UpdatePanel>       
            
        </div>
        <!-- partMain End -->
        
        <div class="partSider part">


            <!--栏目-->
           <div class="box"> 
                <div class="content"> 
                	如果你已经注册，请<a href="Login.aspx">登录</a>
                </div>
            </div>
            
			
        </div>
        <!-- partSider End -->
        <div class="clear"></div>


</asp:Content>

