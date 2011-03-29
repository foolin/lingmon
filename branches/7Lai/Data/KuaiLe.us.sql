USE [KuaiLeUs]
GO
/****** Object:  StoredProcedure [dbo].[Wb_Paging]    Script Date: 03/07/2011 01:54:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Foolin
-- Create date: 2010-09-22
-- Description:	存储过程分页
-- 调用：(排序ASC不可少)
--       exec PR_Paging 'select * from [order] ', 20, 0, 'CreateTime ASC,  Money DESC' 
-- =============================================
CREATE PROCEDURE [dbo].[Wb_Paging]
(
 @SQL nvarchar(1024),   --查询语句
 @PageSize int = 20,    --分页大小
 @PageIndex int = 0,    --分页索引
 @Sort nvarchar(100) = '',    --排序字段
 @TotalCount int = 0 output --总数    
)
AS

-- 值默认值
if (IsNUll(@PageSize,0)=0)
	Set @PageSize=20
if (IsNull(@PageIndex,0)=0)
	Set @PageIndex=0

set nocount on
/*声明查询字符串*/
declare @strSQL nvarchar(4000)

set @strSQL = ' select @TotalCount=count(*) from ('+@SQL+') as t ' 

/*取得查询结果总数*/
exec sp_executesql
@strSQL, 
N'@TotalCount int=0 OUTPUT', 
@TotalCount=@TotalCount OUTPUT 

declare @ItemCount int 
declare @_PageIndex int

set @_PageIndex = @PageIndex + 1;
/*确定搜索边界*/
set @ItemCount = @TotalCount - @PageSize * @_PageIndex

if(@ItemCount < 0) 
    set @ItemCount = @ItemCount + @PageSize 
else 
    set @ItemCount = @PageSize 

if(@ItemCount < 0) return 1 

if(@Sort != '')
begin
    /*声明排序变量*/
    declare @IndexSort1 nvarchar(50), @IndexSort2 nvarchar(50), @Sort1 nvarchar(50), @Sort2 nvarchar(50)
    
    SET @Sort1 = @Sort
    SET @Sort2 = Replace(Replace(Replace(@Sort, 'DESC', '@SORT'), 'ASC', 'DESC'), '@SORT', 'ASC')

    set @strSQL = 'SELECT * FROM 
    (SELECT TOP ' + STR(@ItemCount) + ' * FROM 
    (SELECT TOP ' + STR(@PageSize * @_PageIndex) + ' * FROM 
    ('+@SQL+') AS t0 
    ORDER BY '+@Sort1 +') AS t1 
    ORDER BY '+@Sort2 +') AS t2 
    ORDER BY ' +@Sort 
end
else
begin
    set @strSQL = 'SELECT * FROM 
    (SELECT TOP ' + STR(@ItemCount) + ' * FROM 
    (SELECT TOP ' + STR(@PageSize * @_PageIndex) + ' * FROM 
    ('+@SQL+') As t0) 
    aS t1) 
    AS t2'
end

exec sp_executesql 
@strSQL
GO
/****** Object:  Table [dbo].[T_Tags]    Script Date: 03/07/2011 01:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[ArtID] [int] NULL,
	[Tag] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Article]    Script Date: 03/07/2011 01:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Article](
	[ArtID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[Title] [nvarchar](50) NULL,
	[Content] [text] NULL,
	[Tags] [nvarchar](300) NULL,
	[IsAnonym] [int] NULL,
	[UserIP] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[Hits] [int] NULL,
	[DigUp] [int] NULL,
	[DigDown] [int] NULL,
	[Reports] [int] NULL,
	[Comments] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_T_Article] PRIMARY KEY CLUSTERED 
(
	[ArtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签，最大300个字符，多个逗号分割' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Article', @level2type=N'COLUMN',@level2name=N'Tags'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否匿名：0=否，1=匿名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Article', @level2type=N'COLUMN',@level2name=N'IsAnonym'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'-1=冻结，0=未审核，1=审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Article', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[T_Comment]    Script Date: 03/07/2011 01:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Comment](
	[CommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[ArtID] [bigint] NULL,
	[Comment] [nvarchar](300) NULL,
	[UserID] [bigint] NULL,
	[UserName] [nvarchar](50) NULL,
	[UserIP] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[DigUp] [int] NULL,
	[DigDown] [int] NULL,
	[Reports] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_T_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'举报' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Comment', @level2type=N'COLUMN',@level2name=N'Reports'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'-1冻结，0=未审核,1=已经审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Comment', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[T_Dig]    Script Date: 03/07/2011 01:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Dig](
	[DigID] [bigint] IDENTITY(1,1) NOT NULL,
	[SrcID] [bigint] NULL,
	[SrcType] [nvarchar](50) NULL,
	[UserID] [int] NULL,
	[UserIP] [nvarchar](50) NULL,
	[DigType] [int] NULL,
	[DigTime] [datetime] NULL,
 CONSTRAINT [PK_T_Dig] PRIMARY KEY CLUSTERED 
(
	[DigID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Article=文章，Comment=评论' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Dig', @level2type=N'COLUMN',@level2name=N'SrcType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=顶，1=踩，2=举报' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Dig', @level2type=N'COLUMN',@level2name=N'DigType'
GO
/****** Object:  Table [dbo].[T_User]    Script Date: 03/07/2011 01:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_User](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Sex] [int] NULL,
	[ActivateCode] [nvarchar](50) NULL,
	[RegTime] [datetime] NULL,
	[RegIP] [nvarchar](50) NULL,
	[LastLoginTime] [datetime] NULL,
	[LastLoginIP] [nvarchar](50) NULL,
	[LoginCount] [int] NULL,
	[Level] [int] NULL,
	[Credit] [float] NULL,
	[Status] [int] NULL,
	[FindPwdTime] [datetime] NULL,
	[Birth] [datetime] NULL,
	[HomePage] [nvarchar](200) NULL,
	[ImagePath] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Motto] [nvarchar](50) NULL,
	[Intro] [nvarchar](500) NULL,
 CONSTRAINT [PK_T_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别:0=保密，1=男，2=女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'激活码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'ActivateCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LoginCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Level'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Credit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：-1=冻结，0=未激活，1=正常' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'找回密码时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'FindPwdTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人主页' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'HomePage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'ImagePath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
