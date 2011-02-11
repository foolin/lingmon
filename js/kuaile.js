/*
 @Author: Foolin
 @Desc  : JavaScript
 @Date  : 2011-02-02
 @Copyright 灵梦工作室 版权所有
*/

$(function(){
	_KL_FormInputTip();	//输入框提示
	_KL_ListItemFocus();	//列表项激活
	//_KL_ListCommentFocus();	//评论框详细版
	_KL_ListCommentWordCountTip();	//检查字符数
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
function inputComment(artid){
	var el = $("#itemInputComment-" + artid);
	if(!el) return;
	$(".itemInputComment").each(function(i){
		if($(this).attr("id") !=  el.attr("id")){
			$(this).hide();
		}
	});

	el.slideToggle();
	//alignHeight("containerMain","containerSider"); 
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
       url: "Handle/Dig.ashx?t=" + new Date().getTime(),
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


