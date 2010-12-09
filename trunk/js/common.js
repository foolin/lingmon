/********************************************************
    @Desc       :  JavaSrcript公共代码
    @Author     :  Foolin
    @Email      :  Foolin@126.com
    @Created on :  2010-12-8
    @Updated on :  2010-12-8
    Copyright 2010 7dong.net All Rights Reserved.
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
           allParas[_LFL_getParam(paras[i])[0].toLowerCase()] = _LFL_getParam(paras[i])[1].toLowerCase();
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
