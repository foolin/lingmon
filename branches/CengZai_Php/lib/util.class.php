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