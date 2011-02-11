using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KuaiLe.Us.DAL
{
	/// <summary>
	/// 数据访问类:CommentDal
	/// </summary>
	public class CommentDal
	{
        KuaiLe.Us.Common.DbBase db = new KuaiLe.Us.Common.DbBase();

		public CommentDal()
		{}


		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CommentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Comment");
			strSql.Append(" where CommentID=@CommentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.BigInt)};
			parameters[0].Value = CommentID;

			return db.RunSqlReturnInt(strSql.ToString(),parameters) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KuaiLe.Us.Model.CommentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Comment(");
			strSql.Append("ArtID,Comment,UserID,CreateTime,DigUp,DigDown,Reports,Status, UserName, UserIP)");
			strSql.Append(" values (");
			strSql.Append("@ArtID,@Comment,@UserID,@CreateTime,@DigUp,@DigDown,@Reports,@Status,@UserName,@UserIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.BigInt,8),
					new SqlParameter("@Comment", SqlDbType.NVarChar,300),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DigUp", SqlDbType.Int,4),
					new SqlParameter("@DigDown", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar,50),
                                        };
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.Comment;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.DigUp;
			parameters[5].Value = model.DigDown;
			parameters[6].Value = model.Reports;
			parameters[7].Value = model.Status;
            parameters[8].Value = model.UserName;
            parameters[9].Value = model.UserIP;

			return db.RunSqlReturnInt(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.CommentModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Comment set ");
			strSql.Append("ArtID=@ArtID,");
			strSql.Append("Comment=@Comment,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("DigUp=@DigUp,");
			strSql.Append("DigDown=@DigDown,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("Status=@Status,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserIP=@UserIP");
			strSql.Append(" where CommentID=@CommentID");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.BigInt,8),
					new SqlParameter("@ArtID", SqlDbType.BigInt,8),
					new SqlParameter("@Comment", SqlDbType.NVarChar,300),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@DigUp", SqlDbType.Int,4),
					new SqlParameter("@DigDown", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar,50)
                                        };
			parameters[0].Value = model.CommentID;
			parameters[1].Value = model.ArtID;
			parameters[2].Value = model.Comment;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.DigUp;
			parameters[6].Value = model.DigDown;
			parameters[7].Value = model.Reports;
			parameters[8].Value = model.Status;
            parameters[9].Value = model.UserName;
            parameters[10].Value = model.UserIP;

			db.RunSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long CommentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Comment ");
			strSql.Append(" where CommentID=@CommentID");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.BigInt)
};
			parameters[0].Value = CommentID;

			db.RunSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string CommentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Comment ");
			strSql.Append(" where CommentID in ("+CommentIDlist + ")  ");
			db.RunSql(strSql.ToString());
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.CommentModel GetModel(long CommentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CommentID,ArtID,Comment,UserID,CreateTime,DigUp,DigDown,Reports,Status,UserName,UserIP from T_Comment ");
			strSql.Append(" where CommentID=@CommentID");
			SqlParameter[] parameters = {
					new SqlParameter("@CommentID", SqlDbType.BigInt)
};
			parameters[0].Value = CommentID;

			KuaiLe.Us.Model.CommentModel model=new KuaiLe.Us.Model.CommentModel();
			DataSet ds= db.GetDs(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CommentID"].ToString()!="")
				{
					model.CommentID=long.Parse(ds.Tables[0].Rows[0]["CommentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArtID"].ToString()!="")
				{
					model.ArtID=long.Parse(ds.Tables[0].Rows[0]["ArtID"].ToString());
				}
				model.Comment=ds.Tables[0].Rows[0]["Comment"].ToString();
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DigUp"].ToString()!="")
				{
					model.DigUp=int.Parse(ds.Tables[0].Rows[0]["DigUp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DigDown"].ToString()!="")
				{
					model.DigDown=int.Parse(ds.Tables[0].Rows[0]["DigDown"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reports"].ToString()!="")
				{
					model.Reports=int.Parse(ds.Tables[0].Rows[0]["Reports"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserIP = ds.Tables[0].Rows[0]["UserIP"].ToString();
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
			strSql.Append("select CommentID,ArtID,Comment,UserID,CreateTime,DigUp,DigDown,Reports,Status,UserName,UserIP ");
			strSql.Append(" FROM T_Comment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetDs(strSql.ToString());
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
            strSql.Append(" CommentID,ArtID,Comment,UserID,CreateTime,DigUp,DigDown,Reports,Status,UserName,UserIP ");
			strSql.Append(" FROM T_Comment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string strOrder, int pageSize, int pageIndex, out int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from dbo.T_Comment ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" Where " + strWhere + " ");
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " CommentID ASC ";
            }

            return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out records);
        }

		#endregion  Method
	}
}

