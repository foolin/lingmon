using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// CommentModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class CommentModel
	{
		public CommentModel()
		{}
		#region Model
		private long _commentid;
		private long _artid;
		private string _comment;
		private long _userid;
		private DateTime? _createtime;
		private int? _digup;
		private int? _digdown;
		private int? _Reports;
		private int? _status;
        private string _username;
        private string _userip;
		/// <summary>
		/// 
		/// </summary>
		public long CommentID
		{
			set{ _commentid=value;}
			get{return _commentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long ArtID
		{
			set{ _artid=value;}
			get{return _artid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DigUp
		{
			set{ _digup=value;}
			get{return _digup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DigDown
		{
			set{ _digdown=value;}
			get{return _digdown;}
		}
		/// <summary>
		/// 举报
		/// </summary>
		public int? Reports
		{
			set{ _Reports=value;}
			get{return _Reports;}
		}
		/// <summary>
		/// -1冻结，0=正常
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}

        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
		#endregion Model

	}
}

