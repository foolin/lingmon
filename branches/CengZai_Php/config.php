<?php
//禁止独立访问
!defined('IN_LINGLIB') && exit('Access Denied');

$config = array(

  'site_name' => '曾在网',
  'site_domain' => 'cengzai.com',
  'site_url' => 'http://cengzai.test.com',

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

)

?>