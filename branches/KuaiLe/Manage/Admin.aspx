<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="_Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7" /> 
    <title>欢迎使用查询系统</title>
	<link rel="stylesheet" type="text/css" href="../js/themes/default/easyui.css">
	<link rel="stylesheet" type="text/css" href="../js/themes/icon.css">
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/jquery.min.js"></script>
	<script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript">
		//绑定是否Tab打开，如果需要Tab打开，在<a href>连接里加tab="true"即可。
		$(document).ready(function(){
		
		    $(".siderMenu a").click(function(){
		    
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
				        content:'<iframe name="mainFrameTab" src="'+ _href +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> ',
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
				            content:'<iframe name="mainFrameTab" src="'+ _href +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> ',
				            closable:true
				        }
			        });
			     }
			     $('#ttWinTabs').tabs('select', _title);    //选择
			    return false;
			});
			
			
            //右键打开新窗口
		    $(".siderMenu a").bind('contextmenu',function(e){
			    $('#mmTabCtrl').menu('show', {
				    left: e.pageX,
				    top: e.pageY
			    });
			    return false;
		    }).mousedown(function(e){   //绑定鼠标右键
                  if(3 == e.which){
                    GB_MenuCurrUrl.title = $(this).html();
                    GB_MenuCurrUrl.url = $(this).attr("href");
                  }
            });
		    
			
		});
		

		
		
		/***** 右键打开连接函数 ******/
		
		//全局变量
		var GB_MenuCurrUrl = {title:"",url:""};
		//默认：mode=0，当前窗口:mode=1,新窗口:mode=2
		function openTab(mode)
		{
		    if(!GB_MenuCurrUrl.title || !GB_MenuCurrUrl.url
		    || GB_MenuCurrUrl.title == "" || GB_MenuCurrUrl.url == "")
		    {
		        return;
		    }
		    
		    //当前标签
		    if(mode && mode == 1)
		    {
		        var tab = $('#ttWinTabs').tabs('getSelected');
		        //如果当前页是默认页，则iframe的name和id不变
		        if(tab.panel('options').title == $('#ttWinTabs').tabs('tabs')[0].panel('options').title)
		        {
                    $('#ttWinTabs').tabs('update', {
			            tab: tab,
			            options:{
			                content:'<iframe name="mainFrame"  id="mainFrame" src="'+  GB_MenuCurrUrl.url +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> '
			            }
		            });
		        }
		        else
		        {
		            $('#ttWinTabs').tabs('update', {
			            tab: tab,
			            options:{
				            title: GB_MenuCurrUrl.title ,
			                content:'<iframe name="mainFrameTab" src="'+  GB_MenuCurrUrl.url +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> ',
			                closable:true
			            }
		            });
		        }
		    }
		    //新标签
		    else if(mode && mode == 2)
		    {
                    $('#ttWinTabs').tabs('add',{
		                title: GB_MenuCurrUrl.title,
		                content:'<iframe name="mainFrameTab" src="'+ GB_MenuCurrUrl.url +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> ',
		                closable:true
	                });
	        }
	        //默认标签
	        else
	        {
	            var _defaultTab = $('#ttWinTabs').tabs('tabs')[0];
	            $('#ttWinTabs').tabs('update', {
			        tab: _defaultTab,
			        options:{
			            content:'<iframe name="mainFrame"  id="mainFrame" src="'+  GB_MenuCurrUrl.url +'" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe> ',
			            closable:false
			        }
		        });
		        $('#ttWinTabs').tabs('select', _defaultTab.panel('options').title);    //选择
	        }

		}
		
		
		
		
		//加载提示
		window.onload = function(){
            $('#loading-mask').fadeOut('slow');
        }
		
	</script>
    <base target="mainFrame" />
</head>
<body  class="easyui-layout">
    
    <!-- 加载提示 -->
    <div id="loading-mask" style="position:absolute;top:0px; left:0px; width:100%; height:100%; background:#F6F6F6;  z-index:20000"> 
    <div id="pageloading" style="position:absolute; top:50%; left:50%; margin:-120px 0px 0px -120px; text-align:center;  border:4px solid #C1E0FF; width:200px; height:30px;  font-size:14px;padding:10px; font-weight:bold; background:#fff; color:#09F;"> 
        <img src="../images/loading32.gif" align="absmiddle" height="22" /> 正在加载中,请稍候...</div> 
    </div> 
    

	<div region="west" split="true" title="Hi,欢迎" style="width:200px;">
        
        <div class="siderMenu" id="siderMenu">
        <ul class="easyui-tree" animate="true" dnd="true"> 
        
            <%--<li state="closed">--%>
            <li>
                <span>控制面板</span>
                <ul>
                    <li><a href="User/UserDetail.aspx?UserID=" tab="true">退出登录</a></li>
                    <li><a href="User/PasswordEdit.aspx">修改密码</a></li>
                </ul>
            </li>
            
		    <li> 
			    <span>文章管理</span>
			    <ul>
				    <li> 
					    <span><a href="Article/ArtList.aspx?type=uncheck"  tab="true">待审核文章</a></span>
				    </li> 
				    <li> 
					    <span><a href="Article/ArtList.aspx?type=check"  tab="true">已审核文章</a></span>
				    </li> 
				    <li> 
					    <span><a href="Article/ArtList.aspx?type=report"  tab="true">被举报文章</a></span>
				    </li>
				    <li> 
					    <span><a href="Article/ArtList.aspx"  tab="true">全部文章</a></span>
				    </li>
				    <li> 
					    <span><a href="Article/ArtList.aspx?type=trash">文章回收站</a></span>
				    </li>
			    </ul> 
		    </li> 
		    
		    
		    <li> 
			    <span>评论管理</span>
			    <ul>
				    <li> 
					    <span><a href="Comment/CommentList.aspx?type=uncheck"  tab="true">待审核评论</a></span>
				    </li> 
				    <li> 
					    <span><a href="Comment/CommentList.aspx?type=check"  tab="true">全部评论</a></span>
				    </li> 
				    <li> 
					    <span><a href="Comment/CommentList.aspx?type=report"  tab="true">被举报评论</a></span>
				    </li>
				    <li> 
					    <span><a href="Comment/CommentList.aspx"  tab="true">全部评论</a></span>
				    </li>  
				    <li> 
					    <span><a href="Comment/CommentList.aspx?type=trash">评论回收站</a></span>
				    </li>
			    </ul> 
		    </li> 
		    
		    <li> 
			    <span>公告管理</span>
			    <ul>
				    <li> 
					    <span><a href="Notice/NoticeList.aspx"  tab="true">公告列表</a></span>
				    </li> 
				    <li> 
					    <span><a href="Notice/NoticeAdd.aspx"  tab="true">添加公告</a></span>
				    </li> 
			    </ul> 
		    </li> 
		    
		    <li> 
			    <span>用户管理</span>
			    <ul>
				    <li> 
					    <span><a href="User/UserList.aspx?type=notrash"  tab="true">用户列表</a></span>
					    <ul stated="closed">
					        <li><span><a href="User/UserList.aspx?type=vip"  tab="true">VIP用户</a></span></li>
					        <li><span><a href="User/UserList.aspx?type=activate"  tab="true">已激活用户</a></span></li>
					        <li><span><a href="User/UserList.aspx?type=noactivate"  tab="true">未激活用户</a></span></li>
					    </ul>
				    </li> 
				    <li> 
					    <span><a href="User/UserList.aspx?type=trash" tab="true">冻结用户</a></span>
				    </li>
				    <li> 
					    <span><a href="User/UserList.aspx"  tab="true">全部用户</a></span>
				    </li>
			    </ul> 
		    </li> 
		    
	    </ul> 
	    </div>

    </div>
	<div region="center" >
	    <div class="easyui-tabs" id="ttWinTabs"  fit="true"  border="false" >
	        <div  title="欢迎使用本系统！"  fit="true"  style="padding:0px;">
	            <iframe name="mainFrame" id="mainFrame" src="Article/ArtList.aspx?type=uncheck" frameborder="0" height="100%" width="100%" scrolling="auto"></iframe>
	        </div>
	    </div>
	</div>
	
		
	<div id="window">
    </div>
    
    <div id="mmTabCtrl" class="easyui-menu" style="width:120px;">
		<div onclick="openTab(2)">新标签打开</div>
		<div onclick="openTab(1)">当前标签打开</div>
		<div onclick="openTab(0)">默认标签打开</div>
    </div>
    

    
</body>
</html>
