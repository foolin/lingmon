using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// UserModel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class UserModel
	{
		public UserModel()
		{}
		#region Model
		private long _userid;
		private string _username;
		private string _nickname;
		private string _password;
		private string _email;
		private int? _sex;
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
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
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
		/// 邮件
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 性别:0=保密，1=男，2=女
		/// </summary>
		public int? Sex
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
		/// 状态：-2=封号(旧文章、评论也禁),-1=冻结用户，0=未激活，1=正常，2=会员
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
        
        /// <summary>
        /// 找回密码时间
        /// </summary>
        public DateTime? FindPwdTime
        {
            set { _findpwdtime = value; }
            get { return _findpwdtime; }
        }

		#endregion Model



        /// <summary>
        /// 取性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string GetSexName(object sex)
        {
            if (sex == null)
            {
                return "";
            }

            int iSex = -1;
            try
            {
                iSex = Convert.ToInt32(sex);
            }
            catch
            {

            }

            string strSex = "";
            if (iSex == 1)
            {
                strSex = "男";
            }
            else if (iSex == 2)
            {
                strSex = "女";
            }
            else if (iSex == 0)
            {
                strSex = "保密";
            }
            else
            {
                strSex = sex + "";
            }

            return strSex;

        }

        /// <summary>
        /// 取状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetStatusName(object status)
        {
            if (status == null)
            {
                return "";
            }

            int iStatus = -999;
            try
            {
                iStatus = Convert.ToInt32(status);
            }
            catch { }

            string strStatus = "";
            if (iStatus == -2)
            {
                strStatus = "封号";
            }
            else if (iStatus == -1)
            {
                strStatus = "冻结";
            }
            else if (iStatus == 0)
            {
                strStatus = "未激活";
            }
            else if (iStatus == 1)
            {
                strStatus = "已激活";
            }
            else if (iStatus == 2)
            {
                strStatus = "VIP会员";
            }
            else
            {
                strStatus = status + "";
            }

            return strStatus;

        }

	}
}

