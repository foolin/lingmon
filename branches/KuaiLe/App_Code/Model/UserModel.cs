using System;
namespace KuaiLe.Us.Model
{
	/// <summary>
	/// UserModel:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// �û���
		/// </summary>
		public string UserName
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
		/// �ʼ�
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
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
		/// ״̬��-2=���(�����¡�����Ҳ��),-1=�����û���0=δ���1=������2=��Ա
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
            set { _findpwdtime = value; }
            get { return _findpwdtime; }
        }

		#endregion Model



        /// <summary>
        /// ȡ�Ա�
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
                strSex = "��";
            }
            else if (iSex == 2)
            {
                strSex = "Ů";
            }
            else if (iSex == 0)
            {
                strSex = "����";
            }
            else
            {
                strSex = sex + "";
            }

            return strSex;

        }

        /// <summary>
        /// ȡ״̬
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
                strStatus = "���";
            }
            else if (iStatus == -1)
            {
                strStatus = "����";
            }
            else if (iStatus == 0)
            {
                strStatus = "δ����";
            }
            else if (iStatus == 1)
            {
                strStatus = "�Ѽ���";
            }
            else if (iStatus == 2)
            {
                strStatus = "VIP��Ա";
            }
            else
            {
                strStatus = status + "";
            }

            return strStatus;

        }

	}
}

