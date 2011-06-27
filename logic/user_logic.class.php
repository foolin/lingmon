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
		$email = $this->post['reg_email'];
		$password = $this->post['reg_password'];
		$repassword = $this->post['reg_repassword'];
		$verify_code = $this->post['reg_verify_code'];
		session_start();
		$server_verify_code = $_SESSION['verify_code'];
		if(empty($verify_code))
		{
			$this->messager('验证码不能为空！');
			exit;
		}
		if($verify_code != $server_verify_code)
		{
			$this->messager('验证码不正确！');
			exit;
		}
		if(empty($email) || !Util::is_email($email))
		{
			$this->messager("邮箱为空或者不合法");
			exit;
		}
		if(empty($password) || strlen($password) < 6 || strlen($password) > 20)
		{
			$this->messager('密码长度必须位于6~20位字符');
			exit;
		}


		$password = md5($password);
		$regtime = date('Y-m-d H:i:s');
		$regip = Util::get_ip();
		$status = 0;

		include_once ROOT_PATH . 'model/user_model.class.php';
		$user_model = new UserModel($this->config);
		$is_exists = $user_model->exists_email($email);
		if($is_exists)
		{
			$this->messager($email."邮箱已被注册！", "对不起，该邮箱".$email."已经被注册，请使用其它邮箱，或者使用该邮箱".$email."登录！");
			exit;
		}

		$userid = $user_model -> add($email, $password, $regtime, $regip, $status);

		if($userid > 0)
		{
			$active_url = "http://".$this->config['site_domain']. "/index.php?mod=user&cmd=active&email=".$email."&code=".md5($regtime);
			$this->send_mail($email,'', '您注册曾在网(cengzai.com)成功!', "尊敬的".$email.": <br/>您注册曾在网(CengZai.com)成功，您帐号号是：".$email."，请保管好密码。帐号需要激活才能正常登录，<a href='".$active_url."'>请点击这里</a>或者以下连接进行激活：<br /><a href='".$active_url."'>".$active_url."</a>");

			$this->messager('您注册曾在网(cengzai.com)成功!', "尊敬的".$email.": <br/>您帐号需要激活才能登录，我们已经发送一封激活邮件到您的邮箱[".$email."]，请及时登录邮箱进行激活！");
		}
		else
		{
			$this->messager("注册失败","对不起，注册失败，请稍后再试！");
		}

		

	}

}
?>