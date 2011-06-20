using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:TwitterDal
	/// </summary>
	public partial class TwitterDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public TwitterDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("TwiID", "T_Twitter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TwiID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Twitter");
			strSql.Append(" where TwiID=@TwiID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TwiID", SqlDbType.Int,4)};
			parameters[0].Value = TwiID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.TwitterModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Twitter(");
			strSql.Append("Content,Image,Media,UserID,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@Content,@Image,@Media,@UserID,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.NVarChar,200),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@Media", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.Image;
			parameters[2].Value = model.Media;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.IsLock;

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
		public bool Update(CengZai.Model.TwitterModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Twitter set ");
			strSql.Append("Content=@Content,");
			strSql.Append("Image=@Image,");
			strSql.Append("Media=@Media,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where TwiID=@TwiID");
			SqlParameter[] parameters = {
					new SqlParameter("@Content", SqlDbType.NVarChar,200),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@Media", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@TwiID", SqlDbType.Int,4)};
			parameters[0].Value = model.Content;
			parameters[1].Value = model.Image;
			parameters[2].Value = model.Media;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.IsLock;
			parameters[5].Value = model.TwiID;

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
		public bool Delete(int TwiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Twitter ");
			strSql.Append(" where TwiID=@TwiID");
			SqlParameter[] parameters = {
					new SqlParameter("@TwiID", SqlDbType.Int,4)
};
			parameters[0].Value = TwiID;

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
		public bool DeleteList(string TwiIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Twitter ");
			strSql.Append(" where TwiID in ("+TwiIDlist + ")  ");
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
		public CengZai.Model.TwitterModel GetModel(int TwiID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TwiID,Content,Image,Media,UserID,IsLock from T_Twitter ");
			strSql.Append(" where TwiID=@TwiID");
			SqlParameter[] parameters = {
					new SqlParameter("@TwiID", SqlDbType.Int,4)
};
			parameters[0].Value = TwiID;

			CengZai.Model.TwitterModel model=new CengZai.Model.TwitterModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TwiID"].ToString()!="")
				{
					model.TwiID=int.Parse(ds.Tables[0].Rows[0]["TwiID"].ToString());
				}
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Image=ds.Tables[0].Rows[0]["Image"].ToString();
				model.Media=ds.Tables[0].Rows[0]["Media"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
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
			strSql.Append("select TwiID,Content,Image,Media,UserID,IsLock ");
			strSql.Append(" FROM T_Twitter ");
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
			strSql.Append(" TwiID,Content,Image,Media,UserID,IsLock ");
			strSql.Append(" FROM T_Twitter ");
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
			parameters[0].Value = "T_Twitter";
			parameters[1].Value = "TwiID";
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

