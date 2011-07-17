<?php

class LetterModel extends BaseModel
{
	private $draft_table_name = 'letter_draft';
	
	function __construct(&$config) 
	{
		$this->db_table = 'letter'; //表名，不用加前缀，前缀在config配置。
		parent::init($config);
	}


	//取草稿列表
	function draft_get_list($where='', $order='')
	{
		$this->set_db_table($this->draft_table_name);
		return $this->base_get_list($where, $order);
	}

	//取草稿列表
	function draft_get_page_list($where='', $order='', $page_index=1, $page_size=20)
	{
		$this->set_db_table($this->draft_table_name);
		return $this->base_get_page_list($where, $order, $page_index, $page_size);
	}

	//取实体
	function draft_get_model($id)
	{
		$this->set_db_table($this->draft_table_name);
		if(!isset($id) || !is_numeric($id))
		{
			return false;
		}

		$where = " id='{$id}' ";
		return $this->base_get_model($where);
	}



	//添加草稿
	function draft_del($id)
	{
		$this->set_db_table($this->draft_table_name);
		if(!isset($id) || !is_numeric($id))
		{
			return false;
		}

		$where = " id='{$id}' ";
		return $this->base_del($where);
	}

	//保存草稿
	function draft_save($model)
	{
		$this->set_db_table($this->draft_table_name);

		//判断是否更新
		if(isset($model['id']) && is_numeric($model['id']))
		{
			$where = "id={$model['id']}";			
			return $this->base_update($model, $where);
			
		}

		//添加
		return $this->base_add($model);
	}


	//取回复
	function get_reply_list($where='', $order='')
	{
		$sql = "SELECT * FROM {$this->db->table_prefix}letter_reply";
		if(!empty($where))
		{
			$sql .= " WHERE {$where} ";
		}
		if(!empty($order))
		{
			$sql .= " ORDER BY {$order} ";
		}

		return $this->db->fetch_all($sql);
	}

}
?>