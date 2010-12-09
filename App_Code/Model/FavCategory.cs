using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// 实体类FavCategory 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FavCategory
	{
		public FavCategory()
		{}
		#region Model
		private int _favcategoryid;
		private string _categoryname;
		private int? _parentid;
		/// <summary>
		/// 分类ID
		/// </summary>
		public int FavCategoryID
		{
			set{ _favcategoryid=value;}
			get{return _favcategoryid;}
		}
		/// <summary>
		/// 分类名
		/// </summary>
		public string CategoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// 父ID，如果为根类，则为0
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

