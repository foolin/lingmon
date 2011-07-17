<?php
require(ROOT_PATH . "lib/template.class.php");
require(ROOT_PATH.'lib/util.class.php');
require(ROOT_PATH . 'lib/cookie.class.php');

class BaseLogic
{
	var $config = array();
	var $title = '';
	var $post = array();
	var $get = array();
	var $tpl = null;
	var $cookie = null;
	var $user = null;

	public function init(&$config)
	{
		$this->get = $_GET;
		$this->post = $_POST;
		$this->config = $config;
		$this->tpl = new Template($config);
		$this->cookie = new Cookie($config, $_COOKIE);

		//验证是否已经登录
		$uid = 0;
		$password = '';
		if(($auth_code=$this->cookie->get('auth')))
		{
			list($uid, $password)=explode("|", Util::auth_code($auth_code,'DECODE'));
		}
		include_once ROOT_PATH . 'model/user_model.class.php';
		$user_model = new UserModel($this->config);
		$this->user = $user_model -> base_get_model("uid='". $uid ."' AND password='". $password ."' ");
	}

	//取参数
	public function request($key, $is_get_first = false)
	{
		$querystring = '';
		if(false == $is_get_first)
		{
			if(isset($this->get[$key]))
			{
				$querystring = $this->get[$key];
			}
			elseif(isset($this->post[$key]))
			{
				$querystring = $this->post[$key];
			}
		}
		else
		{
			if(isset($this->post[$key]))
			{
				$querystring = $this->post[$key];
			}
			elseif(isset($this->get[$key]))
			{
				$querystring = $this->get[$key];
			}
		}

		return $querystring;
	}

	
	//消息框
	function messager($title, $message='', $redirect_to=null, $time = null)
	{
		$history_back = false;

		if ($time===null)
        {
			$time = 0;
		}
		
		if($redirect_to===null or $redirect_to==-1)
		{
			$history_back = true;
			$to_title = "返回上一页";
			$redirect_to=Util::referer();
		}
		elseif($redirect_to==='')
		{
			$to_title = "跳转到指定页面";
			$redirect_to = Util::referer();
		}
		else
		{
			$to_title = "跳转到指定页面";
		}

		if(empty($title))
		{
			$title = "消息提示";
		}
		$this->title = $title;

		include($this->tpl->get_tpl('messager'));

		exit;
		
	}

	function send_mail($to, $cc='', $subject='', $body='')
	{
		include_once ROOT_PATH. '/lib/smtp.class.php';


		$smtp = new smtp($this->config['smtp_server'], $this->config['smtp_port'], true
							, $this->config['smtp_user'], $this->config['smtp_password']);
		$smtp->debug = FALSE;
		/*
		$body_header = '<HTML><HEAD><META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=UTF-8"></HEAD><BODY>';
		$body_footer = '</BODY></HTML>';
		$body = $body_header . $body . $body_footer;
		*/
		$smtp -> sendmail($to, $this->config['smtp_from'], $subject, $body, 'HTML', $cc);
	}


	//判断是否登录
	function is_login()
	{
		return $this->user && is_array($this->user);
	}


	//检查是否登录，如果未登录，则跳转
	function check_login()
	{
		if(!$this->is_login())
		{
			$url = $this->config['site_url'] . '/index.php?mod=user&cmd=login';
			Util::go($url);
		}
	}

}
?>