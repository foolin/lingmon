using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CengZai.Helper;
namespace CengZai.DAL
{
	/// <summary>
	/// 数据访问类:LetterCommentDal
	/// </summary>
	public partial class LetterCommentDal
	{
        DbHelperSQL db = new DbHelperSQL();

		public LetterCommentDal()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return db.GetMaxID("ID", "T_LetterComment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_LetterComment");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return db.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CengZai.Model.LetterCommentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_LetterComment(");
			strSql.Append("ArtID,Letter,UserID,PostIP,PostTime,Reports,IsLock)");
			strSql.Append(" values (");
			strSql.Append("@ArtID,@Letter,@UserID,@PostIP,@PostTime,@Reports,@IsLock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@Letter", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.Char,15),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.Letter;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostIP;
			parameters[4].Value = model.PostTime;
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
		public bool Update(CengZai.Model.LetterCommentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_LetterComment set ");
			strSql.Append("ArtID=@ArtID,");
			strSql.Append("Letter=@Letter,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("PostIP=@PostIP,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("IsLock=@IsLock");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@Letter", SqlDbType.NVarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@PostIP", SqlDbType.Char,15),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.Letter;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.PostIP;
			parameters[4].Value = model.PostTime;
			parameters[5].Value = model.Reports;
			parameters[6].Value = model.IsLock;
			parameters[7].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LetterComment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LetterComment ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public CengZai.Model.LetterCommentModel GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ArtID,Letter,UserID,PostIP,PostTime,Reports,IsLock from T_LetterComment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			CengZai.Model.LetterCommentModel model=new CengZai.Model.LetterCommentModel();
			DataSet ds=db.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArtID"].ToString()!="")
				{
					model.ArtID=int.Parse(ds.Tables[0].Rows[0]["ArtID"].ToString());
				}
				model.Letter=ds.Tables[0].Rows[0]["Letter"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.PostIP=ds.Tables[0].Rows[0]["PostIP"].ToString();
				if(ds.Tables[0].Rows[0]["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
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
			strSql.Append("select ID,ArtID,Letter,UserID,PostIP,PostTime,Reports,IsLock ");
			strSql.Append(" FROM T_LetterComment ");
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
			strSql.Append(" ID,ArtID,Letter,UserID,PostIP,PostTime,Reports,IsLock ");
			strSql.Append(" FROM T_LetterComment ");
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
			parameters[0].Value = "T_LetterComment";
			parameters[1].Value = "ID";
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

