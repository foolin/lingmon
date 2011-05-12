using System;
namespace BLPin.Model
{
	/// <summary>
	/// LetterModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LetterModel
	{
		public LetterModel()
		{}
		#region Model
		private int _loveid;
		private int? _touserid;
		private int? _fromuserid;
		private string _title;
		private string _content;
		private string _postip;
		private DateTime? _posttime;
		private int? _isread;
		private DateTime? _readtime;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int LoveID
		{
			set{ _loveid=value;}
			get{return _loveid;}
		}
		/// <summary>
		/// 接收者
		/// </summary>
		public int? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// 发送信息
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
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
		/// 发送的IP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 发送的时间
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 是否接受：0=等待表白，1=接受，2=拒绝
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 回答时间
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// 隐私设置:0=只双方可见内容，1=所有人可见内容，默认0
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

