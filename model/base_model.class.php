<?php

class BaseModel
{
	protected $db;
	
	function init(&$config) 
	{
		$this->init_db($config);
	}
	
	function init_db($config) 
	{
		require_once ROOT_PATH.'lib/db.class.php';
		$this->db = new Db();
		$this->db->connect($config['db_host'], $config['db_user'], $config['db_pwd']
							 , $config['db_name'], $config['db_table_prefix'], $config['db_charset']);
		//$this->db->connect('127.0.0.1:3306', 'root', '123456', 'cengzai', 'cz_', 'utf8');

	}
	
}


?>