-- phpMyAdmin SQL Dump
-- version 3.3.7
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2011 年 06 月 20 日 17:36
-- 服务器版本: 5.0.90
-- PHP 版本: 5.2.14

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `cengzai`
--

-- --------------------------------------------------------

--
-- 表的结构 `cz_ask`
--

CREATE TABLE IF NOT EXISTS `cz_ask` (
  `id` int(11) unsigned NOT NULL auto_increment COMMENT 'id',
  `uid` int(11) unsigned NOT NULL COMMENT '用户id',
  `title` varchar(50) NOT NULL COMMENT '标题',
  `content` text NOT NULL COMMENT '内容',
  `isanonym` tinyint(4) NOT NULL COMMENT '是否匿名（0=否，1=是）',
  `postip` varchar(50) NOT NULL COMMENT '提交者IP',
  `posttime` datetime NOT NULL COMMENT '提交时间',
  `status` tinyint(4) NOT NULL,
  `bestreplyid` int(11) unsigned NOT NULL COMMENT '最佳答案ID（默认0）',
  `views` int(11) unsigned NOT NULL COMMENT '浏览次数',
  `awardcredit` int(11) unsigned NOT NULL COMMENT '奖励积分',
  `replys` int(11) unsigned NOT NULL COMMENT '回答次数',
  `islock` tinyint(4) NOT NULL COMMENT '锁定。',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='问答' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_ask`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_ask_reply`
--

CREATE TABLE IF NOT EXISTS `cz_ask_reply` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT '评论id',
  `askid` int(10) unsigned NOT NULL COMMENT '匿名问答id',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `content` text NOT NULL COMMENT '回复内容',
  `postip` varchar(50) NOT NULL COMMENT '回复IP',
  `posttime` datetime NOT NULL COMMENT '回复时间',
  `islock` tinyint(4) NOT NULL COMMENT '状态',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='心情评论表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_ask_reply`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_help`
--

CREATE TABLE IF NOT EXISTS `cz_help` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT 'id',
  `uid` int(11) unsigned NOT NULL COMMENT '用户id',
  `touid` int(11) unsigned NOT NULL COMMENT '接收者id',
  `title` varchar(50) NOT NULL COMMENT '标题',
  `content` text NOT NULL COMMENT '内容',
  `postip` varchar(50) NOT NULL COMMENT '提交者ip',
  `posttime` int(11) unsigned NOT NULL COMMENT '提交者时间',
  `status` tinyint(4) NOT NULL COMMENT '状态（0=待接受，1=已接收，-1=已结束）',
  `statustime` int(11) unsigned NOT NULL COMMENT '状态更新时间',
  `islock` tinyint(11) NOT NULL COMMENT '锁定',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='匿名问答' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_help`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_help_reply`
--

CREATE TABLE IF NOT EXISTS `cz_help_reply` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT '评论id',
  `helpid` int(10) unsigned NOT NULL COMMENT '匿名问答id',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `content` text NOT NULL COMMENT '回复内容',
  `postip` varchar(50) NOT NULL COMMENT '回复IP',
  `posttime` datetime NOT NULL COMMENT '回复时间',
  `islock` tinyint(4) NOT NULL COMMENT '状态',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='心情评论表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_help_reply`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_message`
--

CREATE TABLE IF NOT EXISTS `cz_message` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT 'id',
  `fromuid` int(10) unsigned NOT NULL COMMENT '发送者uid',
  `touid` int(10) unsigned NOT NULL COMMENT '接收者uid',
  `title` varchar(50) NOT NULL COMMENT '标题',
  `content` text NOT NULL COMMENT '消息内容',
  `sendtime` datetime NOT NULL COMMENT '发送时间',
  `readtime` datetime NOT NULL COMMENT '接收时间',
  `isread` tinyint(4) NOT NULL COMMENT '是否阅读',
  `issys` tinyint(4) NOT NULL COMMENT '是否系统消息',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='短消息' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_message`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_mood`
--

CREATE TABLE IF NOT EXISTS `cz_mood` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT 'ID',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `content` varchar(140) NOT NULL COMMENT '内容',
  `image` varchar(255) NOT NULL COMMENT '图片路径',
  `audio` varchar(255) NOT NULL COMMENT '音频路径',
  `video` varchar(255) NOT NULL COMMENT '视频路径',
  `type` varchar(50) NOT NULL COMMENT '类型（image=照片，audio=音频，video=视频）',
  `postip` varchar(50) NOT NULL COMMENT '提交者IP',
  `posttime` datetime NOT NULL COMMENT '提交时间',
  `replys` int(11) NOT NULL COMMENT '回复数',
  `islock` tinyint(11) NOT NULL COMMENT '是否锁定',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='心情表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_mood`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_mood_reply`
--

CREATE TABLE IF NOT EXISTS `cz_mood_reply` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT '评论id',
  `moodid` int(10) unsigned NOT NULL COMMENT '心情id',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `content` varchar(140) NOT NULL COMMENT '回复内容',
  `postip` varchar(50) NOT NULL COMMENT '回复IP',
  `posttime` datetime NOT NULL COMMENT '回复时间',
  `islock` tinyint(4) NOT NULL COMMENT '状态',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='心情评论表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_mood_reply`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_user`
--

CREATE TABLE IF NOT EXISTS `cz_user` (
  `uid` int(10) unsigned NOT NULL auto_increment COMMENT '用户id',
  `username` varchar(50) NOT NULL COMMENT '用户名',
  `password` varchar(50) NOT NULL COMMENT '密码',
  `email` varchar(50) NOT NULL COMMENT '邮箱',
  `nickname` varchar(50) NOT NULL COMMENT '昵称',
  `birth` date NOT NULL COMMENT '生日',
  `areaid` int(11) NOT NULL default '0' COMMENT '地区',
  `face` varchar(255) NOT NULL COMMENT '头像',
  `sign` varchar(140) NOT NULL COMMENT '签名',
  `regtime` datetime NOT NULL COMMENT '注册时间',
  `regip` varchar(50) NOT NULL COMMENT '注册ip',
  `lastlogintime` datetime NOT NULL COMMENT '登录时间',
  `lastloginip` varchar(50) NOT NULL COMMENT '最后登录ip',
  `logincount` int(11) NOT NULL COMMENT '登录次数',
  `status` tinyint(11) NOT NULL COMMENT '登录状态：-1=冻结，0=未激活，1=正常',
  PRIMARY KEY  (`uid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='用户表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_user`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_user_dyn`
--

CREATE TABLE IF NOT EXISTS `cz_user_dyn` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT 'id',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `content` varchar(255) NOT NULL COMMENT '动态消息内容',
  `type` varchar(50) NOT NULL COMMENT '类型：ask=问答,mood=心情,friend=好友',
  `postip` varchar(50) NOT NULL COMMENT '提交ip',
  `posttime` datetime NOT NULL COMMENT '提交时间',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='用户动态' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_user_dyn`
--


-- --------------------------------------------------------

--
-- 表的结构 `cz_user_friend`
--

CREATE TABLE IF NOT EXISTS `cz_user_friend` (
  `id` int(10) unsigned NOT NULL auto_increment COMMENT 'id',
  `uid` int(10) unsigned NOT NULL COMMENT '用户id',
  `frienduid` int(10) unsigned NOT NULL COMMENT '朋友id',
  `status` tinyint(4) NOT NULL COMMENT '状态（0=申请状态，1=好友状态，-1=黑名单）',
  `msg` int(11) NOT NULL COMMENT '验证信息',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='好友列表' AUTO_INCREMENT=1 ;

--
-- 转存表中的数据 `cz_user_friend`
--

