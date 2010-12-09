using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// ʵ����User ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class User
	{
		public User()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _nickname;
		private string _password;
		private string _email;
		private string _sex;
		private string _activatecode;
		private DateTime? _regtime;
		private string _regip;
		private DateTime? _lastlogintime;
		private string _lastloginip;
		private int? _logincount;
		private int? _level;
		private decimal? _credit;
		private int? _status;
		/// <summary>
		/// UserID���Զ�����
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// �û���¼��
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// �ǳ�
		/// </summary>
		public string Nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
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
		/// ��������
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
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
		/// �û�״̬��1=�����û���0-δ�����û��� -1=�����û�
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

