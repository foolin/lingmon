/********************************************************
    @Desc       :  首页JavaSrcript代码
    @Author     :  Foolin
    @Email      :  Foolin@126.com
    @Created on :  2010-12-1
    @Updated on :  2010-12-2
    Copyright 2010 灵梦工作室 All Rights Reserved.
********************************************************/



/************************************************/
/*             打开Win窗口函数                  */
/************************************************/
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
				    //top.window.location.href = "#";
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
    
    top.window.location.href = "#url=" + url + "&title=" + title + "&width=" + width + "&height=" + height + "&scrolling=" + scrolling;
    top.window.document.title = title + ' - 启动网（7dong.net）';
}

/***** 关闭窗口 ******/
function closeUrlWin(){
	$('#window').window("close");
	top.window.document.title = '启动网 - 畅游网络，从此启动！';
	
}



/************************************************/
/*               网址缩略图功能                 */
/************************************************/
	
	$(document).ready(function(){
        initThumbUrl();
		
	});
	
	/*
	function enableEditThumbURL()
	{
			$('.thumbURL dl').draggable({
					revert:true,
					proxy:'clone',
					handle:'.title'
			}).droppable({
				onDragEnter:function(){
					$(this).addClass('over');
				},
				onDragLeave:function(){
					$(this).removeClass('over');
				},
				onDrop:function(e,source){
					$(this).removeClass('over');
					var src = $(source).children().clone();	//复制源子元素
					var thi = $(this).children().clone();	//复制this元素
					$(this).empty().append(src);
					$(source).empty().append(thi);
				}
			});
	}
	
	
	function disableEditThumbURL(){
		$('.thumbURL dl').disable();
		alert("Disable OK!");
	}
	*/
	

	
    /******************** ThumbUrl载入数据 **********************/
	
	//初始化URL数据
	function initThumbUrl()
	{
	    var datThumbUrl = getCookie("ThumbUrl");
	    
	    if(!datThumbUrl)
	    {
	        AjaxLoadThumbUrl();
	    }
	    else
	    {
	        FillThumbUrl(eval(datThumbUrl));
	    }
	}
	
	
	//异步取URL数据
    function AjaxLoadThumbUrl(){
        $.ajax({
           type: "GET",
           url: "Ajax/GetThumbUrlList.aspx?UserID=2&ramdom=" + parseInt(Math.random() * 9999 + 1).toString(),
           data: "",
           dataType: "text",
           success: function(data){
             data = data.replace(/\n/g,"").replace(/\r/g,"").replace(/\s/g,""); //过滤掉\r\n\空格等字符
             setCookie('ThumbUrl', data);  //存储
             FillThumbUrl(eval(data));
             
           },
           error: function(XMLHttpRequest, textStatus, errorThrown) 
           {
                alert("出错啦，请稍候再试！");
           }
        });
    }
    
    //取得Json数据，将数据进行填充
	function FillThumbUrl(data){
			/* 2011-1-2 21:28:29
		    <div class="item">
            <dl>
    	            <dt class="title">启动网1</dt>
                    <dd class="img">
                        <a href="http://www.7dong.net" target="_blank"><img src="style/images/img1.png" /></a>
                    </dd>
                    <dd class="url"><a href="http://www.7dong.net" target="_blank">http://www.7dong.net</a></dd>
             </dl>
             </div>
            */
	        var thumHtml = "<div class=\"thumbURL\">";
	        
            for(var i = 0; i < data.length; i++)
            {
                if(!data[i].title || data[i].title == "")  data[i].title="启动网";
                if(!data[i].url || data[i].url == "") data[i].url = "http://www.7dong.net";
                if(!data[i].img || data[i].img == "") data[i].img = "style/images/thumburl/nopic.jpg";
                if(!data[i].target || data[i].target == "") data[i].target = "_self";
                thumHtml += "<div class=\"item\">";
	            thumHtml += "<dl>";
	            thumHtml += "  <dt class=\"title\">"+ data[i].title +"</dt>";
	            thumHtml += "  <dd class=\"img\">";
	            thumHtml += "  <a href=\""+ data[i].url +"\" target=\""+ data[i].target +"\">";
	            thumHtml += "    <img src=\""+ data[i].img +"\" />";
	            thumHtml += "  </a>";
	            thumHtml += "  </dd>"
	            thumHtml += "  <dd class=\"url\">";
	            thumHtml += "  <a href=\""+ data[i].url +"\" title=\""+ data[i].title +"\" target=\""+ data[i].target +"\">";
	            thumHtml += "    "+ data[i].url +"";
	            thumHtml += "  </a>";
	            thumHtml += "  </dd>"
	            thumHtml += "</dl>";
	            thumHtml += "</div>";
            }
		    
	        thumHtml += "</div>"
		    
	        $("#thumbURL").html(thumHtml);
            initThumbUrlJs(); //初始化JS功能
	}
    
    
    
    /************* ThumbUrl保存数据 **************/
	
	//保存URL数据
	function saveThumbUrl(){
	    var strJson = "";
	    $("#thumbURL dl").each(function(i){
	        var title = $(this).find(".title").html();
	        var img = $(this).find(".img img").attr("src").replace(/\s/g,"").replace($Domain + "/", "");    //replace($Domain,"")过滤掉IE自动添加成绝对路径
	        var url = $(this).find(".img a").attr("href");
	        var target = $(this).find(".img a").attr("target");
	        
	        if(!url) return false;
	        if(!title) title = "";
	        if(!img) img = "";
	        if(!target) target = "";
	        
	        if(i > 0){
	            strJson += " ,";
	        }
	        
	        strJson += "{'title':'" + title + "', 'img':'" + img + "', 'url':'"+ url +"', target:'"+ target +"'}"
	    });
	    strJson = "[" + strJson + "]";
	    delCookie("ThumbUrl");  //删除
	    setCookie("ThumbUrl", strJson); //添加
	    
	    
	    //提示保存成功
	    $.messager.show({title:"温馨提示—启动网",msg:"恭喜您，您保存数据成功！"});
	}
	
	
	//自动保存ThumbUrl数据
	function autoSaveThumbUrl(){
	    //$("#saveThumbUrl").show();
	    saveThumbUrl();
	}
    

    /********************* ThumbUrl编辑功能 Code Begin ***********************/
	
	//全局变量
	var currThumbUrlItemIndex = -1; //找当前ThumbUrl索引
	var isLockThumbUrlItemIndex = false;    //是否锁定
	
	
	//初始化Javascipt脚本
	function initThumbUrlJs()
	{
	    //添加拖动排序
		$('.thumbURL dl').draggable({
				revert:true,
				proxy:'clone',
				handle:'.title'
		}).droppable({
			onDragEnter:function(){
				$(this).addClass('over');
			},
			onDragLeave:function(){
				$(this).removeClass('over');
			},
			onDrop:function(e,source){
				$(this).removeClass('over');
				var src = $(source).children().clone();	//复制源子元素
				var thi = $(this).children().clone();	//复制this元素
				$(this).empty().append(src);
				$(source).empty().append(thi);
				$(this).draggable({
					revert:true,
					proxy:'clone',
					handle:'.title'
				});
				$(source).draggable({
					revert:true,
					proxy:'clone',
					handle:'.title'
				});
				
				//保存
				autoSaveThumbUrl();
			}
		});
        
        //移动添加时激活特效
	    $("#thumbURL dl").mouseover(function(){
	        $(this).addClass("on");
	     });
	     $("#thumbURL dl").mouseout(function(){
	        $(this).removeClass("on");
	     });
	    
	    //添加右键菜单
	    $(".item").bind('contextmenu',function(e){
			$('#mmThumbUrl').menu('show', {
				left: e.pageX,
				top: e.pageY
			});
			return false;
		});
	
		
		//查找当前索引，右键菜单选项传递当前索引
		$("#thumbURL .item").mouseover(function(){
		    if(isLockThumbUrlItemIndex == false)
		    {
		        currThumbUrlItemIndex = $(this).prevAll().length;
		    }
		});
	}
	
	
	//编辑：isAdd=是否添加
	function mmEditThumbUrl(isAdd){

        //如果不存在isAdd或者isAdd=false
	    if(isAdd && isAdd == true)
	    {
	        $("#ddEditThumbUrl input[name='txtTitle']").val('');
            $("#ddEditThumbUrl input[name='txtUrl']").val('http://');
            $("#ddEditThumbUrl input[name='txtImg']").val('');
            //$("#ddEditThumbUrl select[name='selTarget']").val('');
	    }
	    else
	    {
	        if(currThumbUrlItemIndex == -1)
	        {
	            return false;
	        }
	        //找当前节点
	        var thisNode = $("#thumbURL .item").get(currThumbUrlItemIndex);
	        if(!thisNode)
	        {
	            return false;
	        }
	        
	        //取内容
	        var title = $(thisNode).find(".title").html();
            var img = $(thisNode).find(".img img").attr("src").replace(/\s/g,"").replace($Domain + "/", "");    //replace($Domain,"")过滤掉IE自动添加成绝对路径
            var url = $(thisNode).find(".img a").attr("href").replace(/\s/g,"");
            var target = $(thisNode).find("a").attr("target").replace(/\s/g,"");
	        
	        
            $("#ddEditThumbUrl input[name='txtTitle']").val(title);
            $("#ddEditThumbUrl input[name='txtUrl']").val(url);
            $("#ddEditThumbUrl input[name='txtImg']").val(img);
            $("#ddEditThumbUrl select[name='selTarget']").val(target);
	        
	    }

        var dlgTitle = "编辑URL—启动网";
        if(isAdd && isAdd == true)
	    {
	        dlgTitle = "添加URL—启动网";
	    }
	    
//		    $('#ddEditThumbUrl').dialog('setTitle', dlgTitle);
//		    $('#ddEditThumbUrl').dialog('open');
	    
	    
	    //先显示，再打开
	    $('#ddEditThumbUrl').show();
        //打开Dailog
	    $('#ddEditThumbUrl').dialog({
	        title: dlgTitle,
			buttons:[{
				text:'保存',
				iconCls:'icon-ok',
				handler:function(){
				    if(mmEditThumbUrl_Save(isAdd))
				    {
				        $('#ddEditThumbUrl').dialog('close');
				    }
				}
			},{
				text:'取消',
				handler:function(){
				    mmEditThumbUrl_Cancel();
					$('#ddEditThumbUrl').dialog('close');
				}
			}]
		});
		
		
		//锁定
		isLockThumbUrlItemIndex = true;
		
	    
	};
	
	//编辑网址保存
	function mmEditThumbUrl_Save(isAdd){

	    if(currThumbUrlItemIndex == -1)
	    {
	        return false;
	    }
	    //找当前节点
	    var thisNode = $("#thumbURL .item").get(currThumbUrlItemIndex);
	    if(!thisNode)
	    {
	        return false;
	    }
	    
	    //取内容
	    var title = $("#ddEditThumbUrl input[name='txtTitle']").val();
        var img = $("#ddEditThumbUrl input[name='txtImg']").val().replace(/\s/g,"");
        var url = $("#ddEditThumbUrl input[name='txtUrl']").val().replace(/\s/g,"");
        var target = $("#ddEditThumbUrl select[name='selTarget']").val().replace(/\s/g,"");
        
        if(!title || title == "") title = "无标题";
        if(!img || img == "") img = "style/images/thumburl/nopic.jpg";
        if(!url || url == "" || url.toLowerCase() == "http://" )
        {
            alert("网址不能为空！");
            return false;
        }
	    
	    //判断是否时添加
	    if(isAdd && isAdd == true)
	    {
	        var newNode = $(thisNode).clone();
            //保存
            $(newNode).find(".title").html(title);
            $(newNode).find(".img img").attr("src", img);
            $(newNode).find("a").attr("href", url);
            $(newNode).find("a").attr("target", target);
            $(newNode).find(".url a").html(url);
            $(thisNode).before(newNode);
            
		    //提示保存成功
	        $.messager.show({title:"温馨提示",msg:"恭喜您，您添加成功！"});
	        initThumbUrlJs();
	    }
	    else
	    {
            //保存
            $(thisNode).find(".title").html(title);
            $(thisNode).find(".img img").attr("src", img);
            $(thisNode).find("a").attr("href", url);
            $(thisNode).find("a").attr("target", target);
            $(thisNode).find(".url a").html(url);
            
		    //提示保存成功
	        $.messager.show({title:"温馨提示",msg:"恭喜您，您编辑成功！"});
        }
        
        
	    //取消锁定
		isLockThumbUrlItemIndex = false;
		//保存
		autoSaveThumbUrl();
		
		
		return true;
		
	};
	
	//编辑网址取消
	function  mmEditThumbUrl_Cancel(){
	    //取消锁定
		isLockThumbUrlItemIndex = false;
	}
	
	//删除
	function mmDeleteThumbUrl(){
	
	    if(currThumbUrlItemIndex == -1)
	    {
	        return false;
	    }
	    //找当前节点
	    var thisNode = $("#thumbURL .item").get(currThumbUrlItemIndex);
	    if(!thisNode)
	    {
	        return false;
	    }
	    if(confirm('确定删除？'))
	    {
	        $(thisNode).remove();
	    }
	    
	    //提示保存成功
	    $.messager.show({title:"温馨提示",msg:"恭喜您，删除成功！"});
	    //保存
	    autoSaveThumbUrl();
	    
	};
	
	/********************* ThumbUrl编辑功能 Code End ***********************/




