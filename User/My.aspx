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
                    <td> <input type="text" name="txtUserName" disabled="disabled" value="<%=GB_LoginUser.UserName %>" /> 不可修改 </td>
                </tr>
                <tr>
                    <td>昵称：</td>
                    <td> <input type="text" name="txtNickName" value="<%=GB_LoginUser.Nickname %>" />  </td>
                </tr>
                <tr>
                    <td>邮箱：</td>
                    <td> <input type="text" disabled="disabled" name="txtEmail" value="<%=GB_LoginUser.Email %>" />   </td>
                </tr>
                <tr>
                    <td>性别：</td>
                    <td> <input type="radio" name="rdSex" value="0"  <%=(GB_LoginUser.Sex + "")=="0" ? "checked=\"checked\"":"" %> />保密  
                         <input type="radio" name="rdSex" value="1"  <%=(GB_LoginUser.Sex + "")=="1" ? "checked=\"checked\"":"" %>  />男  
                         <input type="radio" name="rdSex" value="2"  <%=(GB_LoginUser.Sex + "")=="2" ? "checked=\"checked\"":"" %>  />女  </td>
                </tr>
                <tr>
                    <td>生日：</td>
                    <td> <input type="text" name="txtBirth" value="<%=GB_LoginUser.Birth %>" />   </td>
                </tr>
                <tr>
                    <td>电话：</td>
                    <td> <input type="text" name="txtPhone" value="<%=GB_LoginUser.Phone %>" />   </td>
                </tr>
                <tr>
                    <td>手机：</td>
                    <td> <input type="text" name="txtMobile" value="<%=GB_LoginUser.Mobile %>" />   </td>
                </tr>
                <tr>
                    <td>地址：</td>
                    <td> <input type="text" name="txtAddress" style="width:300px;" value="<%=GB_LoginUser.Address %>" /> 50个字符内  </td>
                </tr>
                <tr>
                    <td>签名：</td>
                    <td> <input type="text" name="txtMotto" style="width:300px;"  value="<%=GB_LoginUser.Motto %>" /> 50个字符内   </td>
                </tr>
                <tr>
                    <td>个人简介：</td>
                    <td>
                        <textarea name="txtArea" style="width:300px; height:60px;"><%=GB_LoginUser.Intro %></textarea>
                        300个字符内
                    </td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td> <input type="password" name="txtPassword" value="" />  为了安全，需要验证密码，否则无法修改 </td>
                </tr>
                <tr>
                    <td></td>
                    <td> <input type="button" class="btn"  name="btnSaveInfo" value="保存" /> </td>
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
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

