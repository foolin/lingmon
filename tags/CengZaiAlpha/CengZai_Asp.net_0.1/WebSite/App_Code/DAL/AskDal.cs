using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:AskDal
	/// </summary>
	public partial class AskDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public AskDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("AskID", "T_Ask"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AskID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Ask");
			strSql.Append(" where AskID=@AskID ");
			SqlParameter[] parameters = {
					new SqlParameter("@AskID", SqlDbType.Int,4)};
			parameters[0].Value = AskID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.AskModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Ask(");
			strSql.Append("Title,Content,RewardCredit,UserID,PostTime,IsAnonym,ReplyID,Status,Views,Replys,Reports,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Content,@RewardCredit,@UserID,@PostTime,@IsAnonym,@ReplyID,@Status,@Views,@Replys,@Reports,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@RewardCredit", SqlDbType.Float,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@IsAnonym", SqlDbType.Int,4),
					new SqlParameter("@ReplyID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Replys", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.RewardCredit;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostTime;
			parameters[5].Value = model.IsAnonym;
			parameters[6].Value = model.ReplyID;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.Views;
			parameters[9].Value = model.Replys;
			parameters[10].Value = model.Reports;
			parameters[11].Value = model.IsLock;

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
		public bool Update(CengZai.Model.AskModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Ask set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("RewardCredit=@RewardCredit,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("IsAnonym=@IsAnonym,");
			strSql.Append("ReplyID=@ReplyID,");
			strSql.Append("Status=@Status,");
			strSql.Append("Views=@Views,");
			strSql.Append("Replys=@Replys,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where AskID=@AskID");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@RewardCredit", SqlDbType.Float,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@IsAnonym", SqlDbType.Int,4),
					new SqlParameter("@ReplyID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Replys", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AskID", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Content;
			parameters[2].Value = model.RewardCredit;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.PostTime;
			parameters[5].Value = model.IsAnonym;
			parameters[6].Value = model.ReplyID;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.Views;
			parameters[9].Value = model.Replys;
			parameters[10].Value = model.Reports;
			parameters[11].Value = model.IsLock;
			parameters[12].Value = model.AskID;

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
		public bool Delete(int AskID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Ask ");
			strSql.Append(" where AskID=@AskID");
			SqlParameter[] parameters = {
					new SqlParameter("@AskID", SqlDbType.Int,4)
};
			parameters[0].Value = AskID;

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
		public bool DeleteList(string AskIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Ask ");
			strSql.Append(" where AskID in ("+AskIDlist + ")  ");
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
		public CengZai.Model.AskModel GetModel(int AskID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AskID,Title,Content,RewardCredit,UserID,PostTime,IsAnonym,ReplyID,Status,Views,Replys,Reports,IsLock from T_Ask ");
			strSql.Append(" where AskID=@AskID");
			SqlParameter[] parameters = {
					new SqlParameter("@AskID", SqlDbType.Int,4)
};
			parameters[0].Value = AskID;

			CengZai.Model.AskModel model=new CengZai.Model.AskModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AskID"].ToString()!="")
				{
					model.AskID=int.Parse(ds.Tables[0].Rows[0]["AskID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				if(ds.Tables[0].Rows[0]["RewardCredit"].ToString()!="")
				{
					model.RewardCredit=decimal.Parse(ds.Tables[0].Rows[0]["RewardCredit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsAnonym"].ToString()!="")
				{
					model.IsAnonym=int.Parse(ds.Tables[0].Rows[0]["IsAnonym"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplyID"].ToString()!="")
				{
					model.ReplyID=int.Parse(ds.Tables[0].Rows[0]["ReplyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Views"].ToString()!="")
				{
					model.Views=int.Parse(ds.Tables[0].Rows[0]["Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Replys"].ToString()!="")
				{
					model.Replys=int.Parse(ds.Tables[0].Rows[0]["Replys"].ToString());
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
			strSql.Append("select AskID,Title,Content,RewardCredit,UserID,PostTime,IsAnonym,ReplyID,Status,Views,Replys,Reports,IsLock ");
			strSql.Append(" FROM T_Ask ");
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
			strSql.Append(" AskID,Title,Content,RewardCredit,UserID,PostTime,IsAnonym,ReplyID,Status,Views,Replys,Reports,IsLock ");
			strSql.Append(" FROM T_Ask ");
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
			parameters[0].Value = "T_Ask";
			parameters[1].Value = "AskID";
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

