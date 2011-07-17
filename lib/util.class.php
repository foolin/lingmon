<?php

/**
 * �ļ�����util.class.php
 * �汾�ţ�LingLib v1.0.0
 * ����޸�ʱ�䣺 2011��6��21��
 * ���ߣ�����<foolin@126.com>
 * ����������һ��Util��������������
 */

class Util{
	function __construct(){
		die("Class util can not instantiated!");
	}

	//�ж������Ƿ�Ϸ�
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

	//��ȡ��ǰʱ��
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

	//��ת��
	function go($url)
	{
		if(!isset($url) || empty($url))
		{
			$url = Util::referer();
		}
		header("Location: {$url}");
	}

	/*
		��һ��ҳ��
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

	//��ȡ����url
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

	// ˵������ȡ����URL
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

	// ��������
	// $string�� ���� �� ����
	// $operation��DECODE��ʾ����,������ʾ������ENCODE
	// $key�� �ܳ�
	// $expiry��������Ч��
	function auth_code($string, $operation = 'DECODE', $key = '', $expiry = 0) {
		// ��̬�ܳ׳��ȣ���ͬ�����Ļ����ɲ�ͬ���ľ���������̬�ܳ�
		$ckey_length = 4;
		
		// �ܳ�
		$key = md5($key ? $key : 'ling_lib_auth_key');
		
		// �ܳ�a�����ӽ���
		$keya = md5(substr($key, 0, 16));
		// �ܳ�b��������������������֤
		$keyb = md5(substr($key, 16, 16));
		// �ܳ�c���ڱ仯���ɵ�����
		$keyc = $ckey_length ? ($operation == 'DECODE' ? substr($string, 0, $ckey_length): substr(md5(microtime()), -$ckey_length)) : '';
		// ����������ܳ�
		$cryptkey = $keya.md5($keya.$keyc);
		$key_length = strlen($cryptkey);
		// ���ģ�ǰ10λ��������ʱ���������ʱ��֤������Ч�ԣ�10��26λ��������$keyb(�ܳ�b)������ʱ��ͨ������ܳ���֤����������
		// ����ǽ���Ļ�����ӵ�$ckey_lengthλ��ʼ����Ϊ����ǰ$ckey_lengthλ���� ��̬�ܳף��Ա�֤������ȷ
		$string = $operation == 'DECODE' ? base64_decode(substr($string, $ckey_length)) : sprintf('%010d', $expiry ? $expiry + time() : 0).substr(md5($string.$keyb), 0, 16).$string;
		$string_length = strlen($string);
		$result = '';
		$box = range(0, 255);
		$rndkey = array();
		// �����ܳײ�
		for($i = 0; $i <= 255; $i++) {
			$rndkey[$i] = ord($cryptkey[$i % $key_length]);
		}
		// �ù̶����㷨�������ܳײ�����������ԣ�����ܸ��ӣ�ʵ���϶Բ������������ĵ�ǿ��
		for($j = $i = 0; $i < 256; $i++) {
			$j = ($j + $box[$i] + $rndkey[$i]) % 256;
			$tmp = $box[$i];
			$box[$i] = $box[$j];
			$box[$j] = $tmp;
		}
		// ���ļӽ��ܲ���
		for($a = $j = $i = 0; $i < $string_length; $i++) {
			$a = ($a + 1) % 256;
			$j = ($j + $box[$a]) % 256;
			$tmp = $box[$a];
			$box[$a] = $box[$j];
			$box[$j] = $tmp;
			// ���ܳײ��ó��ܳ׽��������ת���ַ�
			$result .= chr(ord($string[$i]) ^ ($box[($box[$a] + $box[$j]) % 256]));
		}
		if($operation == 'DECODE') {
			// substr($result, 0, 10) == 0 ��֤������Ч��
			// substr($result, 0, 10) - time() > 0 ��֤������Ч��
			// substr($result, 10, 16) == substr(md5(substr($result, 26).$keyb), 0, 16) ��֤����������
			// ��֤������Ч�ԣ��뿴δ�������ĵĸ�ʽ
			if((substr($result, 0, 10) == 0 || substr($result, 0, 10) - time() > 0) && substr($result, 10, 16) == substr(md5(substr($result, 26).$keyb), 0, 16)) {
				return substr($result, 26);
			} else {
				return '';
			}
		} else {
			// �Ѷ�̬�ܳױ������������Ҳ��Ϊʲôͬ�������ģ�������ͬ���ĺ��ܽ��ܵ�ԭ��
			// ��Ϊ���ܺ�����Ŀ�����һЩ�����ַ������ƹ��̿��ܻᶪʧ��������base64����
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
	 * ������IP�Ƿ�Ϊ����Ip
	 * @param <type> $ip
	 * @return <type> ������IP ����TRUE
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