<?php

class LetterLogic extends BaseLogic
{
	function __construct(&$config)
	{
		parent::init($config);
	}

	function execute()
	{
		//判断是否登录
		$this->check_login();

		include_once ROOT_PATH . 'model/letter_model.class.php';

		$cmd = $this->request('cmd');
		switch($cmd)
		{
			//显示列表
			case 'list':
				$this->show_list();
				break;
			

			//显示草稿
			case 'draft_list':
				$this->show_draft_list();
				break;

			//显示详细
			case 'detail':
				$this->show_detail();
				break;

			//添加
			case 'add':
				$this->show_add();
				break;

			//处理添加
			case 'do_add':
				$this->do_add();
				break;

			//删除草稿
			case 'draft_del':
				$this->draft_del();
				break;

			
			//默认首页
			default:
				$this->show_list();
				break;

		}
	}
	
	
	//显示列表
	function show_list()
	{
		$mod = $this->request('mod');
		$type = $this->request('type');
		
		

		require_once(ROOT_PATH . '/lib/page.class.php');
		$page=new Page();

		$letter_model = new LetterModel($this->config);
		//where条件
		$where = "uid='{$this->user['uid']}' or touid='{$this->user['uid']}' ";
		if($type == 'send')
		{
			$where = "uid='{$this->user['uid']}'";
		}
		else if($type == 'receive')
		{
			$where = " touid='{$this->user['uid']}' ";
		}
		//取列表
		$page_list = $letter_model->base_get_page_list($where, 'id desc', $page->get_index() -1 ,  $page->get_size());

		$total = $page_list['total'];
		$list = $page_list['list'];

		$pager = $page->get_pager($total);

		$this->title = '匿信列表';

		include $this->tpl->get_tpl('letter_list');
	}


	//显示草稿列表
	function show_draft_list()
	{
		$mod = $this->request('mod');
		$this->title = '匿信-我的草稿箱';

		require_once(ROOT_PATH . '/lib/page.class.php');
		$page=new Page();

		$letter_model = new LetterModel($this->config);
		$page_list = $letter_model->draft_get_page_list("id > 0", 'id desc', $page->get_index() -1 ,  $page->get_size());
		$total = $page_list['total'];
		$list = $page_list['list'];

		$pager = $page->get_pager($total);
		include $this->tpl->get_tpl('letter_draft_list');
	}


	//显示添加
	function show_add()
	{
		$this->title = '匿信-发送匿信';
		
		$draftid = $this->request('draftid');
		$draft = null;
		
		if(is_numeric($draftid) && $draftid > 0)
		{
			$letter_model = new LetterModel($this->config);
			$draft = $letter_model->draft_get_model($draftid);
			//print_r($draft);
			//exit;
		}
		
		if(empty($draft) || !is_array($draft))
		{
			$draft = array(
				'id' => '0',
				'title' => '',
				'content' => '',
				);
		}
		
		include $this->tpl->get_tpl('letter_add');
	}


	//处理添加
	function do_add()
	{
		$isdraft = $this->request('hdIsDraft');
		if(!empty($isdraft) && $isdraft == 1)
		{
			$this->_draft_save();
		}
		else
		{
			$this->_letter_save();
		}

 	}

	//保存草稿
	function _draft_save()
	{
		$title = $this->request('txtTitle');
		$content = $this->request('txtContent');
		$draftid = $this->request('hdDraftId');
		$uid = $this->user['uid'];

		if(empty($uid))
		{
			$url = $this->config['site_url'] . 'index.php?mod=user&cmd=logout';
			$this->messager('尚未登录！！','登录超时或者尚未登录，请重新操作！', $url, 3);
			exit;
		}

		$letter = array();
		$letter['title'] = $title;
		$letter['content'] = $content;
		$letter['uid'] = $uid;
		$letter['touid'] = 0;
		$letter['postip'] = Util::get_ip();
		$letter['posttime'] = Util::date();
		if(is_numeric($draftid) && $draftid > 0)
		{
			$letter['id'] = $draftid;
		}
		//保存草稿
		$letter_model = new LetterModel($this->config);
		$letter_model->draft_save($letter);

		$this->messager('保存草稿成功！','您保存匿名信草稿成功！', 'index.php?mod=letter&cmd=draft_list', 3);
	}

	//保存
	function _letter_save()
	{
		$title = $this->request('txtTitle');
		$content = $this->request('txtContent');
		$draftid = $this->request('hdDraftId');
		$uid = $this->user['uid'];
		if(empty($content))
		{
			$this->messager('匿名信内容不能为空！','请返回上一步填写匿名信内容' . $content, null, 3);
			exit;
		}

		//print_r($this->post);
		//exit;

		if(empty($uid))
		{
			$url = $this->config['site_url'] . 'index.php?mod=user&cmd=logout';
			$this->messager('尚未登录！！','登录超时或者尚未登录，请重新操作！', $url, 3);
			exit;
		}

		
		//实体
		$letter = array();
		$letter['title'] = $title;
		$letter['content'] = $content;
		$letter['uid'] = $uid;
		$letter['touid'] = 0;
		$letter['postip'] = Util::get_ip();
		$letter['posttime'] = Util::date();
		$letter['status'] = 0;
		$letter['statustime'] = Util::date();
		$letter['islock'] = 0;
		
		//添加
		$letter_model = new LetterModel($this->config);
		$id = $letter_model->base_add($letter);

		//删除草稿
		if(is_numeric($draftid) && $draftid > 0)
		{
			$letter_model->draft_del($draftid);
		}
		
		$this->messager('恭喜，匿名信已经成功投递！','恭喜，您的匿名信已经投递到有缘人信箱，请耐心等待有缘人的回复！', 'index.php?mod=letter&cmd=list');
	}


	//显示当条信息
	function show_detail()
	{
		$this->title = "阅读匿名信";
		$id = $this->request('id');
		if(!is_numeric($id))
		{
			$this->messager('404：该匿信未找到！','对不起，该匿信未找到，请检查地址是否非法！', 'index.php?mod=letter&cmd=list');
		}

		$letter_model = new LetterModel($this->config);

		$letter = $letter_model->base_get_model("id='$id'");
		if(!is_array($letter))
		{
			$this->messager('404：该匿信未找到！','对不起，该匿信未找到，请检查地址是否非法！', 'index.php?mod=letter&cmd=list');
		}
		
		$this->title = $letter['title'];
		$reply_list = $letter_model->get_reply_list("letterid='$id'", 'id desc');


		include $this->tpl->get_tpl('letter_detail');
	}


	//删除草稿
	function draft_del()
	{
		$draftid = $this->request('draftid');

		if(!is_numeric($draftid))
		{
			$this->messager('参数错误','对不起，该草稿不存在！', 'index.php?mod=letter&cmd=draft_del');
		}

		$letter_model = new LetterModel($this->config);
		$letter_model->draft_del($draftid);
		$this->messager('删除成功！','对不起，删除成功！', 'index.php?mod=letter&cmd=draft_list', 3);
	}

}

?>