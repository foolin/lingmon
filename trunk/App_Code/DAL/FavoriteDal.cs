using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/***********************************************
  *  DAL数据层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/17 23:34:46
  *  Copyright(C) 2010 灵梦团队 保留所有权利。。
***********************************************/
namespace LFL.Favorite.DAL
{
	/// <summary>
	/// 数据访问类FavoriteDal。
	/// </summary>
	public class FavoriteDal
	{

		DbBase db = new DbBase();

		public FavoriteDal()
		{}

		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.Favorite model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.FavID != null)
			{
				strSql1.Append("FavID,");
				strSql2.Append(""+model.FavID+",");
			}
			if (model.Title != null)
			{
				strSql1.Append("Title,");
				strSql2.Append("'"+model.Title+"',");
			}
			if (model.URL != null)
			{
				strSql1.Append("URL,");
				strSql2.Append("'"+model.URL+"',");
			}
			if (model.FavCategoryID != null)
			{
				strSql1.Append("FavCategoryID,");
				strSql2.Append(""+model.FavCategoryID+",");
			}
			strSql.Append("insert into T_Favorite(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.Favorite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Favorite set ");
			if (model.FavID != null)
			{
				strSql.Append("FavID="+model.FavID+",");
			}
			if (model.Title != null)
			{
				strSql.Append("Title='"+model.Title+"',");
			}
			if (model.URL != null)
			{
				strSql.Append("URL='"+model.URL+"',");
			}
			if (model.FavCategoryID != null)
			{
				strSql.Append("FavCategoryID="+model.FavCategoryID+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Favorite ");
			strSql.Append(" where " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.Favorite GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" FavID,Title,URL,FavCategoryID ");
			strSql.Append(" from T_Favorite ");
			strSql.Append(" where " );
			LFL.Favorite.Model.Favorite model=new LFL.Favorite.Model.Favorite();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FavID"].ToString()!="")
				{
					model.FavID=int.Parse(ds.Tables[0].Rows[0]["FavID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.URL=ds.Tables[0].Rows[0]["URL"].ToString();
				if(ds.Tables[0].Rows[0]["FavCategoryID"].ToString()!="")
				{
					model.FavCategoryID=int.Parse(ds.Tables[0].Rows[0]["FavCategoryID"].ToString());
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
			strSql.Append("select FavID,Title,URL,FavCategoryID ");
			strSql.Append(" FROM T_Favorite ");
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
			strSql.Append(" FavID,Title,URL,FavCategoryID ");
			strSql.Append(" FROM T_Favorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return db.GetDs(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(string strWhere, string strOrder,int pageSize, int pageIndex, out int totalCount)
		{
			StringBuilder strSql = new StringBuilder();
			//Sql语句
			strSql.Append(" Select ");
			strSql.Append(" FavID,Title,URL,FavCategoryID ");
			strSql.Append(" FROM T_Favorite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return db.GetPageDs(strSql.ToString(), strOrder, pageSize, pageIndex, out totalCount);
		}
		*/

		#endregion  成员方法
	}
}

