/************************************
* @Author: Foolin
* @Create: 2011.05.12
* @Email: Foolin@126.com
************************************/

var Utils = new Object();

//检查email邮箱
Utils.isEmail = function(str) {
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
    return reg.test(str);
}


//英文一个字符，中文两个字符
Utils.charCount = function(str) {
    var len = 0;
    for (var i = 0; i < str.length; i++) {
        if (str[i].match(/[^\x00-\xff]/ig) != null) //全角 
            len += 2;
        else
            len += 1;
    }
    return len;
}