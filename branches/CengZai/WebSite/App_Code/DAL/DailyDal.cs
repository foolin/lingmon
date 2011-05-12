using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:DailyDal
	/// </summary>
	public partial class DailyDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public DailyDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("DailyID", "T_Daily"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DailyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Daily");
			strSql.Append(" where DailyID=@DailyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DailyID", SqlDbType.Int,4)};
			parameters[0].Value = DailyID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.DailyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Daily(");
			strSql.Append("ClassID,Title,Content,UserID,PostIP,PostTime,Views,Comments,Reports,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@ClassID,@Title,@Content,@UserID,@PostIP,@PostTime,@Views,@Comments,@Reports,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Views;
			parameters[7].Value = model.Comments;
			parameters[8].Value = model.Reports;
			parameters[9].Value = model.IsLock;

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
		public bool Update(BLPin.Model.DailyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Daily set ");
			strSql.Append("ClassID=@ClassID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Views=@Views,");
			strSql.Append("Comments=@Comments,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where DailyID=@DailyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@DailyID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Views;
			parameters[7].Value = model.Comments;
			parameters[8].Value = model.Reports;
			parameters[9].Value = model.IsLock;
			parameters[10].Value = model.DailyID;

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
		public bool Delete(int DailyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Daily ");
			strSql.Append(" where DailyID=@DailyID");
			SqlParameter[] parameters = {
					new SqlParameter("@DailyID", SqlDbType.Int,4)
};
			parameters[0].Value = DailyID;

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
		public bool DeleteList(string DailyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Daily ");
			strSql.Append(" where DailyID in ("+DailyIDlist + ")  ");
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
		public BLPin.Model.DailyModel GetModel(int DailyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DailyID,ClassID,Title,Content,UserID,PostIP,PostTime,Views,Comments,Reports,IsLock from T_Daily ");
			strSql.Append(" where DailyID=@DailyID");
			SqlParameter[] parameters = {
					new SqlParameter("@DailyID", SqlDbType.Int,4)
};
			parameters[0].Value = DailyID;

			BLPin.Model.DailyModel model=new BLPin.Model.DailyModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DailyID"].ToString()!="")
				{
					model.DailyID=int.Parse(ds.Tables[0].Rows[0]["DailyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
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
				if(ds.Tables[0].Rows[0]["Views"].ToString()!="")
				{
					model.Views=int.Parse(ds.Tables[0].Rows[0]["Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Comments"].ToString()!="")
				{
					model.Comments=int.Parse(ds.Tables[0].Rows[0]["Comments"].ToString());
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
			strSql.Append("select DailyID,ClassID,Title,Content,UserID,PostIP,PostTime,Views,Comments,Reports,IsLock ");
			strSql.Append(" FROM T_Daily ");
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
			strSql.Append(" DailyID,ClassID,Title,Content,UserID,PostIP,PostTime,Views,Comments,Reports,IsLock ");
			strSql.Append(" FROM T_Daily ");
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
			parameters[0].Value = "T_Daily";
			parameters[1].Value = "DailyID";
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

