using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// ArticleModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ArticleModel
	{
		public ArticleModel()
		{}
		#region Model
		private long _artid;
		private long _userid;
        private string _userip;
		private string _title;
		private string _content;
		private string _tags;
		private int? _isanonym;
		private DateTime? _createtime;
		private int? _hits;
		private int? _digup;
		private int? _digdown;
		private int? _comments;
		private int? _Reports;
		private int? _status;
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
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
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
		/// 标签，最大300个字符，多个逗号分割
		/// </summary>
		public string Tags
		{
			set{ _tags=value;}
			get{return _tags;}
		}
		/// <summary>
		/// 是否匿名：0=否，1=匿名
		/// </summary>
		public int? IsAnonym
		{
			set{ _isanonym=value;}
			get{return _isanonym;}
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
		public int? Hits
		{
			set{ _hits=value;}
			get{return _hits;}
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
		/// 
		/// </summary>
		public int? Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Reports
		{
			set{ _Reports=value;}
			get{return _Reports;}
		}
		/// <summary>
		/// -1=冻结，0=未审核，1=审核
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
		#endregion Model

	}
}

