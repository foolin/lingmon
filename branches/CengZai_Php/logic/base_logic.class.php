<?php
require(ROOT_PATH . "lib/template.class.php");
require(ROOT_PATH.'lib/util.class.php');

class BaseLogic
{
	var $config = array();
	var $title = '';
	var $post = array();
	var $get = array();
	var $tpl = false;

	public function init(&$config)
	{
		$this->get = $_GET;
		$this->post = $_POST;
		$this->config = $config;
		$this->tpl = new Template($config);
	}

	//取参数
	public function request($key, $is_get_first = 1)
	{
		$querystring = '';
		if(1 == $is_get_first)
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


	function messager($title, $message, $redirectto='',$time = -1)
	{
		if ($time===-1)
        {
			$time=(is_numeric($this->config['msg_time'])?$this->config['msg_time']:5);
		}


		$to_title=($redirectto==='' or $redirectto==-1)?"返回上一页":"跳转到指定页面";

		if($redirectto===null)
		{
			$return_msg=$return_msg===false?"&nbsp;":$return_msg;
		}
		else
		{
			
			$redirectto=($redirectto!=='')?$redirectto:($from_referer=Util::referer());
		}

		if(empty($title))
		{
			$title = "消息提示";
		}

		include($this->tpl->get_tpl('messager'));
		
	}

}
?>