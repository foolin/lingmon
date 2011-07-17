<?php

class UserModel extends BaseModel
{
	
	
	function __construct(&$config) 
	{
		$this->db_table = 'user'; //表名，不用加前缀，前缀在config配置。
		parent::init($config);
	}


	//判断是否存在邮箱
	function exists_email($email)
	{
		$sql = "SELECT COUNT(0) FROM {$this->db_table} WHERE email='$email'";
		return $this->db->result_first($sql) > 0;
	}


	//获取用户信息
	function get_user($email)
	{
		$where = "email='$email'";
		return $this->base_get_model($where);
	}

	
	//判断用户是否存在
	function check_user($uid, $password)
	{
		$sql = "SELECT COUNT(0) FROM {$this->db_table} WHERE uid='{$uid}' AND Password='{$password}' ";
		return $this->db->result_first($sql) > 0;
	}

	/*
	function add($email, $password, $regtime='', $regip='127.0.0.1', $status=0)
	{

		$sql = "INSERT INTO {$this->db_table} (email, password, regtime, regip, status) VALUES('$email', '$password', '$regtime', '$regip', '$status') ";

		$this->db->query($sql);
		return $this->db->insert_id();

	}

	*/

/*
	function update($user, $where)
	{
		if(!$user || !is_array($user))
		{
			return false;
		}

		$sql = "UPDATE {$this->db_table} SET ";
		$count = count($user);
		$i = 1;
		foreach($user as $key=>$val)
		{
			if(!empty($key))
			{	//更新的字段
				$sql .= " {$key}='{$val}' ";
				if($i != $count)
				{
					$sql .= " , ";
				}
			}

			$i = $i + 1;
		}

		if(!isset($where))
		{
			die('Update()没传入Where参数');
		}
		if(!empty($where))
		{
			$sql .= " WHERE " . $where;
		}

		die($sql);
		return $this->db->query($sql);
	}
	*/
	
	/*
	function get_list()
	{
		$sql = "SELECT * FROM {$this->db->table_prefix}user ";
		return $this->db->fetch_all($sql);
	}
	*/
}
?>