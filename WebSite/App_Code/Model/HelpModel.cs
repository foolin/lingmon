using System;
namespace BLPin.Model
{
	/// <summary>
	/// HelpModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class HelpModel
	{
		public HelpModel()
		{}
		#region Model
		private int _helpid;
		private string _title;
		private string _content;
		private int? _userid;
		private string _postip;
		private DateTime? _posttime;
		private int? _helperid;
		private int? _status;
		private int? _reports;
		private int? _islock;
		/// <summary>
		/// 
		/// </summary>
		public int HelpID
		{
			set{ _helpid=value;}
			get{return _helpid;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �ύIP
		/// </summary>
		public string PostIP
		{
			set{ _postip=value;}
			get{return _postip;}
		}
		/// <summary>
		/// �ύʱ��
		/// </summary>
		public DateTime? PostTime
		{
			set{ _posttime=value;}
			get{return _posttime;}
		}
		/// <summary>
		/// ������ID�������ȡ�������߿���ѡ����ջ��ߴ���Ͷ��
		/// </summary>
		public int? HelperID
		{
			set{ _helperid=value;}
			get{return _helperid;}
		}
		/// <summary>
		/// 0=�����ܣ�1=�ѽ��գ�-1=�Ѿ�����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �ٱ�����
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

