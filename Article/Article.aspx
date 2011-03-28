<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article_Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">


    <div class="article">
        <div class="title"><%=GetTitle(Article.Title, Article.Content) %></div>
        <div class="info"> 作者：<%=GetUserName(Article.UserID)%>  发布：<%=Article.CreateTime %> 顶：<%=Article.DigUp %> 踩：<%=Article.DigDown %> 评论：<%=Article.Comments %>  </div>
        <div class="hr"></div>
        <div class="content">
            <%=Article.Content %>
        </div>
        
   </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">


</asp:Content>

