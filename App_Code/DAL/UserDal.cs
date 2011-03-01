using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KuaiLe.Us.DAL
{
	/// <summary>
	/// 数据访问类:UserDal
	/// </summary>
	public class UserDal
	{
        KuaiLe.Us.Common.DbBase db = new KuaiLe.Us.Common.DbBase();

		public UserDal()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_User");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)};
			parameters[0].Value = UserID;

			return db.RunSqlReturnInt(strSql.ToString(),parameters) > 0 ;
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_User");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar, 50)};
            parameters[0].Value = UserName;

            return db.RunSqlReturnInt(strSql.ToString(), parameters) > 0;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ChkEmail(string Email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_User");
            strSql.Append(" where Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar, 50)};
            parameters[0].Value = Email;

            return db.RunSqlReturnInt(strSql.ToString(), parameters) > 0;
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KuaiLe.Us.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_User(");
            strSql.Append("UserName,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime)");
			strSql.Append(" values (");
            strSql.Append("@UserName,@Nickname,@Password,@Email,@Sex,@ActivateCode,@RegTime,@RegIP,@LastLoginTime,@LastLoginIP,@LoginCount,@Level,@Credit,@Status,@FindPwdTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@ActivateCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@FindPwdTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Nickname;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.Sex;
			parameters[5].Value = model.ActivateCode;
			parameters[6].Value = model.RegTime;
			parameters[7].Value = model.RegIP;
			parameters[8].Value = model.LastLoginTime;
			parameters[9].Value = model.LastLoginIP;
			parameters[10].Value = model.LoginCount;
			parameters[11].Value = model.Level;
			parameters[12].Value = model.Credit;
			parameters[13].Value = model.Status;
            parameters[14].Value = model.FindPwdTime;

			return db.RunSqlReturnInt(strSql.ToString(),parameters);
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_User set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Nickname=@Nickname,");
			strSql.Append("Password=@Password,");
			strSql.Append("Email=@Email,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("ActivateCode=@ActivateCode,");
			strSql.Append("RegTime=@RegTime,");
			strSql.Append("RegIP=@RegIP,");
			strSql.Append("LastLoginTime=@LastLoginTime,");
			strSql.Append("LastLoginIP=@LastLoginIP,");
			strSql.Append("LoginCount=@LoginCount,");
			strSql.Append("Level=@Level,");
			strSql.Append("Credit=@Credit,");
			strSql.Append("Status=@Status,");
            strSql.Append("FindPwdTime=@FindPwdTime");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Nickname", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@ActivateCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@FindPwdTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Nickname;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.ActivateCode;
			parameters[7].Value = model.RegTime;
			parameters[8].Value = model.RegIP;
			parameters[9].Value = model.LastLoginTime;
			parameters[10].Value = model.LastLoginIP;
			parameters[11].Value = model.LoginCount;
			parameters[12].Value = model.Level;
			parameters[13].Value = model.Credit;
			parameters[14].Value = model.Status;
            parameters[15].Value = model.FindPwdTime;

			db.RunSql(strSql.ToString(),parameters);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_User ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
};
			parameters[0].Value = UserID;

			db.RunSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_User ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
			db.RunSql(strSql.ToString());
		}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KuaiLe.Us.Model.UserModel GetModel(string strNameOrEmail, bool isEmail)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime from T_User ");
            SqlParameter[] parameters = null;
            if (isEmail)
            {
                strSql.Append(" where Email=@Email");
                parameters = new SqlParameter[] {
					new SqlParameter("@Email", SqlDbType.NVarChar, 50)
};   
            }
            else
            {
                strSql.Append(" where UserName=@UserName");
                parameters = new SqlParameter[] {
					new SqlParameter("@UserName", SqlDbType.NVarChar, 50)
};
            }
            parameters[0].Value = strNameOrEmail;

            KuaiLe.Us.Model.UserModel model = new KuaiLe.Us.Model.UserModel();
            DataSet ds = db.GetDs(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Nickname = ds.Tables[0].Rows[0]["Nickname"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                model.ActivateCode = ds.Tables[0].Rows[0]["ActivateCode"].ToString();
                if (ds.Tables[0].Rows[0]["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
                }
                model.RegIP = ds.Tables[0].Rows[0]["RegIP"].ToString();
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                model.LastLoginIP = ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Credit"].ToString() != "")
                {
                    model.Credit = decimal.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FindPwdTime"].ToString() != "")
                {
                    model.FindPwdTime = DateTime.Parse(ds.Tables[0].Rows[0]["FindPwdTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.UserModel GetModel(long UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime from T_User ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
};
			parameters[0].Value = UserID;

			KuaiLe.Us.Model.UserModel model=new KuaiLe.Us.Model.UserModel();
			DataSet ds= db.GetDs(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Nickname=ds.Tables[0].Rows[0]["Nickname"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
				}
				model.ActivateCode=ds.Tables[0].Rows[0]["ActivateCode"].ToString();
				if(ds.Tables[0].Rows[0]["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(ds.Tables[0].Rows[0]["RegTime"].ToString());
				}
				model.RegIP=ds.Tables[0].Rows[0]["RegIP"].ToString();
				if(ds.Tables[0].Rows[0]["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
				}
				model.LastLoginIP=ds.Tables[0].Rows[0]["LastLoginIP"].ToString();
				if(ds.Tables[0].Rows[0]["LoginCount"].ToString()!="")
				{
					model.LoginCount=int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Credit"].ToString()!="")
				{
					model.Credit=decimal.Parse(ds.Tables[0].Rows[0]["Credit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
                if (ds.Tables[0].Rows[0]["FindPwdTime"].ToString() != "")
                {
                    model.FindPwdTime = DateTime.Parse(ds.Tables[0].Rows[0]["FindPwdTime"].ToString());
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select UserID,UserName,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetDs(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" UserID,UserName,Nickname,Password,Email,Sex,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string strOrder, int pageSize, int pageIndex, out int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dbo.T_User ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" Where " + strWhere + " ");
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " UserID ASC ";
            }

            return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out records);
        }

		#endregion  Method
	}
}

