<?php
define('IN_LINGLIB','1');
 include dirname(__FILE__) . '/inc/config.php';
 include dirname(__FILE__) . '/lib/util.class.php';
 include dirname(__FILE__) . '/lib/cookie.class.php';

@header('Content-Type: text/html; charset=utf-8');

$code = "我是liuFuLing99";

$cookie = new Cookie($config, $_COOKIE);
$cookie -> remove('auth');

$encode = Util::auth_code($code, 'ENCODE', 'ling',  0);

$decode = Util::auth_code($encode, 'DECODE', 'lings', 2);

echo 'code:' . $code
. '<br />$decode:' . $encode . '<br />'
. '<br />$decode:' . $decode . '<br />'
;
 //print_r($_SERVER);
?>