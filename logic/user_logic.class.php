<?php
class UserLogic
{
	var $post = array();
	var $get = array();
	var $cmd = '';

	public function UserLogic()
	{
		$this->get = $_GET;
		$this->post = $_POST;
	}

	public function Run()
	{
		
		$cmd = $this->get['cmd'];
		
		if('login' == $cmd)
		{
			$this->show_login();
		}
		else if('dologin' == $cmd)
		{
			$this->do_login();
		}
		else if('register' == $cmd)
		{
			$this->show_register();
		}
		else if('doregister' == $cmd)
		{
			$this->do_register();
		}
		else
		{
			$this->show_login_index();
		}

	}

	public function show_login()
	{
		die('show_login:' + $this->cmd);
		Header("Location:http://cengzai.test.com/?cmd=show_login");
	}

	public function do_login()
	{
		die('do_login');
		Header("Location:http://cengzai.test.com/?cmd=do_login");
	}

	public function show_register()
	{
		die('show_register');
		Header("Location:http://cengzai.test.com/?cmd=show_register");
	}

	public function do_register()
	{
		die('do_register');
		Header("Location:http://cengzai.test.com/?cmd=do_register");

/*
		include_once ROOT_PATH.'model/user_model.class.php';
		$user_model = new UserModel($config);
		$list = $user_model->get_list();
		$user = array(
					 'username' => 'foolin',
					 'password' => 'password',
					 'email' => 'foolin@126.com',
					 'nickname' => '负卐零'
					 );
		//$uid = $user_model->add($user);
		//echo 'uid:' . $uid . '<br />';*/
	}
	
	public function show_login_index()
	{
		require $this->tpl->gettpl('index_login');
	}
}
?>