using System;
namespace BLPin.Model
{
	/// <summary>
	/// TwitterModel:实体类(属性说明自动提取数据库字段的描述信息)
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
		/// 音乐或者图片地址
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
		/// 音频地址
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
		/// 是否锁定：0=否，1=是
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

