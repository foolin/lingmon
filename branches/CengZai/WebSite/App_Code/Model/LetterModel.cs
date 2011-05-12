using System;
namespace BLPin.Model
{
	/// <summary>
	/// LetterModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class LetterModel
	{
		public LetterModel()
		{}
		#region Model
		private int _loveid;
		private int? _touserid;
		private int? _fromuserid;
		private string _title;
		private string _content;
		private string _postip;
		private DateTime? _posttime;
		private int? _isread;
		private DateTime? _readtime;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int LoveID
		{
			set{ _loveid=value;}
			get{return _loveid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// ������Ϣ
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
		/// ���͵�IP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// ���͵�ʱ��
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// �Ƿ���ܣ�0=�ȴ���ף�1=���ܣ�2=�ܾ�
		/// </summary>
		public int? IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		/// <summary>
		/// �ش�ʱ��
		/// </summary>
		public DateTime? ReadTime
		{
			set{ _readtime=value;}
			get{return _readtime;}
		}
		/// <summary>
		/// ��˽����:0=ֻ˫���ɼ����ݣ�1=�����˿ɼ����ݣ�Ĭ��0
		/// </summary>
		public int? IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		#endregion Model

	}
}

