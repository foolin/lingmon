using System;
namespace BLPin.Model
{
	/// <summary>
	/// HelpModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HelpModel
	{
		public HelpModel()
		{}
		#region Model
		private int _helpid;
		private string _title;
		private string _content;
		private int? _userid;
		private string _postip;
		private DateTime? _posttime;
		private int? _helperid;
		private int? _status;
		private int? _reports;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int HelpID
		{
			set{ _helpid=value;}
			get{return _helpid;}
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
		/// 求助内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 求助者
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 提交IP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 提交时间
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 帮助者ID，随机抽取，帮助者可以选择接收或者从新投递
		/// </summary>
		public int? HelperID
		{
			set{ _helperid=value;}
			get{return _helperid;}
		}
		/// <summary>
		/// 0=待接受，1=已接收，-1=已经结束
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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
		/// 是否锁定，0=正常，1=锁定
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

