<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FavList.aspx.cs" Inherits="Favorite_FavList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>搜藏夹列表</title>
</head>
<body>
    <table class="easyui-datagrid" fitColumns="true">
		<thead>
			<tr>
			    <th field="FavID" checkbox="true" width="10" style="width:100px;"><input type="checkbox" name="selAllIds" /></th>
				<th field="Title" width="100" style="width:100px;">标题</th>
				<th field="URL" width="200">网址</th>
			</tr>
		</thead>
		<tbody>
			<tr>
			    <td>1</td>
				<td>E酷网络</td>
				<td>http://www.eekku.com</td>
			</tr>
			<tr>
			    <td>2</td>
				<td>启动网</td>
				<td>http://www.7dong.net</td>
			</tr>
			<tr>
			    <td>3</td>
				<td>刘付氏族网</td>
				<td>http://www.liufu.org</td>
			</tr>
			<tr>
			    <td><input type="checkbox" name="FavID" value="1" /></td>
				<td>刘付氏族网</td>
				<td>http://www.liufu.org</td>
			</tr>
			<tr>
			    <td><input type="checkbox" name="FavID" value="1" /></td>
				<td>刘付氏族网</td>
				<td>http://www.liufu.org</td>
			</tr>
		</tbody>
	</table>
	<div class="page"><a href="FavList.aspx?id=1&page=2">第二页</a></div>
</body>
</html>
