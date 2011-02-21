<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="My.aspx.cs" Inherits="User_My" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .gray{
            color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">

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
    </div>   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
</asp:Content>

