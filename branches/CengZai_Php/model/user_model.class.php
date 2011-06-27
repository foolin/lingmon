<?php

require_once ROOT_PATH . 'model/base_model.class.php';

class UserModel extends BaseModel
{
	
	function __construct(&$config) 
	{
		parent::init($config);
	}


	//判断是否存在邮箱
	public function exists_email($email)
	{
		$sql = "SELECT COUNT(0) FROM {$this->db->table_prefix}user WHERE email='$email'";
		return $this->db->result_first($sql);
	}
	
	public function add($email, $password, $regtime='', $regip='127.0.0.1', $status=0)
	{

		$sql = "INSERT INTO {$this->db->table_prefix}user (email, password, regtime, regip, status) VALUES('$email', '$password', '$regtime', '$regip', '$status') ";

		$this->db->query($sql);
		return $this->db->insert_id();

	}
	
	
	public function get_list()
	{
		$sql = "SELECT * FROM {$this->db->table_prefix}user ";
		return $this->db->fetch_all($sql);
	}
}
?>