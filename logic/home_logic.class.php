<?php

class HomeLogic extends BaseLogic
{
	function __construct(&$config)
	{
		parent::init($config);
	}

	function execute()
	{
		$cmd = $this->request('cmd');
		switch($cmd)
		{
			//登录处理
			case 'do_login':
				$this->do_login();
				break;
			
			//注册处理
			case 'do_register':
				$this->do_register();
				break;

			//注册处理
			case 'activate':
				$this->do_activate();
				break;
			
			//默认首页
			default:
				$this->show_index();
				break;

		}
	}

				
	function show_index()
	{
		$this->title = '首页-年轻人的情感网站，挽救爱情的情感社区';
		include $this->tpl->get_tpl('home_index');
	}



}

?>