using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// ʵ����ThumbUrl ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		public string ThumbImage
		{
			set{ _thumbimage=value;}
			get{return _thumbimage;}
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
		/// <summary>
		/// ��
		/// </summary>
		public string Target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public int? Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		#endregion Model

	}
}

