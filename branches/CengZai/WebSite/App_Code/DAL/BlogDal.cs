using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:BlogDal
	/// </summary>
	public partial class BlogDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public BlogDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("BlogID", "T_Blog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BlogID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Blog");
			strSql.Append(" where BlogID=@BlogID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)};
			parameters[0].Value = BlogID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.BlogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Blog(");
			strSql.Append("Blog,BlogName,BlogDesc,Privacy,CreateTime,Status)");
			strSql.Append(" values (");
			strSql.Append("@Blog,@BlogName,@BlogDesc,@Privacy,@CreateTime,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Blog", SqlDbType.NVarChar,50),
					new SqlParameter("@BlogName", SqlDbType.NVarChar,50),
					new SqlParameter("@BlogDesc", SqlDbType.NVarChar,300),
					new SqlParameter("@Privacy", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4)};
			parameters[0].Value = model.Blog;
			parameters[1].Value = model.BlogName;
			parameters[2].Value = model.BlogDesc;
			parameters[3].Value = model.Privacy;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.Status;

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
		public bool Update(BLPin.Model.BlogModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Blog set ");
			strSql.Append("Blog=@Blog,");
			strSql.Append("BlogName=@BlogName,");
			strSql.Append("BlogDesc=@BlogDesc,");
			strSql.Append("Privacy=@Privacy,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Status=@Status");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@Blog", SqlDbType.NVarChar,50),
					new SqlParameter("@BlogName", SqlDbType.NVarChar,50),
					new SqlParameter("@BlogDesc", SqlDbType.NVarChar,300),
					new SqlParameter("@Privacy", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@BlogID", SqlDbType.Int,4)};
			parameters[0].Value = model.Blog;
			parameters[1].Value = model.BlogName;
			parameters[2].Value = model.BlogDesc;
			parameters[3].Value = model.Privacy;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.BlogID;

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
		public bool Delete(int BlogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Blog ");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)
};
			parameters[0].Value = BlogID;

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
		public bool DeleteList(string BlogIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Blog ");
			strSql.Append(" where BlogID in ("+BlogIDlist + ")  ");
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
		public BLPin.Model.BlogModel GetModel(int BlogID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BlogID,Blog,BlogName,BlogDesc,Privacy,CreateTime,Status from T_Blog ");
			strSql.Append(" where BlogID=@BlogID");
			SqlParameter[] parameters = {
					new SqlParameter("@BlogID", SqlDbType.Int,4)
};
			parameters[0].Value = BlogID;

			BLPin.Model.BlogModel model=new BLPin.Model.BlogModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["BlogID"].ToString()!="")
				{
					model.BlogID=int.Parse(ds.Tables[0].Rows[0]["BlogID"].ToString());
				}
				model.Blog=ds.Tables[0].Rows[0]["Blog"].ToString();
				model.BlogName=ds.Tables[0].Rows[0]["BlogName"].ToString();
				model.BlogDesc=ds.Tables[0].Rows[0]["BlogDesc"].ToString();
				if(ds.Tables[0].Rows[0]["Privacy"].ToString()!="")
				{
					model.Privacy=int.Parse(ds.Tables[0].Rows[0]["Privacy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append("select BlogID,Blog,BlogName,BlogDesc,Privacy,CreateTime,Status ");
			strSql.Append(" FROM T_Blog ");
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
			strSql.Append(" BlogID,Blog,BlogName,BlogDesc,Privacy,CreateTime,Status ");
			strSql.Append(" FROM T_Blog ");
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
			parameters[0].Value = "T_Blog";
			parameters[1].Value = "BlogID";
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

