using System;
namespace BLPin.Model
{
	/// <summary>
	/// FriendModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// 0=����״̬��1=����״̬��-1=������
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int? FriendID
		{
			set{ _friendid=value;}
			get{return _friendid;}
		}
		/// <summary>
		/// ��ע��������
		/// </summary>
		public string RemarkName
		{
			set{ _remarkname=value;}
			get{return _remarkname;}
		}
		/// <summary>
		/// ����������Ϣ
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

