using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:LetterDal
	/// </summary>
	public partial class LetterDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public LetterDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return db.GetMaxID("LoveID", "T_Letter"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LoveID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Letter");
			strSql.Append(" where LoveID=@LoveID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LoveID", SqlDbType.Int,4)};
			parameters[0].Value = LoveID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.LetterModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Letter(");
			strSql.Append("ToUserID,FromUserID,Title,Content,PostIP,PostTime,IsRead,ReadTime,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@ToUserID,@FromUserID,@Title,@Content,@PostIP,@PostTime,@IsRead,@ReadTime,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.ToUserID;
			parameters[1].Value = model.FromUserID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.IsRead;
			parameters[7].Value = model.ReadTime;
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
		public bool Update(CengZai.Model.LetterModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Letter set ");
			strSql.Append("ToUserID=@ToUserID,");
			strSql.Append("FromUserID=@FromUserID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("IsRead=@IsRead,");
			strSql.Append("ReadTime=@ReadTime,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where LoveID=@LoveID");
			SqlParameter[] parameters = {
					new SqlParameter("@ToUserID", SqlDbType.Int,4),
					new SqlParameter("@FromUserID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@PostIP", SqlDbType.NVarChar,50),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@IsRead", SqlDbType.Int,4),
					new SqlParameter("@ReadTime", SqlDbType.DateTime),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@LoveID", SqlDbType.Int,4)};
			parameters[0].Value = model.ToUserID;
			parameters[1].Value = model.FromUserID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.PostIP;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.IsRead;
			parameters[7].Value = model.ReadTime;
			parameters[8].Value = model.IsLock;
			parameters[9].Value = model.LoveID;

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
		public bool Delete(int LoveID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Letter ");
			strSql.Append(" where LoveID=@LoveID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoveID", SqlDbType.Int,4)
};
			parameters[0].Value = LoveID;

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
		public bool DeleteList(string LoveIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Letter ");
			strSql.Append(" where LoveID in ("+LoveIDlist + ")  ");
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
		public CengZai.Model.LetterModel GetModel(int LoveID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LoveID,ToUserID,FromUserID,Title,Content,PostIP,PostTime,IsRead,ReadTime,IsLock from T_Letter ");
			strSql.Append(" where LoveID=@LoveID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoveID", SqlDbType.Int,4)
};
			parameters[0].Value = LoveID;

			CengZai.Model.LetterModel model=new CengZai.Model.LetterModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LoveID"].ToString()!="")
				{
					model.LoveID=int.Parse(ds.Tables[0].Rows[0]["LoveID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToUserID"].ToString()!="")
				{
					model.ToUserID=int.Parse(ds.Tables[0].Rows[0]["ToUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(ds.Tables[0].Rows[0]["FromUserID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsRead"].ToString()!="")
				{
					model.IsRead=int.Parse(ds.Tables[0].Rows[0]["IsRead"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReadTime"].ToString()!="")
				{
					model.ReadTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReadTime"].ToString());
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
			strSql.Append("select LoveID,ToUserID,FromUserID,Title,Content,PostIP,PostTime,IsRead,ReadTime,IsLock ");
			strSql.Append(" FROM T_Letter ");
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
			strSql.Append(" LoveID,ToUserID,FromUserID,Title,Content,PostIP,PostTime,IsRead,ReadTime,IsLock ");
			strSql.Append(" FROM T_Letter ");
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
			parameters[0].Value = "T_Letter";
			parameters[1].Value = "LoveID";
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

