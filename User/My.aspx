<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="My.aspx.cs" Inherits="User_My" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .gray{
            color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
<%--
    <div class="formList" style="padding:20px;">
        <table class="easyui-datagrid"  title="欢迎您，<%=GB_LoginUser.UserName %>！""  fitColumns="true" nowrap="false" singleSelect="true" >
            <thead>
            <tr>
                 <th field="FieldName" width="30">我的信息</th>
                 <th field="FieldValue" width="100"></th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <td>用户名：</td>
                <td> <%=GB_LoginUser.UserName %> </td>
            </tr>
            <tr>
                <td>昵称：</td>
                <td> <%=GB_LoginUser.Nickname %>  </td>
            </tr>
            <tr>
                <td>邮箱：</td>
                <td> <%=GB_LoginUser.Email %>  </td>
            </tr>
            <tr>
                <td>性别：</td>
                <td> <%=GetSexName(GB_LoginUser.Sex) %>  </td>
            </tr>
            <tr>
                <td>等级：</td>
                <td> <%=GB_LoginUser.Level %> </td>
            </tr>
            <tr>
                <td>积分：</td>
                <td> <%=GB_LoginUser.Credit %> </td>
            </tr>
            <tr>
                <td>状态：</td>
                <td> <%= GetStatusName(GB_LoginUser.Status) %>  </td>
            </tr>
            <tr>
                <td>注册时间：</td>
                <td> <%=GB_LoginUser.RegTime %> </td>
            </tr>
            </tbody>
        </table>
    </div>--%>
    
    
    <div id="tt" style="height:600px; overflow:auto;"  class="easyui-tabs"  fit="true"  border="false" >

        <div title="我的档案" style="padding:8px;display:block;">

              <table class="easyui-datagrid"   fitColumns="true" nowrap="false" singleSelect="true" >
                <thead>
                <tr>
                     <th field="FieldName" width="30">我的信息</th>
                     <th field="FieldValue" width="100"></th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>用户名：</td>
                    <td> <%=GB_LoginUser.UserName %> </td>
                </tr>
                <tr>
                    <td>昵称：</td>
                    <td> <%=GB_LoginUser.Nickname %>  </td>
                </tr>
                <tr>
                    <td>邮箱：</td>
                    <td> <%=GB_LoginUser.Email %>  </td>
                </tr>
                <tr>
                    <td>性别：</td>
                    <td> <%=GetSexName(GB_LoginUser.Sex) %>  </td>
                </tr>
                <tr>
                    <td>生日：</td>
                    <td> <%=GB_LoginUser.Birth %>   </td>
                </tr>
                <tr>
                    <td>电话：</td>
                    <td> <%=GB_LoginUser.Phone %>  </td>
                </tr>
                <tr>
                    <td>手机：</td>
                    <td> <%=GB_LoginUser.Mobile %>   </td>
                </tr>
                <tr>
                    <td>地址：</td>
                    <td> <%=GB_LoginUser.Address %>   </td>
                </tr>
                <tr>
                    <td>签名：</td>
                    <td> <%=GB_LoginUser.Motto %>   </td>
                </tr>
                <tr>
                    <td>个人简介：</td>
                    <td> <%=GB_LoginUser.Intro %>   </td>
                </tr>
                <tr>
                    <td>等级：</td>
                    <td> <%=GB_LoginUser.Level %> </td>
                </tr>
                <tr>
                    <td>积分：</td>
                    <td> <%=GB_LoginUser.Credit %> </td>
                </tr>
                <tr>
                    <td>状态：</td>
                    <td> <%= GetStatusName(GB_LoginUser.Status) %>  </td>
                </tr>
                <tr>
                    <td>注册时间：</td>
                    <td> <%=GB_LoginUser.RegTime %> </td>
                </tr>
                </tbody>
            </table>

        </div>
        
        <div title="编辑资料"  style="padding:20px;display:block;">

            <table class="easyui-datagrid"   fitColumns="true" nowrap="false" singleSelect="true" >
                <thead>
                <tr>
                     <th field="FieldName" width="30">编辑资料</th>
                     <th field="FieldValue" width="100"></th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>用户名：</td>
                    <td> <input type="text" name="txtUserName" id="txtUserName" disabled="disabled" value="<%=GB_LoginUser.UserName %>" /> <span id="tipUserName">不可修改</span> </td>
                </tr>
                <tr>
                    <td>昵称：</td>
                    <td> <input type="text" name="txtNickName" id="txtNickName" value="<%=GB_LoginUser.Nickname %>" /> <span id="tipNickName">20个字符内 </span>  </td>
                </tr>
                <tr>
                    <td>邮箱：</td>
                    <td> <input type="text" disabled="disabled" name="txtEmail" id="txtEmail" value="<%=GB_LoginUser.Email %>" /> <span id="tipEmail">不可更改 </span>   </td>
                </tr>
                <tr>
                    <td>性别：</td>
                    <td> <input type="radio" name="rdSex" id="rdSex_0" value="0"  <%=(GB_LoginUser.Sex + "")=="0" ? "checked=\"checked\"":"" %> />保密  
                         <input type="radio" name="rdSex" id="rdSex_1"  value="1"  <%=(GB_LoginUser.Sex + "")=="1" ? "checked=\"checked\"":"" %>  />男  
                         <input type="radio" name="rdSex" id="rdSex_2"  value="2"  <%=(GB_LoginUser.Sex + "")=="2" ? "checked=\"checked\"":"" %>  />女  </td>
                </tr>
                <tr>
                    <td>生日：</td>
                    <td> <input type="text" name="txtBirth" id="txtBirth" value="<%=GetShortDate(GB_LoginUser.Birth) %>" /> <span id="tipBirth">格式：2011-03-03 </span>   </td>
                </tr>
                <tr>
                    <td>电话：</td>
                    <td> <input type="text" name="txtPhone" id="txtPhone" value="<%=GB_LoginUser.Phone %>" /> <span id="tipPhone">格式：0759-6413**** </span>  </td>
                </tr>
                <tr>
                    <td>手机：</td>
                    <td> <input type="text" name="txtMobile" id="txtMobile" value="<%=GB_LoginUser.Mobile %>" />  <span id="tipMobile">格式：134161***** </span> </td>
                </tr>
                <tr>
                    <td>地址：</td>
                    <td> <input type="text" name="txtAddress" id="txtAddress" style="width:300px;" value="<%=GB_LoginUser.Address %>" /> <span id="tipAddress"> 50个字符内 </span>  </td>
                </tr>
                <tr>
                    <td>签名：</td>
                    <td> <input type="text" name="txtMotto" id="txtMotto" style="width:300px;"  value="<%=GB_LoginUser.Motto %>" /> <span id="tipMotto"> 50个字符内 </span>   </td>
                </tr>
                <tr>
                    <td>个人简介：</td>
                    <td>
                        <textarea name="txtIntro" id="txtIntro" style="width:300px; height:60px;"><%=GB_LoginUser.Intro %></textarea>
                        <span id="tipIntro"> 300个字符内 </span>
                    </td>
                </tr>
                <tr>
                    <td>验证密码：</td>
                    <td> <input type="password" name="txtPassword" id="txtPassword" value="" />  <span id="tipPassword"> 为了安全，需要验证密码，否则无法修改 </span> </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <input type="button" class="btn"  name="btnSaveInfo" onclick="saveInfo();" id="btnSaveInfo" value="保存" /> </td>
                </tr>
                </tbody>
            </table>

        </div>
        
        <div title="上传头像"  style="padding:20px;display:block;">
            <table class="easyui-datagrid"   fitColumns="true" nowrap="false" singleSelect="true" >
                <thead>
                <tr>
                     <th field="FieldName" width="30">上传头像</th>
                     <th field="FieldValue" width="100"></th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>旧头像：</td>
                    <td> <img src="<%=GB_LoginUser.ImagePath == "" ? "../images/nopic.jpg" : GB_LoginUser.ImagePath   %>" alt="" height="100" /> <br /> </td>
                </tr>
                <tr>
                    <td>选择头像文件：</td>
                    <td> <input type="file" name="fileImage" /> 建议规格：100px×100px </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <input type="button" class="btn"  name="btnSaveImage" value="保存" /> </td>
                </tr>
                </tbody>
            </table>
        </div>

        <div title="修改密码" style="overflow:auto;padding:20px;display:block;">

            <table class="easyui-datagrid"   fitColumns="true" nowrap="false" singleSelect="true" >
                <thead>
                <tr>
                     <th field="FieldName" width="30">修改密码</th>
                     <th field="FieldValue" width="100"></th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>旧密码：</td>
                    <td> <input type="password" name="txtOldPassword" value="" /> </td>
                </tr>
                <tr>
                    <td>新密码：</td>
                    <td> <input type="password" name="txtNewPassword" value="" />  </td>
                </tr>
                <tr>
                    <td>重复新密码：</td>
                    <td> <input type="password" name="txtNewRePassword" value="" /> </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <input type="button" class="btn"  name="btnSavePassword" value="保存" /> </td>
                </tr>
                </tbody>
            </table>

        </div>


    </div>
    
    <script type="text/javascript">

        function saveInfo() {
            var nickName = $("#txtNickName").val() + "";
            var sex = 0;
            if ($("#rdSex_1 ").attr("checked")) {
                sex = 1;
            }
            else if ($("#rdSex_2 ").attr("checked")) {
                sex = 2;
            }
            else {
                sex = 0;
            }
            var birth = $("#txtBirth").val() + "";
            var phone = $("#txtPhone").val() + "";
            if (phone.length > 20) {
                tip("#tipPhone", "电话号码长度必须再20位以内", -1);
                return;
            }
            var mobile = $("#txtMobile").val() + "";
            if (mobile.length > 11) {
                tip("#tipMobile", "手机长度必须再11位以内", -1);
                return;
            }
            var address = $("#txtAddress").val() + "";
            if (address.length > 50) {
                tip("#tipAddress", "地址长度必须再50位以内", -1);
                return;
            }
            var motto = $("#txtMotto").val() + "";
            if (motto.length > 50) {
                tip("#tipMotto", "签名长度必须再50位以内", -1);
                return;
            }
            var intro = $("#txtIntro").val() + "";
            if (intro.length > 50) {
                tip("#tipIntro", "介绍长度必须再50位以内", -1);
                return;
            }
            var password = $("#txtPassword").val() + "";
            if (password.length < 6) {
                tip("#tipPassword", "密码不正确", -1);
                return;
            }

            $("#btnSaveInfo").val("请在保存...");
            $("#btnSaveInfo").attr("disabled", "disabled");

            //注册
            $.ajax({
                type: "POST",
                url: "../Handle/SaveUserInfo.ashx?t=" + new Date().getTime(),
                //cache: false,
                data: "nickname=" + nickName + "&sex=" + sex + "&birth=" + birth + "&phone=" + phone
                 + "&mobile=" + mobile + "&address=" + address + "&motto=" + motto + "&intro=" + intro + "&password=" + password,
                //dataType: "text",
                //contentType: "charset=utf-8",
                success: function(msg) {
                    $.messager.alert('恭喜，保存成功！',
                         msg,
                         "info",
                         function() {
                             top.location.href = "My.aspx";
                         }
                     );

                },
                error: function(xhr, textStatus, errorThrown) {
                    $.messager.alert("Sorry，保存失败！",
                         "<font color='red'>" + xhr.responseText + " 请检查输入是否正确或稍后重试！</font>",
                        "error");
                    $("#btnSaveInfo").val("保存");
                    $("#btnSaveInfo").attr("disabled", "");
                }
            });
        }
    
    </script>
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

