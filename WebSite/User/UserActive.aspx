<%@ Page Title="" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="UserActive.aspx.cs" Inherits="User_UserActive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .content
    {
	    font-size:14px;
	    padding:20px;
	    height:300px;
    }
    .intro
    {
    	font-size:25px;
    	font-weight:bold;
    	padding-top:20px;
    	display:block;
    }
    </style>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content" Runat="Server">

<div class="content">

    <div class="title">激活帐号</div>
    <asp:Label ID="lbDesc" CssClass="intro" runat="server" Text="Label"></asp:Label>
    
</div>
    
    
</asp:Content>

