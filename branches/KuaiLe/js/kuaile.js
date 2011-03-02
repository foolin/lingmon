/*
 @Author: Foolin
 @Desc  : JavaScript
 @Date  : 2011-02-02
 @Copyright 灵梦工作室 版权所有
*/

var KL_ROOT = $_Domain("");    //虚拟目录

$(function() {
    _KL_FormInputTip(); //输入框提示
    _KL_ListItemMaxHeight();
    //_KL_ListItemFocus();	//列表项激活
    //_KL_ListCommentFocus();	//评论框详细版
    _KL_ListCommentWordCountTip(); //检查评论字符数
    _KL_ListArticleWordCountTip(); //检查文章字符数
    //alignHeight("containerMain","containerSider"); //只需将需要对齐的两个模块的id写在此处即可。
});

/******** 两栏自动适应高度 *****/
function alignHeight(eleA,eleB){
  if(!document.getElementById(eleA)){return false;}
  if(!document.getElementById(eleB)){return false;}
  document.getElementById(eleB).style.height = "auto";
  document.getElementById(eleA).style.height = "auto";
  var heightA = document.getElementById(eleA).clientHeight;
  var heightB = document.getElementById(eleB).clientHeight;
  if(heightA > heightB){
	document.getElementById(eleB).style.height = heightA + "px";
	document.getElementById(eleA).style.height = heightA + "px";
  }else{
	document.getElementById(eleA).style.height = heightB + "px";
	document.getElementById(eleB).style.height = heightB + "px";
  }
}


/********** 输入框提示 ************/
function _KL_FormInputTip(){
	$("input[tip],textarea[tip]").each(function(i){
		var val = $(this).val();
		var tip = $(this).attr("tip");
		if(!tip || tip == "")
		{
			return ;
		}
		if(!val || val == ""){
			$(this).css("color","#999");
			$(this).val(tip);
		}
		
      	
		if(tip && tip != ""){
			$(this).blur( function () {
				var bVal = $(this).val();
				if(!bVal || bVal == ""){
					$(this).css("color","#999");
					$(this).val(tip);
				}
			});	
			$(this).focus( function () {
				var fVal = $(this).val();
				if(fVal == tip)
				{
					$(this).val("");
				}
				$(this).css("color","#000");
			});	
		}
	});
}


/**** 列表内容 ******/
function _KL_ListItemFocus(){
	$(".item").mouseover(function(){
		$(this).addClass("itemOn");
	}).mouseout(function(){
		$(this).removeClass("itemOn");
	});
}
function _KL_ListItemMaxHeight(){
	$(".itemContent").each(function(){
		var height = $(this).height();
		if(height > 200)
		{
			$(this).height("200");
			$(this).css("overflow","hidden");
			$(this).parent().find(".moreDetail").show();
		}
		
	});
}

function moreDetail(_this){
	var height = $(_this).parent().parent().find(".itemContent").height();
	if(height > 200)
	{
		$(_this).parent().parent().find(".itemContent").height("200");
		$(_this).parent().parent().find(".itemContent").css("overflow","hidden");
		$(_this).html("展开全部>>");
	}
	else
	{
		$(_this).parent().parent().find(".itemContent").css("height","auto");
		$(_this).html("<<收起隐藏");
		
	}
}

/****** 列表评论框 ******/
function _KL_ListCommentFocus(){
	$("textarea[name='comment']").bind("focus click",function(){
		$(this).addClass("focus");
		$(this).parent().parent().find(".btnArea").show();
	}).blur(function(){
		$(this).find(".focus").removeClass("focus");
		$(this).find(".btnArea").hide();
	});
	//alignHeight("containerMain","containerSider"); 
}

function _KL_ListCommentWordCountTip(){
	$("textarea[name='comment']").keyup(function(){
		var maxLength = $(this).attr("maxlen");
		if(!maxLength || maxLength <= 0){
			maxLength = 0;
		}
		
		var textVal = $(this).val() + "";
		var currLength = textVal.length;
		if(!currLength || currLength < 0){
			currLength = 0;
		}
		
		if(maxLength > 0 && currLength > maxLength)
		{
			$(this).val(textVal.substring(0, maxLength));
			currLength = maxLength;
		}
		
		var tip = "";
		if(maxLength > 0){
			tip = (maxLength-currLength) + "/" + maxLength;
		}
		else{
			tip = (maxLength-currLength) + "";
		}

		//alert(tip);
		$(this).parent().parent().find(".indicator").html(tip);
		
	});
}

/******* 显示隐藏评论 *****/
function toggleComment(artid) {
	var el = $("#itemInputComment-" + artid);
	if(!el) return;
	$(".itemInputComment").each(function(i){
		if($(this).attr("id") !=  el.attr("id")){
			$(this).hide();
		}
	});

	el.slideToggle();

	$("#commentList-" + artid).html("评论加载中。。。");
	$.get( KL_ROOT + "/Handle/CommentList.ashx?ArtID=" + artid + "&t=" + new Date().getTime(),
      function(data) {
          $("#commentList-" + artid).html(data);
      });
	
	//alignHeight("containerMain","containerSider"); 
}


function postComment(artid, _thisbtn) {
    var comment = $("#comment-" + artid).val() + "";
    if (comment.replace(/\s/ig, "") == "") {
        $.messager.show({ title: "温馨提示 — 快乐网(kuaile.us)",
            msg: "<font color='red'>评论内容不能为空！</font>"
        });
    }

    var commentUserName = $("#commentUserName-" + artid).val() + "";
    var commentChkCode = $("#commentChkCode-" + artid).val() + "";

    //禁用
    $(_thisbtn).attr("disabled", "disabled");
    $(_thisbtn).val("评论正在提交...");

    $.ajax({
        type: "POST",
        url: KL_ROOT + "/Handle/CommentAdd.ashx?t=" + new Date().getTime(),
        data: { "ArtID": artid,
            "Comment": comment,
            "CommentUserName": commentUserName,
            "CommentChkCode": commentChkCode
        },
        success: function(msg) {
            if (!msg || msg == "") {
                msg = "你提交的评论成功，请耐心等候我们的审核，谢谢！";
            }
            $.messager.show({ title: "温馨提示 — 快乐网(kuaile.us)",
                msg: "<font color='blue'>√ " + msg + "</font>"
            });

            //清空评论
            $("#comment-" + artid).val("");
            $("#commentUserName-" + artid).val("");
            $("#commentChkCode-" + artid).val("");
            refreshCode('#imgCommentChkCode-' + artid); //刷新验证码

            //刷新评论
            $("#commentList-" + artid).html("评论刷新中。。。");
            $.get(KL_ROOT + "/Handle/CommentList.ashx?ArtID=" + artid + "&t=" + new Date().getTime(),
              function(data) {
                  $("#commentList-" + artid).html(data);
              });

        },
        error: function(xhr) {
            var errmsg = xhr.responseText + "";
            if (errmsg == "") {
                errmsg = "操作错误，请稍后重试！";
            }
            $.messager.show({ title: "温馨提示 — 快乐网(kuaile.us)",
                msg: "<font color='red'> ×" + errmsg + "</font>"
            });

        }
    });
    
    //启动
    $(_thisbtn).attr("disabled", "");
    $(_thisbtn).val("发表");
    
    
}


/******** 表单提示 *********/

//提示，ID,信息，类型：0=无，1=成功，-1=失败
function formTip(id, msg, type){
    if(type == 1){
        msg = "√ " + msg;
        $("#" + id).css("color","#090");
    }
    else if(type == -1){
        msg = "× " + msg;
        $("#" + id).css("color","#f00");
    }
    else{
        $("#" + id).css("color","#000");
    }
    $("#" + id).html(msg);
};


/********* 顶、踩、举报 ************/
//顶: id：ID； Type：0=顶，1=踩，2=举报； src="Article|Comment"
function dig(id, digType, srcType){
    if(!id) return;
    if(!digType) digType = 0;
    if(!srcType) srcType = "Article";
    
    $.ajax({
       type: "Get",
       url: KL_ROOT + "/Handle/Dig.ashx?t=" + new Date().getTime(),
       data: { "SrcID": id,
               "DigType": digType,
               "SrcType":srcType
                
       },
       success: function(msg){
             if(!msg || msg == ""){
                msg = "你提交的帖子成功，请耐心等候我们的审核，谢谢！";
             }
             $.messager.show({title:"温馨提示 — 快乐网(kuaile.us)",
                msg:"<font color='blue'>√ "+ msg+"</font>"
             });
       },
       error: function(xhr){
            var errmsg = xhr.responseText + "";
            if(errmsg == "")
            {
                errmsg = "操作错误，请稍后重试！";
            }
            $.messager.show({title:"温馨提示 — 快乐网(kuaile.us)",
                msg:"<font color='red'> ×"+ errmsg+"]</font>"
            });
             
       }
    });

}



//刷新
function refreshCode(id) {
    $(id).attr("src",KL_ROOT + "/Handle/ChkCodeImage.ashx?t=" + new Date().getTime());
}

//检查是否登录
function checkIsLogin(){
    $.ajax({
        type: "GET",
        url: KL_ROOT + "/Handle/IsAuthPost.ashx?t=" + new Date().getTime(),
        success: function(data) {
        },
        error: function(xhr) {
            var errmsg = xhr.responseText + "";
            if (errmsg == "") {
                errmsg = "对不起，你暂未有权限发表，请联系本站客服。";
            }
            $.messager.alert("对不起，没有权限操作", errmsg, "error");
        }
    });
};

/**************** 提交文章  *****************/

function _KL_ListArticleWordCountTip() {
    $("#artContent").keyup(function() {
        var maxLength = $(this).attr("maxlen");
        if (!maxLength || maxLength <= 0) {
            maxLength = 0;
        }

        var textVal = $(this).val() + "";
        var currLength = textVal.length;
        if (!currLength || currLength < 0) {
            currLength = 0;
        }

        if (maxLength > 0 && currLength > maxLength) {
            $(this).val(textVal.substring(0, maxLength));
            currLength = maxLength;
        }

        var tip = "";
        if (maxLength > 0) {
            tip = (maxLength - currLength) + "/" + maxLength;
        }
        else {
            tip = (maxLength - currLength) + "";
        }

        //alert(tip);
        $("#indicatorArticleWordCount").html("您可输入" + tip + "个字符");

    });
}


//提交文章
function postArticle() {
    //var artContent = HTMLEncode($("#artContent").val() + "");
    var artContent = $("#artContent").val() + "";
    var artChkCode = $("#artChkCode").val() + "";

    if (artContent.length < 5 || artContent == ($("#artContent").attr("tip") + "")) {
        $.messager.alert('无法提交！', "您提交的内容不能少于5个字符", "error");
        return;
    }

    if (artContent.length > 1000) {
        $.messager.alert('无法提交！', "您提交的内容大于1000个字符", "error");
        return;
    }

    if (artChkCode.length < 1) {
        $.messager.alert('无法提交！', "请输入验证码", "error");
        return;
    }

    $("#btnPostArticle").val("正在提交...");
    $("#btnPostArticle").attr("disabled", "disabled");

    $.ajax({
        type: "POST",
        url: KL_ROOT + "/Handle/ArticleAdd.ashx?t=" + new Date().getTime(),
        data: { "Content": artContent,
            "ChkCode": artChkCode
        },
        success: function(msg) {
            if (!msg || msg == "") {
                msg = "你提交的帖子成功，请耐心等候我们的审核，谢谢！";
            }
            $.messager.alert('恭喜，发表成功！',
                 msg,
                 "info",
                 function() {
                     top.location.href = "Default.aspx";
                 }
             );
        },
        error: function(xhr) {
            $("#btnPostArticle").val("发表");
            $("#btnPostArticle").attr("disabled", "");
            var errTips = xhr.responseText + "";
            if (errTips == "") {
                errTips = " Sorry，未知错误。请检查输入是否正确，或稍后重试！";
            }
            $.messager.alert("发表失败！", "<font color='red'>" + xhr.responseText + "</font>", "error");

        }
    });
    
}



/**** 搜索 ***********/
function search(keyword) {
    soUrl = KL_ROOT + "/Article/Search.aspx?keyword=" + keyword;
    window.top.location.href = soUrl;
}

$(function() {
    $("input[name='keyword']").each(function(i) {
        $(this).keyup(function(e) {
            if (e.which == 13) {
                search($(this).val())
            }
        });
    });

});


//提示，ID,信息，类型：0=无，1=成功，-1=失败
function tip(id, msg, type) {
    if (type == 1) {
        msg = "√ " + msg;
        $(id).css("color", "#090");
    }
    else if (type == -1) {
        msg = "× " + msg;
        $(id).css("color", "#f00");
    }
    else {
        $(id).css("color", "#000");
    }
    $(id).html(msg);
};
