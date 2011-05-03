<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/Manage.master" AutoEventWireup="true" CodeFile="NoticeAdd.aspx.cs" Inherits="Manage_Noticle_NoticeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    dd
    {
    	padding:2px 5px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h3>发布公告</h3>

    <dl>
        <dd>公告标题：</dd>
        <dd><asp:TextBox ID="tbTitle" Width="400" Value="" runat="server"></asp:TextBox></dd>
        <dd>公告内容：</dd>
        <dd><asp:TextBox ID="tbContent" TextMode="MultiLine" Width="400" Height="200" runat="server"></asp:TextBox></dd>
        <dd>公告作者：</dd>
        <dd><asp:TextBox ID="tbAuthor" Text="快乐团队" runat="server"></asp:TextBox></dd>
        <dd><asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" /></dd>
    </dl>

</asp:Content>

