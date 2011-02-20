using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KuaiLe.Us.DAL
{
	/// <summary>
	/// 数据访问类:ArticleDal
	/// </summary>
	public class ArticleDal
	{
        KuaiLe.Us.Common.DbBase db = new KuaiLe.Us.Common.DbBase();

		public ArticleDal()
		{}


		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ArtID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Article");
			strSql.Append(" where ArtID=@ArtID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.BigInt)};
			parameters[0].Value = ArtID;

			return db.RunSqlReturnInt(strSql.ToString(),parameters) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KuaiLe.Us.Model.ArticleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Article(");
            strSql.Append("UserID,Title,Content,Tags,IsAnonym,CreateTime,Hits,DigUp,DigDown,Comments,Reports,Status,UserIP)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@Title,@Content,@Tags,@IsAnonym,@CreateTime,@Hits,@DigUp,@DigDown,@Comments,@Reports,@Status,@UserIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@IsAnonym", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@DigUp", SqlDbType.Int,4),
					new SqlParameter("@DigDown", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@UserIP", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Tags;
			parameters[4].Value = model.IsAnonym;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.Hits;
			parameters[7].Value = model.DigUp;
			parameters[8].Value = model.DigDown;
			parameters[9].Value = model.Comments;
			parameters[10].Value = model.Reports;
			parameters[11].Value = model.Status;
            parameters[12].Value = model.UserIP;

			return db.RunSqlReturnInt(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.ArticleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Article set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Title=@Title,");
			strSql.Append("Content=@Content,");
			strSql.Append("Tags=@Tags,");
			strSql.Append("IsAnonym=@IsAnonym,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Hits=@Hits,");
			strSql.Append("DigUp=@DigUp,");
			strSql.Append("DigDown=@DigDown,");
			strSql.Append("Comments=@Comments,");
			strSql.Append("Reports=@Reports,");
			strSql.Append("Status=@Status,");
            strSql.Append("UserIP=@UserIP");
			strSql.Append(" where ArtID=@ArtID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Tags", SqlDbType.NVarChar,300),
					new SqlParameter("@IsAnonym", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@DigUp", SqlDbType.Int,4),
					new SqlParameter("@DigDown", SqlDbType.Int,4),
					new SqlParameter("@Comments", SqlDbType.Int,4),
					new SqlParameter("@Reports", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.Title;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.Tags;
			parameters[5].Value = model.IsAnonym;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.Hits;
			parameters[8].Value = model.DigUp;
			parameters[9].Value = model.DigDown;
			parameters[10].Value = model.Comments;
			parameters[11].Value = model.Reports;
			parameters[12].Value = model.Status;
            parameters[13].Value = model.UserIP;

			db.RunSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long ArtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Article ");
			strSql.Append(" where ArtID=@ArtID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.BigInt)
};
			parameters[0].Value = ArtID;

			db.RunSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string ArtIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Article ");
			strSql.Append(" where ArtID in ("+ArtIDlist + ")  ");
			db.RunSql(strSql.ToString());
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.ArticleModel GetModel(long ArtID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ArtID,UserID,Title,Content,Tags,IsAnonym,CreateTime,Hits,DigUp,DigDown,Comments,Reports,Status,UserIP from T_Article ");
			strSql.Append(" where ArtID=@ArtID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.BigInt)
};
			parameters[0].Value = ArtID;

			KuaiLe.Us.Model.ArticleModel model=new KuaiLe.Us.Model.ArticleModel();
            DataSet ds = db.GetDs(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ArtID"].ToString()!="")
				{
					model.ArtID=long.Parse(ds.Tables[0].Rows[0]["ArtID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				model.Tags=ds.Tables[0].Rows[0]["Tags"].ToString();
				if(ds.Tables[0].Rows[0]["IsAnonym"].ToString()!="")
				{
					model.IsAnonym=int.Parse(ds.Tables[0].Rows[0]["IsAnonym"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(ds.Tables[0].Rows[0]["Hits"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DigUp"].ToString()!="")
				{
					model.DigUp=int.Parse(ds.Tables[0].Rows[0]["DigUp"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DigDown"].ToString()!="")
				{
					model.DigDown=int.Parse(ds.Tables[0].Rows[0]["DigDown"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Comments"].ToString()!="")
				{
					model.Comments=int.Parse(ds.Tables[0].Rows[0]["Comments"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reports"].ToString()!="")
				{
					model.Reports=int.Parse(ds.Tables[0].Rows[0]["Reports"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
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
            //strSql.Append("select ArtID,UserID,Title,Content,Tags,IsAnonym,CreateTime,Hits,DigUp,DigDown,Comments,Reports,Status,UserIP ");
            strSql.Append(" select A.* ");
            strSql.Append(" ,U.UserName,U.NickName,U.Email ");
            strSql.Append(" FROM T_Article A ");
            strSql.Append(" Left join  dbo.T_User  U ");
            strSql.Append(" on A.UserID=U.UserID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where ArtID in ( ");
                strSql.Append("   Select ArtID from T_Article Where " + strWhere);
                strSql.Append(" ) ");
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
            //strSql.Append(" ArtID,UserID,Title,Content,Tags,IsAnonym,CreateTime,Hits,DigUp,DigDown,Comments,Reports,Status,UserIP ");
            strSql.Append(" select A.* ");
            strSql.Append(" ,U.UserName,U.NickName,U.Email ");
            strSql.Append(" FROM T_Article A ");
            strSql.Append(" Left join  dbo.T_User  U ");
            strSql.Append(" on A.UserID=U.UserID ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where ArtID in ( ");
                strSql.Append("   Select ArtID from T_Article Where " + strWhere);
                strSql.Append(" ) ");
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}


        /// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetList(string strWhere, string strOrder, int pageSize, int pageIndex, out int records)
        {
            return GetList( strWhere, strOrder,  pageSize,  pageIndex, out  records, true);
        }

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(string strWhere,string strOrder, int pageSize, int pageIndex, out int records, bool isPublic)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select A.* ");
            strSql.Append(" ,U.UserName,U.NickName,U.Email ");
            strSql.Append(" FROM T_Article A ");
            strSql.Append(" Left join  dbo.T_User  U ");
            strSql.Append(" on A.UserID=U.UserID ");

            bool isHasWhere = false;
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where ArtID in ( ");
                strSql.Append("   Select ArtID from T_Article Where " + strWhere);
                strSql.Append(" ) ");
                isHasWhere = true;
            }

            if (isPublic)
            {
                if (isHasWhere)
                {
                    strSql.Append(" And ");
                }
                strSql.Append(" A.Status>=0 And U.Status>=-1  ");
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " ArtID DESC ";
            }

            

            return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out records);
		}


		#endregion  Method
	}
}

