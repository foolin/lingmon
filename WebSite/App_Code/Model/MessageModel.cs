using System;
namespace BLPin.Model
{
	/// <summary>
	/// MessageModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class MessageModel
	{
		public MessageModel()
		{}
		#region Model
		private int _msgid;
		private int? _touserid;
		private string _title;
		private string _content;
		private int? _fromuserid;
		private DateTime? _sendtime;
		private int? _isread;
		private DateTime? _readtime;
		/// <summary>
		/// 
		/// </summary>
		public int MsgID
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// �����ߣ�0=��ʾϵͳ��Ϣ
		/// </summary>
		public int? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 0=δ����1=�Ѷ�
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		#endregion Model

	}
}

