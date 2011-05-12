using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:UserDal
	/// </summary>
	public partial class UserDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public UserDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("UserID", "T_User"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_User");
			strSql.Append(" where UserID=@UserID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = UserID;

			return db.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_User ");
            strSql.Append(" where Email=@Email ");
            SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,50)};
            parameters[0].Value = email;

            return db.Exists(strSql.ToString(), parameters);
        }



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_User(");
			strSql.Append("Email,Password,NickName,Sex,Birth,Motto,Face,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime)");
			strSql.Append(" values (");
			strSql.Append("@Email,@Password,@NickName,@Sex,@Birth,@Motto,@Face,@ActivateCode,@RegTime,@RegIP,@LastLoginTime,@LastLoginIP,@LoginCount,@Level,@Credit,@Status,@FindPwdTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Motto", SqlDbType.NVarChar,50),
					new SqlParameter("@Face", SqlDbType.NVarChar,200),
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
			parameters[0].Value = model.Email;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.NickName;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Birth;
			parameters[5].Value = model.Motto;
			parameters[6].Value = model.Face;
			parameters[7].Value = model.ActivateCode;
			parameters[8].Value = model.RegTime;
			parameters[9].Value = model.RegIP;
			parameters[10].Value = model.LastLoginTime;
			parameters[11].Value = model.LastLoginIP;
			parameters[12].Value = model.LoginCount;
			parameters[13].Value = model.Level;
			parameters[14].Value = model.Credit;
			parameters[15].Value = model.Status;
			parameters[16].Value = model.FindPwdTime;

			object obj = db.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CengZai.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_User set ");
			strSql.Append("Email=@Email,");
			strSql.Append("Password=@Password,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Birth=@Birth,");
			strSql.Append("Motto=@Motto,");
			strSql.Append("Face=@Face,");
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
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Birth", SqlDbType.DateTime),
					new SqlParameter("@Motto", SqlDbType.NVarChar,50),
					new SqlParameter("@Face", SqlDbType.NVarChar,200),
					new SqlParameter("@ActivateCode", SqlDbType.NVarChar,50),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@RegIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIP", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginCount", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Credit", SqlDbType.Float,8),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@FindPwdTime", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.Email;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.NickName;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Birth;
			parameters[5].Value = model.Motto;
			parameters[6].Value = model.Face;
			parameters[7].Value = model.ActivateCode;
			parameters[8].Value = model.RegTime;
			parameters[9].Value = model.RegIP;
			parameters[10].Value = model.LastLoginTime;
			parameters[11].Value = model.LastLoginIP;
			parameters[12].Value = model.LoginCount;
			parameters[13].Value = model.Level;
			parameters[14].Value = model.Credit;
			parameters[15].Value = model.Status;
			parameters[16].Value = model.FindPwdTime;
			parameters[17].Value = model.UserID;

			int rows=db.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_User ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
			parameters[0].Value = UserID;

			int rows=db.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_User ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
			int rows=db.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CengZai.Model.UserModel GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,Email,Password,NickName,Sex,Birth,Motto,Face,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime from T_User ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
};
			parameters[0].Value = UserID;

			CengZai.Model.UserModel model=new CengZai.Model.UserModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.NickName=ds.Tables[0].Rows[0]["NickName"].ToString();
				if(ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Birth"].ToString()!="")
				{
					model.Birth=DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
				}
				model.Motto=ds.Tables[0].Rows[0]["Motto"].ToString();
				model.Face=ds.Tables[0].Rows[0]["Face"].ToString();
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
				if(ds.Tables[0].Rows[0]["FindPwdTime"].ToString()!="")
				{
					model.FindPwdTime=DateTime.Parse(ds.Tables[0].Rows[0]["FindPwdTime"].ToString());
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
			strSql.Append("select UserID,Email,Password,NickName,Sex,Birth,Motto,Face,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.Query(strSql.ToString());
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
			strSql.Append(" UserID,Email,Password,NickName,Sex,Birth,Motto,Face,ActivateCode,RegTime,RegIP,LastLoginTime,LastLoginIP,LoginCount,Level,Credit,Status,FindPwdTime ");
			strSql.Append(" FROM T_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_User";
			parameters[1].Value = "UserID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return db.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

