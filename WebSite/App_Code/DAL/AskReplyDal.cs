using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:AskReplyDal
	/// </summary>
	public partial class AskReplyDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public AskReplyDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("ReplyID", "T_AskReply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReplyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_AskReply");
			strSql.Append(" where ReplyID=@ReplyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplyID", SqlDbType.Int,4)};
			parameters[0].Value = ReplyID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.AskReplyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_AskReply(");
			strSql.Append("AskID,Content,UserID,PostTime,PostIP,Reports,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@AskID,@Content,@UserID,@PostTime,@PostIP,@Reports,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AskID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.AskID;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostTime;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.Reports;
			parameters[6].Value = model.IsLock;

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
		public bool Update(CengZai.Model.AskReplyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_AskReply set ");
			strSql.Append("AskID=@AskID,");
			strSql.Append("Content=@Content,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where ReplyID=@ReplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@AskID", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@ReplyID", SqlDbType.Int,4)};
			parameters[0].Value = model.AskID;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostTime;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.Reports;
			parameters[6].Value = model.IsLock;
			parameters[7].Value = model.ReplyID;

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
		public bool Delete(int ReplyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AskReply ");
			strSql.Append(" where ReplyID=@ReplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplyID", SqlDbType.Int,4)
};
			parameters[0].Value = ReplyID;

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
		public bool DeleteList(string ReplyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_AskReply ");
			strSql.Append(" where ReplyID in ("+ReplyIDlist + ")  ");
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
		public CengZai.Model.AskReplyModel GetModel(int ReplyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReplyID,AskID,Content,UserID,PostTime,PostIP,Reports,IsLock from T_AskReply ");
			strSql.Append(" where ReplyID=@ReplyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReplyID", SqlDbType.Int,4)
};
			parameters[0].Value = ReplyID;

			CengZai.Model.AskReplyModel model=new CengZai.Model.AskReplyModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ReplyID"].ToString()!="")
				{
					model.ReplyID=int.Parse(ds.Tables[0].Rows[0]["ReplyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AskID"].ToString()!="")
				{
					model.AskID=int.Parse(ds.Tables[0].Rows[0]["AskID"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
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
			strSql.Append("select ReplyID,AskID,Content,UserID,PostTime,PostIP,Reports,IsLock ");
			strSql.Append(" FROM T_AskReply ");
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
			strSql.Append(" ReplyID,AskID,Content,UserID,PostTime,PostIP,Reports,IsLock ");
			strSql.Append(" FROM T_AskReply ");
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
			parameters[0].Value = "T_AskReply";
			parameters[1].Value = "ReplyID";
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

