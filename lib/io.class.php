<?php
/**
 * 文件名：io.class.php
 * 版本号：LingLib v1.0.0 
 * 最后修改时间： 2011年6月21日
 * 作者：负零<foolin@126.com>
 * 功能描述：磁盘的检测，读取，以及文件目录的操作
 */
!defined('IN_LINGLIB') && exit('Access Denied');

class Io
{
	function __construct()
	{
	}
	
	function compare($file1, $file2)
	{
		if (md5_file($file1) == md5_file($file2))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	function size_convert($filesize)
	{
		if ($filesize >= 1073741824)
		{
			$filesize = round($filesize / 1073741824 , 2) . "G";
		}elseif ($filesize >= 1048576)
		{
			$filesize = round($filesize / 1048576, 2) . "M";
		}elseif ($filesize >= 1024)
		{
			$filesize = round($filesize / 1024, 2) . "k";
		}
		else
		{
			$filesize = $filesize . "b";
		}
		return $filesize;
	}
	function convert_size($filesize)
	{
		return Io::size_convert($filesize);
	}
	
	function read_dir($dir, $children = 0)
	{
		if(is_dir($dir) === false)return false;;
		$dir = rtrim(str_replace("\\", "/", $dir), "/") ;
		$dirfp = @opendir($dir);
		if ($dirfp === false)
		{
			trigger_error("{$dir}目录名不存在或者无效,请检查您的目录设置!<br>", E_USER_NOTICE);
			return false;
		}
		while (false !== ($file = readdir($dirfp)))
		{
			if ($file != '.' and $file != '..')
			{
				$abspath = $dir . '/' . $file;
				if (is_file($abspath) !== false)
				{
					$files[] = $abspath ;
				}
				if(is_dir($abspath) !== false)
				{
					if ($children == '1')
					{
						$files = array_merge((array) $files, (array) Io::read_dir($abspath, $children));
					}
				}
			}
		}
		closedir($dirfp);
		return (array) $files;
	}
	
	function read_file($file_name)
	{
		if (is_readable($file_name) != false)
		{
			if (function_exists('file_get_contents') != false)
			{
				$file_contents = file_get_contents($file_name);
				return $file_contents;
			}
			else
			{
				$file_handler = @fopen($file_name, 'r');
				if ($file_handler)
				{
					$file_contents = @fread($file_handler, filesize($file_name));
					fclose($file_handler);
					return $file_contents;
				}
				else
				{
					return false;
				}
			}
		}
		else
		{
			return false;
		}
	}
	
	function write_file($file_name, $file_contents, $mode = 'wb')
	{
		if (($mode == 'w' || $mode == 'wb') && function_exists('file_put_contents'))
		{
			return file_put_contents($file_name, $file_contents);
		}
		else
		{
			$file_handler = @fopen($file_name, $mode);
			if ($file_handler)
			{
				$len=fwrite($file_handler, $file_contents);
				fclose($file_handler);
				return $len;
			}
			else
			{
				return false;
			}
		}
	}

	
	function get_disk_list()
	{
		if (strpos(PHP_OS, 'WIN') === false)
		{
			return false;
		}
		$disks = range('c', 'w');
		foreach($disks as $disk)
		{
			$disk = $disk . ":";
			if (is_dir($disk) !== false && disk_total_space($disk) > 0)
			{
				$disk_list[] = $disk;
			}
		}
		return $disk_list;
	}
	
	function get_disk_space($disk_name, $convert_size = false)
	{
		if (is_dir($disk_name) === false)
		{
			return false;
		}
		$disk_space['total'] = (float)disk_total_space($disk_name);
		$disk_space['free'] = (float)disk_free_space($disk_name);
		$disk_space['used'] = $disk_space['total'] - $disk_space['free'];
		@$disk_space['percent'] = (float)round($disk_space['used'] / $disk_space['total'] * 100);
		if ($convert_size === false)
		{
			return $disk_space;
		}
		$disk_space['total'] = Io::convert_size($disk_space['total']);
		$disk_space['free'] = Io::convert_size($disk_space['free']);
		$disk_space['used'] = Io::convert_size($disk_space['used']);
		$disk_space['percent'] = $disk_space['percent'] . '%';
		return $disk_space;
	}
	
	function get_pattern_files($path, $pattern)
	{
		if (is_dir($path) == false)
		{
			return false;
		}
		$file_pattern = rtrim($path, '/') . "/"."*.{" . str_replace("|", ",", $pattern) . "}";
		$file_list = glob($file_pattern, GLOB_BRACE);
		if (count($file_list) == 0)
		{
			return false;
		}
		return $file_list;
	}
	
	function copy_file($from, $to)
	{
		$copy_count = 0;

		if (is_string($from))
		{
			if (copy($from, $to . '/' . Io::base_name($from)))
			{
				$copy_count = 1;
				return $copy_count;
			}
		}
		else
		{
			if (is_array($from))
			{
				if (is_dir($to) == false)
				{
					if (Io::make_dir($to) == false)
					{
						return $copy_count;
					}
				}
				foreach($from as $file_name)
				{
					if (copy($file_name, $to . '/' . Io::base_name($file_name)))
					{
						$copy_count++;
					}
				}
			}
		}
		return $copy_count;
	}

	
	function delete_file($file)
	{

		if('' == trim($file)) return ;

		$delete = @unlink($file);

				clearstatcache();
		@$filesys = preg_replace("~\/+~","\\",$file);
		if(is_file($filesys) and file_exists($filesys))
		{
			$delete = @system("del $filesys");
			clearstatcache();
			if(file_exists($file))
			{
				$delete = @chmod($file, 0777);
				$delete = @unlink($file);
				$delete = @system("del $filesys");
			}
		}
		clearstatcache();
		if(file_exists($file))
		{
			return false;
		}
		else
		{
			return true;
		}
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

	
	function clear_dir($dir_name)
	{
		clearstatcache();
		if(is_dir($dir_name) == false)return false;
		$dir_handle = opendir($dir_name);
		while(($file = readdir($dir_handle)) !== false)
		{
			if($file != '.' and $file != "..")
			{
				clearstatcache();
				if(is_dir($dir_name . '/' . $file))
				{
					Io::remove_dir($dir_name . '/' . $file);
				}
				if(is_file($dir_name . '/' . $file))
				{
					@unlink($dir_name . '/' . $file);
				}
			}
		}
		closedir($dir_handle);
		return true;
	}

	
	function remove_dir($dir_name)
	{
		clearstatcache();
		if(is_dir($dir_name) == false)return false;
		$dir_handle = opendir($dir_name);
		while(($file = readdir($dir_handle)) !== false)
		{
			if($file != '.' and $file != "..")
			{
				clearstatcache();
				if(is_dir($dir_name . '/' . $file))
				{
					Io::remove_dir($dir_name . '/' . $file);
				}
				if(is_file($dir_name . '/' . $file))
				{
					Io::delete_file($dir_name . '/' . $file);
				}
			}
		}
		closedir($dir_handle);
		rmdir($dir_name);
		return true;
	}
	
	function copy_dir($from, $to, $children = true)
	{
		if(is_dir($from) == false)return false;
		if(is_dir($to) == false)
		{
			if(Io::make_dir($to) == false)
			{
				return false;
			}
		}
		$from_handle = opendir($from);
		while(($file = readdir($from_handle)) !== false)
		{
			if($file != '.' and $file != '..')
			{
				$from_abs_path = $from . '/' . $file;
				$to_abs_path = $to . '/' . $file;
				if(is_dir($from_abs_path) != false and $children == true)
				{
					Io::make_dir($to_abs_path);
					Io::copy_dir($from_abs_path, $to_abs_path, $children);
				}
				if(is_file($from_abs_path) != false)
				{
					if(copy($from_abs_path, $to_abs_path) == false)
					{
						return false;
					}
				}
			}
		}
		closedir($from_handle);
		return true;
	}
	
	function file_fermission($file_name)
	{
		return substr(base_convert(fileperms($file_name), 10, 8), -4);
	}
	
	function base_name($path, $suffix = false)
	{
		$name = trim($path);
		$name = str_replace('\\', '/', $name);
		if(strpos($name, '/') !== false)
		{
			$name = substr(strrchr($path, '/'), 1);
		}
		else
		{
			$name = ltrim($path, '.');
		}
		if($suffix)
		{
			$suffix = strrchr($name, '.');
			$name = str_replace($suffix, '', $name);
		}
		return $name;
	}
	
	function update_file_array($file, $name, $array)
	{
		
		$out = "<?php\n";
		foreach($array as $key => $val)
		{
			$out .= "\${$name}['{$key}'] = '{$val}';\n";
		}
		$out .= '?>';
		if(Io::write_file($file, $out, "wb"))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	function read_disk_space($drive)
	{
		$disk_space['size']['total'] = disk_total_space($drive);
		$disk_space['size']['free'] = disk_free_space($drive);
		$disk_space['size']['used'] = $disk_space['size']['total'] - $disk_space['size']['free'];
		$disk_space['size_converted']['used'] = Io::size_convert($disk_space['size']['total'] - $disk_space['size']['free']);
		$disk_space['size_converted']['total'] = Io::size_convert($disk_space['size']['total']);
		$disk_space['size_converted']['free'] = Io::size_convert($disk_space['size']['free']);
		return $disk_space;
	}
}

?>