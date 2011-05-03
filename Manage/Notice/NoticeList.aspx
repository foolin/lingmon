<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="Manage_Noticle_NoticeList" %>

<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="list">
        <asp:Repeater ID="repDataList" runat="server">
            <ItemTemplate>
                <dl>
                    <dt><b><%#Eval("Title") %></b></dt>
                    <dd class="content"><%#Eval("Content") %></dd>
                    <dd> <%#Eval("Author") %> 发布于 <%#Eval("PostTime")%> </dd>
                    <dd> <a href="NoticeAdd.aspx?id=<%#Eval("ID") %>">管理</a> | <a href="NoticeDel.aspx?id=<%#Eval("ID") %>" onclick="return confirm('确定删除？');">删除</a> </dd>
                </dl>
            </ItemTemplate>
        </asp:Repeater>
        </div>
        
        <div class="page">
            <cc1:Paging ID="Paging1" runat="server" ShowPageGo="True" PageSplitNum="10" PageSize="20">
            </cc1:Paging>
        </div>

</asp:Content>