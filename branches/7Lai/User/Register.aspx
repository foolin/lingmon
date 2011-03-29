<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="User_Register" Title="用户注册—快乐网(www.kuaile.us)" %>

<%@ Register src="../WebUserControl/WucRegister.ascx" tagname="WucRegister" tagprefix="uc1" %>

<%@ Register src="../WebUserControl/WucSiderContent.ascx" tagname="WucSiderContent" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .registerArea
        {
        	padding:20px 50px 20px;
        	border:dashed 1px #ccc;
        }
        .registerArea dl
        {
        	
        }
        .registerArea dt,.registerArea dd
        {
        	margin:0;
        	padding:3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
   
   <div class="registerArea">
        <div style="font-size:16px; font-weight:bold;text-indent:5em; border-bottom:dashed 1px #ccc; padding-bottom:10px;">用户注册</div>
        <uc1:WucRegister ID="WucRegister1" runat="server" /> 
   </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">
    <uc2:WucSiderContent ID="WucSiderContent1" runat="server" />
</asp:Content>

