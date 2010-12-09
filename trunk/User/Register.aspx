<%@ Page Language="C#" MasterPageFile="~/Frame.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="新用户注册" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    
    <style type="text/css">
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="padding:5px;" class="form" runat="server" id="regForm">
       <%--<tr>
            <th colspan="2">新用户注册</th>
        </tr>--%>
        <tr>
            <td class="txtR">用户名  ：</td>
            <td class="txtL">
                <input id="txtUsername" runat="server" class="easyui-validatebox input" message="字符{0}与{1}之间" type="text" name="txtUsername" validType="length[4,20]"></input>
                </td>
        </tr>
        <tr>
            <td class="txtR">密 码：</td>
            <td class="txtL">
                <input id="txtPassword" runat="server" class="easyui-validatebox input" type="password" name="txtPassword" validType="length[6,50]"></input></td>
        </tr>
        <tr>
            <td class="txtR">重复密码：</td>
            <td class="txtL">
                <input id="txtRePassword" runat="server" class="easyui-validatebox input" type="password" name="txtRePassword" validType="length[6,50]"></input></td>
        </tr>
        <tr>
            <td class="txtR">电子邮箱：</td>
            <td class="txtL">
                <input id="txtEmail" runat="server" class="easyui-validatebox input" type="text" name="txtEmail"  validType="email"></input> </td>
        </tr>
        <tr>
            <td class="txtR">验证码：</td>
            <td class="txtL">
                <input id="txtChkCode" runat="server" style="width:120px"  class=" input" type="text" name="txtCheckCode"></input>
                <asp:Image ID="imgVal" runat="server" /><a href="javascript:refreshCode()">看不清？</a>
                  </td>
        </tr>
        <tr>
            <td class="txtR">注册协议：</td>
            <td class="txtL">
                <input id="chkAgreement" runat="server" type="checkbox" checked="checked" value="true" /> 同意<a href="Agreement.aspx" target="_blank">《注册协议》</a> </td>
        </tr>
        <tr>
            <td class="txtR"></td>
            <td class="txtL">
                <input type="hidden" runat="server" id="hdValCode"  name="hdValCode" value="1234" />
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="注册" 
                    onclick="btnSubmit_Click" OnClientClick="return checkForm();" /> 
                <input id="btnCacel" type="button" value="取消"  class="btn" onclick="parent.closeUrlWin();" /> </td>
        </tr>
    </table>
    
    <div id="regOk" runat="server" style="line-height:25px;">
        <div style="font-size:16px; text-align:center; font-weight:bold;"> 
            <asp:Label ID="lblOKTitle" runat="server" Text="恭喜您注册成功！"></asp:Label></div>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;您的用户名是：<asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>，密码是：<asp:Label
            ID="lblPassword" runat="server" Text=""></asp:Label>，请妥善保管！
        </p>
        <p>
          &nbsp;&nbsp;&nbsp;&nbsp;我们已经发送一封激活邮件到您的信箱，您注册的账号需要激活才能正常使用，请尽快激活您的账号。
        </p>
        
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;如果你收不到邮件，请<asp:Button ID="btnReEmail" runat="server" CssClass="btn" Text="点击这里" 
            onclick="btnReEmail_Click" />重发邮件！
         
        
        <asp:HiddenField ID="hdRegTime" runat="server" />
        
    </div>

    
    <script type="text/javascript" language="javascript">
        function refreshCode() {
            var num = parseInt(Math.random() * 9999 + 1).toString();
            var img = document.getElementById("<%=imgVal.ClientID%>");
            if (num.length < 4) num = "0" + num;
            $("#<%=hdValCode.ClientID%>").val(num);
            $("#<%=imgVal.ClientID%>").src = "ImageVal.aspx?id=" + num;
        }
        function checkForm() {
            if ($("#<%=txtUsername.ClientID%>").val() == "") {
                alert("请输入用户名!");
                $("#<%=txtUsername.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtPassword.ClientID%>").val() == "") {
                alert("请输入密码!");
                $("#<%=txtPassword.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtRePassword.ClientID%>").val() == "") {
                alert("请重复输入密码!");
                $("#<%=txtRePassword.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtRePassword.ClientID%>").val() != $("#<%=txtPassword.ClientID%>").val()) {
                alert("两次密码不一致!");
                $("#<%=txtRePassword.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtEmail.ClientID%>").val() == "") {
                alert("请输入邮箱!");
                $("#<%=txtEmail.ClientID%>").focus();
                return false;
            }
            if($("#<%=txtEmail.ClientID%>").val().search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) == -1)
            {
                alert("邮箱不合法!");
                $("#<%=txtEmail.ClientID%>").focus();
                return false;
            }
            if ($("#<%=txtChkCode.ClientID%>").val() == "") {
                alert("请输入验证码!");
                $("#<%=txtEmail.ClientID%>").focus();
                return false;
            }
            
            if ($("#<%=txtChkCode.ClientID%>").val() == "") {
                alert("请输入验证码!");
                $("#<%=txtEmail.ClientID%>").focus();
                return false;
            }
            return true;
        }
        
    </script>
    
</asp:Content>

