using System;
namespace CengZai.Model
{
	/// <summary>
	/// AskModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AskModel
	{
		public AskModel()
		{}
		#region Model
		private int _askid;
		private string _title;
		private string _content;
		private decimal? _rewardcredit;
		private int? _userid;
		private DateTime? _posttime;
		private int? _isanonym;
		private int? _replyid;
		private int? _status;
		private int? _views;
		private int? _replys;
		private int? _reports;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int AskID
		{
			set{ _askid=value;}
			get{return _askid;}
		}
		/// <summary>
		/// 
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
		/// 
		/// </summary>
		public decimal? RewardCredit
		{
			set{ _rewardcredit=value;}
			get{return _rewardcredit;}
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
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 是否匿名
		/// </summary>
		public int? IsAnonym
		{
			set{ _isanonym=value;}
			get{return _isanonym;}
		}
		/// <summary>
		/// 最优答案的ID
		/// </summary>
		public int? ReplyID
		{
			set{ _replyid=value;}
			get{return _replyid;}
		}
		/// <summary>
		/// 0=等待回答、1=无满意答案，2=已有满意答案
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
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
		/// 
		/// </summary>
		public int? Replys
		{
			set{ _replys=value;}
			get{return _replys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Reports
		{
			set{ _reports=value;}
			get{return _reports;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

