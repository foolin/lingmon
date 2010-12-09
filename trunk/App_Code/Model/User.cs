using System;
namespace LFL.Favorite.Model
{
	/// <summary>
	/// 实体类User 。(属性说明自动提取数据库字段的描述信息)
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
		/// UserID，自动增长
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户登录名
		/// </summary>
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nickname
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 电子信箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 激活码
		/// </summary>
		public string ActivateCode
		{
			set{ _activatecode=value;}
			get{return _activatecode;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 注册IP
		/// </summary>
		public string RegIP
		{
			set{ _regip=value;}
			get{return _regip;}
		}
		/// <summary>
		/// 最后登录时间
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 最后登录IP
		/// </summary>
		public string LastLoginIP
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// 登录次数
		/// </summary>
		public int? LoginCount
		{
			set{ _logincount=value;}
			get{return _logincount;}
		}
		/// <summary>
		/// 用户等级
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 用户积分
		/// </summary>
		public decimal? Credit
		{
			set{ _credit=value;}
			get{return _credit;}
		}
		/// <summary>
		/// 用户状态：1=正常用户，0-未激活用户， -1=冻结用户
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

