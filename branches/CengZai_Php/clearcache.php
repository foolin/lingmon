<?php
define('IN_LINGLIB',true);
define('ROOT_PATH',dirname(__FILE__) . '/');

require(ROOT_PATH . "lib/io.class.php");
echo ROOT_PATH . 'cache/templates/';
Io::clear_dir(ROOT_PATH . 'cache/templates/');
?>