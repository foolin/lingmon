using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:WikiDal
	/// </summary>
	public partial class WikiDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public WikiDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("WikiID", "T_Wiki"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WikiID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Wiki");
			strSql.Append(" where WikiID=@WikiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WikiID", SqlDbType.Int,4)};
			parameters[0].Value = WikiID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.WikiModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Wiki(");
			strSql.Append("Word,VerID,Views,Edits,CreateUserID,CreateTime,UpdateUserID,UpdateTime,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@Word,@VerID,@Views,@Edits,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Word", SqlDbType.NVarChar,50),
					new SqlParameter("@VerID", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Edits", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Word;
			parameters[1].Value = model.VerID;
			parameters[2].Value = model.Views;
			parameters[3].Value = model.Edits;
			parameters[4].Value = model.CreateUserID;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateUserID;
			parameters[7].Value = model.UpdateTime;
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
		public bool Update(CengZai.Model.WikiModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Wiki set ");
			strSql.Append("Word=@Word,");
			strSql.Append("VerID=@VerID,");
			strSql.Append("Views=@Views,");
			strSql.Append("Edits=@Edits,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where WikiID=@WikiID");
			SqlParameter[] parameters = {
					new SqlParameter("@Word", SqlDbType.NVarChar,50),
					new SqlParameter("@VerID", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Edits", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@WikiID", SqlDbType.Int,4)};
			parameters[0].Value = model.Word;
			parameters[1].Value = model.VerID;
			parameters[2].Value = model.Views;
			parameters[3].Value = model.Edits;
			parameters[4].Value = model.CreateUserID;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateUserID;
			parameters[7].Value = model.UpdateTime;
			parameters[8].Value = model.IsLock;
			parameters[9].Value = model.WikiID;

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
		public bool Delete(int WikiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Wiki ");
			strSql.Append(" where WikiID=@WikiID");
			SqlParameter[] parameters = {
					new SqlParameter("@WikiID", SqlDbType.Int,4)
};
			parameters[0].Value = WikiID;

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
		public bool DeleteList(string WikiIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Wiki ");
			strSql.Append(" where WikiID in ("+WikiIDlist + ")  ");
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
		public CengZai.Model.WikiModel GetModel(int WikiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WikiID,Word,VerID,Views,Edits,CreateUserID,CreateTime,UpdateUserID,UpdateTime,IsLock from T_Wiki ");
			strSql.Append(" where WikiID=@WikiID");
			SqlParameter[] parameters = {
					new SqlParameter("@WikiID", SqlDbType.Int,4)
};
			parameters[0].Value = WikiID;

			CengZai.Model.WikiModel model=new CengZai.Model.WikiModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["WikiID"].ToString()!="")
				{
					model.WikiID=int.Parse(ds.Tables[0].Rows[0]["WikiID"].ToString());
				}
				model.Word=ds.Tables[0].Rows[0]["Word"].ToString();
				if(ds.Tables[0].Rows[0]["VerID"].ToString()!="")
				{
					model.VerID=int.Parse(ds.Tables[0].Rows[0]["VerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Views"].ToString()!="")
				{
					model.Views=int.Parse(ds.Tables[0].Rows[0]["Views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Edits"].ToString()!="")
				{
					model.Edits=int.Parse(ds.Tables[0].Rows[0]["Edits"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateUserID"].ToString()!="")
				{
					model.CreateUserID=int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUserID"].ToString()!="")
				{
					model.UpdateUserID=int.Parse(ds.Tables[0].Rows[0]["UpdateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
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
			strSql.Append("select WikiID,Word,VerID,Views,Edits,CreateUserID,CreateTime,UpdateUserID,UpdateTime,IsLock ");
			strSql.Append(" FROM T_Wiki ");
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
			strSql.Append(" WikiID,Word,VerID,Views,Edits,CreateUserID,CreateTime,UpdateUserID,UpdateTime,IsLock ");
			strSql.Append(" FROM T_Wiki ");
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
			parameters[0].Value = "T_Wiki";
			parameters[1].Value = "WikiID";
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

