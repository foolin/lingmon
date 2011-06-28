<?php

class UserLogic extends BaseLogic
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
		include $this->tpl->get_tpl('index_login');
	}

	function do_login()
	{
		$this->messager('暂无测试登录', 'aaaa',null, null);
	}

	//注册处理
	function do_register()
	{
		
		$email = $this->post['reg_email'];
		$password = $this->post['reg_password'];
		$repassword = $this->post['reg_repassword'];
		$verify_code = $this->post['reg_verify_code'];
		
		if(!isset($this->post['reg_agreement']) || $this->post['reg_agreement'] != 1)
		{
			$this->messager('必须同意《网络服务协议》', '请返回仔细阅读和同意本站《网络服务协议》才允许注册！', null, 5);
			exit;
		}

		session_start();
		$server_verify_code = $_SESSION['verify_code'];
		if(empty($verify_code))
		{
			$this->messager('验证码不能为空！', '请返回填写验证码！', null, 5);
			exit;
		}
		if($verify_code != $server_verify_code)
		{
			$this->messager('验证码不正确！', '请填写正确的验证码！', null, 5);
			exit;
		}
		if(empty($email) || !Util::is_email($email))
		{
			$this->messager("邮箱为空或者不合法", '请填写正确的邮箱！', null, 5);
			exit;
		}
		if(empty($password) || strlen($password) < 6 || strlen($password) > 20)
		{
			$this->messager('密码长度不对', '密码长度必须位于6~20位字符', null, 5);
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
			$this->messager($email."邮箱已被注册！", "对不起，该邮箱".$email."已经被注册，请使用其它邮箱，或者使用该邮箱".$email."登录！", null, null);
			exit;
		}

		//$userid = $user_model -> add($email, $password, $regtime, $regip, $status);

		$user = array();
		$user['email'] = $email;
		$user['password'] = $password;
		$user['regtime'] = $regtime;
		$user['regip'] = $regip;
		$user['status'] = $status;
		$userid = $user_model -> base_add($user);
		

		if($userid > 0)
		{
			$active_url = Util::get_domain_url(). "/index.php?mod=user&cmd=activate&email=".$email."&code=".md5($regtime);
			
			$email_title = '恭喜您注册曾在网(cengzai.com)成功!';
			$email_content = "尊敬的".$email.": <br/>您注册曾在网(CengZai.com)成功，您帐号是：".$email."，请保管好您的密码。帐号需要激活才能正常登录，<a href='".$active_url."'>请点击这里</a>或者以下连接进行激活：<br /><a href='".$active_url."'>".$active_url."</a>  ";

			//发送邮件
			$this->send_mail($email,'', $email_title, $email_content);
			
			//注册成功，提示
			$this->messager('您注册曾在网(cengzai.com)成功!', "尊敬的".$email.": <br/>您帐号需要激活才能登录，我们已经发送一封激活邮件到您的邮箱[".$email."]，请及时登录邮箱进行激活！", null, null );
		}
		else
		{
			$this->messager("注册失败","对不起，注册失败，请稍后再试！");
		}
	}

	//用户激活
	function do_activate()
	{
		$user = array();
		$user['status'] = 9;
		$user['face'] = 9;
		$user['lastlogintime'] = date("Y-m-d H:i:s");

		$email = $this->request('email',true);
		$code = $this->request('code',true);
		if(empty($email) || !Util::is_email($email) || empty($code))
		{
			$this->messager($email."激活失败！", '非法邮箱和参数！', null, 5);
			exit;
		}

		include_once ROOT_PATH . 'model/user_model.class.php';
		$user_model = new UserModel($this->config);
		//验证用户是否存在
		$user = $user_model->get_user($email);
		if(!$user || !is_array($user))
		{
			$this->messager($email."激活失败！", "对不起，激活失败，邮箱不合法！", null, null);
			exit;
		}

		if($user['status'] < 0)
		{
			$this->messager($email."帐号被锁定！", "对不起，激活失败，帐号被锁定！", Util::get_domain_url() . '/index.php', null);
			exit;
		}
		elseif($user['status'] > 0)
		{
			$this->messager($email."帐号已经激活！", "您的帐号已经激活，无需重复激活！", Util::get_domain_url() . '/index.php', null);
			exit;
		}
		
		$server_code = md5($user['regtime']);
		if($server_code != $code)
		{
			$this->messager($email."激活失败！", "对不起，激活失败，非法URL不合法！", null, null);
			exit;
		}

		//更新
		$update_user = array();
		$update_user['status'] = 1;
		$user_model -> base_update($update_user, 'userid=' . $user['userid']);
		
		$go_url = 'index.php?mod=user&cmd=login';
		$this->messager($email."激活成功！",  $email . "，恭喜您的帐号激活成功，您现在可以登录了！",  $go_url, 5);
	}

}
?>