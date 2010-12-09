/********************************************************
    @Desc       :  首页JavaSrcript代码
    @Author     :  Foolin
    @Email      :  Foolin@126.com
    @Created on :  2010-12-1
    @Updated on :  2010-12-2
    Copyright 2010 7dong.net All Rights Reserved.
********************************************************/

$(document).ready(function(){
    //桌面占满屏幕
    $("#desktop").css("height", $(window).height());
	//初始化小窗口，如果参数传入Url的话
	initUrlWin();
	
});


function initUrlWin(){
    //获取参数
    var url = $Request.get('url');
    var title = $Request.get('title');
    var width = $Request.get('width');
    var height = $Request.get('height');
    var modal = $Request.get("modal");
    if(url)
    {
        openUrlWin(url, title, true, width, height);
    }
}


/**** 用户登录 ********/
function loadRegisterWin(){
	openUrlWin("User/Register.aspx", "新用户注册", true, "500", "400", "no");
}


/******** 弹出]文本窗口 *********/
function openTxtWin(content, title, modal, width, height)
{
    if(!url)	{ alert("URL参数错误！"); return;}
    if(!title)	{ title = "窗口";}
	if(!width)	{ width=500};
	if(!height)	{ height=450};
	if(!modal) { modal = true;}
    
    $("#window").window({
				title: title + ' - 启动网（7dong.net）',
				width: width,
				collapsible: false,
				maximizable: false,
				minimizable: false,
				modal: true,
				shadow: false,
				closed: false,
				height: height
			});
	
	$("#window").html(content);
}
/***** 关闭窗口 ******/
function closeTxtWin(){
	$('#window').window("close");
}

/******** 弹出URL窗口 *********/
function openUrlWin(url, title, modal, width, height, scrolling)
{
    if(!url)	{ alert("URL参数错误！"); return;}
    if(!title)	{ title = "窗口";}
	if(!width)	{ width=500};
	if(!height)	{ height=450};
	if(!modal) { modal = true;}
	
	var strScroll = "auto";
	if(scrolling) {
		if(scrolling == "no")
			strScroll = "no";
		else if( scrolling = "yes")
			strScroll = "yes";
		else
			strScroll = "auto";
	}
	
    $("#window").window({
				title: title + ' - 启动网（7dong.net）',
				width: width,
				collapsible: false,
				maximizable: true,
				minimizable: false,
				modal: true,
				shadow: false,
				closed: false,
				height: height,
				onClose: function(){
				    top.window.document.title = '启动网 - 畅游网络，从此启动！';
				}
			});
	
	$("#window").html("<div id=\"winLoading\"><img src=\"style/images/loading.gif\" />加载中，请稍候...</div><iframe name=\"winFrame\" id=\"winFrame\" src=\"about:blank\" frameborder=\"0\" height=\"0\" width=\"0\" scrolling=\""+ strScroll +"\"></iframe>");
	$("#winFrame").attr("src", url);
	$("#winFrame").load(function(){ 
        $("#winLoading").hide();
        $("#winFrame").attr("width","100%");
        $("#winFrame").attr("height","100%");
    });
    
    top.window.document.title = title + ' - 启动网（7dong.net）';
}

/***** 关闭窗口 ******/
function closeUrlWin(){
	$('#window').window("close");
	top.window.document.title = '启动网 - 畅游网络，从此启动！';
	
}

