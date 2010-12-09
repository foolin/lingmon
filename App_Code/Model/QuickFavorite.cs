using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// 实体类QuickFavorite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class QuickFavorite
	{
		public QuickFavorite()
		{}
		#region Model
		private int? _quickfavid;
		private int? _favid;
		private string _minimage;
		private decimal? _offsetleft;
		private decimal? _offsettop;
		private decimal? _width;
		private decimal? _height;
		/// <summary>
		/// 
		/// </summary>
		public int? QuickFavID
		{
			set{ _quickfavid=value;}
			get{return _quickfavid;}
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
		public string MinImage
		{
			set{ _minimage=value;}
			get{return _minimage;}
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
		#endregion Model

	}
}

