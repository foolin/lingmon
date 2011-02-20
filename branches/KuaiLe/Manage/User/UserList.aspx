<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Manage_User_UserList" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="list">
        <asp:Repeater ID="repDataList" runat="server">
            <HeaderTemplate>
                <table  class="easyui-datagrid"  title="用户列表"  fitColumns="true" nowrap="false" singleSelect="true" >
                    <thead>
                    <tr>
                        <th field="UserID" width="20">ID</th>
                        <th field="UserName" width="30">用户名</th>
                        <th field="NickName" width="30">昵称</th>
                        <th field="Email" width="50">邮箱</th>
                        <th field="Sex" width="20">性别</th>
                        <th field="LoginIP" width="50">登录IP</th>
                        <th field="LoginTime" width="50">登录时间</th>
                        <th field="LoginCount" width="20">登录次数</th>
                        <th field="Level" width="20">等级</th>
                        <th field="Credit" width="20">积分</th>
                        <th field="Status" width="20">状态</th>
                        <th field="CtrlLink" width="50">操作</th>
                    </tr>
                    </thead>
                    <tbody> 
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("UserID") %></td>
                    <td><%#Eval("UserName")%></td>
                    <td><%#Eval("Nickname") %></td>
                    <td><%#Eval("Email")%></td>
                    <td><%#GetSexName(Eval("Sex"))%></td>
                    <td><%#Eval("LastLoginIP")%></td>
                    <td><%#Eval("LastLoginTime")%></td>
                    <td><%#Eval("LoginCount")%></td>
                    <td><%#Eval("Level")%></td>
                    <td><%#Eval("Credit")%></td>
                    <td><%#GetStatusName(Eval("Status"))%></td>
                    <td> 
                        <a href="UserSetStatus.aspx?UserID=<%#Eval("UserID") %>">设置状态</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> 
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    
    <div class="page">
            <cc1:Paging ID="Paging1" runat="server" ShowPageGo="True" PageSplitNum="10" PageSize="20">
            </cc1:Paging>
        </div>
    
</asp:Content>

