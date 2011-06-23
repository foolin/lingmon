<?php
class OtherLogic extends BaseLogic
{
	public function __construct(&$config)
	{
		parent::init($config);
	}

	public function execute()
	{
		$cmd = $this->request('cmd');
		if('about' == $cmd)
		{
			$this->show_about();
		}
		elseif('contact' == $cmd)
		{
			$this->show_contact();
		}
		elseif('agreement' == $cmd)
		{
			$this->show_agreement();
		}
		else
		{
			show_error();
		}
	}



	public function show_about()
	{
		$this->messager('关于我们', '该版块正在建设中...');
		die('test');
	}

	public function show_contact()
	{
		$user = array();
		$this->messager('联系我们', '该版块正在建设中...');
	}

	public function show_agreement()
	{
		$this->title = '曾在网络服务协议';
		include $this->tpl->get_tpl('other_agreement');
	}
		
	public function show_error()
	{
		$this->title = '出错喇';
		$this->messager('出错喇！', '您的网页未能找到！', ROOT_PATH . 'index.php');
	}

}
?>