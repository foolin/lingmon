using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// 实体类Favorite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Favorite
	{
		public Favorite()
		{}
		#region Model
		private int? _favid;
		private string _title;
		private string _url;
		private int? _favcategoryid;
		/// <summary>
		/// 
		/// </summary>
		public int? FavID
		{
			set{ _favid=value;}
			get{return _favid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// URL地址
		/// </summary>
		public string URL
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 分类ID
		/// </summary>
		public int? FavCategoryID
		{
			set{ _favcategoryid=value;}
			get{return _favcategoryid;}
		}
		#endregion Model

	}
}

