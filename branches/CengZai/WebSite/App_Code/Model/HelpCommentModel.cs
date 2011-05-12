using System;
namespace BLPin.Model
{
	/// <summary>
	/// HelpCommentModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class HelpCommentModel
	{
		public HelpCommentModel()
		{}
		#region Model
		private int _id;
		private int _helpid;
		private string _content;
		private int _userid;
		private string _postip;
		private DateTime _posttime;
		private int? _reports;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int HelpID
		{
			set{ _helpid=value;}
			get{return _helpid;}
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
		public int UserID
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
		public DateTime PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
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
		/// �Ƿ�������0=������1=����
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

