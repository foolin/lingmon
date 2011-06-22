<?php
define('IN_LINGLIB',true);
define('ROOT_PATH',dirname(__FILE__) . '/');
define('MAGIC_QUOTES_GPC', get_magic_quotes_gpc());

@header('Content-Type: text/html; charset=utf-8');
@header('P3P: CP="CAO PSA OUR"');


require(ROOT_PATH . "config.php");
require(ROOT_PATH . "lib/string.class.php");

if($_GET)
{
	$_GET = String::haddslashes($_GET,1);
}
if($_POST)
{
	$_POST = String::haddslashes($_POST);
}


App::run($config);


class App
{
	public function run(&$config)
	{
		$mod = App::get_mod();
		if('index' == $mod)
		{
			include ROOT_PATH . 'logic/index_logic.class.php';
			$index_logic = new IndexLogic($config);
			$index_logic->execute();
		}
		else if('message' == $mod)
		{

		}
	}


	public function get_mod($default='index')
	{

		$arrmods = array(
				'index'=>1,
				'home'=>1,
				'login'=>1,
				'register'=>1,
				'find_register'=>1,
				'user_active'=>1,
				'get_password'=>1,
			);
		
		if(isset($_POST['mod']))
		{
		}
		else if(isset($_GET['mod']))
		{
		}
		else
		{
		}
		@$mod = (isset($_POST['mod']) ? $_POST['mod'] : $_GET['mod']);

		if(!isset($arrmods[$mod])) 
		{
			$mod = ($default ? $default : 'index');
		}
		
		$_POST['mod'] = $_GET['mod'] = $mod;	
		
		return $mod;
	}
}

?>