<?php
require_once ROOT_PATH.'logic/base_logic.class.php';

class IndexLogic extends BaseLogic
{
	public function IndexLogic(&$config)
	{
		parent::init($config);
	}

	public function execute()
	{
		$cmd = $this->request_string('cmd');
		//die($cmd);
		if('do_login' == $cmd)
		{
			$this->do_login();
		}
		else
		{
			$this->show_index();
		}
	}

	
	public function show_index()
	{
		$this->title = '首页-年轻人的情感网站，挽救爱情的情感社区';
		include $this->tpl->get_tpl('index_login');
	}

	public function do_login()
	{
		$this->messager('测试跳转');
	}

}
?>