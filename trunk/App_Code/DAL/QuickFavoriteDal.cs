using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/***********************************************
  *  DAL数据层 
  *  Author       : Foolin 
  *  Email        : LingLiufu@gmail.com
  *  Created Date : 2010/12/4 0:33:01
  *  Copyright(C) 2010 灵梦团队 保留所有权利。。
***********************************************/
namespace LFL.Favorite.DAL
{
	/// <summary>
	/// 数据访问类QuickFavoriteDal。
	/// </summary>
	public class QuickFavoriteDal
	{

		DbBase db = new DbBase();

		public QuickFavoriteDal()
		{}

		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LFL.Favorite.Model.QuickFavorite model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.QuickFavID != null)
			{
				strSql1.Append("QuickFavID,");
				strSql2.Append(""+model.QuickFavID+",");
			}
			if (model.FavID != null)
			{
				strSql1.Append("FavID,");
				strSql2.Append(""+model.FavID+",");
			}
			if (model.MinImage != null)
			{
				strSql1.Append("MinImage,");
				strSql2.Append("'"+model.MinImage+"',");
			}
			if (model.OffsetLeft != null)
			{
				strSql1.Append("OffsetLeft,");
				strSql2.Append(""+model.OffsetLeft+",");
			}
			if (model.OffsetTop != null)
			{
				strSql1.Append("OffsetTop,");
				strSql2.Append(""+model.OffsetTop+",");
			}
			if (model.Width != null)
			{
				strSql1.Append("Width,");
				strSql2.Append(""+model.Width+",");
			}
			if (model.Height != null)
			{
				strSql1.Append("Height,");
				strSql2.Append(""+model.Height+",");
			}
			strSql.Append("insert into T_QuickFavorite(");
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
		public void Update(LFL.Favorite.Model.QuickFavorite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_QuickFavorite set ");
			if (model.QuickFavID != null)
			{
				strSql.Append("QuickFavID="+model.QuickFavID+",");
			}
			if (model.FavID != null)
			{
				strSql.Append("FavID="+model.FavID+",");
			}
			if (model.MinImage != null)
			{
				strSql.Append("MinImage='"+model.MinImage+"',");
			}
			if (model.OffsetLeft != null)
			{
				strSql.Append("OffsetLeft="+model.OffsetLeft+",");
			}
			if (model.OffsetTop != null)
			{
				strSql.Append("OffsetTop="+model.OffsetTop+",");
			}
			if (model.Width != null)
			{
				strSql.Append("Width="+model.Width+",");
			}
			if (model.Height != null)
			{
				strSql.Append("Height="+model.Height+",");
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
			strSql.Append("delete from T_QuickFavorite ");
			strSql.Append(" where " );
			db.RunSql(strSql.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LFL.Favorite.Model.QuickFavorite GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" QuickFavID,FavID,MinImage,OffsetLeft,OffsetTop,Width,Height ");
			strSql.Append(" from T_QuickFavorite ");
			strSql.Append(" where " );
			LFL.Favorite.Model.QuickFavorite model=new LFL.Favorite.Model.QuickFavorite();
			DataSet ds = db.GetDs(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["QuickFavID"].ToString()!="")
				{
					model.QuickFavID=int.Parse(ds.Tables[0].Rows[0]["QuickFavID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FavID"].ToString()!="")
				{
					model.FavID=int.Parse(ds.Tables[0].Rows[0]["FavID"].ToString());
				}
				model.MinImage=ds.Tables[0].Rows[0]["MinImage"].ToString();
				if(ds.Tables[0].Rows[0]["OffsetLeft"].ToString()!="")
				{
					model.OffsetLeft=decimal.Parse(ds.Tables[0].Rows[0]["OffsetLeft"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OffsetTop"].ToString()!="")
				{
					model.OffsetTop=decimal.Parse(ds.Tables[0].Rows[0]["OffsetTop"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=decimal.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Height"].ToString()!="")
				{
					model.Height=decimal.Parse(ds.Tables[0].Rows[0]["Height"].ToString());
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
			strSql.Append("select QuickFavID,FavID,MinImage,OffsetLeft,OffsetTop,Width,Height ");
			strSql.Append(" FROM T_QuickFavorite ");
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
			strSql.Append(" QuickFavID,FavID,MinImage,OffsetLeft,OffsetTop,Width,Height ");
			strSql.Append(" FROM T_QuickFavorite ");
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
		public DataSet GetList(int pageSize, int pageIndex, out int totalCount)
		{
			StringBuilder strSql = new StringBuilder();
			StringBuilder strSort = new StringBuilder();
			//Sql语句
			strSql.Append(" QuickFavID,FavID,MinImage,OffsetLeft,OffsetTop,Width,Height ");
			strSql.Append(" FROM T_QuickFavorite ");
			//排序
			//strSort.Append(" ID Asc");
			
			return db.GetPageDs(strSql.ToString(), strSort.ToString(), pageSize, pageIndex, out totalCount);
		}
		*/

		#endregion  成员方法
	}
}

