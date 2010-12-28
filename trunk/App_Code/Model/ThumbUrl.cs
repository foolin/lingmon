using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// 实体类ThumbUrl 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ThumbUrl
	{
		public ThumbUrl()
		{}
		#region Model
		private int? _thumbid;
		private int? _favid;
		private string _thumbimage;
		private decimal? _offsetleft;
		private decimal? _offsettop;
		private decimal? _width;
		private decimal? _height;
		private string _target;
		private int? _sort;
		/// <summary>
		/// 
		/// </summary>
		public int? ThumbID
		{
			set{ _thumbid=value;}
			get{return _thumbid;}
		}
		/// <summary>
		/// 收藏ID
		/// </summary>
		public int? FavID
		{
			set{ _favid=value;}
			get{return _favid;}
		}
		/// <summary>
		/// 缩略图
		/// </summary>
		public string ThumbImage
		{
			set{ _thumbimage=value;}
			get{return _thumbimage;}
		}
		/// <summary>
		/// 左偏移
		/// </summary>
		public decimal? OffsetLeft
		{
			set{ _offsetleft=value;}
			get{return _offsetleft;}
		}
		/// <summary>
		/// 顶部偏移
		/// </summary>
		public decimal? OffsetTop
		{
			set{ _offsettop=value;}
			get{return _offsettop;}
		}
		/// <summary>
		/// 宽度
		/// </summary>
		public decimal? Width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 高度
		/// </summary>
		public decimal? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 打开
		/// </summary>
		public string Target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

