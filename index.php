<?php

/*******************************************************************
 * Copyright (C)2011 Ling Team.
 *
 * @Desc: CengZai.com 程序入口
 *
 * @Author: Foolin
 *
 * @Email: Foolin@126.com
 *
 * @Date: 2011-06-23 22:23:26
 *******************************************************************/


error_reporting(E_ERROR | E_WARNING | E_PARSE);	//过滤一些Notice提示
ini_set("arg_seperator.output", "&amp;");
ini_set("magic_quotes_runtime", 0);
define('IN_LINGLIB',true);
define('ROOT_PATH',dirname(__FILE__) . '/');
define('MAGIC_QUOTES_GPC', get_magic_quotes_gpc());
		

@header('Content-Type: text/html; charset=utf-8');
@header('P3P: CP="CAO PSA OUR"');

require(ROOT_PATH . "config.php");

if($config['debug'])
{
	include(ROOT_PATH . "lib/io.class.php");
	Io::clear_dir(ROOT_PATH . 'cache/templates/');
}



App::run($config);	//运行


//程序入口类
class App
{
	public function run(&$config)
	{
		include(ROOT_PATH . "lib/string.class.php");
		if($_GET)
		{
			$_GET = String::haddslashes($_GET,1);
		}
		if($_POST)
		{
			$_POST = String::haddslashes($_POST);
		}
		
		//取模块参数
		$mod = App::get_mod();

		//包含文件
		include_once ROOT_PATH.'logic/base_logic.class.php';
		include_once ROOT_PATH . 'logic/'. $mod['file'] .'.class.php';

		//实例化类
		$logic = new $mod['class']($config);
		$logic->execute(); 		//执行
	}


	//取模块
	// 返回$['file']文件名,$['class']类名
	public function get_mod($default='user')
	{
		$arrmods = array(
				'user'=> array(
					'file' => 'user_logic',
					'class' => 'UserLogic',
				),
				'home'=> array(
					'file' => 'home_logic',
					'class' => 'HomeLogic',	
				),
				'other'=> array(
					'file' => 'other_logic',
					'class' => 'OtherLogic',	
				),
			);
		
		@$mod = (isset($_POST['mod']) ? $_POST['mod'] : $_GET['mod']);

		if(!isset($arrmods[$mod])) 
		{
			$mod = ($default ? $default : 'user');
		}
		
		
		$_POST['mod'] = $_GET['mod'] = $mod;	
		
		return $arrmods[$mod];
	}
}

?>