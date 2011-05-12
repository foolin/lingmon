<%@ Page Title="" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" %>

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
	color:#f90;
	color:#090;
	padding:2px 5px;
	width:200px;
	font-size:14pt;
	background:#fffceb;
	border:1px solid #ccc;
}
.regForm .agreement
{
	font-size:12px;
	height:30px;
	display:block;
}
.regForm  .agreement input
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
            if (!isEmail(email)) {
                $("#tipEmail").removeClass().addClass("errTips").html("× 邮箱不合法！");
            }
            else {
                $("#tipEmail").removeClass().addClass("tips").html("正在验证邮箱...");
                $.ajax({
                    type: "POST",
                    url: "some.php",
                    data: "name=John&location=Boston",
                    success: function(msg) {
                        alert("Data Saved: " + msg);
                    }
                });
                
            }
            //$("#tipEmail").removeClass().html("");
        });
        $("#<%=tbPassword.ClientID%>").focus(function() {
            $("#tipPassword").removeClass().addClass("tips").html("* 请输入6-16位的密码，区分大小写。");
        }).blur(function() {
            //$("#tipPassword").removeClass().addClass("okTips").html("√ 密码合法");
        });
        $("#<%=tbRePassword.ClientID%>").focus(function() {
            $("#tipRePassword").removeClass().addClass("tips").html("* 请重新输入一遍密码。");
        }).blur(function() {
            //$("#tipRePassword").removeClass().addClass("errTips").html("× 密码错误！");
        });
        $("#<%=cbAgreement.ClientID%>").focus(function() {
            $("#tipAgreement").addClass("tips").html("* 请仔细阅读协议并同意才可注册。");
        }).blur(function() {
            //$("#tipAgreement").removeClass("tips").html("");
        });
    });
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
                        <td class="txtR"></td>
                        <td class="txtL"> 
                            <span class="agreement">
                            <asp:CheckBox ID="cbAgreement" Checked="true" runat="server" /> 同意<a href="../Abount/Agreemtment.aspx">《曾在网络服务协议》</a> </span> </td>
                        <td> <span id="tipAgreement"></span> </td>
                      </tr>
                      <tr>
                        <td class="txtR"></td>
                        <td class="txtL"> 
                            <asp:ImageButton ID="ibRegister" ImageUrl="~/images/btn_register2.jpg" 
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

