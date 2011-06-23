<?php
/**
 * 文件名：template.class.php
 * 版本号： LingLib v1.0.0
 * 最后修改时间： 2011年6月17日
 * 作者：负零<foolin@126.com>
 * 功能描述：一个模板模板操作类
 */
 /*
选项描述
g 改变模式中的所有匹配
i 忽略模式中的大小写
e 替换字符串作为表达式
m 将待匹配串视为多行
o 仅赋值一次
s 将待匹配串视为单行
x 忽略模式中的空白
 
注：e选项把替换部分的字符串看作表达式，在替换之前先计算其值
 */

/*
$config = array(
  'template_path' => 'default',
  'template_root_path' => './templates/',
  'compiled_root_path' => './cache/templates/',
)
*/

!defined('IN_LINGLIB') && exit('Access Denied');

//加上引号，如： data[test]转为data['test']
function addquote($var) {
	return str_replace("\\\"", "\"", preg_replace("/\[([a-zA-Z0-9_\-\.\x7f-\xff]+)\]/s", "['\\1']", $var));
}

function stripvtags($expr, $statement) {
		$expr = str_replace("\\\"", "\"", preg_replace("/\<\?php echo (\\\$.+?); \?\>/s", "\\1", $expr));
	$statement = str_replace("\\\"", "\"", $statement);
	return $expr.$statement;
}


//模板处理类
class Template
{
	public $template_root_path="./templates/";
	public $template_path="";					
	public $template_dir="default";				
	public $compiled_folder="compiled_tpl/";	
	public $compiled_path="";					
	public $template_file="";					
	public $compiled_file="";					
	public $template_string="";				
	public $template_extension='.html'; 	
	public $compiled_extension='.php'; 	
	public $link_file_type='css|js|jpeg|jpg|png|bmp|gif|swf';     
	public $template_head_add = '';

	
	//载入配置
	function __construct(&$config)
	{
		$this->template_root_path=isset($config['template_root_path'])?$config['template_root_path']:"./templates/";
		$this->template_dir=$config['template_path'];
		$this->template_path=$this->template_root_path.$this->template_dir.'/';
		if(!isset($config['compiled_root_path']) or $config['compiled_root_path']=='')
		{
			$this->compiled_path=$this->template_path.$this->compiled_folder;
		}
		else
		{
			$this->compiled_path=$config['compiled_root_path'].'/'.$this->template_dir.'/';
		}
        $this->template_head_add = '<?php /'.'* '.date('Y-m-d').' invalid request template *'.'/ !defined("IN_LINGLIB") && exit("Access Denied"); ?>';
	}

	//取模板文件，返回文件路径
	function get_tpl($filename)
	{
		$this->template_file=$this->template_path.$filename.$this->template_extension;
		$this->compiled_file=$this->compiled_path.$filename.$this->compiled_extension;
        $to = $this->compiled_file;
		if(!is_file($this->compiled_file)) {
			if(!is_file($this->template_file))
			{
				$tpl_path= strpos($this->template_dir,'/') ? dirname($this->template_path) . '/' : dirname($this->template_path).'/default/';
				$this->template_file=$tpl_path.$filename.$this->template_extension;
				if(!is_file($this->template_file)) 
                {
					die("模板文件'".$this->template_file."'不存在，请检查目录");
				}
			}
            
			if($this->load())
			{	
				$this->compile();                
                
				$this->write($to);
			}
			else
			{
				return false;
			}
		}
		return $to;
	}
	
	
	//返回模板内容
	function eval_tpl($filename)
	{
		$this->template_file=$this->template_path.$filename.$this->template_extension;
		$this->load();
		$contents=str_replace('"','\"',$this->template_string);
		return "return \"{$contents}\";";
	}

	
	//打开文件
	function load()
	{
		$fp= @fopen($this->template_file,'rb');
		if($fp)
		{
			@$this->template_string=fread($fp,filesize($this->template_file));
		}
		fclose($fp);
		return true;
	}

	
	//编译
	function compile()
	{
		//$变量名->变量名[数字字母_-."'[]$]
		$var_regexp = "((\\\$[a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*)(-\>[a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*)?(\[[a-zA-Z0-9_\-\.\"\'\[\]\$\x7f-\xff]+\])*)";
		//常量
		$const_regexp = "([a-zA-Z_\x7f-\xff][a-zA-Z0-9_\x7f-\xff]*)";

		$nest = 5;

		$template=$this->template_string;

		if(defined('FORMHASH') && FORMHASH)
        {
            $template = preg_replace("/(\<form.*? method=[\"\']?post[\"\']?)([^\>]*\>)/i","\\1 \\2\n<input type=\"hidden\" name=\"FORMHASH\" value='{FORMHASH}'/>",$template);
        }
		
		//<!--{}-->变为{}
		$template = preg_replace("/\<\!\-\-\{(.+?)\}\-\-\>/s", "{\\1}", $template);
		
		//{LF}
		$template = str_replace("{LF}", "<?php echo \"\\n\"; ?>", $template);
		
		//输出{变量}
		$template = preg_replace("/\{$var_regexp\}/s", "<?php echo \\1; ?>", $template);
		//给数组变量加引号'
		$template = preg_replace("/$var_regexp/es", "addquote('<?php echo \\1; ?>')", $template); 
		//*过滤掉重复<?php echo <?php echo $var; ？> ？> */
		$template = preg_replace("/\<\?php echo \<\?php echo $var_regexp; \?\>; \?\>/es", "addquote('<?php echo \\1; ?>')", $template);

		
        $template = preg_replace("/[\n\r\t]*\{date\((.+?)\)\}[\n\r\t]*/ie", "\$this->_datetags('\\1')", $template);
		$template = preg_replace("/[\n\r\t]*\{eval\s+(.+?)\}[\n\r\t]*/ies", "stripvtags('\n<?php \\1 ?>\n','')", $template);

		$template = preg_replace("/[\n\r\t]*\{conf\s+(.+?)\}[\n\r\t]*/ies", "addquote('<?php echo \$this->config[\\1]; ?>')", $template);

		$template = preg_replace("/[\n\r\t]*\{echo\s+(.+?)\}[\n\r\t]*/ies", "stripvtags('<?php echo \\1; ?>','')", $template);
		$template = preg_replace("/[\n\r\t]*\{elseif\s+(.+?)\}[\n\r\t]*/ies", "stripvtags('<?php } elseif(\\1) { ?>','')", $template);
		$template = preg_replace("/[\n\r\t]*\{else\}[\n\r\t]*/is", "\n<?php } else { ?>", $template);

		for($i = 0; $i < $nest; $i++) {
            $template = preg_replace("/[\n\r\t]*\{(?:sub)?templates?\s+[\"\']?([\w\d\-\_\.\:\/]+)[\"\']?\}/ies",'$this->_load_sub_template("\\1")',$template);
            		      		  
			$template = preg_replace("/[\n\r\t]*\{loop\s+(\<\?[^\?]+?\?\>)\s+(\<\?[^\?]+?\?\>)\}[\n\r]*(.+?)[\n\r]*\{\/loop\}[\n\r\t]*/ies", "stripvtags('\n<?php if(is_array(\\1)) { foreach(\\1 as \\2) { ?>','\n\\3\n<?php } } ?>\n')", $template);
			$template = preg_replace("/[\n\r\t]*\{loop\s+(\<\?[^\?]+?\?\>)\s+(\<\?[^\?]+?\?\>)\s+(\<\?[^\?]+?\?\>)\}[\n\r\t]*(.+?)[\n\r\t]*\{\/loop\}[\n\r\t]*/ies", "stripvtags('\n<?php if(is_array(\\1)) { foreach(\\1 as \\2 => \\3) { ?>','\n\\4\n<?php } } ?>\n')", $template);
			$template = preg_replace("/[\n\r\t]*\{if\s+(.+?)\}[\n\r]*(.+?)[\n\r]*\{\/if\}[\n\r\t]*/ies", "stripvtags('\n<?php if(\\1) { ?>','\n\\2\n<?php } ?>\n')", $template);
			$template = preg_replace("/[\n\r\t]*\{while\s+(.+?)\}[\n\r]*(.+?)[\n\r]*\{\/while\}[\n\r\t]*/ies", "stripvtags('\n<?php while(\\1) { ?>','\n\\2\n<?php } ?>\n')", $template);
		}
		$template = preg_replace("/\{$const_regexp\}/s", "<?php echo \\1; ?>", $template);
        $template = $this->template_head_add . $template;
		$template = trim($template);
		$this->template_string=$template;

		if(!empty($this->link_file_type))
		{
			$this->modify_links();
		}
	}
	
	function write($to='')
	{ 
		$save_dir=dirname($to);
		if(!is_dir($save_dir))$this->make_dir($save_dir, 0777);
        $fp = @fopen($to, 'wb');
        if(!$fp)die('模板无法写入,请检查目录是否有可写');
        $length=fwrite($fp, $this->template_string);
        fclose($fp);
		return $length;
	}

    
    function make_dir($dir_name, $mode = 0777)
    {
        if(false!==strpos($dir_name,'\\'))
    	{
    		$dir_name = str_replace("\\", "/", $dir_name);
    	}
    	if(false!==strpos($dir_name,'/'.'/'))
    	{
    		$dir_name = preg_replace("#(/"."/+)#", "/", $dir_name);
    	}
    	if (is_dir($dir_name))
    	{
    		return true;
    	}

        $dirs = '';
        $_dir_name = $dir_name;
    	$dir_name = explode("/", $dir_name);
        if('/'==$_dir_name{0})
        {
            $dirs = '/';
        }

    	foreach($dir_name as $dir)
    	{
    		$dir = trim($dir);
            if ('' != $dir)
            {
                $dirs .= $dir;

                if ('..' == $dir || '.' == $dir)
                {
                    
                    $dirs .= '/';

                    continue;
                }
            }
            else
            {
                continue;
            }

            $dirs .= '/';

            if (!is_dir($dirs))
    		{
    			if(!mkdir($dirs, $mode))
    			{
    				return false;
    			}
    		}
    	}
    	return true;
    }
	


	function modify_links_bak()
	{
		preg_match_all("/src=[\"\'\s]?(.*?)[\"\'\s]|url[\(\"\']{1,3}(.*?)[\s\"\'\)]|background=[\"\']?(.*?)[\"\'\s]|href=[\"\'\s]?(.*?)[\"\'](.*?)\>/si", $this->template_string, $match);

		$old = @array_values(array_merge(@array_unique($match[1]), $match[2], @array_unique($match[3]), $match[4]));
		$old = array_unique($old);
		$old=preg_grep("~.*?\.(".$this->link_file_type.")$~i",$old);
		foreach($old as $link)
		{
			if(trim($link) != "" and !strpos($link, ':/'.'/'))
			{
				if(strpos($link,'../')===0)
				{
					$this->template_string=str_replace($link, dirname($this->template_path) . '/' . ltrim($link, './'), $this->template_string);
				}
				else
				{
				$this->template_string = str_replace($link, rtrim($this->template_path,'\/') . '/' . ltrim($link, './'), $this->template_string);
				}
			}
		}
		return $this->template_string;
	}
	
	
	function modify_links()
	{
		preg_match_all("/src=[\"\'\s]?(.*?)[\"\'\s]|url[\(\"\']{1,3}(.*?)[\s\"\'\)]|background=[\"\']?(.*?)[\"\'\s]|href=[\"\'\s]?(.*?)[\"\'](.*?)\>/si", $this->template_string, $match);

		$old = @array_values(array_merge(@array_unique($match[1]), $match[2], @array_unique($match[3]), $match[4]));
		$old = array_unique($old);
		$old=preg_grep("~.*?\.(".$this->link_file_type.")$~i",$old);
		foreach($old as $link)
		{
			if(trim($link) != "" and false===strpos($link, ':/'.'/'))
			{
				$private_file=str_replace('templates/default/','templates/'.$this->template_dir.'/',$link);
				if (!is_file($private_file) && false===strpos($private_file,'templates')) {
					$private_file = 'templates/' . $this->template_dir . '/' . $private_file;
				}
				if('default'!=$this->template_dir && !is_file($private_file)) {
					$private_file = str_replace('templates/'.$this->template_dir.'/','templates/default/',$private_file);
				}
				if(is_file($private_file)==false) {
					continue;
				}

				$this->template_string = str_replace($link,$private_file, $this->template_string);
			}
		}
		return $this->template_string;
	}

	
	function repair_bracket($var)
	{
		return preg_replace("~\[([a-z0-9_\x7f-\xff]*?[a-z_\x7f-\xff]+[a-z0-9_\x7f-\xff]*?)\]~i","[\"\\1\"]",$var);
	}


    function _load_sub_template($file)
    {
        $tpl_file = $this->get_tpl($file);
                
        if(($content = @implode('',file($tpl_file))))
        {
            $content = str_replace($this->template_head_add,'',$content);
            
            return $content;
        }
        else
        {
            return '<!-- '.$file.' -->';
                    
        }   
    }  
    

    function _datetags($parameter) 
    {
		$format="Y-m-d H:i:s";
		return "<?php echo gmdate($format,($parameter+3600*8)); ?>";
	} 




}



?>