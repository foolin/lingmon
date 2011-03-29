<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>
<%@ Register Assembly="Utility" Namespace="Utility.Web" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" style="border:1px solid #ccc; border-collapse:collapse; width:800px;">
            <tr>
                <th>ID</th>
                <th>用户</th>
                <th>性别</th>
                <th>备注</th>
            </tr>
            <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
            <tr>
                <td><%#Eval("UserID")%></td>
                <td><%#Eval("UserName")%></td>
                <td><%#Eval("Sex")%></td>
                <td><%#Eval("Info")%></td>
            </tr>
            </ItemTemplate>
           </asp:Repeater>
        </table>
        <cc1:Paging ID="Paging2" runat="server" ShowPageGo="True" ShowPageJump="True" 
            ShowPageTips="True" PageSize="50" ShowPageLan="2">
        </cc1:Paging>

    </div>
    </form>
</body>
</html>
