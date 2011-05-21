<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WucUserLogin.ascx.cs" Inherits="WebUserControl_WucUserLogin" %>

<dl>
    <dt>用户名：</dt>
    <dd><input type="text" name="LoginUserName" id="LoginUserName" value="" /><span id="tipLoginUserName"></span></dd>
    <dt>密 码：</dt>
    <dd><input type="password" name="LoginPassword" id="LoginPassword" value="" /> <span id="tipLoginPassword"></span> <a href="<%=GB_SitePath %>/User/FindPassword.aspx">忘记密码？</a> </dd>
    <dd><input type="button" name="btnUserLogin" id="btnUserLogin" class="btn" value="登录" />  <a href="<%=GB_SitePath %>/User/Register.aspx">注册</a></dd>
    <dd style="font-size:12px;">尚未激活？<a href="<%=GB_SitePath %>/User/ReSendActiveEmail.aspx">点击这里重发激活邮件</a></dd>
</dl>


<script type="text/javascript">
    $(function() {
        $("#LoginUserName,#LoginPassword").each(function(i) {
            $(this).keyup(function(e) {
                if (e.which == 13) {
                    userLogin();
                }
            });
        });

        $("#LoginUserName").blur(function() {
            var loginUsername = $("#LoginUserName").val() + "";
            if (loginUsername.length < 3 || loginUsername.length > 20) {
                formTip("tipLoginUserName", "用户名长度必须为3~20个字符", -1);
                return;
            }
            else {
                formTip("tipLoginUserName", "用户名ok", 1);
                return;
            }
        });

        $("#LoginPassword").blur(function() {
            var loginPassword = $("#LoginPassword").val() + "";
            if (loginPassword.length < 6 || loginPassword.length > 20) {
                formTip("tipLoginPassword", "密码长度必须为6~20个字符", -1);
                return;
            }
            else {
                formTip("tipLoginPassword", "密码ok", 1);
                return;
            }
        });

        $("#btnUserLogin").click(function() {
            userLogin();
        });




    });



    function userLogin() {
        var loginUsername = $("#LoginUserName").val() + "";
        var loginPassword = $("#LoginPassword").val() + "";
        if (loginUsername.length < 3 || loginUsername.length > 20) {
            formTip("tipLoginUserName", "用户名长度必须为3~20个字符", -1);
            return;
        }


        if (loginPassword.length < 6 || loginPassword.length > 20) {
            formTip("tipLoginPassword", "密码长度必须为6~20个字符", -1);
            return;
        }

        $("#btnUserLogin").val("正在登录...");
        $("#btnUserLogin").attr("disabled", "disabled");

        //登录
        $.ajax({
            type: "POST",
            url: "<%=GB_SitePath %>/Handle/Login.ashx?t=" + new Date().getTime(),
            data: "UserName=" + loginUsername + "&Password=" + loginPassword,
            success: function(msg) {
                top.location.href = "<%=GB_SitePath %>/Default.aspx";
            },
            error: function(xhr, textStatus, errorThrown) {
                $.messager.alert("Sorry，登录" + loginUsername + "失败！",
                 "<font color='red'>" + xhr.responseText + "</font>",
                "error");
                $("#btnUserLogin").val("登录");
                $("#btnUserLogin").attr("disabled", "");
            }
        });
    }
    

</script>
