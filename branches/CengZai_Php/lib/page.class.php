<?php
/**
 * 文件名：db.class.php
 * 版本号：LingLib v1.0.0
 * 最后修改时间： 2011-07-09 14:41:54
 * 作者：负零<foolin@126.com>
 * 功能描述：一个分页操作类
 */


class Page 
{
	public $index = 0;	//当前页
	public $size = 20;	//最大记录数
	public $url = '';	//当前url
	public $records = 0;	//总记录数
	public $pages = 0;	//总页数
	public $name = 'page';
	public $page_num_count = 6;

	//构造函数
	function __construct($size = 20, $url = '')
	{
		if(isset($size))
		{
			$this->size = $size;
		}
		if($size <= 0)
		{
			$this->size = 20;
		}


		//
		if(isset($_GET[$this->name]) && is_numeric($_GET[$this->name]))
		{
			$this->index = (int) $_GET[$this->name];
		}
		if($this->index <= 0)
		{
			$this->index = 1;
		}
	}

	//取当前页
	function get_index()
	{
		return $this->index;
	}

	//取当前页
	function get_size()
	{
		return $this->size;
	}

	
	//取页数
	function get_pager($records = -1)
	{
		if($records > -1)
		{
			$this->records = $records;
		}
		
		$this->set_url();


		$this->pages = (int)($this->records / $this->size);
		if($this->pages <=0)
		{
			$this->pages = 1;
		}

		$pre_no = $this->index -1;
		$next_no = $this->index + 1;

		//分页导航条
		$pager = '';

		/****** 首页,上一页 *********/
		if($this->index > 1)
		{
			$pager .= " <a href='{$this->url}1'>首页</a> ";
		}
		else
		{
			$pager .= " <span>首页</span> ";
		}

		if($pre_no > 0)
		{
			$pager .= " <a href='{$this->url}{$pre_no}'>上一页</a> ";
		}
	
		/********* 数字导航 *********/

		//分割数字，左右两边多少个数字
		$split_num = (int) ($this->page_num_count / 2);
		//索引左边导航
		$left_num = $this->index - $split_num;
		if($left_num < 1)
		{
			$left_num = 1;
		}
		for($i = $left_num; $i < $this->index ; $i++)
		{
			$pager .= " <a href='{$this->url}{$i}'>$i</a> ";
		}

		$pager .= " <span>$this->index</span> ";

		//右边索引数字导航
		$right_num = $this->index + $split_num;
		if($right_num > $this->pages)
		{
			$right_num = $this->pages;
		}
		for($i = $this->index + 1; $i <= $right_num; $i++)
		{
			$pager .= " <a href='{$this->url}{$i}'>$i</a> ";
		}

		
		/******** 尾页, 下一页 *******/
		if($next_no < $this->pages)
		{
			$pager .= " <a href='{$this->url}{$next_no}'>下一页</a> ";
		}

		if($this->index < $this->pages)
		{
			$pager .= " <a href='{$this->url}{$this->pages}'>尾页</a> ";
		}
		else
		{
			$pager .= " <span>尾页</span> ";
		}

		return $pager;

	}

	function set_url($url = '')
	{
		if(!empty($url))
		{
			//手动设置
			$this->url = $url . ((stristr($url,'?'))?'&':'?') . $this->name . "=";
			
		}
		else
		{
			//自动获取
			if(empty($_SERVER['QUERY_STRING']))
			{
				//不存在QUERY_STRING时
				$this->url=$_SERVER['REQUEST_URI']."?".$this->name."=";
			}
			else
			{
				//
				if(stristr($_SERVER['QUERY_STRING'],$this->name.'='))
				{
					//地址存在页面参数
					$this->url=str_replace($this->name.'='.$this->index,'',$_SERVER['REQUEST_URI']);
					$last=$this->url[strlen($this->url)-1];
					if($last=='?'||$last=='&')
					{
						$this->url.=$this->name."=";
					}
					else
					{
						$this->url.='&'.$this->name."=";
					}
				}
				else
				{
					//
					$this->url=$_SERVER['REQUEST_URI'].'&'.$this->name.'=';
				}//end if    
			}//end if
		}//end if
	}


}
?>