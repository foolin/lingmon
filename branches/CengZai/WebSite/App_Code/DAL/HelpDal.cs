using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:HelpDal
	/// </summary>
	public partial class HelpDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public HelpDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("HelpID", "T_Help"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int HelpID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Help");
			strSql.Append(" where HelpID=@HelpID ");
			SqlParameter[] parameters = {
					new SqlParameter("@HelpID", SqlDbType.Int,4)};
			parameters[0].Value = HelpID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.HelpModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Help(");
			strSql.Append("Title,Content,UserID,PostIP,PostTime,HelperID,Status,Reports,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Content,@UserID,@PostIP,@PostTime,@HelperID,@Status,@Reports,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@HelperID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostIP;
			parameters[4].Value = model.PostTime;
			parameters[5].Value = model.HelperID;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.Reports;
			parameters[8].Value = model.IsLock;

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
		public bool Update(CengZai.Model.HelpModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Help set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("HelperID=@HelperID,");
			strSql.Append("Status=@Status,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where HelpID=@HelpID");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@HelperID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@HelpID", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostIP;
			parameters[4].Value = model.PostTime;
			parameters[5].Value = model.HelperID;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.Reports;
			parameters[8].Value = model.IsLock;
			parameters[9].Value = model.HelpID;

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
		public bool Delete(int HelpID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Help ");
			strSql.Append(" where HelpID=@HelpID");
			SqlParameter[] parameters = {
					new SqlParameter("@HelpID", SqlDbType.Int,4)
};
			parameters[0].Value = HelpID;

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
		public bool DeleteList(string HelpIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Help ");
			strSql.Append(" where HelpID in ("+HelpIDlist + ")  ");
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
		public CengZai.Model.HelpModel GetModel(int HelpID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 HelpID,Title,Content,UserID,PostIP,PostTime,HelperID,Status,Reports,IsLock from T_Help ");
			strSql.Append(" where HelpID=@HelpID");
			SqlParameter[] parameters = {
					new SqlParameter("@HelpID", SqlDbType.Int,4)
};
			parameters[0].Value = HelpID;

			CengZai.Model.HelpModel model=new CengZai.Model.HelpModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["HelpID"].ToString()!="")
				{
					model.HelpID=int.Parse(ds.Tables[0].Rows[0]["HelpID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HelperID"].ToString()!="")
				{
					model.HelperID=int.Parse(ds.Tables[0].Rows[0]["HelperID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reports"].ToString()!="")
				{
					model.Reports=int.Parse(ds.Tables[0].Rows[0]["Reports"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
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
			strSql.Append("select HelpID,Title,Content,UserID,PostIP,PostTime,HelperID,Status,Reports,IsLock ");
			strSql.Append(" FROM T_Help ");
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
			strSql.Append(" HelpID,Title,Content,UserID,PostIP,PostTime,HelperID,Status,Reports,IsLock ");
			strSql.Append(" FROM T_Help ");
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
			parameters[0].Value = "T_Help";
			parameters[1].Value = "HelpID";
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

