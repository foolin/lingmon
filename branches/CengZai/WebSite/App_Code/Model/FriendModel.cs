using System;
namespace BLPin.Model
{
	/// <summary>
	/// FriendModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FriendModel
	{
		public FriendModel()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int? _friendid;
		private string _remarkname;
		private string _joinmsg;
		private DateTime? _posttime;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 0=申请状态，1=好友状态，-1=黑名单
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 朋友ID
		/// </summary>
		public int? FriendID
		{
			set{ _friendid=value;}
			get{return _friendid;}
		}
		/// <summary>
		/// 备注好友名称
		/// </summary>
		public string RemarkName
		{
			set{ _remarkname=value;}
			get{return _remarkname;}
		}
		/// <summary>
		/// 朋友请求信息
		/// </summary>
		public string JoinMsg
		{
			set{ _joinmsg=value;}
			get{return _joinmsg;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

