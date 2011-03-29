using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KuaiLe.Us.DAL
{
	/// <summary>
	/// 数据访问类:TagsDal
	/// </summary>
	public class TagsDal
	{
        KuaiLe.Us.Common.DbBase db = new KuaiLe.Us.Common.DbBase();

		public TagsDal()
		{}


		#region  Method


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Tags");
			strSql.Append(" where TagID=@TagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)};
			parameters[0].Value = TagID;

			return db.RunSqlReturnInt(strSql.ToString(),parameters) > 0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(KuaiLe.Us.Model.TagsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Tags(");
			strSql.Append("ArtID,Tag)");
			strSql.Append(" values (");
			strSql.Append("@ArtID,@Tag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@Tag", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.ArtID;
			parameters[1].Value = model.Tag;

			return db.RunSqlReturnInt(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(KuaiLe.Us.Model.TagsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Tags set ");
			strSql.Append("ArtID=@ArtID,");
			strSql.Append("Tag=@Tag");
			strSql.Append(" where TagID=@TagID");
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4),
					new SqlParameter("@ArtID", SqlDbType.Int,4),
					new SqlParameter("@Tag", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.TagID;
			parameters[1].Value = model.ArtID;
			parameters[2].Value = model.Tag;

			db.RunSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int TagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Tags ");
			strSql.Append(" where TagID=@TagID");
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
};
			parameters[0].Value = TagID;

			db.RunSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void DeleteList(string TagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Tags ");
			strSql.Append(" where TagID in ("+TagIDlist + ")  ");
			db.RunSql(strSql.ToString());
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KuaiLe.Us.Model.TagsModel GetModel(int TagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TagID,ArtID,Tag from T_Tags ");
			strSql.Append(" where TagID=@TagID");
			SqlParameter[] parameters = {
					new SqlParameter("@TagID", SqlDbType.Int,4)
};
			parameters[0].Value = TagID;

			KuaiLe.Us.Model.TagsModel model=new KuaiLe.Us.Model.TagsModel();
			DataSet ds=db.GetDs(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TagID"].ToString()!="")
				{
					model.TagID=int.Parse(ds.Tables[0].Rows[0]["TagID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ArtID"].ToString()!="")
				{
					model.ArtID=int.Parse(ds.Tables[0].Rows[0]["ArtID"].ToString());
				}
				model.Tag=ds.Tables[0].Rows[0]["Tag"].ToString();
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
			strSql.Append("select TagID,ArtID,Tag ");
			strSql.Append(" FROM T_Tags ");
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
			strSql.Append(" TagID,ArtID,Tag ");
			strSql.Append(" FROM T_Tags ");
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
            strSql.Append(" select * from dbo.T_Tags ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" Where " + strWhere + " ");
            }

            if (string.IsNullOrEmpty(strOrder))
            {
                strOrder = " TagID ASC ";
            }

            return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out records);
        }

		#endregion  Method
	}
}

