using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// ʵ����QuickFavorite ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �ղ�ID
		/// </summary>
		public int? FavID
		{
			set{ _favid=value;}
			get{return _favid;}
		}
		/// <summary>
		/// ����ͼ
		/// </summary>
		public string MinImage
		{
			set{ _minimage=value;}
			get{return _minimage;}
		}
		/// <summary>
		/// ��ƫ��
		/// </summary>
		public decimal? OffsetLeft
		{
			set{ _offsetleft=value;}
			get{return _offsetleft;}
		}
		/// <summary>
		/// ����ƫ��
		/// </summary>
		public decimal? OffsetTop
		{
			set{ _offsettop=value;}
			get{return _offsettop;}
		}
		/// <summary>
		/// ���
		/// </summary>
		public decimal? Width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// �߶�
		/// </summary>
		public decimal? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		#endregion Model

	}
}

