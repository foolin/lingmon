<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSetStatus.aspx.cs" Inherits="Manage_User_UserSetStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        选择状态：
        <asp:DropDownList ID="ddlStatusList" runat="server">
            <asp:ListItem Text="选择状态" Value=""></asp:ListItem>
            <asp:ListItem Text="VIP" Value="2"></asp:ListItem>
            <asp:ListItem Text="已激活" Value="1"></asp:ListItem>
            <asp:ListItem Text="未激活" Value="0"></asp:ListItem>
            <asp:ListItem Text="冻结" Value="-1"></asp:ListItem>
            <asp:ListItem Text="封号" Value="-2"></asp:ListItem>
        </asp:DropDownList>
    
        
        <asp:Button ID="btnSubmit" runat="server" Text="修改" onclick="btnSubmit_Click" OnClientClick="return confirm('确定修改？');" />
        
        <input type="button" name="back" value="返回" onclick="history.go(-1);" />
        
        <asp:HiddenField ID="hfPreUrl" runat="server" />
    
    </div>
    </form>
</body>
</html>
