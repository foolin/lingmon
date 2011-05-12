using System;
namespace BLPin.Model
{
	/// <summary>
	/// UserModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class UserModel
	{
		public UserModel()
		{}
		#region Model
		private int _userid;
		private string _email;
		private string _password;
		private string _nickname;
		private int? _sex;
		private DateTime? _birth;
		private string _motto;
		private string _face;
		private string _activatecode;
		private DateTime? _regtime;
		private string _regip;
		private DateTime? _lastlogintime;
		private string _lastloginip;
		private int? _logincount;
		private int? _level;
		private decimal? _credit;
		private int? _status;
		private DateTime? _findpwdtime;
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �ʼ�
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// �û����������ġ�Ӣ����֡��»��ߣ��ɸ���
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// �Ա�:0=���ܣ�1=�У�2=Ů
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birth
		{
			set{ _birth=value;}
			get{return _birth;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string Motto
		{
			set{ _motto=value;}
			get{return _motto;}
		}
		/// <summary>
		/// ͷ��
		/// </summary>
		public string Face
		{
			set{ _face=value;}
			get{return _face;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string ActivateCode
		{
			set{ _activatecode=value;}
			get{return _activatecode;}
		}
		/// <summary>
		/// ע��ʱ��
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// ע��IP
		/// </summary>
		public string RegIP
		{
			set{ _regip=value;}
			get{return _regip;}
		}
		/// <summary>
		/// ����¼ʱ��
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// ����¼IP
		/// </summary>
		public string LastLoginIP
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// ��¼����
		/// </summary>
		public int? LoginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// �û��ȼ�
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// �û�����
		/// </summary>
		public decimal? Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// ״̬��-1=���ᣬ0=δ���1=����
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �һ�����ʱ��
		/// </summary>
		public DateTime? FindPwdTime
		{
			set{ _findpwdtime=value;}
			get{return _findpwdtime;}
		}
		#endregion Model

	}
}

