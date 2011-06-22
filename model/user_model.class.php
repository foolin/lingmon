<?php

require_once ROOT_PATH . 'model/base_model.class.php';

class UserModel extends BaseModel
{
	
	function __construct(&$config) 
	{
		parent::init($config);
	}
	
	public function add($user)
	{
		$sql = "INSERT INTO {$this->db->table_prefix}user (username, password, email, nickname) VALUES('$user[username]', '$user[password]', '$user[email]', '$user[nickname]') ";

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