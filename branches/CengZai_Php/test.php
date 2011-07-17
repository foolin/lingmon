<?php
define('IN_LINGLIB','1');
define('ROOT_PATH',dirname(__FILE__) . '/');
 include dirname(__FILE__) . '/inc/config.php';
 include dirname(__FILE__) . '/lib/util.class.php';
 include dirname(__FILE__) . '/lib/cookie.class.php';

@header('Content-Type: text/html; charset=utf-8');

/*
$code = "我是liuFuLing99";

$cookie = new Cookie($config, $_COOKIE);
$cookie -> remove('auth');

$encode = Util::auth_code($code, 'ENCODE', 'ling',  0);

$decode = Util::auth_code($encode, 'DECODE', 'lings', 2);

echo 'code:' . $code
. '<br />$decode:' . $encode . '<br />'
. '<br />$decode:' . $decode . '<br />'
;
*/

 include dirname(__FILE__) . '/model/base_model.class.php';
$base = new BaseModel();
$base->init($config);
$list = $base->base_get_page_list("where id > 3 ", '', 0, 3);
print_r($list);

 //print_r($_SERVER);
?>