<?php
//禁止独立访问
!defined('IN_LINGLIB') && exit('Access Denied');

//设置默认时间
date_default_timezone_set('PRC'); 

//配置文件
$config = array(
	//是否调试
	'debug' => 1,

	//网站
	'site_name' => '曾在网',
	'site_domain' => 'cengzai.com',
	'site_url' => 'http://cengzai.test.com',

	//消息框
	'msg_time' => 5,

	//模板
	'template_path' => 'default',
	'template_root_path' => './templates/',
	'compiled_root_path' => './cache/templates/',


	//数据库
	'db_host' => '127.0.0.1:3306',
	'db_user' => 'root',
	'db_pwd' => '123456',
	'db_name' => 'cengzai',
	'db_table_prefix' => 'cz_',
	'db_charset' => 'utf8',


	//Smtp发送邮件
	'smtp_server'=>'smtp.exmail.qq.com',
	'smtp_port'=>'25',
	'smtp_user' => 'noreply@cengzai.com',
	'smtp_password' => 'lingmon',
	'smtp_from' => 'noreply@cengzai.com(曾在网)',

)







?>