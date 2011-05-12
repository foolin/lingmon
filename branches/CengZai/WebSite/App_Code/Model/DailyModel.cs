using System;
namespace BLPin.Model
{
	/// <summary>
	/// DailyModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DailyModel
	{
		public DailyModel()
		{}
		#region Model
		private int _dailyid;
		private int? _classid;
		private string _title;
		private string _content;
		private int? _userid;
		private string _postip;
		private DateTime? _posttime;
		private int? _views;
		private int? _comments;
		private int? _reports;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int DailyID
		{
			set{ _dailyid=value;}
			get{return _dailyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 标题，可选
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 内容，必填
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// 
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Views
		{
			set{ _views=value;}
			get{return _views;}
		}
		/// <summary>
		/// 评论数
		/// </summary>
		public int? Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 举报次数
		/// </summary>
		public int? Reports
		{
			set{ _reports=value;}
			get{return _reports;}
		}
		/// <summary>
		/// 0=正常，1=锁定
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

