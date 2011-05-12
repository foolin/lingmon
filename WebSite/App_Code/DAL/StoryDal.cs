using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BLPin.Helper;
namespace BLPin.DAL
{
	/// <summary>
	/// 数据访问类:StoryDal
	/// </summary>
	public partial class StoryDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public StoryDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("StoryID", "T_Story"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Story");
			strSql.Append(" where StoryID=@StoryID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StoryID", SqlDbType.Int,4)};
			parameters[0].Value = StoryID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BLPin.Model.StoryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Story(");
			strSql.Append("ClassID,Title,Content,Author,Source,UserID,PostIP,PostTime,Status,Views,Comments,Reports)");
			strSql.Append(" values (");
			strSql.Append("@ClassID,@Title,@Content,@Author,@Source,@UserID,@PostIP,@PostTime,@Status,@Views,@Comments,@Reports)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Source", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.UserID;
			parameters[6].Value = model.PostIP;
			parameters[7].Value = model.PostTime;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Views;
			parameters[10].Value = model.Comments;
			parameters[11].Value = model.Reports;

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
		public bool Update(BLPin.Model.StoryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Story set ");
			strSql.Append("ClassID=@ClassID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("Author=@Author,");
			strSql.Append("Source=@Source,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Status=@Status,");
			strSql.Append("Views=@Views,");
			strSql.Append("Comments=@Comments,");
			strSql.Append("Reports=@Reports");
			strSql.Append(" where StoryID=@StoryID");
			SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@Source", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@StoryID", SqlDbType.Int,4)};
			parameters[0].Value = model.ClassID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Author;
			parameters[4].Value = model.Source;
			parameters[5].Value = model.UserID;
			parameters[6].Value = model.PostIP;
			parameters[7].Value = model.PostTime;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.Views;
			parameters[10].Value = model.Comments;
			parameters[11].Value = model.Reports;
			parameters[12].Value = model.StoryID;

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
		public bool Delete(int StoryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Story ");
			strSql.Append(" where StoryID=@StoryID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoryID", SqlDbType.Int,4)
};
			parameters[0].Value = StoryID;

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
		public bool DeleteList(string StoryIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Story ");
			strSql.Append(" where StoryID in ("+StoryIDlist + ")  ");
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
		public BLPin.Model.StoryModel GetModel(int StoryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StoryID,ClassID,Title,Content,Author,Source,UserID,PostIP,PostTime,Status,Views,Comments,Reports from T_Story ");
			strSql.Append(" where StoryID=@StoryID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoryID", SqlDbType.Int,4)
};
			parameters[0].Value = StoryID;

			BLPin.Model.StoryModel model=new BLPin.Model.StoryModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StoryID"].ToString()!="")
				{
					model.StoryID=int.Parse(ds.Tables[0].Rows[0]["StoryID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Author=ds.Tables[0].Rows[0]["Author"].ToString();
				model.Source=ds.Tables[0].Rows[0]["Source"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
			strSql.Append("select StoryID,ClassID,Title,Content,Author,Source,UserID,PostIP,PostTime,Status,Views,Comments,Reports ");
			strSql.Append(" FROM T_Story ");
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
			strSql.Append(" StoryID,ClassID,Title,Content,Author,Source,UserID,PostIP,PostTime,Status,Views,Comments,Reports ");
			strSql.Append(" FROM T_Story ");
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
			parameters[0].Value = "T_Story";
			parameters[1].Value = "StoryID";
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

