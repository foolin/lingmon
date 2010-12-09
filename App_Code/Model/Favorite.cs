using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// ʵ����Favorite ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// URL��ַ
		/// </summary>
		public string URL
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int? FavCategoryID
		{
			set{ _favcategoryid=value;}
			get{return _favcategoryid;}
		}
		#endregion Model

	}
}

