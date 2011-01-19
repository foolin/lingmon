<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Favorite_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>启动网—收藏夹|www.7dong.net</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="../style/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.min.js" type="text/javascript"></script>
    <style type="text/css">
        .divLogo
        {
        	float:left;
        	width:30%;
        }
        .divRight
        {
        	float:right;
        	width:70%;
        	text-align:right;
        }
    </style>
    
    <script type="text/javascript">
		$(function(){
            $(".favCategory a").click(function(){
                  //取是否存在tab属性
		        var _isNewTab = $(this).attr("tab");
		        var _title =  $(this).html();   //标题
		        var _href = $(this).attr("href");   //连接
		        var tab = $('#ttWinTabs').tabs('getTab',_title);
		        
		        //如果不存在，则置默认的窗口
		        if(!_isNewTab || _isNewTab != "true")
		        {
		            var _defaultTab = $('#ttWinTabs').tabs('tabs')[0];
		            if(_defaultTab)
		            {
		                var _defaultTabTitle = _defaultTab.panel('options').title;
		                $('#ttWinTabs').tabs('select', _defaultTabTitle);
			        }
			        
			        //返回真，即是跳转到该连接
		            return true;
		        }
 
		        if(!tab)
		        {
		            //添加
		            $('#ttWinTabs').tabs('add',{
				        title: _title,
				        href: _href,
				        closable:true
			        });
			     }
			     else
			     {
			        //更新
			        $('#ttWinTabs').tabs('update', {
				        tab: tab,
				        options:{
					        title: _title,
				            href:_href,
				            closable:true
				        }
			        });
			     }
			     $('#ttWinTabs').tabs('select', _title);    //选择
			    return false;
			});
		});
	</script>
	<base target="mainFrame" />
</head>
<body class="easyui-layout">
	<div  region="north" border="false" style="height:50px;background:#F9F9F9; overflow:hidden;">
	    <div class="divLogo">
	        <a href="../"> <img src="../style/images/miniLogo.gif" height="45" border="0"  alt="启动网" /> </a>
	    </div>
	    <div class="divRight">
	        <span>
	            <input type="text" name="soKeyword" value="请输入关键词" />
	            <input type="button" name="soGO" value="搜索" />
	        </span>
	    </div>
	</div>
	
	
	<div region="west" split="true" title="Hi，Foolin" style="width:200px;padding:10px;">
	    <div class="favCategory">
	        <ul class="easyui-tree" animate="true" dnd="true"> 
                <li> 
                    <span>控制面板</span> 
                    <ul> 
                        <li><a href="http://www.7dong.net" tab="false">我的资料</a></li> 
                        
                        <li><a href="Logout.aspx"  tab="false">退出登录</a></li> 
                    </ul> 
                </li> 
          	</ul>
            <ul class="easyui-tree" animate="true" dnd="true"> 
                <li> 
                    <span>我的收藏夹</span> 
                    <ul> 
                        <li><a href="FavList.aspx?CategoryID=1" tab="true">网站开发</a></li>
                        <li> <span><a href="FavList.aspx?CategoryID=1" tab="true">娱乐频道</a></span>
                            <ul>
                                <li><a href="FavList.aspx?CategoryID=1" tab="true">E酷网络</a></li>
                            </ul>
                        </li> 
                    </ul> 
                </li> 
          	</ul>
	    </div>
	</div>
    
    	
	<div region="center">
        <div class="easyui-tabs" id="ttWinTabs"  fit="true"  border="false" > 
	        <div  title="启动网欢迎您！"  fit="true" style="padding:0px;"> 
	            <iframe name="mainFrame" id="mainFrame" src="FavList.aspx" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> 
	        </div> 
	    </div> 
	</div>
	
	
	<div region="south" border="false" style="height:30px;background:#eee;text-align:center; line-height:30px; overflow:hidden;">
	    Copyright &copy 2011 启动网(7dong.net). All Rights Reserved
	</div>
	

</body>
</html>

