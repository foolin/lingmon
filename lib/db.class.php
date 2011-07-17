<?php

/**
 * 文件名：db.class.php
 * 版本号：LingLib v1.0.0
 * 最后修改时间： 2011年6月21日
 * 作者：负零<foolin@126.com>
 * 功能描述：一个数据库操作类
 */

class Db {
	var $query_num = 0;
	var $link;
	var $histories;

	var $db_host;
	var $db_port;
	var $db_user;
	var $db_pwd;
	var $db_charset;
	var $pconnect;
	var $table_prefix;
	var $time;

	var $goneaway = 5;

	function connect($db_host, $db_user, $db_pwd, $dbname = '', $table_prefix='',  $db_charset = '', $pconnect = 0, $time = 0) {
		$this->db_host = $db_host;
		$this->db_user = $db_user;
		$this->db_pwd = $db_pwd;
		$this->dbname = $dbname;
		$this->db_charset = $db_charset;
		$this->pconnect = $pconnect;
		$this->table_prefix = $table_prefix;
		$this->time = $time;

		if($pconnect) {
			if(!$this->link = mysql_pconnect($db_host, $db_user, $db_pwd)) {
				$this->halt('Can not connect to MySQL server');
			}
		} else {
			if(!$this->link = mysql_connect($db_host, $db_user, $db_pwd)) {
				$this->halt('Can not connect to MySQL server');
			}
		}

		if($this->version() > '4.1') {
			if($db_charset) {
				mysql_query("SET character_set_connection=".$db_charset.", character_set_results=".$db_charset.", character_set_client=binary", $this->link);
			}

			if($this->version() > '5.0.1') {
				mysql_query("SET sql_mode=''", $this->link);
			}
		}

		if($dbname) {
			mysql_select_db($dbname, $this->link);
		}

	}

	//查询并转为数组
	function fetch_array($query, $result_type = MYSQL_ASSOC) {
		return mysql_fetch_array($query, $result_type);
	}

	//查询并返回第一行第一列数据
	function result_first($sql) {
		$query = $this->query($sql);
		return $this->result($query, 0);
	}

	//查询并返回第一行数据
	function fetch_first($sql) {
		$query = $this->query($sql);
		return $this->fetch_array($query);
	}

	//查询
	function fetch_all($sql, $id = '') {
		$arr = array();
		$query = $this->query($sql);
		while($data = $this->fetch_array($query)) {
			$id ? $arr[$data[$id]] = $data : $arr[] = $data;
		}
		return $arr;
	}

	function cache_gc() {
		$this->query("DELETE FROM {$this->table_prefix}sqlcaches WHERE expiry<$this->time");
	}

	function query($sql, $type = '', $cachetime = FALSE) {
		$func = $type == 'UNBUFFERED' && @function_exists('mysql_unbuffered_query') ? 'mysql_unbuffered_query' : 'mysql_query';
		if(!($query = $func($sql, $this->link)) && $type != 'SILENT') {
			$this->halt('MySQL Query Error', $sql);
		}
		$this->query_num++;
		$this->histories[] = $sql;
		return $query;
	}

	function affected_rows() {
		return mysql_affected_rows($this->link);
	}

	function error() {
		return (($this->link) ? mysql_error($this->link) : mysql_error());
	}

	function errno() {
		return intval(($this->link) ? mysql_errno($this->link) : mysql_errno());
	}

	function result($query, $row) {
		$query = @mysql_result($query, $row);
		return $query;
	}

	function num_rows($query) {
		$query = mysql_num_rows($query);
		return $query;
	}

	function num_fields($query) {
		return mysql_num_fields($query);
	}

	function free_result($query) {
		return mysql_free_result($query);
	}

	function insert_id() {
		return ($id = mysql_insert_id($this->link)) >= 0 ? $id : $this->result($this->query("SELECT last_insert_id()"), 0);
	}

	function fetch_row($query) {
		$query = mysql_fetch_row($query);
		return $query;
	}

	function fetch_fields($query) {
		return mysql_fetch_field($query);
	}

	function version() {
		return mysql_get_server_info($this->link);
	}

	function close() {
		return mysql_close($this->link);
	}

	function halt($message = '', $sql = '') {
		$error = mysql_error();
		$errorno = mysql_errno();
		if($errorno == 2006 && $this->goneaway-- > 0) {
			$this->connect($this->db_host, $this->db_user, $this->db_pwd, $this->dbname, $this->db_charset, $this->pconnect, $this->table_prefix, $this->time);
			$this->query($sql);
		} else {
			$s = '';
			if($message) {
				$s = "<b>Info:</b> $message<br />";
			}
			if($sql) {
				$s .= '<b>SQL:</b>'.htmlspecialchars($sql).'<br />';
			}
			$s .= '<b>Error:</b>'.$error.'<br />';
			$s .= '<b>Errno:</b>'.$errorno.'<br />';
			exit($s);
		}
	}
}

?>