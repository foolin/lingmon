<?php
/*******************************************************************
 * Copyright (C)2011 Ling Team.
 *
 * @Desc: Model层基类封装一些基础操作
 *
 * @Author: Foolin
 *
 * @Email: Foolin@126.com
 *
 * @Date: 2011-06-28 23:29:29
 *******************************************************************/

class BaseModel
{
	protected $db;
	protected $db_table = '';
	
	//初始化
	function init(&$config) 
	{
		$this->_init_db($config);
		$this->db_table = $this->db->table_prefix . $this->db_table;
	}
	
	//初始化数据库
	protected function _init_db($config) 
	{
		require_once ROOT_PATH.'lib/db.class.php';
		$this->db = new Db();
		$this->db->connect($config['db_host'], $config['db_user'], $config['db_pwd']
							 , $config['db_name'], $config['db_table_prefix'], $config['db_charset']);
		//$this->db->connect('127.0.0.1:3306', 'root', '123456', 'cengzai', 'cz_', 'utf8');

	}

	
	//添加
	function base_add($model)
	{
		if(!isset($model) || !is_array($model))
		{
			die('base_add($model)出错，$model必须为｛key=val｝的数组！');
			return false;
		}

		
		$field_keys = '';
		$field_vals = '';

		//循环遍历查找字段
		$count = count($model);
		$i = 1;
		foreach($model as $key=>$val)
		{
			if(!empty($key))
			{	//插入的字段
				$field_keys .= $key;
				$field_vals .= "'{$val}'";
				if($i != $count)
				{
					$field_keys .= " , ";
					$field_vals .= " , ";
				}
			}
			
			$i = $i + 1;
		}

		//拼接SQL
		$sql = "INSERT INTO {$this->db_table} ({$field_keys}) VALUES({$field_vals}) ";

		$this->db->query($sql);
		return $this->db->insert_id();
	}


	//更新
	function base_update($model, $where)
	{
		if(!isset($model) || !is_array($model))
		{
			die('base_update($model)出错，$model必须为｛key=val｝的数组！');
			return false;
		}

		if(!isset($where))
		{
			die('base_update($model, $where)出错，传入$where参数！');
			return false;
		}
		
		$field_key_val = '';
		$count = count($model);
		$i = 1;
		foreach($model as $key=>$val)
		{
			if(!empty($key))
			{	//更新的字段
				$field_key_val .= " {$key}='{$val}' ";
				if($i != $count)
				{
					$field_key_val .= " , ";
				}
			}

			$i = $i + 1;
		}


		$sql = "UPDATE {$this->db_table} SET {$field_key_val} ";
		if(!empty($where))
		{
			$sql .= " WHERE " . $where;
		}

		return $this->db->query($sql);
	}

	
	//取列表
	function base_get_list($where='', $order='')
	{
		$sql = " SELECT * FROM {$this->db_table} ";

		if(isset($where) && !empty($where))
		{
			$sql .= " WHERE {$where} ";
		}

		if(isset($order) && !empty($order))
		{
			$sql .= " ORDER BY {$order} ";
		}

		return $this->db->fetch_all($sql);
	}

	
	//取单个数据
	function base_get_model($where, $order='')
	{
		if(isset($where) && !empty($where))
		{
			$where = " WHERE {$where} ";
		}
		else
		{
			$where = '';
		}

		if(isset($order) && !empty($order))
		{
			$order = " ORDER BY {$order} ";
		}
		else
		{
			$order = '';
		}

		$sql = " SELECT * FROM {$this->db_table} {$where} {$order} LIMIT 0,1 ";

		return $this->db->fetch_first($sql);
	}


	//删除
	function base_delete($where)
	{
		if(!isset($where))
		{
			die('base_delete($where)出错，传入$where参数！');
			return false;
		}

		$sql = "DELETE FROM {$this->db_table} ";

		if(!empty($where))
		{
			$sql .= " WHERE " . $where;
		}
		
		return $this->db->query($sql);
	}
	
}


?>