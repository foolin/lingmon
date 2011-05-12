/************************************
* @Author: Foolin
* @Create: 2011.05.12
* @Email: Foolin@126.com
************************************/


//检查email邮箱
function isEmail(str) {
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
    return reg.test(str);
}