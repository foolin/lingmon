using System;
namespace BLPin.Model
{
	/// <summary>
	/// TwitterModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class TwitterModel
	{
		public TwitterModel()
		{}
		#region Model
		private int _twiid;
		private string _content;
		private string _image;
		private string _media;
		private int? _userid;
		private int? _islock;
		/// <summary>
		/// ���ֻ���ͼƬ��ַ
		/// </summary>
		public int TwiID
		{
			set{ _twiid=value;}
			get{return _twiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Image
		{
			set{ _image=value;}
			get{return _image;}
		}
		/// <summary>
		/// ��Ƶ��ַ
		/// </summary>
		public string Media
		{
			set{ _media=value;}
			get{return _media;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �Ƿ�������0=��1=��
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

