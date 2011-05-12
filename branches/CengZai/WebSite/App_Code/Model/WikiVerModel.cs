using System;
namespace BLPin.Model
{
	/// <summary>
	/// WikiVerModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WikiVerModel
	{
		public WikiVerModel()
		{}
		#region Model
		private int _verid;
		private string _content;
		private string _supply;
		private string _reason;
		private int? _userid;
		private string _postip;
		private DateTime? _posttime;
		private int? _status;
		private string _statusmsg;
		/// <summary>
		/// 
		/// </summary>
		public int VerID
		{
			set{ _verid=value;}
			get{return _verid;}
		}
		/// <summary>
		/// 维基正文
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 扩展阅读
		/// </summary>
		public string Supply
		{
			set{ _supply=value;}
			get{return _supply;}
		}
		/// <summary>
		/// 编辑理由
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 编辑者
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 编辑者IP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// 编辑时间
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// 状态：0=带审核，1=已通过，-1=审核不通过
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 通过信息
		/// </summary>
		public string StatusMsg
		{
			set{ _statusmsg=value;}
			get{return _statusmsg;}
		}
		#endregion Model

	}
}

