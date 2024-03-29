SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_FavCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_FavCategory](
	[FavCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_FavCategory] PRIMARY KEY CLUSTERED 
(
	[FavCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_FavCategory', N'COLUMN',N'FavCategoryID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_FavCategory', @level2type=N'COLUMN',@level2name=N'FavCategoryID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_FavCategory', N'COLUMN',N'CategoryName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_FavCategory', @level2type=N'COLUMN',@level2name=N'CategoryName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_FavCategory', N'COLUMN',N'ParentID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父ID，如果为根类，则为0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_FavCategory', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Favorite]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Favorite](
	[FavID] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[URL] [nvarchar](500) NULL,
	[FavCategoryID] [int] NULL
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Favorite', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Favorite', @level2type=N'COLUMN',@level2name=N'Title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Favorite', N'COLUMN',N'URL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Favorite', @level2type=N'COLUMN',@level2name=N'URL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_Favorite', N'COLUMN',N'FavCategoryID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Favorite', @level2type=N'COLUMN',@level2name=N'FavCategoryID'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wb_Paging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Foolin
-- Create date: 2010-09-22
-- Description:	存储过程分页
-- 调用：(排序ASC不可少)
--       exec PR_Paging ''select * from [order] '', 20, 0, ''CreateTime ASC,  Money DESC'' 
-- =============================================
CREATE PROCEDURE [dbo].[Wb_Paging]
(
 @SQL nvarchar(1024),   --查询语句
 @PageSize int = 20,    --分页大小
 @PageIndex int = 0,    --分页索引
 @Sort nvarchar(100) = '''',    --排序字段
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

set @strSQL = '' select @TotalCount=count(*) from (''+@SQL+'') as t '' 

/*取得查询结果总数*/
exec sp_executesql
@strSQL, 
N''@TotalCount int=0 OUTPUT'', 
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

if(@Sort != '''')
begin
    /*声明排序变量*/
    declare @IndexSort1 nvarchar(50), @IndexSort2 nvarchar(50), @Sort1 nvarchar(50), @Sort2 nvarchar(50)
    
    SET @Sort1 = @Sort
    SET @Sort2 = Replace(Replace(Replace(@Sort, ''DESC'', ''@SORT''), ''ASC'', ''DESC''), ''@SORT'', ''ASC'')

    set @strSQL = ''SELECT * FROM 
    (SELECT TOP '' + STR(@ItemCount) + '' * FROM 
    (SELECT TOP '' + STR(@PageSize * @_PageIndex) + '' * FROM 
    (''+@SQL+'') AS t0 
    ORDER BY ''+@Sort1 +'') AS t1 
    ORDER BY ''+@Sort2 +'') AS t2 
    ORDER BY '' +@Sort 
end
else
begin
    set @strSQL = ''SELECT * FROM 
    (SELECT TOP '' + STR(@ItemCount) + '' * FROM 
    (SELECT TOP '' + STR(@PageSize * @_PageIndex) + '' * FROM 
    (''+@SQL+'') As t0) 
    aS t1) 
    AS t2''
end

exec sp_executesql 
@strSQL
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Sex] [nvarchar](5) NULL,
	[ActivateCode] [nvarchar](50) NULL,
	[RegTime] [datetime] NULL,
	[RegIP] [nvarchar](50) NULL,
	[LastLoginTime] [datetime] NULL,
	[LastLoginIP] [nvarchar](50) NULL,
	[LoginCount] [int] NULL,
	[Level] [int] NULL,
	[Credit] [float] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'UserID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID，自动增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'UserID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Username'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Username'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Nickname'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Nickname'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Password'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Email'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子信箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Email'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Sex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'ActivateCode'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'激活码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'ActivateCode'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'RegTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'RegIP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'RegIP'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'LastLoginTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'LastLoginIP'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'LoginCount'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'LoginCount'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Level'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Level'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Credit'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Credit'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_User', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态：1-正常用户，0=未激活用户， -1=冻结用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_User', @level2type=N'COLUMN',@level2name=N'Status'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ThumbUrl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_ThumbUrl](
	[ThumbID] [int] NULL,
	[FavID] [int] NULL,
	[ThumbImage] [nvarchar](200) NULL,
	[OffsetLeft] [float] NULL,
	[OffsetTop] [float] NULL,
	[Width] [float] NULL,
	[Height] [float] NULL,
	[Target] [nvarchar](50) NULL,
	[Sort] [int] NULL CONSTRAINT [DF_T_ThumbUrl]  DEFAULT ((0))
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'FavID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收藏ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'FavID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'ThumbImage'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'ThumbImage'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'OffsetLeft'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'左偏移' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'OffsetLeft'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'OffsetTop'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顶部偏移' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'OffsetTop'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'Width'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'Width'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'Height'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'Height'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'Target'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打开' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'Target'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'T_ThumbUrl', N'COLUMN',N'Sort'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ThumbUrl', @level2type=N'COLUMN',@level2name=N'Sort'
