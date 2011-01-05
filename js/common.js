/********************************************************
    @Desc       :  JavaSrcript公共代码
    @Author     :  Foolin
    @Email      :  Foolin@126.com
    @Created on :  2010-12-8
    @Updated on :  2010-12-8
    Copyright 2010 灵梦工作室 All Rights Reserved.
********************************************************/

/*获取url的#后参数
  如: index.aspx#key=value
  调用： $Request["key"] 即可获取 value的值。
/****************** 获取#后参数 *******************/
function _LFL_getUrlParams(){
    var paraString =  window.location.href.split('#');
    
    if(!paraString)
    {
        return null;
    }
    if(!paraString[1]){
        return null;
    }
    var paras = paraString[1].split('&');
    var allParas=new Array(paras.length);
    for(var i = 0;i<paras.length; i++){
        var _key = _LFL_getParam(paras[i])[0];
        var _value = _LFL_getParam(paras[i])[1];
           if(!_key || !_value)
           {
                continue;
           }
           allParas[_key.toLowerCase()] = _value.toLowerCase();
    }
    return allParas;
}

//获取Para
function _LFL_getParam(word){
    if(!word){
        return null;
    }
    var onePara = word.split('=');
    return onePara;
}

//全局
var $Request = {};
$(document).ready(function(){
    var params = _LFL_getUrlParams();
    if(!params)
    {
        $Request.get = function(key) { return null;};  //如果不存在，则付空对象，防止出错
    }
    else
    {
        $Request.get = function(key) { return params[key.toLowerCase()];}
    }
});

/**********************/


/***** cookies *****/
//function setCookie(key, value){
//    $.cookie("www_7dong_net_" + key, value, {expires: 7, path: '/', domain: 'www.7dong.com', secure: true});  //存储
//}

//function getCookie(key){
//    return $.cookie("www_7dong_net_" + key);
//}

//写cookies函数
function setCookie(key, value)//两个参数，一个是cookie的名子，一个是值
{
    var Days = 30; //此 cookie 将被保存 30 天
    var exp  = new Date();    //new Date("December 31, 9998");
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    document.cookie = key + "="+ escape (value) + ";expires=" + exp.toGMTString();
}
//取cookies函数    
function getCookie(key)    
{
    var arr = document.cookie.match(new RegExp("(^| )"+ key +"=([^;]*)(;|$)"));
     if(arr != null) return unescape(arr[2]); return null;

}
//删除cookie
function delCookie(key)
{
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval=getCookie(key);
    if(cval!=null) document.cookie= key + "="+cval+";expires="+exp.toGMTString();
}


/********* Domain **************/
//取主机：http://www.7dong.net
var $Domain = __getDomain__();
function __getDomain__()
{
    var _domain =  window.location.href;
    _domain = _domain.substring( 0, _domain.lastIndexOf('/'));
    if(!_domain || _domain == "") _domain = window.location.href;
    return _domain;
}
