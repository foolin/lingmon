<?php

/**
 * 文件名：util.class.php
 * 版本号：LingLib v1.0.0
 * 最后修改时间： 2011年6月21日
 * 作者：负零<foolin@126.com>
 * 功能描述：一个Util公共函数操作类
 */

class Util{
	function __construct(){
		die("Class util can not instantiated!");
	}

	//判断邮箱是否合法
	function is_email($email){
		if(ereg("^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+",$email)){
			return true;
		}else{
			return false;
		}
	}


	/**
     * random
     * @param int $length
     * @return string $hash
   */
	function random($length=6,$type=0) {
		$hash = '';
		$chararr =array(
			'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz',
			'0123456789',
			'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'
		);
		$chars=$chararr[$type];
		$max = strlen($chars) - 1;
		PHP_VERSION < '4.2.0' && mt_srand((double)microtime() * 1000000);
		for($i = 0; $i < $length; $i++) {
			$hash .= $chars[mt_rand(0, $max)];
		}
		return $hash;
	}

	//获取当前时间
	function date($format = '')
	{
		date_default_timezone_set('PRC'); 
		$date = date('Y-m-d H:i:s');
		if(!empty($format))
		{
			$date = date($format);
		}
		return $date;
	}

	//跳转到
	function go($url)
	{
		if(!isset($url) || empty($url))
		{
			$url = Util::referer();
		}
		header("Location: {$url}");
	}

	/*
		上一个页面
	*/
	function referer($default = '?') {
		$DOMAIN = preg_replace("~^www\.~",'',strtolower(getenv('HTTP_HOST') ? getenv('HTTP_HOST') : $_SERVER['HTTP_HOST']));
		$referer = "";
		if(isset($_POST['referer']))
		{
			$referer=$_POST['referer'];
		}
		elseif(isset($_GET['referer']))
		{
			$referer = $_GET['referer'];
		}
		elseif(isset($_SERVER['HTTP_REFERER']))
		{
			$referer = $_SERVER['HTTP_REFERER'];
		}

		if($referer=="" || (strpos($referer,":/"."/")!==false && strpos($referer,$DOMAIN)===false))
		{
			return $default;
		}
		return $referer;
	}

	//获取主机url
	function get_domain_url()
	{
		$domain = 'http';
		if (isset($_SERVER["HTTPS"]) && $_SERVER["HTTPS"] == "on") 
		{
			$domain .= "s";
		}
		$domain .= "://";
		if ($_SERVER["SERVER_PORT"] != "80") 
		{
			$domain .= $_SERVER["SERVER_NAME"] . ":" . $_SERVER["SERVER_PORT"];
		} 
		else 
		{
			$domain .= $_SERVER["SERVER_NAME"];
		}
		return $domain;
	}

	// 说明：获取完整URL
	function get_url() 
	{
		$page_url = 'http';

		if (isset($_SERVER["HTTPS"]) && $_SERVER["HTTPS"] == "on") 
		{
			$page_url .= "s";
		}
		$page_url .= "://";

		if ($_SERVER["SERVER_PORT"] != "80") 
		{
			$page_url .= $_SERVER["SERVER_NAME"] . ":" . $_SERVER["SERVER_PORT"] . $_SERVER["REQUEST_URI"];
		} 
		else 
		{
			$page_url .= $_SERVER["SERVER_NAME"] . $_SERVER["REQUEST_URI"];
		}
		return $page_url;
	}

	// 参数解释
	// $string： 明文 或 密文
	// $operation：DECODE表示解密,其它表示加密如ENCODE
	// $key： 密匙
	// $expiry：密文有效期
	function auth_code($string, $operation = 'DECODE', $key = '', $expiry = 0) {
		// 动态密匙长度，相同的明文会生成不同密文就是依靠动态密匙
		$ckey_length = 4;
		
		// 密匙
		$key = md5($key ? $key : 'ling_lib_auth_key');
		
		// 密匙a会参与加解密
		$keya = md5(substr($key, 0, 16));
		// 密匙b会用来做数据完整性验证
		$keyb = md5(substr($key, 16, 16));
		// 密匙c用于变化生成的密文
		$keyc = $ckey_length ? ($operation == 'DECODE' ? substr($string, 0, $ckey_length): substr(md5(microtime()), -$ckey_length)) : '';
		// 参与运算的密匙
		$cryptkey = $keya.md5($keya.$keyc);
		$key_length = strlen($cryptkey);
		// 明文，前10位用来保存时间戳，解密时验证数据有效性，10到26位用来保存$keyb(密匙b)，解密时会通过这个密匙验证数据完整性
		// 如果是解码的话，会从第$ckey_length位开始，因为密文前$ckey_length位保存 动态密匙，以保证解密正确
		$string = $operation == 'DECODE' ? base64_decode(substr($string, $ckey_length)) : sprintf('%010d', $expiry ? $expiry + time() : 0).substr(md5($string.$keyb), 0, 16).$string;
		$string_length = strlen($string);
		$result = '';
		$box = range(0, 255);
		$rndkey = array();
		// 产生密匙簿
		for($i = 0; $i <= 255; $i++) {
			$rndkey[$i] = ord($cryptkey[$i % $key_length]);
		}
		// 用固定的算法，打乱密匙簿，增加随机性，好像很复杂，实际上对并不会增加密文的强度
		for($j = $i = 0; $i < 256; $i++) {
			$j = ($j + $box[$i] + $rndkey[$i]) % 256;
			$tmp = $box[$i];
			$box[$i] = $box[$j];
			$box[$j] = $tmp;
		}
		// 核心加解密部分
		for($a = $j = $i = 0; $i < $string_length; $i++) {
			$a = ($a + 1) % 256;
			$j = ($j + $box[$a]) % 256;
			$tmp = $box[$a];
			$box[$a] = $box[$j];
			$box[$j] = $tmp;
			// 从密匙簿得出密匙进行异或，再转成字符
			$result .= chr(ord($string[$i]) ^ ($box[($box[$a] + $box[$j]) % 256]));
		}
		if($operation == 'DECODE') {
			// substr($result, 0, 10) == 0 验证数据有效性
			// substr($result, 0, 10) - time() > 0 验证数据有效性
			// substr($result, 10, 16) == substr(md5(substr($result, 26).$keyb), 0, 16) 验证数据完整性
			// 验证数据有效性，请看未加密明文的格式
			if((substr($result, 0, 10) == 0 || substr($result, 0, 10) - time() > 0) && substr($result, 10, 16) == substr(md5(substr($result, 26).$keyb), 0, 16)) {
				return substr($result, 26);
			} else {
				return '';
			}
		} else {
			// 把动态密匙保存在密文里，这也是为什么同样的明文，生产不同密文后能解密的原因
			// 因为加密后的密文可能是一些特殊字符，复制过程可能会丢失，所以用base64编码
			return $keyc.str_replace('=', '', base64_encode($result));
		}
	}



	/**
     * image_compress
     * @param string $url,$prefix;int  $width,$height
     * @return array $result
   */
	function image_compress($url,$prefix='s_',$width=80,$height=60,$suffix=''){
		global $lang;
		$result=array ('result'=>false,'tempurl'=>'','msg'=>'something Wrong');
		if(!file_exists($url)){
			$result['msg'] =$url. 'img is not exist';
			return $result;
		}
		$urlinfo=pathinfo($url);
		$ext=strtolower($urlinfo['extension']);
		$tempurl=$urlinfo['dirname'].'/'.$prefix.substr($urlinfo['basename'],0,-1-strlen($ext)).$suffix.'.'.$ext;
		if ( ! util::is_image($ext)) {
			$result['msg'] ='img must be gif|jpg|jpeg|png';
			return $result;
		}
		$ext=($ext=='jpg')?'jpeg':$ext;
		$createfunc='imagecreatefrom'.$ext;
		$imagefunc='image'.$ext;
		if(function_exists($createfunc)){
			list($actualWidth,$actualHeight) = getimagesize($url);
			if($actualWidth<$width&&$actualHeight<$height){
				    copy($url,$tempurl);
					$result['tempurl']=$tempurl;
					$result['result']=true;
					return $result;
			}
			if ($actualWidth < $actualHeight){
				$width=round(($height / $actualHeight) *$actualWidth);
			} else {
				$height=round(($width/ $actualWidth) *$actualHeight);
			}
			$tempimg=imagecreatetruecolor($width, $height);
			$img = $createfunc($url);
			imagecopyresampled($tempimg, $img, 0, 0, 0, 0, $width, $height, $actualWidth, $actualHeight);
			$result['result']=($ext=='png')?$imagefunc($tempimg, $tempurl):$imagefunc($tempimg, $tempurl, 80);
			
			imagedestroy($tempimg);
			imagedestroy($img);
			if(file_exists($tempurl)){
				$result['tempurl']=$tempurl;
			}else {
				$result['tempurl']=$url;
			}
		}else{
				copy($url, $tempurl);
				if(file_exists($tempurl)){
					$result['result']= true;
					$result['tempurl']=$tempurl;
				}else {
					$result['tempurl']=$url;
				}
		  }
		return $result;
	}
	
	/**
     * isimage
     * @param string $extname
     * @return true or false
   */
	function is_image($extname){
		return in_array( $extname,array('jpg','jpeg','png','gif') );
	}
	
	/**
     * getfirstimg
     * @param string $content
     * @return string $tempurl
   */
	function get_first_img($string){
		preg_match("/<img.+?src=[\\\\]?\"(.+?)[\\\\]?\"/i",$string,$imgs);
		if(isset($imgs[1])){
			return $imgs[1];
		}else{
			return "";
		}
		
	}
	
	function get_images_num($string){
		preg_match_all("/<img.+?src=[\\\\]?\"(.+?)[\\\\]?\"/i",$string,$imgs);
		return count($imgs[0]);
	}
	



 
    /**
     * getip
     *
     * @return string
     */
    function get_ip(){
        if (getenv('HTTP_CLIENT_IP') && strcasecmp(getenv('HTTP_CLIENT_IP'), 'unknown')){
            $ip = getenv('HTTP_CLIENT_IP');
        }else if (getenv('HTTP_X_FORWARDED_FOR') && strcasecmp(getenv('HTTP_X_FORWARDED_FOR'), 'unknown')){
            $ip = getenv('HTTP_X_FORWARDED_FOR');
        }else if (getenv('REMOTE_ADDR') && strcasecmp(getenv('REMOTE_ADDR'), 'unknown')){
            $ip = getenv('REMOTE_ADDR');
        }else if (isset($_SERVER['REMOTE_ADDR']) && $_SERVER['REMOTE_ADDR'] && strcasecmp($_SERVER['REMOTE_ADDR'], 'unknown')){
            $ip = $_SERVER['REMOTE_ADDR'];
        }
        preg_match("/[\d\.]{7,15}/", $ip, $temp);
        $ip = $temp[0] ? $temp[0] : 'unknown';
        unset($temp);
        return $ip;
    }
 

	function str_code($string,$action='ENCODE'){
		$key	= substr(md5($_SERVER["HTTP_USER_AGENT"].PP_KEY),8,18);
		$string	= $action == 'ENCODE' ? $string : base64_decode($string);
		$len	= strlen($key);
		$code	= '';
		for($i=0; $i < strlen($string); $i++){
			$k		= $i % $len;
			$code  .= $string[$i] ^ $key[$k];
		}
		$code = $action == 'DECODE' ? $code : base64_encode($code);
		return $code;
	}

	/**
	 * 检测给出IP是否为内网Ip
	 * @param <type> $ip
	 * @return <type> 是内网IP 返回TRUE
	 */
	function is_private_ip($ip='') {
		if(empty($ip)) {
			$ip = $_SERVER['SERVER_ADDR'];
		}
		else {
			$ip = gethostbyname($ip);
		}
		
		$i = explode('.', $ip);
		if ($i[0] == 127) return true;
		if ($i[0] == 10) return true;
		if ($i[0] == 172 && $i[1] > 15 && $i[1] < 32) return true;
		if ($i[0] == 192 && $i[1] == 168) return true;
		return false;
	}




}
?>