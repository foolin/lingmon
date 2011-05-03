﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="CommentList.aspx.cs" Inherits="Manage_Comment_CommentList" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="list">
        <asp:Repeater ID="repDataList" runat="server">
            <ItemTemplate>
                <dl>
                    <dt></dt>
                    <dd class="content"><%#Eval("Comment")%></dd>
                    <dd> <%#Eval("UserName") %> 发布于 <%#Eval("CreateTime")%> </dd>
                    <dd> <%#GetStatusDesc(Eval("Status"), Eval("CommentID"))%> </dd>
                </dl>
            </ItemTemplate>
        </asp:Repeater>
        </div>
        
        <div class="page">
            <cc1:Paging ID="Paging1" runat="server" ShowPageGo="True" PageSplitNum="10" PageSize="20">
            </cc1:Paging>
        </div>

</asp:Content>
