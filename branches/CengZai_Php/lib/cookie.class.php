<?php
/**
 * 文件名：cookie.class.php
 * 版本号： LingLib v1.0.0
 * 最后修改时间： 2011年6月17日
 * 作者：负零<foolin@126.com>
 * 功能描述：一个Cookie操作类
 */


if(!defined('IN_LINGLIB'))
{
    exit('Access Denied');
}

class Cookie
{

   
	var $_config;

   
	var $_cookie;

   
	var $_prefix;

   
	var $_path;

   
	var $_domain;

	function __construct(& $config, & $cookie)
	{
		$this->_config =& $config;
		$this->_cookie =& $cookie;

		$this->_prefix = $this->_config['cookie_prefix'];
		$this->_path   = $this->_config['cookie_path']   ? $this->_config['cookie_path']   : '/';
		$this->_domain = $this->_config['cookie_domain'] ? $this->_config['cookie_domain'] : '';
	}

	function set($name, $value, $time = false)
	{
		$expire = 0;

        if($time)
        {
            $expire = time() + $time;
        }

		@setcookie($this->_prefix . $name, $value, $expire, $this->_path, $this->_domain);
		return true;
	}

	function get($key)
	{
		if(isset($this->_cookie[$this->_prefix . $key]))
        {
			return rawurldecode($this->_cookie[$this->_prefix . $key]);
        }
        else {
			return false;
        }
	}
	
	function delete($name)
	{
		$name_list=func_get_args();
		foreach ($name_list as $name)
		{
			$this->set($name,'',-86400000);
		}
	}
	
	function clear_all()
	{
		$prefix_len=strlen($this->_prefix);
		foreach ((array)$this->_cookie as $name=>$value)
		{
			$name=substr($name,$prefix_len);
			$this->set($name,'',-86400000);
		}
	}

}

?>