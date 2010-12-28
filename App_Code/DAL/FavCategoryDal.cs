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
	/// 数据访问类FavCategoryDal。
	/// </summary>
	public class FavCategoryDal
	{

		DbBase db = new DbBase();

		public FavCategoryDal()
		{}

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		//public int GetMaxId()
		//{
		//return DbBase.GetMaxID("FavCategoryID", "T_FavCategory"); 
		//}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_FavCategory");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" ");
			return (db.RunSqlReturnInt(strSql.ToString()) > 0);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(LFL.Favorite.Model.FavCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.CategoryName != null)
			{
				strSql1.Append("CategoryName,");
				strSql2.Append("'"+model.CategoryName+"',");
			}
			if (model.ParentID != null)
			{
				strSql1.Append("ParentID,");
				strSql2.Append(""+model.ParentID+",");
			}
			strSql.Append("insert into T_FavCategory(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";SELECT SCOPE_IDENTITY() AS [ID]");
			return db.RunSqlReturnInt(strSql.ToString());
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LFL.Favorite.Model.FavCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_FavCategory set ");
			if (model.CategoryName != null)
			{
				strSql.Append("CategoryName='"+model.CategoryName+"',");
			}
			if (model.ParentID != null)
			{
				strSql.Append("ParentID="+model.ParentID+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where FavCategoryID="+ model.FavCategoryID+" ");
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_FavCategory ");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.FavCategory GetModel(int FavCategoryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" from T_FavCategory ");
			strSql.Append(" where FavCategoryID="+FavCategoryID+" " );
			LFL.Favorite.Model.FavCategory model=new LFL.Favorite.Model.FavCategory();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FavCategoryID"].ToString()!="")
				{
					model.FavCategoryID=int.Parse(ds.Tables[0].Rows[0]["FavCategoryID"].ToString());
				}
				model.CategoryName=ds.Tables[0].Rows[0]["CategoryName"].ToString();
				if(ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
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
			strSql.Append("select FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
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
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
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
			strSql.Append(" FavCategoryID,CategoryName,ParentID ");
			strSql.Append(" FROM T_FavCategory ");
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

