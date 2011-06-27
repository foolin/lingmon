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
			
			//默认首页
			default:
				$this->show_index();
				break;

		}

	}

	
	public function show_index()
	{
		$this->title = '首页-年轻人的情感网站，挽救爱情的情感社区';
		include $this->tpl->get_tpl('index_login');
	}

	public function do_login()
	{
		$this->messager('暂无测试登录', 'aaaa',null, null);
	}

	public function do_register()
	{
		
		$this->send_mail('(刘灵)252687345@qq.com','', '恭喜刘灵，注册曾在网(cengzai.com)成功2!', "您帐号需要激活才能登录，我们已经发送一封激活邮件到您的邮箱[liufuling@cengzai.com]2，请及时登录邮箱进行激活！");
		//sendmail("smtp.exmail.qq.com","noreply@cengzai.com","lingmon","ling@Liufu.org","noreply@cengzai.com","title_test","body_test");
		die('ok!' . getdate());
		/*
		$smtp = new smtp('smtp.exmail.qq.com', 25, true, 'noreply@cengzai.com', 'lingmon');
		$smtp -> sendmail('ling@liufu.org','onreply@cengzai.com','测试PHP发送邮件','这是PHP邮件内容。', 'HTML','liufuling@sxmobi.com');
		*/
		die('send ok!');

		sendmail("smtp.exmail.qq.com","noreply@cengzai.com","lingmon","ling@Liufu.org","曾在<noreply@cengzai.com>","title_test","body_test");
		
		$this->messager('恭喜您，注册成功!', "您帐号需要激活才能登录，我们已经发送一封激活邮件到您的邮箱[$email]，请及时登录邮箱进行激活！", 'refresh' , 10);
		$user = array();
		$email = $this->post['reg_email'];
		$password = $this->post['reg_password'];
		$repassword = $this->post['reg_repassword'];
		$chkcode = $this->post['reg_chkcode'];
		//
		session_start();
		$server_chkcode = $_SESSION['reg_chkcode'];
		if(empty($chkcode))
		{

		}
		

		if($email){};

	}

}
?>