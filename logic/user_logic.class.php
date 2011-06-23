<?php

class UserLogic extends BaseLogic
{
	public function __construct(&$config)
	{
		parent::init($config);
	}

	public function execute()
	{
		$cmd = $this->request('cmd');
		if('dologin' == $cmd)
		{
			$this->do_login();
		}
		if('doregister' == $cmd)
		{
			$this->do_register();
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
		$this->messager('暂无测试登录', 'http://www.baidu.com');
		die('test');
	}

	public function do_register()
	{
		
		$user = array();
		$email = $this->post['reg_email'];
		$password = $this->post['reg_password'];
		$repassword = $this->post['reg_repassword'];
		$chkcode = $this->post['reg_chkcode'];
		//
		session_start();
		$server_chkcode = $_SESSION['reg_chkcode'].'';
		if($chkcode != $server_chkcode)
		{
			die("<script>window.alert('验证码不正确！');history.back();</script>");
		}
		else
		{
			die('验证成功！');
		}

		if($email){};

		$this->messager('恭喜您，注册成功!', "您帐号需要激活才能登录，我们已经发送一封激活邮件到您的邮箱[$email]，请及时登录邮箱进行激活！", null , null);
	}

}
?>