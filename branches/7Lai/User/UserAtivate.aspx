<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserAtivate.aspx.cs" Inherits="User_UserAtivate" Title="帐号激活—快乐网(www.kuaile.us)" %>



<%@ Register src="../WebUserControl/WucSiderContent.ascx" tagname="WucSiderContent" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
    <div style="padding:100px 50px 200px 50px; line-height:1.5em; font-size:14px; text-align:center;">
        

        
        <div style="font-size:26px; font-weight:bold; line-height:1.8em;">
            <asp:Label ID="lbDesc" runat="server" Text=""></asp:Label>
        </div>
        
        <br />
        <br />
        
        <br />
        <br />
        温馨提示：请<a href="Login.aspx">点击这里登录</a>，如果您尚未注册，请<a href="Register.aspx">点击这里进行注册</a>。
        <div style="text-align:right; padding:20px 5px; font-size:14px; font-weight:bold; color:#090;"> 
        快乐网(www.kuaile.us)
        </div>
        <div style="text-align:right">快乐.我们一起分享！ &nbsp;&nbsp;</div>
        
    </div>
</asp:Content>

 <asp:Content ID="Content3" ContentPlaceHolderID="CphSider" Runat="Server">  
     <uc1:WucSiderContent ID="WucSiderContent1" runat="server" />
 </asp:Content>