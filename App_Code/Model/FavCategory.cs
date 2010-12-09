using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// ʵ����FavCategory ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����ID
		/// </summary>
		public int FavCategoryID
		{
			set{ _favcategoryid=value;}
			get{return _favcategoryid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string CategoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		/// <summary>
		/// ��ID�����Ϊ���࣬��Ϊ0
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

