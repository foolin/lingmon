using System;
namespace BLPin.Model
{
	/// <summary>
	/// WikiVerModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ά������
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// ��չ�Ķ�
		/// </summary>
		public string Supply
		{
			set{ _supply=value;}
			get{return _supply;}
		}
		/// <summary>
		/// �༭����
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// �༭��
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �༭��IP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// �༭ʱ��
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// ״̬��0=����ˣ�1=��ͨ����-1=��˲�ͨ��
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// ͨ����Ϣ
		/// </summary>
		public string StatusMsg
		{
			set{ _statusmsg=value;}
			get{return _statusmsg;}
		}
		#endregion Model

	}
}

